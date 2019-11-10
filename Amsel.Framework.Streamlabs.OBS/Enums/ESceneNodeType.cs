using Newtonsoft.Json;

namespace Amsel.Framework.StreamlabsOBS.OBS.Enums
{
    public enum ESceneNodeType
    {
        [JsonProperty("folder")]
        FOLDER, 
        [JsonProperty("item")]
        ITEM
    };
}