using System.Collections.Generic;
using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    public class SceneCollectionSchema
    {
        #region Properties
        [JsonProperty("id")]
        public string Id { get; protected set; }

        [JsonProperty("name")]
        public string Name { get; protected set; }

        [JsonProperty("scenes")]
        public IEnumerable<StreamlabsOBSSceneBase> Scenes { get; protected set; }

        [JsonProperty("sources")]
        public IEnumerable<StreamlabsSourceBase> Sources { get; protected set; }
        #endregion
    }
}