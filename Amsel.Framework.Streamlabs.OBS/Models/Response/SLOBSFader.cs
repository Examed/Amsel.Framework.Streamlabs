using System;
using System.Threading.Tasks;
using Amsel.Framework.Streamlabs.OBS.Service;
using Amsel.Framework.Streamlabs.Socket.Models.EventTypes;
using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Models.Response
{
    public class StreamlabsPromise<TResult> : StreamlabsPromise
    {
        private TResult result;
        public StreamlabsResponse Responses { get; set; }
        public async Task<TResult> GetPromiseAsync()
        {
            if (result != null)
                return result;


            return result;
        }

        private void Sub_OnPipeMessage(object sender, StreamlabsResponse e)
        {
            Responses = e;
            result = e.Results.ToObject<TResult>();
        }
    }

    public class StreamlabsPromise
    {
        [JsonProperty("emitter")]
        public string Emitter { get; protected set; }

        [JsonProperty("resourceId")]
        public string ResourceId { get; protected set; }

        [JsonProperty("_type")]
        public string Type { get; protected set; }
    }

    public class Fader
    {
        [JsonProperty("db")]
        public double DB { get; protected set; }

        [JsonProperty("deflection")]
        public double Deflection { get; protected set; }

        [JsonProperty("mul")]
        public double Mul { get; protected set; }
    }

    public class SceneCollection
    {
        [JsonProperty("id")]
        public string Id { get; protected set; }

        [JsonProperty("name")]
        public string Name { get; protected set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; protected set; }

        [JsonProperty("modified")]

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Modified { get; protected set; }

        [JsonProperty("needsRename")]
        public bool NeedsRename { get; protected set; }

        [JsonProperty("serverId")]
        public bool ServerId { get; protected set; }

        [JsonProperty("resourceId")] private string resourceId;

        public string ResourceId
        {
            get => string.IsNullOrEmpty(resourceId) ? $"SceneCollection[\"{Id}\"]" : resourceId;
            set => resourceId = value;
        }

    }
}