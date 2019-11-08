using System;
using Amsel.Clients.Sample.SLOBS.Interfaces.Response;
using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Models.Response
{
    [Serializable]
    public class SLOBSCrop
    {
        [JsonProperty("bottom")]
        public long Bottom { get; protected set; }

        [JsonProperty("left")]
        public long Left { get; protected set; }

        [JsonProperty("right")]
        public long Right { get; protected set; }

        [JsonProperty("top")]
        public long Top { get; protected set; }
    }
}