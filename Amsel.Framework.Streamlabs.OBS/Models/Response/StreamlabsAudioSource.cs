using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Response
{
    public class StreamlabsAudioSource 
    {
        [JsonProperty("audioMixers")]
        public double AudioMixers { get; protected set; }

        [JsonProperty("fader")]
        public StreamlabsFader Fader { get; protected set; }

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