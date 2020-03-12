using Newtonsoft.Json.Converters;

namespace Amsel.Framework.Streamlabs.Socket.Converter
{
    internal class StreamlabsDateTimeConverter : IsoDateTimeConverter
    {
        #region  CONSTRUCTORS

        public StreamlabsDateTimeConverter() => DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
    #endregion
    }
}