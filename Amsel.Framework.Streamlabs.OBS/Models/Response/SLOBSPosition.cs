using System;
using Amsel.Clients.Sample.SLOBS.Interfaces.Response;
using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Models.Response
{
    [Serializable]
    public class SLOBSPosition
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
        public double X { get; protected set; }

        [JsonProperty("y")]
        public double Y { get; protected set; }

        public static SLOBSPosition operator +(SLOBSPosition a, SLOBSPosition b) => a + (b.X, b.Y);
        public static SLOBSPosition operator +(SLOBSPosition a, (double X, double Y) b) => new SLOBSPosition { X = a.X + b.X, Y = a.Y + b.Y };
        public static SLOBSPosition operator -(SLOBSPosition a, SLOBSPosition b) => a - (b.X, b.Y);
        public static SLOBSPosition operator -(SLOBSPosition a, (double X, double Y) b) => new SLOBSPosition { X = a.X - b.X, Y = a.Y - b.Y };
        public static SLOBSPosition operator /(SLOBSPosition a, double b) => new SLOBSPosition { X = a.X / b, Y = a.Y / b };
        public static bool operator ==(SLOBSPosition a, SLOBSPosition b) => (int)a.X == (int)b.X && (int)a.Y == (int)b.Y;
        public static bool operator !=(SLOBSPosition a, SLOBSPosition b) => !(a == b);

        public double Distance()
        {
            return Math.Abs(X + Y);
        }

    }
}