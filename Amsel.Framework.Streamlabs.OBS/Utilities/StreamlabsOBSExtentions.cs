using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Amsel.Framework.Streamlabs.OBS.Utilities
{
    public static class StreamlabsOBSExtensions
    {
        public static bool IsPromise(this JToken token) {
            if (token == null || !token.HasValues || token.Value<string>("_type") != "SUBSCRIPTION" || token.Value<string>("emitter") != "PROMISE")
                return false;
            return true;
        }

        [NotNull]
        public static IEnumerable<TResult> GetData<TResult>(this JToken data) {
            if (data == null)
                return new List<TResult>();

            return data.Type switch {
                JTokenType.Array => (data.ToObject<List<TResult>>() ?? new List<TResult>()),
                _                => new List<TResult> {data.ToObject<TResult>()}
            };
        }
    }
}