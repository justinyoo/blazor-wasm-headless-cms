﻿using Newtonsoft.Json;

namespace BlazorApp.Models
{
    public class Metadata
    {
        public virtual Dictionary<string, string> Links { get; set; }

        [JsonProperty("next_page")]
        public virtual string NextPage { get; set; }

        [JsonProperty("wpcom")]
        public virtual bool IsWordpressCom { get; set; }
    }


}