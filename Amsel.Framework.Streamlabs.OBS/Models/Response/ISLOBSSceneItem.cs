using Amsel.Clients.Sample.SLOBS.Models.Response;
using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Interfaces.Response
{
    public class StreamlabsItem : StreamlabsNode
    {
        [JsonProperty("sourceId")]
        public string SourceId { get;protected set; }

        [JsonProperty("sceneItemId")]
        public string SceneItemId { get;protected set; }

        [JsonProperty("transform")]
        public StreamlabsTransform Transform { get;protected set; }

        [JsonProperty("visible")]
        public bool? Visible { get; protected set; }

        [JsonProperty("locked")]
        public bool? Locked { get; protected set; }

        [JsonProperty("streamVisible")]
        public bool? StreamVisible { get; protected set; }
        [JsonProperty("recordingVisible")]
        public bool? RecordingVisible { get; protected set; }

        [JsonProperty("resourceId")]
        private string resourceId;
        public string ResourceId
        {
            get => string.IsNullOrEmpty(resourceId) ? $"SceneItem[\"{SceneId}\",\"{SceneItemId}\",\"{SourceId}\"]" : resourceId;
            set => resourceId = value;
        }
    }
}