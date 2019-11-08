using System.Collections.Generic;
using Amsel.Clients.Sample.SLOBS.Converter;
using Amsel.Clients.Sample.SLOBS.Enums;
using Amsel.Clients.Sample.SLOBS.Interfaces.Response;
using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Models.Response
{
    public class SLOBSNode
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
        public ESLOBSSceneNodeType SceneNodeType { get; protected set; }


    }
}