using System.Text.Json.Serialization;

namespace BlazorApp.Models
{
    public class Author
    {
        [JsonPropertyName("ID")]
        public virtual int AuthorId { get; set; }

        [JsonPropertyName("first_name")]
        public virtual string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public virtual string Surname { get; set; }

        public virtual string Name { get; set; }
    }
}