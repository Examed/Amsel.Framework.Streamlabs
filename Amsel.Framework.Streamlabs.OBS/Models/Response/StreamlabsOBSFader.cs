using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response {
    public class StreamlabsOBSFader
    {
        [JsonProperty("db")]
        public double Db { get; protected set; }
        [JsonProperty("deflection")]
        public double Deflection { get; protected set; }
        [JsonProperty("mul")]
        public double Mul { get; protected set; }
    }
}