using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Models.Response
{
    public class SLOBSFader
    {
        [JsonProperty("db")]
        public double DB { get; set; }

        [JsonProperty("deflection")]
        public double Deflection { get; set; }

        [JsonProperty("mul")]
        public double Mul { get; set; }
    }
}