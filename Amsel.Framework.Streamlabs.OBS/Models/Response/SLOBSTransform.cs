using System;
using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Models.Response
{
    [Serializable]
    public class StreamlabsTransform
    {
        public StreamlabsTransform(StreamlabsCrop crop, StreamlabsPosition position, long rotation, StreamlabsPosition scale)
        {
            Crop = crop;
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }
        protected StreamlabsTransform()
        {
        }

        [JsonProperty("crop")]
        public StreamlabsCrop Crop { get; set; }

        [JsonProperty("position")]
        public StreamlabsPosition Position { get; set; }

        [JsonProperty("rotation")]
        public long Rotation { get; set; }

        [JsonProperty("scale")]
        public StreamlabsPosition Scale { get; set; }
    }
}