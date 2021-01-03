using System.Collections.Generic;
using Amsel.Framework.Streamlabs.OBS.Clients;
using Amsel.Framework.Streamlabs.OBS.Models.Request;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    public class StreamlabsOBSFolder : StreamlabsOBSNode
    {
        #region Fields
        [JsonProperty("resourceId")] private string resourceId;
        #endregion

        #region Properties
        [JsonProperty("childrenIds")]
        public List<string> ChildrenIds { get; protected set; }

        public string ResourceId {
            get => string.IsNullOrEmpty(resourceId) ? ($"SceneItemFolder[\"{SceneId}\",\"{Id}\"]") : resourceId;
            set => resourceId = value;
        }
        #endregion

        #region Methods
        public IEnumerable<StreamlabsOBSFolder> GetFolders(StreamlabsOBSClient client) {
            return client.SendRequest<StreamlabsOBSFolder>(new StreamlabsOBSRequest("getFolders", ResourceId)); }
        public IEnumerable<StreamlabsOBSItem> GetItems(StreamlabsOBSClient client) {
            return client.SendRequest<StreamlabsOBSItem>(new StreamlabsOBSRequest("getItems", ResourceId)); }
        [NotNull]
        public IEnumerable<StreamlabsOBSFolder> GetNestedFolders(StreamlabsOBSClient client)
        {
            List<StreamlabsOBSFolder> result = new List<StreamlabsOBSFolder>();
            IEnumerable<StreamlabsOBSFolder> folders = GetFolders(client);
            foreach(StreamlabsOBSFolder node in folders) {
                result.Add(node);
                result.AddRange(node.GetNestedFolders(client));
            }

            return result;
        }

        [NotNull]
        public IEnumerable<StreamlabsOBSItem> GetNestedItems(StreamlabsOBSClient client)
        {
            List<StreamlabsOBSItem> result = new List<StreamlabsOBSItem>();
            IEnumerable<StreamlabsOBSItem> currentItems = GetItems(client);
            if(currentItems != null) {
                result.AddRange(currentItems);
            }

            IEnumerable<StreamlabsOBSFolder> folders = GetNestedFolders(client);
            foreach(StreamlabsOBSFolder node in folders) {
                IEnumerable<StreamlabsOBSItem> folderItems = node.GetItems(client);
                if(folderItems != null) {
                    result.AddRange(folderItems);
                }
            }

            return result;
        }
        #endregion
    }
}