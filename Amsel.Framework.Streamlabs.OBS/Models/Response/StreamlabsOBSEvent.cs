using System.Collections.Generic;
using System.Linq;
using Amsel.Framework.Streamlabs.OBS.Utilities;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    public class StreamlabsOBSEvent
    {
        #region Properties
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
        #endregion

        #region Methods
        [NotNull]
        public IEnumerable<TResult> GetData<TResult>() { return Data.GetData<TResult>(); }
        public TResult GetDataFirstOrDefault<TResult>() { return GetData<TResult>().FirstOrDefault(); }
        #endregion
    }
}