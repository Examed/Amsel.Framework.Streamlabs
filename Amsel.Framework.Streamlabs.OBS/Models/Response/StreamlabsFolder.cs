using System.Collections.Generic;
using Amsel.Framework.StreamlabsOBS.OBS.Models.Request;
using Amsel.Framework.StreamlabsOBS.OBS.Service;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Amsel.Framework.StreamlabsOBS.OBS.Models.Response
{
    public class StreamlabsOBSFolder : StreamlabsOBSNode
    {
        [JsonProperty("childrenIds")] public List<string> ChildrenIds { get; protected set; }

        [JsonProperty("resourceId")] private string resourceId;

        public string ResourceId
        {
            get => string.IsNullOrEmpty(resourceId) ? $"SceneItemFolder[\"{SceneId}\",\"{Id}\"]" : resourceId;
            set => resourceId = value;
        }


        public IEnumerable<StreamlabsOBSFolder> GetFolders(StreamlabsOBSClient client)
        {
            return client.SendRequest<StreamlabsOBSFolder>(new StreamlabsOBSRequest("getFolders", ResourceId));
        }
        [NotNull]
        public IEnumerable<StreamlabsOBSFolder> GetNestedFolders(StreamlabsOBSClient client)
        {
            var result = new List<StreamlabsOBSFolder>();
            var folders = GetFolders(client);
            var a = Name;
            foreach (var node in folders)
            {
                result.Add(node);
                result.AddRange(node.GetNestedFolders(client));
            }
            return result;
        }

        public IEnumerable<StreamlabsOBSItem> GetItems(StreamlabsOBSClient client)
        {
            return client.SendRequest<StreamlabsOBSItem>(new StreamlabsOBSRequest("getItems", ResourceId));
        }
        [NotNull]
        public IEnumerable<StreamlabsOBSItem> GetNestedItems(StreamlabsOBSClient client)
        {
            var result = new List<StreamlabsOBSItem>();
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