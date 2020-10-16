﻿using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.Socket.Models
{
    public class StreamlabsTwitchHost : StreamlabsEventModel
    {
        [JsonProperty("viewers")]
        public int Viewers { get; protected set; }
    }
}