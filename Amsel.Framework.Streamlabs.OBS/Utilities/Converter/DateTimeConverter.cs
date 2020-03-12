using Newtonsoft.Json.Converters;

namespace Amsel.Framework.Streamlabs.OBS.Utilities.Converter
{
    internal class DateTimeConverter : IsoDateTimeConverter
    {
        #region  CONSTRUCTORS

        public DateTimeConverter() => DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";
    #endregion
    }
}