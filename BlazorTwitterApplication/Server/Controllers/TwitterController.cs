using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using BlazorTwitterApplication.Shared;

namespace BlazorTwitterApplication.Server.Controllers
{
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private readonly ILogger<TwitterController> _logger;

        public TwitterController(ILogger<TwitterController> logger)
        {
            _logger = logger;
        }

        [Route("api/Tweetss")]
        [HttpGet]
        public async Task<IActionResult> GetTweets()
        {
            HttpClient client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.twitter.com/2/tweets/search/recent?max_results=20&query=%23azure+%23dotnetcore");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "AAAAAAAAAAAAAAAAAAAAAJOplAEAAAAAsxspavA1J73TX6pF9fH%2Buae15lM%3DNZVMEhuAEGKLgliRvBrmazwb9yKQCQ2VYHr5ArVvPz0IOoH3FD");

            var response = await client.SendAsync(request);
            var apiString = await response.Content.ReadAsStringAsync();

            //Our response hase a meta data, so we need to rid of it
            Tweets tweet = JsonConvert.DeserializeObject<Tweets>(apiString);
            //Move to back to Json format
            string json = JsonConvert.SerializeObject(tweet);

            return Ok(json);
        }
    }
}
