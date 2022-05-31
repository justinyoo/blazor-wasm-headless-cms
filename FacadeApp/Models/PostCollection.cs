using System.Collections.Generic;

using Newtonsoft.Json;

namespace FacadeApp.Models
{
    public class PostCollection
    {
        public virtual int Found { get; set; }

        public virtual List<PostItem> Posts { get; set; } = new List<PostItem>();

        [JsonProperty("meta")]
        public virtual Metadata Metadata { get; set; }
    }
}