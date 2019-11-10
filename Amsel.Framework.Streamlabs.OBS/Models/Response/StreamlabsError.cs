﻿using Newtonsoft.Json;

namespace Amsel.Framework.StreamlabsOBS.OBS.Models.Response
{
    public class StreamlabsOBSError
    {
        [JsonProperty("code")]
        public long Code { get; protected set; }

        [JsonProperty("message")]
        public string Message { get; protected set; }
    }
}