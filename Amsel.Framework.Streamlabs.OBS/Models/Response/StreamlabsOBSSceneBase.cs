using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    public class StreamlabsOBSSceneBase
    {
        #region Properties
        [JsonProperty("id")]
        public string Id { get; protected set; }

        [JsonProperty("name")]
        public string Name { get; protected set; }
        #endregion
    }
}