using Amsel.Framework.Streamlabs.OBS.Enums;
using Amsel.Framework.Streamlabs.OBS.Utilities.Converter;
using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
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