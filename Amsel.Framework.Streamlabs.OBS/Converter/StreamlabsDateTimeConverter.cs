using Newtonsoft.Json.Converters;

namespace Amsel.Framework.Streamlabs.Socket.Models.EventTypes
{
    class DateTimeConverter : IsoDateTimeConverter
    {
        public DateTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";
        }
    }
}