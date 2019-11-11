using Newtonsoft.Json.Converters;

namespace Amsel.Framework.Streamlabs.OBS.Utilities.Converter
{
    class DateTimeConverter : IsoDateTimeConverter
    {
        public DateTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";
        }
    }
}