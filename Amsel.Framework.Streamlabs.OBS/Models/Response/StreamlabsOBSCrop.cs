using Newtonsoft.Json;
using System;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    [Serializable]
    public class StreamlabsOBSCrop
    {
        [JsonProperty("bottom")] public long Bottom { get; protected set; }

        [JsonProperty("left")] public long Left { get; protected set; }

        [JsonProperty("right")] public long Right { get; protected set; }

        [JsonProperty("top")] public long Top { get; protected set; }
    }
}