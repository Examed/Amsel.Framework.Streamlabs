using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.Socket.Models.EventTypes
{
    public class StreamlabsTwitchFollow : StreamlabsEventModel
    {
        [JsonProperty("to")]
        public string To { get; protected set; }

        [JsonProperty("wotcCode")]
        public string WotcCode { get; protected set; }
    }
}