using Newtonsoft.Json.Linq;

namespace Amsel.Framework.Streamlabs.OBS.Service
{
    public static class StreamlabsExtentions
    {
        public static bool IsPromise(this JToken token)
        {
            if (token.Value<string>("_type") != "SUBSCRIPTION" || token.Value<string>("emitter") != "PROMISE")
                return false;
            return true;
        }
    }
}
