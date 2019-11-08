using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Models.Response
{
    public class SLOBSAudioSourceModel 
    {
        [JsonProperty("audioMixers")]
        public double AudioMixers { get; protected set; }

        [JsonProperty("fader")]
        public SLOBSFader Fader { get; protected set; }

        [JsonProperty("forceMono")]
        public bool ForceMono { get; protected set; }

        [JsonProperty("mixerHidden")]
        public bool MixerHidden { get; protected set; }

        // TODO SHOULD BE ENUM
        [JsonProperty("monitoringType")]
        public string MonitoringType { get; protected set; }

        [JsonProperty("muted")]
        public bool Muted { get; protected set; }

        [JsonProperty("name")]
        public string Name { get; protected set; }

        [JsonProperty("sourceId")]
        public string SourceId { get; protected set; }

        [JsonProperty("syncOffset")]
        public bool SyncOffset { get; protected set; }
    }
}