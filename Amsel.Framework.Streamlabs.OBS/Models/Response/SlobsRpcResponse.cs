using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Amsel.Clients.Sample.SLOBS.Models.Response
{
    public class SLOBSRpcResponse
    {
        [JsonProperty("error")]
        public SLOBSError Error { get; protected set; }

        [JsonProperty("id")]
        public string Id { get;protected set; }

        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get;protected set; }

        public string JsonResponse { get; set; }

        [JsonProperty("result")]
        public JToken Results { get;protected set; }

        public IEnumerable<TResult> GetResult<TResult>()
        {
            JToken item = Results;
            switch (item.Type)
            {
                case JTokenType.Boolean:
                    return new List<TResult>();
                case JTokenType.Array:
                    return item.ToObject<List<TResult>>();
            }
            return new List<TResult> { item.ToObject<TResult>() };
        }
    }
}
