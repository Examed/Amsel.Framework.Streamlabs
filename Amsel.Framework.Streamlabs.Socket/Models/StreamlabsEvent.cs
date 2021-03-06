﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Amsel.Framework.Streamlabs.Socket.Models
{
    public class StreamlabsEvent
    {
        #region Properties
        [JsonProperty(PropertyName = "event_id")]
        public string EventId { get; protected set; }

        [JsonProperty(PropertyName = "for")]
        public string For { get; protected set; }

        [JsonProperty(PropertyName = "message")]
        public JToken Message { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; protected set; }
        #endregion
    }
}