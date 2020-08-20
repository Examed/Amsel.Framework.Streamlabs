using Amsel.Framework.Streamlabs.OBS.Models.Request;
using Amsel.Framework.Streamlabs.OBS.Models.Response;
using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;

namespace Amsel.Framework.Streamlabs.OBS.Clients {
    public class StreamlabsOBSSubscriptionHandler<TResponse> : IDisposable where TResponse : class {
        private readonly CancellationToken _externCancellationToken;
        [NotNull] private readonly string pipeName;
        [NotNull] private readonly StreamlabsOBSRequest request;
        [NotNull] private readonly CancellationTokenSource unsubscribeToken = new CancellationTokenSource();

        public StreamlabsOBSSubscriptionHandler([NotNull] StreamlabsOBSRequest request, CancellationToken cancellationToken = default, [NotNull] string pipeName = "slobs")
        {
            // TODO check externCancellationToken
            this.request = request ?? throw new ArgumentNullException(nameof(request));
            this.pipeName = pipeName ?? throw new ArgumentNullException(nameof(pipeName));
            if (cancellationToken != default) {
                _externCancellationToken = cancellationToken;
            }
        }

        public event EventHandler<StreamlabsOBSResponse> OnBegin;
        public event EventHandler<TResponse> OnData;
        public event EventHandler<StreamlabsOBSEvent> OnEvent;
        public event EventHandler<string> OnUnsupported;

        public void Subscribe(EventHandler<TResponse> value)
        {
            OnData += value;
            Task.Run(async() =>
            {
                await using NamedPipeClientStream stream = new NamedPipeClientStream(pipeName);
                using StreamReader reader = new StreamReader(stream);
                await using (StreamWriter writer = new StreamWriter(stream)) {
                    await stream.ConnectAsync(5000, _externCancellationToken).ConfigureAwait(false);

                    await writer.WriteLineAsync(request.ToJson()).ConfigureAwait(false);
                    await writer.FlushAsync().ConfigureAwait(false);
                    stream.WaitForPipeDrain();

                    while (!_externCancellationToken.IsCancellationRequested && !unsubscribeToken.IsCancellationRequested) {
                        string responsJson = await reader.ReadLineAsync().ConfigureAwait(false);
                        StreamlabsOBSResponse response = JsonConvert.DeserializeObject<StreamlabsOBSResponse>(responsJson);
                        response.JsonResponse = responsJson;

                        if (response.Results.Value<string>("_type").Equals("SUBSCRIPTION")) {
                            OnBegin?.Invoke(this, response);
                        }
                        else
                        if (response.Results.Value<string>("_type").Equals("EVENT")) {
                            StreamlabsOBSEvent eventData = response.GetResultFirstOrDefault<StreamlabsOBSEvent>();

                            OnEvent?.Invoke(this, eventData);
                            if (typeof(TResponse).IsAssignableFrom(typeof(StreamlabsOBSEvent))) {
                                OnData?.Invoke(this, eventData as TResponse);
                            }
                            else {
                                OnData?.Invoke(this, eventData.GetDataFirstOrDefault<TResponse>());
                            }
                        }
                        else {
                            OnUnsupported?.Invoke(this, responsJson);
                        }
                    }
                }
            }, _externCancellationToken);
        }

        public void UnSubscribe(EventHandler<TResponse> eventHandler)
        {
            OnData -= eventHandler;
            unsubscribeToken.Cancel();
        }

        #region IDisposable methods
        /// <inheritdoc/>
        public void Dispose() => unsubscribeToken.Cancel();
        #endregion
    }
}