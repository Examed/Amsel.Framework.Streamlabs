using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    public class StreamlabsSourceBase
    {
        #region Properties
        [JsonProperty("id")]
        public string Id { get; protected set; }

        [JsonProperty("name")]
        public string Name { get; protected set; }

        // TODO Enum
        [JsonProperty("type")]
        public string Type { get; protected set; }
        #endregion
    }
}