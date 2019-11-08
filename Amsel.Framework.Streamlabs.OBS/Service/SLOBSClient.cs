using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amsel.Clients.Sample.SLOBS.Models.Request;
using Amsel.Clients.Sample.SLOBS.Models.Response;
using JetBrains.Annotations;
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

        public SLOBSRpcResponse SendRequest(SLOBSRequest requests)
        {
            return SendRequest(new List<SLOBSRequest>() { requests }).Result?.FirstOrDefault();
        }

        public IEnumerable<TResult> SendRequest<TResult>(SLOBSRequest requests)
        {
            return SendRequest(requests).GetResult<TResult>();
        }

        public async Task<IEnumerable<SLOBSRpcResponse>> SendRequest(SLOBSRequest first, SLOBSRequest second,
            params SLOBSRequest[] rest)
        {
            var requests = new List<SLOBSRequest>() { first, second };
            if (rest != null)
                requests.AddRange(rest);

            return await SendRequest(requests);
        }

        public async Task<IEnumerable<SLOBSRpcResponse>> SendRequest(IEnumerable<SLOBSRequest> requests)
        {
            var requestBatch = GetBatch(requests?.ToArray());
            var slobsRpcResponses = new List<SLOBSRpcResponse>();

            using (var pipe = new NamedPipeClientStream(pipeName))
            using (var reader = new StreamReader(pipe))
            using (var writer = new StreamWriter(pipe) { NewLine = "\n" })
            {
                await pipe.ConnectAsync(5000).ConfigureAwait(false);
                foreach (List<SLOBSRequest> batch in requestBatch)
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





        /// <summary>
        /// Make sure that SLOBS only get a Batch of 5 Requests at the same time
        /// </summary>
        /// <param name="requests"></param>
        /// <returns></returns>
        [NotNull]
        private static List<List<SLOBSRequest>> GetBatch(SLOBSRequest[] requests)
        {
            List<List<SLOBSRequest>> result = new List<List<SLOBSRequest>>();
            List<SLOBSRequest> current = new List<SLOBSRequest>();

            for (int i = 0; i < requests.Length; i++)
            {
                if (i % 5 == 0)
                {
                    if (current.Any())
                        result.Add(current);
                    current = new List<SLOBSRequest>();
                }
                current.Add(requests[i]);
            }

            if (current.Any())
                result.Add(current);
            return result;
        }

    }
}
