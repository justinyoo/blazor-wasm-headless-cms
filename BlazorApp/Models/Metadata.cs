using System.Text.Json.Serialization;

namespace BlazorApp.Models
{
    public class Metadata
    {
        public virtual Dictionary<string, string> Links { get; set; }

        [JsonPropertyName("next_page")]
        public virtual string NextPage { get; set; }

        [JsonPropertyName("wpcom")]
        public virtual bool IsWordpressCom { get; set; }
    }
}