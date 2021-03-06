﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using Amsel.Framework.Streamlabs.OBS.Models.Request;
using Amsel.Framework.Streamlabs.OBS.Models.Response;
using Amsel.Framework.Streamlabs.OBS.Utilities;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Clients
{
    public class StreamlabsOBSClient
    {
        #region Fields
        [NotNull] private readonly string pipeName;
        #endregion

        #region Constructors
        public StreamlabsOBSClient(string pipe = "slobs") {
            pipeName =
                        pipe ?? throw new ArgumentNullException(nameof(pipe));
        }
        #endregion

        #region Methods
        public StreamlabsOBSResponse SendRequest(StreamlabsOBSRequest request, bool servePromises = false) {
            return SendRequestAsync(request).ConfigureAwait(false).GetAwaiter().GetResult(); }
        public IEnumerable<TResult> SendRequest<TResult>(StreamlabsOBSRequest request, bool servePromises = false) {
            return SendRequestAsync(request).ConfigureAwait(false).GetAwaiter().GetResult().GetResults<TResult>(); }

        public async Task<StreamlabsOBSResponse> SendRequestAsync(StreamlabsOBSRequest request,
            bool loadPromises = true)
        {
            using NamedPipeClientStream pipe = new NamedPipeClientStream(pipeName);
            using StreamReader reader = new StreamReader(pipe);
            using StreamWriter writer = new StreamWriter(pipe) { NewLine = "\n" };

            await pipe.ConnectAsync(5000).ConfigureAwait(false);
            await writer.WriteLineAsync(request.ToJson()).ConfigureAwait(false);
            await writer.FlushAsync().ConfigureAwait(false);
            pipe.WaitForPipeDrain();

            string responsJson = await reader.ReadLineAsync().ConfigureAwait(false);
            StreamlabsOBSResponse response = JsonConvert.DeserializeObject<StreamlabsOBSResponse>(responsJson);
            response.JsonResponse = responsJson;

            if(!loadPromises) {
                return response;
            }

            if(!response.IsEnumberabeResult() && response.Results.IsPromise()) {
                response.Results = JsonConvert.DeserializeObject<StreamlabsOBSResponse>(await reader.ReadLineAsync().ConfigureAwait(false)).Results;
            }

            return response;
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

            for(int i = 0; i < requests.Length; i++) {
                if(i % 5 == 0) {
                    if(current.Any()) {
                        result.Add(current);
                    }

                    current = new List<StreamlabsOBSRequest>();
                }

                current.Add(requests[i]);
            }

            if(current.Any()) {
                result.Add(current);
            }

            return result;
        }
        #endregion
    }
}