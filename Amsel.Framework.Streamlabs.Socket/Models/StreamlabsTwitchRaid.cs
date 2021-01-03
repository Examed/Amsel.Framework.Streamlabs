using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.Socket.Models
{
    public class StreamlabsTwitchRaid : StreamlabsEventModel
    {
        #region Properties
        [JsonProperty("raiders")]
        public int Raiders { get; protected set; }
        #endregion
    }
}