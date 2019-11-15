using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Enums
{
    public enum ESceneNodeType
    {
        [JsonProperty("folder")] FOLDER,
        [JsonProperty("item")] ITEM
    }
}