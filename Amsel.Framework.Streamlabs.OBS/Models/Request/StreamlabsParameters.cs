using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Amsel.Framework.StreamlabsOBS.OBS.Models.Request
{
    public class StreamlabsOBSParameters : IEquatable<StreamlabsOBSParameters>
    {
        [JsonProperty("args")]
        public List<object> Args { get; set; }

        [JsonProperty("resource", NullValueHandling = NullValueHandling.Ignore)]
        public string Resource { get; set; }

        public StreamlabsOBSParameters(string resource, params object[] args)
        {
            Resource = resource;
            Args = args?.ToList();
        }

        public bool Equals(StreamlabsOBSParameters other)
        {
            var equal = this.Resource == other.Resource && this.Args.Count == other.Args.Count;

            for (var i = 0; i < this.Args.Count; i++)
            {
                equal = equal && this.Args[i].Equals(other.Args[i]);
            }

            return equal;
        }
    }
}