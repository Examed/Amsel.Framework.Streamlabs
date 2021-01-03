using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    public class StreamlabsOBSFader
    {
        #region Properties
        [JsonProperty("db")]
        public double Db { get; protected set; }

        [JsonProperty("deflection")]
        public double Deflection { get; protected set; }

        [JsonProperty("mul")]
        public double Mul { get; protected set; }
        #endregion
    }
}