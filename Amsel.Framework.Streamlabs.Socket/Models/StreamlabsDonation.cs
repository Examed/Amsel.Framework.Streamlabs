using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Amsel.Framework.Streamlabs.Socket.Models
{
    public class StreamlabsDonation : StreamlabsMessage
    {
        [JsonProperty("amount")]
        public string Amount { get; protected set; }

        [JsonProperty("formattedAmount")]
        public string FormattedAmount { get; protected set; }

        [JsonProperty("iconClassName")]
        public string IconClassName { get; protected set; }

        [JsonProperty("currency")]
        public string Currency { get; protected set; }

        [JsonProperty("style")]
        public string Style { get; protected set; }

        [JsonProperty("facemask")]
        public string Facemask { get; protected set; }

        [JsonProperty("mask_name")]
        public string FacemaskName { get; protected set; }

        [JsonProperty("mask_rarity")]
        public string FacemaskRarity { get; protected set; }

        [JsonProperty("pro")]
        public string Pro { get; protected set; }

        [JsonProperty("pro_extras")]
        public string ProExtras { get; protected set; }

        [JsonProperty("wishListItem")]
        public string WishListItem { get; protected set; }
        
        [JsonProperty("media")]
        public string Media { get; protected set; }

        [JsonProperty("alert_status")]
        public int AlertStatus { get; protected set; }

        [JsonProperty("source")]
        public string Source { get; protected set; }

        [JsonProperty("donation_id")]
        public string DonationId { get; protected set; }

        [JsonProperty("donationCurrency")]
        public string DonationCurrency { get; protected set; }

        [JsonProperty("attachments")]
        public JArray Attachments { get; protected set; }

        [JsonProperty("senderId")]
        public string SenderId { get; protected set; }

    }
}