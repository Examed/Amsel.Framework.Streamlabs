using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Enums {
    #region Enums
    public enum ESceneNodeType {
        [JsonProperty("folder")] FOLDER,
        [JsonProperty("item")] ITEM
    }
    #endregion
}