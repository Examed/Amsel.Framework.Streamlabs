using Amsel.Framework.Streamlabs.OBS.Clients;
using Amsel.Framework.Streamlabs.OBS.Enums;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    public class StreamlabsOBSScene : StreamlabsOBSSceneBase
    {
        [JsonProperty("nodes")] public JArray Nodes { get; protected set; }

        [JsonProperty("resourceId")] public string ResourceId { get; protected set; }

        // TODO _type or type
        [JsonProperty("type")] public string ResultType { get; protected set; }

        #region PUBLIC METHODES
        [NotNull]
        public IEnumerable<StreamlabsOBSItem> GetSceneItems(StreamlabsOBSClient client = null)
        {
            List<StreamlabsOBSItem> result = new List<StreamlabsOBSItem>();
            foreach(JToken item in Nodes)
            {
                ESceneNodeType type = item["sceneNodeType"].ToObject<ESceneNodeType>();
                if((type == ESceneNodeType.FOLDER) && (client != null))
                {
                    StreamlabsOBSFolder folder = item.ToObject<StreamlabsOBSFolder>();
                    result.AddRange(folder.GetNestedItems(client));
                } else
                {
                    if(type == ESceneNodeType.ITEM)
                        result.Add(item.ToObject<StreamlabsOBSItem>());
                }
            }

            return result;
        }
        #endregion
    }
}