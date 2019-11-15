using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.Socket.Models
{
    public class StreamlabsTwitchRaid : StreamlabsEventModel
    {
        [JsonProperty("raiders")] public int Raiders { get; protected set; }
    }
}