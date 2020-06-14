using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response {
    public class StreamlabsOBSSceneBase {
        [JsonProperty("id")]
        public string Id { get; protected set; }
        [JsonProperty("name")]
        public string Name { get; protected set; }
    }
}