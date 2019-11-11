using System;
using System.Collections.Generic;
using Amsel.Framework.Streamlabs.OBS.Utilities.Converter;
using Newtonsoft.Json;

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

    public class StreamlabsSourceBase
    {
        [JsonProperty("id")]
        public string Id { get; protected set; }

        [JsonProperty("name")]
        public string Name { get; protected set; }
        // TODO Enum
        [JsonProperty("type")]
        public string Type { get; protected set; }

    }
    public class StreamlabsSource : StreamlabsSourceBase
    {
        [JsonProperty("async")]
        public bool Async { get; protected set; }

        [JsonProperty("audio")]
        public bool Audio { get; protected set; }

        [JsonProperty("channel")]
        public int Channel { get; protected set; }

        [JsonProperty("doNotDuplicate")]
        public bool DoNotDuplicate { get; protected set; }

        [JsonProperty("height")]
        public double Height { get; protected set; }

        [JsonProperty("width")]
        public double Width { get; protected set; }

        [JsonProperty("resourceId")]
        public string ResourceId { get; protected set; }

        [JsonProperty("sourceId")]
        public string SourceId { get; protected set; }

        [JsonProperty("video")]
        public bool Video { get; protected set; }
    }


    public class StreamlabsOBSCollection
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

        public string ResourceId => $"SceneCollection[\"{Id}\"]";
    }
}