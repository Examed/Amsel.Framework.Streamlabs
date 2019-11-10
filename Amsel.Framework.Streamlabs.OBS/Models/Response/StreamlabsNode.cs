using Amsel.Framework.StreamlabsOBS.OBS.Converter;
using Amsel.Framework.StreamlabsOBS.OBS.Enums;
using Newtonsoft.Json;

namespace Amsel.Framework.StreamlabsOBS.OBS.Models.Response
{
    public class StreamlabsOBSNode
    {
        [JsonProperty("id")]
        public string Id { get; protected set; }

        [JsonProperty("name")]
        public string Name { get; protected set; }

        [JsonProperty("parentId")]
        public string ParentId { get; protected set; }

        [JsonProperty("sceneId")]
        public string SceneId { get; protected set; }

        [JsonProperty("sceneNodeType")]
        [JsonConverter(typeof(SceneNodeTypeConverter))]
        public ESceneNodeType SceneNodeType { get; protected set; }


    }
}