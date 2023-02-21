using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;
using SearchService.Models;

namespace SearchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IElasticClient _elasticClient;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SearchController(IElasticClient elasticClient, IWebHostEnvironment webHostEnvironment)
        {
            _elasticClient = elasticClient;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Article article)
        {
            try
            {
                article.Id = DateTime.Now.Second;
                article.PublishDate = DateTime.UtcNow;
                await _elasticClient.IndexDocumentAsync(article);
                return Ok("OK!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{keyword}")]
        public async Task<IActionResult> Query(string keyword)
        {
            var results = await QueryArticles(keyword);
            return Ok(results);
        }

        private async Task<List<Article>> QueryArticles(string keyword)
        {
            var result = await _elasticClient.SearchAsync<Article>(s => s
                .Query(q => q
                    .Bool(b =>
                        b.Should(
                            bs => bs.Match(m => m.Field(f => f.Title).Query(keyword)),
                            bs => bs.Match(m => m.Field(f => f.Author).Query(keyword))
                        )
                    )
            )
            .Highlight(h => h
                .Fields(f => f
                    .Field(f => f.Title)
                    .Field(f => f.Author)
                    .PreTags("<b>")
                    .PostTags("</b>")))
            );            
            var results = result.Hits.OrderBy(h => h.Score).Select(h => h.Source).ToList();
            return results;
        }
    }
}
