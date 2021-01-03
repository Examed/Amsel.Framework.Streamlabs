using System;
using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    [Serializable]
    public class StreamlabsOBSCrop
    {
        #region Properties
        [JsonProperty("bottom")]
        public long Bottom { get; protected set; }

        [JsonProperty("left")]
        public long Left { get; protected set; }

        [JsonProperty("right")]
        public long Right { get; protected set; }

        [JsonProperty("top")]
        public long Top { get; protected set; }
        #endregion
    }
}