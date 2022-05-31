using BlazorApp.Proxies;

using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public ProxyClient Proxy { get; set; }

        public IEnumerable<PostItem> Posts { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await this.Proxy.Posts_getAsync().ConfigureAwait(false);

            this.Posts = response.Posts;
        }
    }
}