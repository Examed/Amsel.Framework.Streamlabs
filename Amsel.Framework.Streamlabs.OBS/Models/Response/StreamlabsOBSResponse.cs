using Amsel.Framework.Streamlabs.OBS.Utilities;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    public class StreamlabsOBSResponse
    {
        public TResult GetResultFirstOrDefault<TResult>() { return GetResults<TResult>().FirstOrDefault(); }

        [NotNull]
        public IEnumerable<TResult> GetResults<TResult>() { return Results.GetData<TResult>(); }

        public bool IsEnumberabeResult() {
            if(Results?.Type == JTokenType.Array) {
                return true;
            }

            return false;
        }

        [JsonProperty("error")]
        public StreamlabsOBSError Error { get; protected set; }

        [JsonProperty("id")]
        public string Id { get; protected set; }

        public string JsonResponse { get; set; }

        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; protected set; }

        [JsonProperty("result")]
        public JToken Results { get; set; }
    }
}