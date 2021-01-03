using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.Socket.Models
{
    public class StreamlabsTwitchFollow : StreamlabsEventModel
    {
        #region Properties
        [JsonProperty("to")]
        public string To { get; protected set; }

        [JsonProperty("wotcCode")]
        public string WotcCode { get; protected set; }
        #endregion
    }
}