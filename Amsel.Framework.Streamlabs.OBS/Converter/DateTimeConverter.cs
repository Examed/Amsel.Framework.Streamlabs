using Newtonsoft.Json.Converters;

namespace Amsel.Framework.StreamlabsOBS.OBS.Converter
{
    class DateTimeConverter : IsoDateTimeConverter
    {
        public DateTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";
        }
    }
}