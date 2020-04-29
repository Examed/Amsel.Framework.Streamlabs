using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response {
    public class StreamlabsOBSItem : StreamlabsOBSNode
    {
        [JsonProperty("locked")]
        public bool? Locked { get; protected set; }
        [JsonProperty("recordingVisible")]
        public bool? RecordingVisible { get; protected set; }
        public string ResourceId => $"SceneItem[\"{SceneId}\",\"{SceneItemId}\",\"{SourceId}\"]";
        [JsonProperty("sceneItemId")]
        public string SceneItemId { get; protected set; }
        [JsonProperty("sourceId")]
        public string SourceId { get; protected set; }
        [JsonProperty("streamVisible")]
        public bool? StreamVisible { get; protected set; }
        [JsonProperty("transform")]
        public StreamlabsOBSTransform Transform { get; protected set; }
        [JsonProperty("visible")]
        public bool? Visible { get; protected set; }
    }
}