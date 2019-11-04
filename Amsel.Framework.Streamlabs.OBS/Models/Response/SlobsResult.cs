using System;
using System.Collections.Generic;
using Amsel.Clients.Sample.SLOBS.Interfaces.Response;
using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Models.Response
{
    public class SLOBSResult : ISLOBSResult
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nodes")]
        public List<SLOBSNode> Nodes { get; set; }

        [JsonProperty("resourceId")]
        public string ResourceId { get; set; }

        [JsonProperty("type")]
        public string ResultType { get; set; }





        [JsonProperty("async")]
        public bool Async { get; set; }

        [JsonProperty("audio")]
        public bool Audio { get; set; }

        [JsonProperty("doNotDuplicate")]
        public bool DoNotDuplicate { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }


        [JsonProperty("muted")]
        public bool Muted { get; set; }



        [JsonProperty("recordingStatus")]
        public string RecordingStatus { get; set; }

        [JsonProperty("recordingStatusTime")]
        public DateTimeOffset RecordingStatusTime { get; set; }

        [JsonProperty("sourceId")]
        public string SourceId { get; set; }

        [JsonProperty("streamingStatus")]
        public string StreamingStatus { get; set; }

        [JsonProperty("streamingStatusTime")]
        public DateTimeOffset StreamingStatusTime { get; set; }

        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }
}