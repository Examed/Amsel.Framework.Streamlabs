using Newtonsoft.Json;
using System;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    [Serializable]
    public class StreamlabsOBSPosition
    {
        [JsonProperty("x")] public double X { get; protected set; }

        [JsonProperty("y")] public double Y { get; protected set; }

        protected bool Equals(StreamlabsOBSPosition other) => X.Equals(other.X) && Y.Equals(other.Y);

        #region PUBLIC METHODES
        public double Distance() => Math.Abs(X + Y);

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj))
                return false;
            if(ReferenceEquals(this, obj))
                return true;
            return (obj.GetType() == GetType()) && Equals((StreamlabsOBSPosition)obj);
        }

        // ReSharper disable NonReadonlyMemberInGetHashCode
        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }
        #endregion

        public static StreamlabsOBSPosition operator -(StreamlabsOBSPosition a, StreamlabsOBSPosition b) => a -
            (b.X, b.Y);
        public static StreamlabsOBSPosition operator -(StreamlabsOBSPosition a, (double X, double Y) b) => new StreamlabsOBSPosition
        { X = a.X - b.X, Y = a.Y - b.Y };
        public static bool operator !=(StreamlabsOBSPosition a, StreamlabsOBSPosition b) => !(a == b);
        public static StreamlabsOBSPosition operator /(StreamlabsOBSPosition a, double b) => new StreamlabsOBSPosition
        { X = a.X / b, Y = a.Y / b };
        public static StreamlabsOBSPosition operator +(StreamlabsOBSPosition a, StreamlabsOBSPosition b) => a +
            (b.X, b.Y);
        public static StreamlabsOBSPosition operator +(StreamlabsOBSPosition a, (double X, double Y) b) => new StreamlabsOBSPosition
        { X = a.X + b.X, Y = a.Y + b.Y };
        public static bool operator ==(StreamlabsOBSPosition a, StreamlabsOBSPosition b) => ((int)a.X == (int)b.X) &&
            ((int)a.Y == (int)b.Y);

        #region  CONSTRUCTORS

        public StreamlabsOBSPosition() { }

        public StreamlabsOBSPosition(double x, double y)
        {
            X = x;
            Y = y;
        }
        #endregion
    }
}