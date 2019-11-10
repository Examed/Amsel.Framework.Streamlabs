using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Amsel.Framework.StreamlabsOBS.OBS.Service
{
    public static class StreamlabsOBSExtentions
    {
        public static bool IsPromise(this JToken token)
        {
            if (token.Value<string>("_type") != "SUBSCRIPTION" || token.Value<string>("emitter") != "PROMISE")
                return false;
            return true;
        }

        public static IEnumerable<TResult> GetData<TResult>(this JToken data)
        {
            switch (data.Type)
            {
                case JTokenType.Boolean:
                    return new List<TResult>();
                case JTokenType.Array:
                    return data.ToObject<List<TResult>>();
            }

            return new List<TResult> {data.ToObject<TResult>()};
        }
    }
}
