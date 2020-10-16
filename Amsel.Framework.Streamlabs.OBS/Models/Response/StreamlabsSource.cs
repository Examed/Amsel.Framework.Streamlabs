using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
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

        [JsonProperty("resourceId")]
        public string ResourceId { get; protected set; }

        [JsonProperty("sourceId")]
        public string SourceId { get; protected set; }

        [JsonProperty("video")]
        public bool Video { get; protected set; }

        [JsonProperty("width")]
        public double Width { get; protected set; }
    }
}