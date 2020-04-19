using Amsel.Framework.Streamlabs.Socket.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;
using System;

namespace Amsel.Framework.Streamlabs.Socket.Methodes
{
    public class StreamlabsSoket
    {
        private readonly ILogger log;

        public StreamlabsSoket(ILogger logger = null) => log = logger;

        public event EventHandler OnConnected;

        public event EventHandler<object> OnDisconnected;

        public event EventHandler<StreamlabsDonation> OnDonation;

        public event EventHandler<object> OnError;

        public event EventHandler<StreamlabsLabels> OnStreamlabels;

        public event EventHandler<StreamlabsTwitchCheer> OnTwitchCheer;

        public event EventHandler<StreamlabsTwitchFollow> OnTwitchFollow;

        public event EventHandler<StreamlabsTwitchHost> OnTwitchHost;

        public event EventHandler<StreamlabsTwitchRaid> OnTwitchRaid;

        public event EventHandler<StreamlabsTwitchSubscription> OnTwitchSubscription;

        public event EventHandler<JToken> OnUndocumented;

        #region PUBLIC METHODES
        public void Connect(string socketToken)
        {
            string url = $"https://sockets.streamlabs.com";
            IO.Options opt = new IO.Options
            {
                QueryString = $"token={socketToken}",
                Reconnection = true,
                ReconnectionDelay = 500,
                Port = 433,
                Secure = true,
                AutoConnect = false,
                Upgrade = true
            };

            Quobject.SocketIoClientDotNet.Client.Socket socket = IO.Socket(url, opt);

            socket.On(Quobject.SocketIoClientDotNet.Client.Socket.EVENT_CONNECT, () =>
            {
                log?.LogDebug("Connected");
                OnConnected?.Invoke(this, new EventArgs());
            });

            socket.On(Quobject.SocketIoClientDotNet.Client.Socket.EVENT_DISCONNECT, data =>
            {
                log?.LogDebug($"Disonnected: {data}");
                OnDisconnected?.Invoke(this, (string)data);
            });

            socket.On(Quobject.SocketIoClientDotNet.Client.Socket.EVENT_ERROR, data =>
            {
                log?.LogDebug($"Error: {data}");
                OnError?.Invoke(this, data);
            });

            socket.On("event", data =>
            {
                log?.LogTrace($"EventData: {data}");
                Console.WriteLine(data);

                StreamlabsEvent streamlabsEvent = JsonConvert.DeserializeObject<StreamlabsEvent>(data.ToString());
                Console.WriteLine(data);

                JToken token = streamlabsEvent.Message;
                if(token.Type == JTokenType.Array)
                    token = token.First;

                switch(streamlabsEvent.Type)
                {
                    case "streamlabels.underlying":
                        OnStreamlabels?.Invoke(this, token.ToObject<StreamlabsLabels>());
                        return;
                    case "donation":
                        OnDonation?.Invoke(this, token.ToObject<StreamlabsDonation>());
                        break;
                    case "redemption":
                        break;
                    case "subscription":
                        switch(token["platform"].Value<string>())
                        {
                            case "twitch_account":
                                OnTwitchSubscription?.Invoke(this, token.ToObject<StreamlabsTwitchSubscription>());
                                break;
                        }

                        break;
                    case "follow":
                        switch(token["platform"].Value<string>())
                        {
                            case "twitch_account":
                                OnTwitchFollow?.Invoke(this, token.ToObject<StreamlabsTwitchFollow>());
                                break;
                        }

                        break;
                    case "host":
                        switch(token["platform"].Value<string>())
                        {
                            case "twitch_account":
                                OnTwitchHost?.Invoke(this, token.ToObject<StreamlabsTwitchHost>());
                                break;
                        }

                        break;
                    case "bits":
                        switch(token["platform"].Value<string>())
                        {
                            case "twitch_account":
                                OnTwitchCheer?.Invoke(this, token.ToObject<StreamlabsTwitchCheer>());
                                break;
                        }

                        break;
                    case "raid":
                        switch(token["platform"].Value<string>())
                        {
                            case "twitch_account":
                                OnTwitchRaid?.Invoke(this, token.ToObject<StreamlabsTwitchRaid>());
                                break;
                        }

                        break;
                    default:
                        OnUndocumented?.Invoke(this, token);
                        break;
                }


                //else if (streamlabsEvent.Message.GetType() is "redemption")
                //{
                //}
                //else if (streamlabsEvent.Message.GetType() is "pausequeue")
                //{
                //}
                //else if (streamlabsEvent.Message.GetType() is "unpausequeue")
                //{
                //}
                //else if (streamlabsEvent.Message.GetType() is "mutevolume")
                //{
                //}
                //else if (streamlabsEvent.Message.GetType() is "unmutevolume")
                //{
                //}
                //else if (streamlabsEvent.Message.GetType() is "skipalert")
                //{
                //}
            });

            socket.Open();
        }
        #endregion
    }
}