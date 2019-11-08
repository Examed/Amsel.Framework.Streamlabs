using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Amsel.Clients.Sample.SLOBS.Enums;
using Amsel.Clients.Sample.SLOBS.Models.Request;
using Amsel.Clients.Sample.SLOBS.Models.Response;
using Amsel.Clients.Sample.SLOBS.Service;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Amsel.Clients.Sample.SLOBS.Interfaces.Response
{
    public class SLOBSScene
    {
        [JsonProperty("id")] public string Id { get; protected set; }
        [JsonProperty("name")] public string Name { get; protected set; }

        [JsonProperty("nodes")] public JArray Nodes { get; protected set; }

        [JsonProperty("resourceId")] public string ResourceId { get; protected set; }

        [JsonProperty("type")] public string ResultType { get; protected set; }

        [NotNull]
        public IEnumerable<SLOBSItem> GetSceneItems(SLOBSClient client = null)
        {
            List<SLOBSItem> result = new List<SLOBSItem>();
            foreach (var item in Nodes)
            {
                var type = item["sceneNodeType"].ToObject<ESLOBSSceneNodeType>();
                if (type == ESLOBSSceneNodeType.FOLDER && client != null)
                {
                    SLOBSFolder folder = item.ToObject<SLOBSFolder>();
                    result.AddRange(folder.GetNestedItems(client));
                }
                else if (type == ESLOBSSceneNodeType.ITEM)
                {
                    result.Add(item.ToObject<SLOBSItem>());
                }
            }

            return result;
        }
    }
}