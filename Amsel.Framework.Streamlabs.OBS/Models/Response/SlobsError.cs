using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Models.Response
{
    public class SLOBSError
    {
        [JsonProperty("code")]
        public long Code { get; protected set; }

        [JsonProperty("message")]
        public string Message { get; protected set; }
    }
}