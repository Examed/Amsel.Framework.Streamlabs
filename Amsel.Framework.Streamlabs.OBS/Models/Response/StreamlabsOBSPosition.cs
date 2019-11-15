using System;
using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    [Serializable]
    public class StreamlabsOBSPosition
    {
        #region  CONSTRUCTORS

        public StreamlabsOBSPosition() { }

        public StreamlabsOBSPosition(double x, double y) {
            X = x;
            Y = y;
        }

        #endregion

        [JsonProperty("x")] public double X { get; protected set; }

        [JsonProperty("y")] public double Y { get; protected set; }

        public static StreamlabsOBSPosition operator +(StreamlabsOBSPosition a, StreamlabsOBSPosition b) {
            return a + (b.X, b.Y);
        }

        public static StreamlabsOBSPosition operator +(StreamlabsOBSPosition a, (double X, double Y) b) {
            return new StreamlabsOBSPosition {X = a.X + b.X, Y = a.Y + b.Y};
        }

        public static StreamlabsOBSPosition operator -(StreamlabsOBSPosition a, StreamlabsOBSPosition b) {
            return a - (b.X, b.Y);
        }

        public static StreamlabsOBSPosition operator -(StreamlabsOBSPosition a, (double X, double Y) b) {
            return new StreamlabsOBSPosition {X = a.X - b.X, Y = a.Y - b.Y};
        }

        public static StreamlabsOBSPosition operator /(StreamlabsOBSPosition a, double b) {
            return new StreamlabsOBSPosition {X = a.X / b, Y = a.Y / b};
        }

        public static bool operator ==(StreamlabsOBSPosition a, StreamlabsOBSPosition b) {
            return (int) a.X == (int) b.X && (int) a.Y == (int) b.Y;
        }

        public static bool operator !=(StreamlabsOBSPosition a, StreamlabsOBSPosition b) {
            return !(a == b);
        }

        public double Distance() {
            return Math.Abs(X + Y);
        }
    }
}