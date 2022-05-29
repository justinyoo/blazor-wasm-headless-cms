using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages
{
    public partial class Index : ComponentBase
    {
        private const string GetPosts = "https://public-api.wordpress.com/rest/v1.1/sites/{0}/posts";

        [Inject]
        public IConfiguration Configuration { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        public string Posts { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            var siteName = this.Configuration.GetValue<string>("SITE__NAME");
            var requestUri = string.Format(GetPosts, siteName);

            var payload = await this.Http.GetStringAsync(requestUri).ConfigureAwait(false);

            this.Posts = payload;
        }
    }
}