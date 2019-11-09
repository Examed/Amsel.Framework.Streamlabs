using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using Amsel.Framework.Streamlabs.OBS.Models.Request;
using Amsel.Framework.Streamlabs.OBS.Models.Response;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Service
{
    public class StreamlabsClient
    {
        [NotNull] private readonly string pipeName;

        public StreamlabsClient(string pipe = "slobs")
        {
            this.pipeName = pipe ?? throw new ArgumentNullException(nameof(pipe));
        }

        public StreamlabsResponse SendRequest(StreamlabsRequest request, bool servePromises = false)
        {
            return SendRequestAsync(request).Result;
        }

        public async Task<StreamlabsResponse> SendRequestAsync(StreamlabsRequest request, bool loadPromises = true)
        {
            await using (NamedPipeClientStream pipe = new NamedPipeClientStream(pipeName))
            using (StreamReader reader = new StreamReader(pipe))
            await using (StreamWriter writer = new StreamWriter(pipe) { NewLine = "\n" })
            {
                await pipe.ConnectAsync(5000);
                await writer.WriteLineAsync(request.ToJson());
                await writer.FlushAsync();
                pipe?.WaitForPipeDrain();

                string responseJson = reader.ReadLine();
                StreamlabsResponse response = JsonConvert.DeserializeObject<StreamlabsResponse>(responseJson);
                response.JsonResponse = responseJson;

                if (!loadPromises)
                    return response;

                if (!response.IsEnumberabeResult() && response.Results.IsPromise())
                    response.Results = JsonConvert.DeserializeObject<StreamlabsResponse>(reader.ReadLine()).Results;

                return response;
            }
        }



        public IEnumerable<TResult> SendRequest<TResult>(StreamlabsRequest request, bool servePromises = false)
        {
            return SendRequestAsync(request).Result.GetResult<TResult>();
        }


        /// <summary>
        /// Make sure that  only get a Batch of 5 Requests at the same time
        /// </summary>
        /// <param name="requests"></param>
        /// <returns></returns>
        [NotNull]
        private static List<List<StreamlabsRequest>> GetBatch(StreamlabsRequest[] requests)
        {
            List<List<StreamlabsRequest>> result = new List<List<StreamlabsRequest>>();
            List<StreamlabsRequest> current = new List<StreamlabsRequest>();

            for (var i = 0; i < requests.Length; i++)
            {
                if (i % 5 == 0)
                {
                    if (current.Any())
                        result.Add(current);
                    current = new List<StreamlabsRequest>();
                }
                current.Add(requests[i]);
            }

            if (current.Any())
                result.Add(current);
            return result;
        }

    }
}