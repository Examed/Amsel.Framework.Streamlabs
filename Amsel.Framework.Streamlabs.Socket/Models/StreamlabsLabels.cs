using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Amsel.Framework.Streamlabs.Socket.Models {
    public class StreamlabsLabels
    {
        [JsonProperty(PropertyName = "data")]
        public JToken Data { get; set; }
        [JsonProperty("hash")]
        public string Hash { get; protected set; }
    }
}