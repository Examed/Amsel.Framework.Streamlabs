using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Enums
{
    public enum ESLOBSSceneNodeType
    {
        [JsonProperty("folder")]
        FOLDER, 
        [JsonProperty("item")]
        ITEM
    };
}