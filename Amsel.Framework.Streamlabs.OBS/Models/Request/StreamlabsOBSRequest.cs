using Newtonsoft.Json;
using System;

namespace Amsel.Framework.Streamlabs.OBS.Models.Request
{
    public class StreamlabsOBSRequest
    {
        public StreamlabsOBSRequest(string method, StreamlabsOBSParameters parameters) {
            Id = Guid.NewGuid().ToString();
            Method = method;
            Parameters = parameters;
        }

        public StreamlabsOBSRequest(string method, string resource, params object[] args) {
            Id = Guid.NewGuid().ToString();
            Method = method;
            Parameters = new StreamlabsOBSParameters(resource, args);
        }

        public string ToJson() { return JsonConvert.SerializeObject(this)?.Replace("\n", string.Empty); }

        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonProperty("jsonrpc")] public string JsonRpc => "2.0";

        [JsonProperty("method")]
        public string Method { get; internal set; }

        [JsonProperty("params")]
        public StreamlabsOBSParameters Parameters { get; internal set; }
    }
}