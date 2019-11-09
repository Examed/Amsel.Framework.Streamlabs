using System;
using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Request
{
    public class StreamlabsRequest 
    {
        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonProperty("jsonrpc")]
        public string JsonRpc => "2.0";

        [JsonProperty("method")]
        public string Method { get; internal set; }

        [JsonProperty("params")]
        public StreamlabsParameters Parameters { get; internal set; }


        public StreamlabsRequest(string method, string resource, params object[] args)
        {
            Id = Guid.NewGuid().ToString();
            Method = method;
            Parameters = new StreamlabsParameters(resource, args);
        }

        public StreamlabsRequest(string method, StreamlabsParameters parameters)
        {
            Id = Guid.NewGuid().ToString();
            Method = method;
            Parameters = parameters;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this)?.Replace("\n", "");
        }
    }
}