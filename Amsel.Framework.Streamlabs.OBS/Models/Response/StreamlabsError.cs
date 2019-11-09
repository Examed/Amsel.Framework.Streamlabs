using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    public class StreamlabsError
    {
        [JsonProperty("code")]
        public long Code { get; protected set; }

        [JsonProperty("message")]
        public string Message { get; protected set; }
    }
}