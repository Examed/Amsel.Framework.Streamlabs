using System;
using Amsel.Clients.Sample.SLOBS.Interfaces.Response;
using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Models.Response
{
    [Serializable]
    public class SLOBSPosition : ISLOBSPosition
    {
        public SLOBSPosition()
        {
        }

        public SLOBSPosition(double x, double y)
        {
            X = x;
            Y = y;
        }

        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }
    } 
}