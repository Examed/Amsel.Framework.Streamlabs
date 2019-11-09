using System.Collections.Generic;
using Amsel.Framework.Streamlabs.OBS.Models.Request;
using Amsel.Framework.Streamlabs.OBS.Service;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    public class StreamlabsFolder : StreamlabsNode
    {
        [JsonProperty("childrenIds")] public List<string> ChildrenIds { get; protected set; }

        [JsonProperty("resourceId")] private string resourceId;

        public string ResourceId
        {
            get => string.IsNullOrEmpty(resourceId) ? $"SceneItemFolder[\"{SceneId}\",\"{Id}\"]" : resourceId;
            set => resourceId = value;
        }


        public IEnumerable<StreamlabsFolder> GetFolders(StreamlabsClient client)
        {
            return client.SendRequest<StreamlabsFolder>(new StreamlabsRequest("getFolders", ResourceId));
        }
        [NotNull]
        public IEnumerable<StreamlabsFolder> GetNestedFolders(StreamlabsClient client)
        {
            var result = new List<StreamlabsFolder>();
            var folders = GetFolders(client);
            var a = Name;
            foreach (var node in folders)
            {
                result.Add(node);
                result.AddRange(node.GetNestedFolders(client));
            }
            return result;
        }

        public IEnumerable<StreamlabsItem> GetItems(StreamlabsClient client)
        {
            return client.SendRequest<StreamlabsItem>(new StreamlabsRequest("getItems", ResourceId));
        }
        [NotNull]
        public IEnumerable<StreamlabsItem> GetNestedItems(StreamlabsClient client)
        {
            var result = new List<StreamlabsItem>();
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