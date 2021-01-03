using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    public class StreamlabsOBSError
    {
        #region Properties
        [JsonProperty("code")]
        public long Code { get; protected set; }

        [JsonProperty("message")]
        public string Message { get; protected set; }
        #endregion
    }
}