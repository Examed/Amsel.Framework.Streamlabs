using System;
using Amsel.Clients.Sample.SLOBS.Interfaces.Response;
using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Models.Response
{
    [Serializable]
    public class SLOBSCrop : ISLOBSCrop
    {
        [JsonProperty("bottom")]
        public long Bottom { get; set; }

        [JsonProperty("left")]
        public long Left { get; set; }

        [JsonProperty("right")]
        public long Right { get; set; }

        [JsonProperty("top")]
        public long Top { get; set; }
    }
}