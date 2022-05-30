using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages
{
    public partial class Index : ComponentBase
    {
        private const string GetPosts = "api/posts";

        [Inject]
        public HttpClient Http { get; set; }

        public string Posts { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            var payload = await this.Http.GetStringAsync(GetPosts).ConfigureAwait(false);

            this.Posts = payload;
        }
    }
}