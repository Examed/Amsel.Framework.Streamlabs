using System.Collections.Generic;
using Amsel.Clients.Sample.SLOBS.Converter;
using Amsel.Clients.Sample.SLOBS.Enums;
using Amsel.Clients.Sample.SLOBS.Models.Request;
using Amsel.Clients.Sample.SLOBS.Models.Response;
using Amsel.Clients.Sample.SLOBS.Service;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Interfaces.Response
{
    public class SLOBSFolder : SLOBSNode
    {
        [JsonProperty("childrenIds")] public List<string> ChildrenIds { get; protected set; }

        [JsonProperty("resourceId")] private string resourceId;

        public string ResourceId
        {
            get => string.IsNullOrEmpty(resourceId) ? $"SceneItemFolder[\"{SceneId}\",\"{Id}\"]" : resourceId;
            set => resourceId = value;
        }


        public IEnumerable<SLOBSFolder> GetFolders(SLOBSClient client)
        {
            return client.SendRequest<SLOBSFolder>(new SLOBSRequest("getFolders", ResourceId));
        }
        [NotNull]
        public IEnumerable<SLOBSFolder> GetNestedFolders(SLOBSClient client)
        {
            var result = new List<SLOBSFolder>();
            var folders = GetFolders(client);
            var a = Name;
            foreach (var node in folders)
            {
                result.Add(node);
                result.AddRange(node.GetNestedFolders(client));
            }
            return result;
        }

        public IEnumerable<SLOBSItem> GetItems(SLOBSClient client)
        {
            return client.SendRequest<SLOBSItem>(new SLOBSRequest("getItems", ResourceId));
        }
        [NotNull]
        public IEnumerable<SLOBSItem> GetNestedItems(SLOBSClient client)
        {
            var result = new List<SLOBSItem>();
            var currentItems = GetItems(client);
            if (currentItems != null)
                result.AddRange(currentItems);

            var folders = GetNestedFolders(client);
            foreach (var node in folders)
            {
                var folderItems = node.GetItems(client);
                if (folderItems != null)
                    result.AddRange(folderItems);
            }
            return result;
        }
    }
}