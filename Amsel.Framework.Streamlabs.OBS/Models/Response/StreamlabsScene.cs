using System.Collections.Generic;
using Amsel.Framework.Streamlabs.OBS.Enums;
using Amsel.Framework.Streamlabs.OBS.Service;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    public class StreamlabsScene
    {
        [JsonProperty("id")] public string Id { get; protected set; }
        [JsonProperty("name")] public string Name { get; protected set; }

        [JsonProperty("nodes")] public JArray Nodes { get; protected set; }

        [JsonProperty("resourceId")] public string ResourceId { get; protected set; }

        [JsonProperty("type")] public string ResultType { get; protected set; }

        [NotNull]
        public IEnumerable<StreamlabsItem> GetSceneItems(StreamlabsClient client = null)
        {
            List<StreamlabsItem> result = new List<StreamlabsItem>();
            foreach (var item in Nodes)
            {
                var type = item["sceneNodeType"].ToObject<ESceneNodeType>();
                if (type == ESceneNodeType.FOLDER && client != null)
                {
                    StreamlabsFolder folder = item.ToObject<StreamlabsFolder>();
                    result.AddRange(folder.GetNestedItems(client));
                }
                else if (type == ESceneNodeType.ITEM)
                {
                    result.Add(item.ToObject<StreamlabsItem>());
                }
            }

            return result;
        }
    }
}