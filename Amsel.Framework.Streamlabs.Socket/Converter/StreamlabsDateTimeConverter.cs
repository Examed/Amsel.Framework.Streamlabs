﻿using Newtonsoft.Json.Converters;

namespace Amsel.Framework.Streamlabs.Socket.Converter {
    internal class StreamlabsDateTimeConverter : IsoDateTimeConverter
    {
        public StreamlabsDateTimeConverter() => DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
    }
}