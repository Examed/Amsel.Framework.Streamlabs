using System;
using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Request
{
    public class StreamlabsOBSSceneCollectionCreateOptions
    {
        #region Constructors
        public StreamlabsOBSSceneCollectionCreateOptions(string name) { Name = name ?? throw new ArgumentNullException(nameof(name)); }
        #endregion

        #region Properties
        [JsonProperty("name")]
        public string Name { get; protected set; }
        #endregion
    }
}