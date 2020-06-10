using Amsel.Framework.Streamlabs.OBS.Utilities;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response {
    public class StreamlabsOBSEvent
    {
        [JsonProperty("data")]
        public JToken Data { get; protected set; }
        [JsonProperty("emitter")]
        public string Emitter { get; protected set; }
        [JsonProperty("isRejected")]
        public bool IsRejected { get; protected set; }
        [JsonProperty("resourceId")]
        public string ResourceId { get; protected set; }
        [JsonProperty("_type")]
        public string Type { get; protected set; }

        #region public methods
        [NotNull]
        public IEnumerable<TResult> GetData<TResult>() => Data.GetData<TResult>();

        public TResult GetDataFirstOrDefault<TResult>() => GetData<TResult>().FirstOrDefault();
        #endregion
    }
}