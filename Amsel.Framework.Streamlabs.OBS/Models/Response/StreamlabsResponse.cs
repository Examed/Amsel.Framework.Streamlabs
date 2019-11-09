using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{

    public class StreamlabsResponse
    {
        [JsonProperty("error")]
        public StreamlabsError Error { get; protected set; }

        [JsonProperty("id")]
        public string Id { get; protected set; }

        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; protected set; }

        public string JsonResponse { get; set; }

        [JsonProperty("result")]
        public JToken Results { get; set; }

        public IEnumerable<TResult> GetResult<TResult>()
        {
            switch (Results.Type)
            {
                case JTokenType.Boolean:
                    return new List<TResult>();
                case JTokenType.Array:
                    return Results.ToObject<List<TResult>>();
            }
            return new List<TResult> { Results.ToObject<TResult>() };
        }

        public bool IsEnumberabeResult()
        {
            if (Results.Type == JTokenType.Array)
                return true;
            return false;
        }


    }
}
