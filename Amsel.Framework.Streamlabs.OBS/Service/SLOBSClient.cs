using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using Amsel.Clients.Sample.SLOBS.Models.Request;
using Amsel.Clients.Sample.SLOBS.Models.Response;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Service
{
    public class StreamlabsClient
    {
        private readonly string pipeName;

        public StreamlabsClient(string pipe = "slobs")
        {
            this.pipeName = pipe ?? throw new ArgumentNullException(nameof(pipe));
        }

        public StreamlabsResponse SendRequest(StreamlabsRequest requests)
        {
            return SendRequest(new List<StreamlabsRequest>() { requests }).Result?.FirstOrDefault();
        }

        public IEnumerable<TResult> SendRequest<TResult>(StreamlabsRequest requests)
        {
            return SendRequest(requests).GetResult<TResult>();
        }

        public async Task<IEnumerable<StreamlabsResponse>> SendRequest(StreamlabsRequest first, StreamlabsRequest second,
            params StreamlabsRequest[] rest)
        {
            var requests = new List<StreamlabsRequest>() { first, second };
            if (rest != null)
                requests.AddRange(rest);

            return await SendRequest(requests);
        }

      
        public async Task<IEnumerable<StreamlabsResponse>> SendRequest(IEnumerable<StreamlabsRequest> requests)
        {
            var requestBatch = GetBatch(requests?.ToArray());
            var RpcResponses = new List<StreamlabsResponse>();

            using (var pipe = new NamedPipeClientStream(pipeName))
            using (var reader = new StreamReader(pipe))
            using (var writer = new StreamWriter(pipe) { NewLine = "\n" })
            {
                await pipe.ConnectAsync(5000).ConfigureAwait(false);
                foreach (List<StreamlabsRequest> batch in requestBatch)
                {
                    foreach (var request in batch)
                        writer.WriteLine(request.ToJson());

                    writer.Flush();
                    pipe?.WaitForPipeDrain();

                    for (int i = 0; i < batch.Count; i++)
                    {
                        string responseJson = reader.ReadLine();
                        var response = JsonConvert.DeserializeObject<StreamlabsResponse>(responseJson);
                        response.JsonResponse = responseJson;
                        RpcResponses.Add(response);
                    }
                }
                return RpcResponses;
            }
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

            for (int i = 0; i < requests.Length; i++)
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
