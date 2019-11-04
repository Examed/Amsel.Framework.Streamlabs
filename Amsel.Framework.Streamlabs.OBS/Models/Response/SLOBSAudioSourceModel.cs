using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Models.Response
{
    public class SLOBSAudioSourceModel : SLOBSResult
    {
        [JsonProperty("audioMixers")]
        public double AudioMixers { get; set; }

        [JsonProperty("fader")]
        public SLOBSFader Fader { get; set; }

        [JsonProperty("forceMono")]
        public bool ForceMono { get; set; }

        [JsonProperty("mixerHidden")]
        public bool MixerHidden { get; set; }

        // TODO SHOULD BE ENUM
        [JsonProperty("monitoringType")]
        public string MonitoringType { get; set; } 

        [JsonProperty("muted")]
        public bool Muted { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }   
        
        [JsonProperty("sourceId")]
        public string SourceId { get; set; }

        [JsonProperty("syncOffset")]
        public bool SyncOffset { get; set; }
    }
}