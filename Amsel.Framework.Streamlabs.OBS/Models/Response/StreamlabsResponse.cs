using System.Collections.Generic;
using System.Linq;
using Amsel.Framework.StreamlabsOBS.OBS.Service;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Amsel.Framework.StreamlabsOBS.OBS.Models.Response
{

    public class StreamlabsOBSResponse
    {
        [JsonProperty("error")]
        public StreamlabsOBSError Error { get; protected set; }

        [JsonProperty("id")]
        public string Id { get; protected set; }

        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; protected set; }

        public string JsonResponse { get; set; }

        [JsonProperty("result")]
        public JToken Results { get; set; }

        [NotNull]
        public IEnumerable<TResult> GetResults<TResult>()
        {
            return Results.GetData<TResult>() ?? new List<TResult>();
        }

        public TResult GetResultFirstOrDefault<TResult>()
        {
            return GetResults<TResult>().FirstOrDefault();
        }

        public bool IsEnumberabeResult()
        {
            if (Results.Type == JTokenType.Array)
                return true;
            return false;
        }


    }
}
