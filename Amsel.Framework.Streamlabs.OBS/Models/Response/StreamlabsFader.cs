using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    public class StreamlabsFader
    {
        [JsonProperty("db")]
        public double DB { get; protected set; }

        [JsonProperty("deflection")]
        public double Deflection { get; protected set; }

        [JsonProperty("mul")]
        public double Mul { get; protected set; }
    }
}