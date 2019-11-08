﻿using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.Socket.Models.EventTypes
{
    public class StreamlabsTwitchHost : StreamlabsEventModel
    {
        [JsonProperty("viewers")]
        public int Viewers { get; protected set; }
        [JsonProperty("type")]
        public string Type { get; protected set; }
    }
}