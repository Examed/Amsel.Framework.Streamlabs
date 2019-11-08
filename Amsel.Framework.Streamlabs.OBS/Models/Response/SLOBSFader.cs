using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Models.Response
{
    public class SLOBSFader
    {
        [JsonProperty("db")]
        public double DB { get;protected set; }

        [JsonProperty("deflection")]
        public double Deflection { get; protected set; }

        [JsonProperty("mul")]
        public double Mul { get; protected set; }
    }
}