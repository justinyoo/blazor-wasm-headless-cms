using BlazorApp.Proxies;

using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components
{
    public partial class Posts : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }

        public IEnumerable<PostItem> PostItems { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            var collection = await this.Proxy.Posts_getAsync().ConfigureAwait(false);

            this.PostItems = collection.Posts;
        }
    }
}