using Amsel.Framework.Streamlabs.Socket.Converter;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Amsel.Framework.Streamlabs.Socket.Models {
    public abstract class StreamlabsEventModel
    {
        [JsonProperty("createdAt"),
        JsonConverter(typeof(StreamlabsDateTimeConverter))]
        public DateTime CreatTime { get; protected set; }
        [JsonProperty("forceRepeat")]
        public bool ForceRepeat { get; protected set; }
        [JsonProperty("forceShow")]
        public bool ForceShow { get; protected set; }
        [JsonProperty("from")]
        public string From { get; protected set; }
        [JsonProperty("hash")]
        public string Hash { get; protected set; }
        [JsonProperty("historical")]
        public bool Historical { get; protected set; }
        [JsonProperty("_id")]
        public string Id { get; protected set; }
        [JsonProperty("isTest")]
        public bool IsTest { get; protected set; }
        [JsonProperty("name")]
        public string Name { get; protected set; }
        [JsonProperty("payload")]
        public JToken Payload { get; protected set; }
        [JsonProperty("platform")]
        public string Platform { get; protected set; }
        [JsonProperty("priority")]
        public int Priority { get; protected set; }
        [JsonProperty("read")]
        public bool Read { get; protected set; }
        [JsonProperty("repeat")]
        public bool Repeat { get; protected set; }
        [JsonProperty("success")]
        public bool Success { get; protected set; }
        [JsonProperty("type")]
        public string Type { get; protected set; }
    }
}