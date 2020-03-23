using Newtonsoft.Json;
using System;

namespace Amsel.Framework.Streamlabs.OBS.Models.Request
{
    public class StreamlabsOBSSceneCollectionCreateOptions
    {
        public StreamlabsOBSSceneCollectionCreateOptions(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));

        [JsonProperty("name")] public string Name { get; protected set; }
    }
}