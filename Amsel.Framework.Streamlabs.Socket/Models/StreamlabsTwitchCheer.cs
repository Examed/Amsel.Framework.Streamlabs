using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.Socket.Models {
    public class StreamlabsTwitchCheer : StreamlabsMessage
    {
        [JsonProperty("amount")]
        public string Amount { get; protected set; }
        [JsonProperty("facemask")]
        public string Facemask { get; protected set; }
        [JsonProperty("style")]
        public string Style { get; protected set; }
    }
}