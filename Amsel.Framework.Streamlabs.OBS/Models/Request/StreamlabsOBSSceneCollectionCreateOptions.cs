using System;
using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Request
{
    public class StreamlabsOBSSceneCollectionCreateOptions
    {
        #region  CONSTRUCTORS

        public StreamlabsOBSSceneCollectionCreateOptions(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        #endregion

        [JsonProperty("name")] public string Name { get; protected set; }
    }
}