using System;
using Amsel.Framework.Streamlabs.OBS.Converter;
using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    public class StreamlabsCollection
    {
        [JsonProperty("id")]
        public string Id { get; protected set; }

        [JsonProperty("name")]
        public string Name { get; protected set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; protected set; }

        [JsonProperty("modified")]

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Modified { get; protected set; }

        [JsonProperty("needsRename")]
        public bool NeedsRename { get; protected set; }

        [JsonProperty("serverId")]
        public bool ServerId { get; protected set; }

        [JsonProperty("resourceId")] private string resourceId;

        public string ResourceId
        {
            get => string.IsNullOrEmpty(resourceId) ? $"SceneCollection[\"{Id}\"]" : resourceId;
            set => resourceId = value;
        }

    }
}