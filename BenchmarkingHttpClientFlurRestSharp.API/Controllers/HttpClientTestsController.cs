using BenchmarkingHttpClientFlurRestSharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BenchmarkingHttpClientFlurRestSharp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpClientTestsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUsingHttpClient([FromServices] IHttpClientService httpClientService)
        {
            return Ok(await httpClientService.GetSpaceflightNewsUsingHttpClientAsync());
        }

        [HttpGet("RestSharp")]
        public async Task<IActionResult> GetUsingRestClient([FromServices] IRestSharpService restSharpService)
        {
            return Ok(await restSharpService.GetSpaceflightNewsAsync());
        }

        [HttpGet("Flurl")]
        public async Task<IActionResult> GetUsingFlurl([FromServices] IFlurlService flurlService)
        {
            return Ok(await flurlService.GetSpaceflightNewsAsync());
        }
    }
}
