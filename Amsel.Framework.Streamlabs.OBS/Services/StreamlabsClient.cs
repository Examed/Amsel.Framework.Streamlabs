﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using Amsel.Framework.StreamlabsOBS.OBS.Models.Request;
using Amsel.Framework.StreamlabsOBS.OBS.Models.Response;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Amsel.Framework.StreamlabsOBS.OBS.Service
{
    public class StreamlabsOBSClient
    {
        [NotNull] private readonly string pipeName;

        public StreamlabsOBSClient(string pipe = "slobs")
        {
            this.pipeName = pipe ?? throw new ArgumentNullException(nameof(pipe));
        }

        public StreamlabsOBSResponse SendRequest(StreamlabsOBSRequest request, bool servePromises = false)
        {
            return SendRequestAsync(request).Result;
        }

        public async Task<StreamlabsOBSResponse> SendRequestAsync(StreamlabsOBSRequest request, bool loadPromises = true)
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
                StreamlabsOBSResponse response = JsonConvert.DeserializeObject<StreamlabsOBSResponse>(responseJson);
                response.JsonResponse = responseJson;

                if (!loadPromises)
                    return response;

                if (!response.IsEnumberabeResult() && response.Results.IsPromise())
                    response.Results = JsonConvert.DeserializeObject<StreamlabsOBSResponse>(reader.ReadLine()).Results;

                return response;
            }
        }



        public IEnumerable<TResult> SendRequest<TResult>(StreamlabsOBSRequest request, bool servePromises = false)
        {
            return SendRequestAsync(request).Result.GetResults<TResult>();
        }


        /// <summary>
        /// Make sure that  only get a Batch of 5 Requests at the same time
        /// </summary>
        /// <param name="requests"></param>
        /// <returns></returns>
        [NotNull]
        private static List<List<StreamlabsOBSRequest>> GetBatch(StreamlabsOBSRequest[] requests)
        {
            List<List<StreamlabsOBSRequest>> result = new List<List<StreamlabsOBSRequest>>();
            List<StreamlabsOBSRequest> current = new List<StreamlabsOBSRequest>();

            for (var i = 0; i < requests.Length; i++)
            {
                if (i % 5 == 0)
                {
                    if (current.Any())
                        result.Add(current);
                    current = new List<StreamlabsOBSRequest>();
                }
                current.Add(requests[i]);
            }

            if (current.Any())
                result.Add(current);
            return result;
        }

    }
}