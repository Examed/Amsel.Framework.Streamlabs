using Newtonsoft.Json.Converters;

namespace Amsel.Framework.Streamlabs.OBS.Utilities.Converter
{
    class DateTimeConverter : IsoDateTimeConverter
    {
        public DateTimeConverter() => DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";
    }
}