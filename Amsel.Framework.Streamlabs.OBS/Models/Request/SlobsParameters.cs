using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Amsel.Clients.Sample.SLOBS.Models.Request
{
    public class SlobsParameters : IEquatable<SlobsParameters>
    {
        [JsonProperty("args")]
        public List<object> Args { get; set; }

        [JsonProperty("resource", NullValueHandling = NullValueHandling.Ignore)]
        public string Resource { get; set; }

        public SlobsParameters(string resource, params object[] args)
        {
            Resource = resource;
            Args = args?.ToList();
        }

        public bool Equals(SlobsParameters other)
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