using System;
using Amsel.Clients.Sample.SLOBS.Interfaces.Request;
using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Models.Request
{
    public class SlobsRequest : ISlobsRequest
    {
        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonProperty("jsonrpc")]
        public string JsonRpc => "2.0";

        [JsonProperty("method")]
        public string Method { get; internal set; }

        [JsonProperty("params")]
        public SlobsParameters Parameters { get; internal set; }

        public SlobsRequest(string method, string resource, params object[] args)
        {
            Id = Guid.NewGuid().ToString();
            Method = method;
            Parameters = new SlobsParameters(resource, args);
        }

        public SlobsRequest(string method, SlobsParameters parameters)
        {
            Id = Guid.NewGuid().ToString();
            Method = method;
            Parameters = parameters;
        }

        public string ToJson()
        {
            var a =JsonConvert.SerializeObject(this);
            
            return JsonConvert.SerializeObject(this);
        }
    }
}