using System.Collections.Generic;
using Amsel.Clients.Sample.SLOBS.Converter;
using Amsel.Clients.Sample.SLOBS.Enums;
using Amsel.Clients.Sample.SLOBS.Interfaces.Response;
using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Models.Response
{
    public class SLOBSNode : ISLOBSSceneFolder, ISLOBSSceneItem
    {
        [JsonProperty("childrenIds")]
        public List<string> ChildrenIds { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("locked")]
        public bool? Locked { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("obsSceneItemId")]
        public long? ObsSceneItemId { get; set; }

        [JsonProperty("parentId")]
        public string ParentId { get; set; }

        private string resourceId;

        [JsonProperty("resourceId")]
        public string ResourceId
        {
            get => string.IsNullOrEmpty(resourceId) ? $"SceneItem[\"{SceneId}\",\"{SceneItemId}\",\"{SourceId}\"]" : resourceId;
            set => resourceId = value;
        }

        [JsonProperty("sceneId")]
        public string SceneId { get; set; }

        [JsonProperty("sceneItemId")]
        public string SceneItemId { get; set; }

        [JsonProperty("sceneNodeType")]
        [JsonConverter(typeof(SceneNodeTypeConverter))]
        public ESLOBSSceneNodeType SceneNodeType { get; set; }

        [JsonProperty("sourceId")]
        public string SourceId { get; set; }

        [JsonProperty("transform")]
        public SLOBSTransform Transform { get; set; }

        [JsonProperty("visible")]
        public bool? Visible { get; set; }
    }
}