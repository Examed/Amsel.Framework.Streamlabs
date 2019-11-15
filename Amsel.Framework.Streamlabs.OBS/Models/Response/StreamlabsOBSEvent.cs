﻿using System.Collections.Generic;
using System.Linq;
using Amsel.Framework.Streamlabs.OBS.Utilities;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    public class StreamlabsOBSEvent
    {
        [JsonProperty("emitter")] public string Emitter { get; protected set; }

        [JsonProperty("resourceId")] public string ResourceId { get; protected set; }

        [JsonProperty("_type")] public string Type { get; protected set; }

        [JsonProperty("isRejected")] public bool IsRejected { get; protected set; }

        [JsonProperty("data")] public JToken Data { get; protected set; }

        [NotNull]
        public IEnumerable<TResult> GetData<TResult>() {
            return Data.GetData<TResult>() ?? new List<TResult>();
        }

        public TResult GetDataFirstOrDefault<TResult>() {
            return GetData<TResult>().FirstOrDefault();
        }
    }
}