using Newtonsoft.Json;
using System.Collections.Generic;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    public class SceneCollectionSchema
    {
        [JsonProperty("id")]
        public string Id { get; protected set; }

        [JsonProperty("name")]
        public string Name { get; protected set; }

        [JsonProperty("scenes")]
        public IEnumerable<StreamlabsOBSSceneBase> Scenes { get; protected set; }

        [JsonProperty("sources")]
        public IEnumerable<StreamlabsSourceBase> Sources { get; protected set; }
    }
}