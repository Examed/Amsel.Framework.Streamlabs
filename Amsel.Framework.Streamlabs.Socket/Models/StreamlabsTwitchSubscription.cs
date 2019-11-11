using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Amsel.Framework.Streamlabs.Socket.Models
{
    public class StreamlabsTwitchSubscription : StreamlabsMessage
    {
        [JsonProperty("month")]
        public int Month { get; protected set; }

        [JsonProperty("streak_month")]
        public int StreakMonth { get; protected set; }

        [JsonProperty("subPlan")]
        public string SubPlan { get; protected set; }

        [JsonProperty("subscriber_twitch_id")]
        public string TwitchId { get; protected set; }

        [JsonProperty("gifter")]
        public string Gifter { get; protected set; }

        [JsonProperty("gifter_display_name")]
        public string GifterDisplayName { get; protected set; }

        [JsonProperty("count")]
        public int Count { get; protected set; }

        [JsonProperty("planName")]
        public string PlanName { get; protected set; }

        [JsonProperty("massSubGiftChildAlerts")]
        public JArray ChildAlterts { get; protected set; }

        [JsonProperty("isSubgiftExpanded")]
        public bool IsExpandedGift { get; protected set; }

        [JsonProperty("benefit_end_month")]
        public string BenefitEndMonth { get; protected set; }
    }
}