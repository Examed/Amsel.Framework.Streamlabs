using System;
using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    [Serializable]
    public class StreamlabsPosition
    {
        public StreamlabsPosition()
        {
        }

        public StreamlabsPosition(double x, double y)
        {
            X = x;
            Y = y;
        }

        [JsonProperty("x")]
        public double X { get; protected set; }

        [JsonProperty("y")]
        public double Y { get; protected set; }

        public static StreamlabsPosition operator +(StreamlabsPosition a, StreamlabsPosition b) => a + (b.X, b.Y);
        public static StreamlabsPosition operator +(StreamlabsPosition a, (double X, double Y) b) => new StreamlabsPosition { X = a.X + b.X, Y = a.Y + b.Y };
        public static StreamlabsPosition operator -(StreamlabsPosition a, StreamlabsPosition b) => a - (b.X, b.Y);
        public static StreamlabsPosition operator -(StreamlabsPosition a, (double X, double Y) b) => new StreamlabsPosition { X = a.X - b.X, Y = a.Y - b.Y };
        public static StreamlabsPosition operator /(StreamlabsPosition a, double b) => new StreamlabsPosition { X = a.X / b, Y = a.Y / b };
        public static bool operator ==(StreamlabsPosition a, StreamlabsPosition b) => (int)a.X == (int)b.X && (int)a.Y == (int)b.Y;
        public static bool operator !=(StreamlabsPosition a, StreamlabsPosition b) => !(a == b);

        public double Distance()
        {
            return Math.Abs(X + Y);
        }

    }
}