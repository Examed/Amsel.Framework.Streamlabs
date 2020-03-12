using Amsel.Framework.Streamlabs.OBS.Utilities.Converter;
using Newtonsoft.Json;
using System;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    public class StreamlabsOBSCollection
    {
        [JsonProperty("deleted")] public bool Deleted { get; protected set; }

        [JsonProperty("id")] public string Id { get; protected set; }

        [JsonProperty("modified")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Modified { get; protected set; }

        [JsonProperty("name")] public string Name { get; protected set; }

        [JsonProperty("needsRename")] public bool NeedsRename { get; protected set; }

        public string ResourceId => $"SceneCollection[\"{Id}\"]";

        [JsonProperty("serverId")] public bool ServerId { get; protected set; }
    }
}