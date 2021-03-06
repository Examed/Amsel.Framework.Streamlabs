﻿using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    public class StreamlabsOBSPromise
    {
        #region Properties
        [JsonProperty("emitter")]
        public string Emitter { get; protected set; }

        [JsonProperty("resourceId")]
        public string ResourceId { get; protected set; }

        [JsonProperty("_type")]
        public string Type { get; protected set; }
        #endregion
    }
}