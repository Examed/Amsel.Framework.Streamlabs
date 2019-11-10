using System;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Amsel.Framework.StreamlabsOBS.OBS.Models.Request;
using Amsel.Framework.StreamlabsOBS.OBS.Models.Response;
using Newtonsoft.Json;

namespace Amsel.Framework.StreamlabsOBS.OBS.Service
{
    public class StreamlabsOBSSubscriptionHandler<TResponse> : IDisposable where TResponse : class
    {
        private readonly StreamlabsOBSRequest request;
        private readonly string pipeName;

        public event EventHandler<TResponse> OnData;
        public event EventHandler<string> OnUnsupported;
        public event EventHandler<StreamlabsOBSEvent> OnEvent;
        public event EventHandler<StreamlabsOBSResponse> OnBegin;
        private readonly CancellationTokenSource unsubscribeToken = new CancellationTokenSource();
        private readonly CancellationToken externCancellationToken = new CancellationToken();

        public StreamlabsOBSSubscriptionHandler(StreamlabsOBSRequest request, CancellationToken cancellationToken = default, string pipeName = "slobs")
        {
            this.request = request;
            this.pipeName = pipeName;
            if (cancellationToken != default)
                externCancellationToken = cancellationToken;
        }

        public void Subscribe(EventHandler<TResponse> value)
        {
            OnData += value;
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
                        var response = JsonConvert.DeserializeObject<StreamlabsOBSResponse>(responseJson);
                        response.JsonResponse = responseJson;

                        if (response.Results.Value<string>("_type") == "SUBSCRIPTION")
                            OnBegin?.Invoke(this, response);
                        else if (response.Results.Value<string>("_type") == "EVENT")
                        {

                            StreamlabsOBSEvent eventData = response.GetResultFirstOrDefault<StreamlabsOBSEvent>();
       
                            OnEvent?.Invoke(this, eventData);
                            if (typeof(TResponse).IsAssignableFrom(typeof(StreamlabsOBSEvent)))
                                OnData?.Invoke(this, eventData as TResponse);
                            else
                                OnData?.Invoke(this, eventData.GetDataFirstOrDefault<TResponse>());
                        }
                        else
                            OnUnsupported?.Invoke(this, responseJson);
                    }
                }
            }, externCancellationToken);
        }


        public void UnSubscribe(EventHandler<TResponse> eventHandler)
        {
            OnData -= eventHandler;
            unsubscribeToken.Cancel();
        }


        /// <inheritdoc />
        public void Dispose()
        {
            unsubscribeToken.Cancel();
        }


    }
}