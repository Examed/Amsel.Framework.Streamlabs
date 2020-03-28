using Newtonsoft.Json;
using System;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    [Serializable]
    public class StreamlabsOBSTransform
    {
        [JsonProperty("crop")] public StreamlabsOBSCrop Crop { get; set; }

        [JsonProperty("position")] public StreamlabsOBSPosition Position { get; set; }

        [JsonProperty("rotation")] public long Rotation { get; set; }

        [JsonProperty("scale")] public StreamlabsOBSPosition Scale { get; set; }

        protected StreamlabsOBSTransform() { }

        public StreamlabsOBSTransform(StreamlabsOBSCrop crop, StreamlabsOBSPosition position, long rotation, StreamlabsOBSPosition scale)
        {
            Crop = crop;
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }
    }
}