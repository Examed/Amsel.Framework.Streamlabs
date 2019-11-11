using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Amsel.Framework.Streamlabs.OBS.Utilities
{
    public static class StreamlabsOBSExtentions
    {
        public static bool IsPromise(this JToken token)
        {
            if (token.Value<string>("_type") != "SUBSCRIPTION" || token.Value<string>("emitter") != "PROMISE")
                return false;
            return true;
        }

        [NotNull]
        public static IEnumerable<TResult> GetData<TResult>(this JToken data)
        {
            if (data == null)
                return new List<TResult>();

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
