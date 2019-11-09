using Amsel.Clients.Sample.SLOBS.Converter;
using Amsel.Clients.Sample.SLOBS.Enums;
using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Models.Response
{
    public class StreamlabsNode
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