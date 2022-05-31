using BlazorApp.Models;

using Microsoft.AspNetCore.Components;

using Newtonsoft.Json;

namespace BlazorApp.Components
{
    public partial class Posts : ComponentBase
    {
        private const string GetPosts = "api/posts";

        [Inject]
        public HttpClient Http { get; set; }

        public IEnumerable<PostItem> PostItems { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            var payload = await this.Http.GetStringAsync(GetPosts).ConfigureAwait(false);
            var collection = JsonConvert.DeserializeObject<PostCollection>(payload);

            this.PostItems = collection.Posts;
        }
    }
}