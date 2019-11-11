using System;
using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Services
{
    public class SceneCollectionCreateOptions
    {
        public SceneCollectionCreateOptions(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        [JsonProperty("name")]
        public string Name { get; protected set; }
    }
}