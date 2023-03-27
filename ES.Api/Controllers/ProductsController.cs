using ES.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace ES.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IElasticClient _elasticClient;

        public ProductsController(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        [HttpGet("getproducts/{keyword}")]
        public async Task<IActionResult> GetProducts(string keyword)
        {
            var result = await _elasticClient.SearchAsync<Product>(
                s => s.Query(
                    q => q.QueryString(
                        d => d.Query($"*{keyword}*")
                    )
                )
                .Size(1000)
                .Index("inventory")
            );

            return Ok(result.Documents.ToArray());
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            await _elasticClient.IndexDocumentAsync<Product>(product);
            return Ok();
        }
    }
}
