using System.Collections.Generic;
using Amsel.Framework.Utilities.Converter;
using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Models.Response
{
    public class SLOBSRpcResponse
    {
        [JsonProperty("error")]
        public SLOBSError Error { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; set; }

        public string JsonResponse { get; set; }

        [JsonProperty("result")]
        [JsonConverter(typeof(SingleOrArrayConverter<SLOBSResult>))]
        public IEnumerable<SLOBSResult> Result { get; set; }
    }
}
