using Microsoft.AspNetCore.Mvc;
using TMDBScraper.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TMDBScraper.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieSearchController : ControllerBase
    {
        private readonly ILogger<MovieSearchController> _logger;

        static HttpClient client = new HttpClient();
        string tmdbApi = "https://api.themoviedb.org";
        string apiKey = "5bec4e76199afb1705ac475687649aab";

        public MovieSearchController(ILogger<MovieSearchController> logger)
        {
            _logger = logger;
        }

        // GET: api/<MovieSearch>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { };
        }

        // GET api/<MovieSearch>/keyword
        [HttpGet("keyword/{keyword}")]
        public Movie[] GetByKeyword(int keyword)
        {
            Movie[] movies = new Movie[] { 
                new Movie() { id = 1, title = "test" } 
            } ;
            string url = $"{tmdbApi}/3/keyword/{keyword}/movies?api_key={apiKey}";
            //var test = client.GetAsync(url).Result;
            movies = client?.GetFromJsonAsync<Movie[]>(url).Result;
            return movies;
        }

        // GET api/<MovieSearch>/keyword
        [HttpGet("discover/{keyword}")]
        public async Task<DiscoverResult> DiscoverByKeyword(int keyword)
        {
            try
            {
                DiscoverResult result = null;
                Movie[] movies = new Movie[] {
                new Movie() { id = 1, title = "test", popularity = 754.241 }
            };
                string url = $"{tmdbApi}/3/discover/movie?api_key={apiKey}&with_keywords={keyword}&sort_by=popularity.desc";
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadFromJsonAsync<DiscoverResult>();
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        // POST api/<MovieSearch>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MovieSearch>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieSearch>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
