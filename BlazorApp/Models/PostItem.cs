using System.Text.Json.Serialization;

namespace BlazorApp.Models
{
    public class PostItem
    {
        [JsonPropertyName("ID")]
        public virtual int PostId { get; set; }

        public virtual Author Author { get; set; }

        [JsonPropertyName("date")]
        public virtual DateTimeOffset DatePublished { get; set; }

        public virtual string Title { get; set; }

        [JsonPropertyName("URL")]
        public virtual string Url { get; set; }

        public virtual string Excerpt { get; set; }

        public virtual string Content { get; set; }
    }
}