﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Amsel.Framework.Streamlabs.OBS.Models.Request
{
    public class StreamlabsOBSParameters : IEquatable<StreamlabsOBSParameters>
    {
        #region Constructors
        public StreamlabsOBSParameters(string resource, params object[] args)
        {
            Resource = resource;
            Args = args?.ToList();
        }
        #endregion

        #region Properties
        [JsonProperty("args")]
        public List<object> Args { get; set; }

        [JsonProperty("resource", NullValueHandling = NullValueHandling.Ignore)]
        public string Resource { get; set; }
        #endregion

        #region Methods
        #region IEquatable methods
        public bool Equals(StreamlabsOBSParameters other)
        {
            bool equal = (Resource == other.Resource) && (Args.Count == other.Args.Count);

            for(int i = 0; i < Args.Count; i++) {
                equal = equal && Args[i].Equals(other.Args[i]);
            }

            return equal;
        }
        #endregion
        #endregion
    }
}