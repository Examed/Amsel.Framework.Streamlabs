using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amsel.Clients.Sample.SLOBS.Models.Request;
using Amsel.Clients.Sample.SLOBS.Models.Response;
using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Service
{
    public class SLOBSClient
    {
        private readonly string pipeName;

        public SLOBSClient(string pipe = "slobs")
        {
            this.pipeName = pipe ?? throw new ArgumentNullException(nameof(pipe));
        }

        public async Task<List<SLOBSRpcResponse>> SendRequest(IEnumerable<SlobsRequest> requests)
        {
            return await SendRequest(requests?.ToArray()).ConfigureAwait(false);
        }

        public async Task<List<SLOBSRpcResponse>> SendRequest(params SlobsRequest[] requests)
        {
            using (var pipe = new NamedPipeClientStream(pipeName))
            using (var reader = new StreamReader(pipe))
            using (var writer = new StreamWriter(pipe) { NewLine = "\n" })
            {
                await pipe.ConnectAsync(5000).ConfigureAwait(false);

                var requestBatch = GetBatch(requests?.ToArray());
                var slobsRpcResponses = new List<SLOBSRpcResponse>();
                foreach (List<SlobsRequest> batch in requestBatch)
                {
                    foreach (var request in batch)
                        writer.WriteLine(request.ToJson());

                    writer.Flush();
                    pipe?.WaitForPipeDrain();

                    for (int i = 0; i < batch.Count; i++)
                    {
                        string responseJson = reader.ReadLine();
                        var response = JsonConvert.DeserializeObject<SLOBSRpcResponse>(responseJson);
                        response.JsonResponse = responseJson;
                        slobsRpcResponses.Add(response);
                    }
                }
                return slobsRpcResponses;
            }
        }

        public async Task<List<SLOBSRpcResponse>> SubscribeEvent(SlobsRequest requests)
        {
            var responses = await SendRequest(requests);
            var resourceId = responses.FirstOrDefault()?.Result?.FirstOrDefault()?.ResourceId;

            using (var pipe = new NamedPipeClientStream(resourceId))
            using (var reader = new StreamReader(pipe))
            {
                await pipe.ConnectAsync(5000).ConfigureAwait(false);

                var slobsRpcResponses = new List<SLOBSRpcResponse>();

                for (int i = 0; i < 10; i++)
                {
                    string responseJson = reader.ReadLine();
                    var response = JsonConvert.DeserializeObject<SLOBSRpcResponse>(responseJson);
                    response.JsonResponse = responseJson;
                    slobsRpcResponses.Add(response);
                }

                return slobsRpcResponses;
            }
        }



        /// <summary>
        /// Make sure that SLOBS only get a Batch of 5 Requests at the same time
        /// </summary>
        /// <param name="requests"></param>
        /// <returns></returns>
        private static List<List<SlobsRequest>> GetBatch(SlobsRequest[] requests)
        {
            List<List<SlobsRequest>> result = new List<List<SlobsRequest>>();
            List<SlobsRequest> current = new List<SlobsRequest>();

            for (int i = 0; i < requests.Length; i++)
            {
                if (i % 5 == 0)
                {
                    if (current.Any())
                        result.Add(current);
                    current = new List<SlobsRequest>();
                }
                current.Add(requests[i]);
            }

            if (current.Any())
                result.Add(current);
            return result;
        }

    }
}
