using Newtonsoft.Json;
using System;

namespace Amsel.Framework.Streamlabs.OBS.Models.Request {
    public class StreamlabsOBSRequest
    {
        public StreamlabsOBSRequest(string method, StreamlabsOBSParameters parameters)
        {
            Id = Guid.NewGuid().ToString();
            Method = method;
            Parameters = parameters;
        }

        public StreamlabsOBSRequest(string method, string resource, params object[] args)
        {
            Id = Guid.NewGuid().ToString();
            Method = method;
            Parameters = new StreamlabsOBSParameters(resource, args);
        }

        [JsonProperty("id")]
        public string Id { get; internal set; }
        [JsonProperty("jsonrpc")] public string JsonRpc => "2.0";
        [JsonProperty("method")]
        public string Method { get; internal set; }
        [JsonProperty("params")]
        public StreamlabsOBSParameters Parameters { get; internal set; }

        #region public methods
        public string ToJson() => JsonConvert.SerializeObject(this)?.Replace("\n", string.Empty);
        #endregion
    }
}