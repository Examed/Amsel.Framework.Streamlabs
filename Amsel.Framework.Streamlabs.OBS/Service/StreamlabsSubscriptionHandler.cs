using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;
using Amsel.Framework.Streamlabs.OBS.Models.Request;
using Amsel.Framework.Streamlabs.OBS.Models.Response;
using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Service
{
    public class StreamlabsSubscriptionHandler<TResponse> : IDisposable
    {
        private readonly StreamlabsRequest request;
        private readonly string pipeName;
        public event EventHandler<TResponse> OnSubscriptionEvent;
        public event EventHandler<string> OnUnsuportetEvent;
        public event EventHandler<StreamlabsResponse> OnBeginSubscription;
        private readonly CancellationTokenSource unsubscribeToken = new CancellationTokenSource();
        private readonly CancellationToken externCancellationToken = new CancellationToken();

        public StreamlabsSubscriptionHandler(StreamlabsRequest request, CancellationToken cancellationToken = default, string pipeName = "slobs")
        {
            this.request = request;
            this.pipeName = pipeName;
            if (cancellationToken != default)
                externCancellationToken = cancellationToken;
        }

        public void Subscribe(EventHandler<TResponse> value)
        {
            OnSubscriptionEvent += value;
            Task.Factory.StartNew(async () =>
            {
                await using var stream = new NamedPipeClientStream(pipeName);
                using var reader = new StreamReader(stream);
                using (var writer = new StreamWriter(stream))
                {
                    await stream.ConnectAsync(5000, externCancellationToken);

                    writer.WriteLine(request.ToJson());
                    writer.Flush();
                    stream?.WaitForPipeDrain();

                    while (!externCancellationToken.IsCancellationRequested && !unsubscribeToken.IsCancellationRequested)
                    {
                        string responseJson = reader.ReadLine();
                        var response = JsonConvert.DeserializeObject<StreamlabsResponse>(responseJson);
                        response.JsonResponse = responseJson;

                        if (response.Results.Value<string>("_type") == "SUBSCRIPTION")
                            OnBeginSubscription?.Invoke(this, response);
                        else if (response.Results.Value<string>("_type") == "EVENT")
                            OnSubscriptionEvent?.Invoke(this, JsonConvert.DeserializeObject<TResponse>(responseJson));
                        else
                            OnUnsuportetEvent?.Invoke(this, responseJson);
                    }
                }
            }, externCancellationToken);
        }


        public void UnSubscribe(EventHandler<TResponse> eventHandler)
        {
            OnSubscriptionEvent -= eventHandler;
            unsubscribeToken.Cancel();
        }


        /// <inheritdoc />
        public void Dispose()
        {
            unsubscribeToken.Cancel();
        }


    }
}