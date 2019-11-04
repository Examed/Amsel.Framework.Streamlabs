using System;
using Amsel.Clients.Sample.SLOBS.Interfaces.Response;
using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Models.Response
{
    [Serializable]
    public class SLOBSTransform : ISLOBSTransform
    {
        public SLOBSTransform(SLOBSCrop crop, SLOBSPosition position, long rotation, SLOBSPosition scale)
        {
            Crop = crop;
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }
        public SLOBSTransform(SLOBSPosition position)
        {
            Position = position;
        }

        public SLOBSTransform()
        {
        }

        [JsonProperty("crop")]
        public SLOBSCrop Crop { get; set; }

        [JsonProperty("position")]
        public SLOBSPosition Position { get; set; }

        [JsonProperty("rotation")]
        public long Rotation { get; set; }

        [JsonProperty("scale")]
        public SLOBSPosition Scale { get; set; }
    }
}