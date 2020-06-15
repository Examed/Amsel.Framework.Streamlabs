using Amsel.Framework.Streamlabs.OBS.Enums;
using Newtonsoft.Json;
using System;

namespace Amsel.Framework.Streamlabs.OBS.Utilities.Converter {
    public class SceneNodeTypeConverter : JsonConverter {
        public override bool CanConvert(Type objectType) =>
            (objectType == typeof(ESceneNodeType)) || (objectType == typeof(ESceneNodeType?));

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            if (reader.TokenType == JsonToken.Null) {
                return null;
            }

            switch (serializer.Deserialize<string>(reader)) {
                case "folder" :
                    return ESceneNodeType.FOLDER;

                case "item" :
                    return ESceneNodeType.ITEM;
            }

            throw new Exception("Cannot unmarshal type SceneNodeType");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            if (value == null) {
                serializer.Serialize(writer, null);
            }

            switch ((ESceneNodeType)value) {
                case ESceneNodeType.FOLDER :
                    serializer.Serialize(writer, "folder");
                    return;

                case ESceneNodeType.ITEM :
                    serializer.Serialize(writer, "item");
                    return;
            }

            throw new Exception("Cannot marshal type SceneNodeType");
        }
    }
}