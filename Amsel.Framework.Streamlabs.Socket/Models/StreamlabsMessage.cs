using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.Socket.Models {
    public abstract class StreamlabsMessage : StreamlabsEventModel {
        [JsonProperty("display_name")]
        public string DisplayName { get; protected set; }
        [JsonProperty("emotes")]
        public string Emotes { get; protected set; }
        [JsonProperty("from_display_name")]
        public string FromDisplayName { get; protected set; }
        [JsonProperty("message")]
        public string Message { get; protected set; }
    }
}