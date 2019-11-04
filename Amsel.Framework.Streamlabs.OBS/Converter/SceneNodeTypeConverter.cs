using System;
using Amsel.Clients.Sample.SLOBS.Enums;
using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Converter
{
    public class SceneNodeTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(ESLOBSSceneNodeType) || objectType == typeof(ESLOBSSceneNodeType?);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            switch (serializer.Deserialize<string>(reader))
            {
                case "folder":
                    return ESLOBSSceneNodeType.Folder;

                case "item":
                    return ESLOBSSceneNodeType.Item;
            }

            throw new Exception("Cannot unmarshal type SceneNodeType");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null) serializer.Serialize(writer, null);

            switch ((ESLOBSSceneNodeType)value)
            {
                case ESLOBSSceneNodeType.Folder:
                    serializer.Serialize(writer, "folder");
                    return;

                case ESLOBSSceneNodeType.Item:
                    serializer.Serialize(writer, "item");
                    return;
            }

            throw new Exception("Cannot marshal type SceneNodeType");
        }
    }
}