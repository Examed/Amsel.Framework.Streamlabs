using System;
using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    [Serializable]
    public class StreamlabsOBSPosition
    {
        #region Constructors
        public StreamlabsOBSPosition() { }

        public StreamlabsOBSPosition(double x, double y)
        {
            X = x;
            Y = y;
        }
        #endregion

        #region Properties
        [JsonProperty("x")]
        public double X { get; protected set; }

        [JsonProperty("y")]
        public double Y { get; protected set; }
        #endregion

        #region Operators
        public static bool operator ==(StreamlabsOBSPosition a, StreamlabsOBSPosition b)
        {
            return ((int)a.X == (int)b.X) && ((int)a.Y == (int)b.Y);
        }
        public static StreamlabsOBSPosition operator +(StreamlabsOBSPosition a, StreamlabsOBSPosition b)
        {
            return a + (b.X, b.Y);
        }
        public static StreamlabsOBSPosition operator +(StreamlabsOBSPosition a, (double X, double Y) b)
        {
            return new StreamlabsOBSPosition { X = a.X + b.X, Y = a.Y + b.Y };
        }
        public static StreamlabsOBSPosition operator /(StreamlabsOBSPosition a, double b)
        {
            return new StreamlabsOBSPosition { X = a.X / b, Y = a.Y / b };
        }
        public static bool operator !=(StreamlabsOBSPosition a, StreamlabsOBSPosition b)
        {
            return !(a == b);
        }
        public static StreamlabsOBSPosition operator -(StreamlabsOBSPosition a, StreamlabsOBSPosition b)
        {
            return a - (b.X, b.Y);
        }
        public static StreamlabsOBSPosition operator -(StreamlabsOBSPosition a, (double X, double Y) b)
        {
            return new StreamlabsOBSPosition { X = a.X - b.X, Y = a.Y - b.Y };
        }
        #endregion

        #region Methods
        public double Distance() { return Math.Abs(X + Y); }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj)) {
                return false;
            }

            if(ReferenceEquals(this, obj)) {
                return true;
            }

            return (obj.GetType() == GetType()) && Equals((StreamlabsOBSPosition)obj);
        }

        // ReSharper disable NonReadonlyMemberInGetHashCode
        public override int GetHashCode()
        {
            unchecked {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        protected bool Equals(StreamlabsOBSPosition other) { return X.Equals(other.X) && Y.Equals(other.Y); }
        #endregion
    }
}