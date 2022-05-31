using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using FacadeApp.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

namespace FacadeApp
{
    public static class GetPostsHttpTrigger
    {
        private const string GetPosts = "https://public-api.wordpress.com/rest/v1.1/sites/{0}/posts";

        private static HttpClient http = new HttpClient();

        [FunctionName("GetPostsHttpTrigger")]
        [OpenApiOperation(operationId: "posts.get", tags: new[] { "posts" })]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(PostCollection), Description = "The OK response")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "posts")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var siteName = Environment.GetEnvironmentVariable("SITE__NAME");
            var requestUri = string.Format(GetPosts, siteName);

            var payload = await http.GetStringAsync(requestUri).ConfigureAwait(false);
            var collection = JsonConvert.DeserializeObject<PostCollection>(payload);

            return new OkObjectResult(collection);
        }
    }
}