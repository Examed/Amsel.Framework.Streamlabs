using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Enums
{
    public enum ESceneNodeType
    {
        [JsonProperty("folder")]
        FOLDER, 
        [JsonProperty("item")]
        ITEM
    };
}