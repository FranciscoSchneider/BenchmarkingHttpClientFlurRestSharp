using Newtonsoft.Json;

namespace BenchmarkingHttpClientFlurRestSharp.Services
{
    public interface IHttpClientService
    {
        Task<ICollection<SpaceflightNewDTO>> GetSpaceflightNewsUsingHttpClientAsync();
        //Task<ICollection<SpaceflightNewDTO>> GetSpaceflightNewsUsingRestSharpAsync();
        //Task<ICollection<SpaceflightNewDTO>> GetSpaceflightNewsUsingFlurlAsync();
    }

    //[MemoryDiagnoser]
    //[Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        ////[Benchmark]
        //public async Task<ICollection<SpaceflightNewDTO>> GetSpaceflightNewsUsingFlurlAsync()
        //{
        //    return (await "https://api.spaceflightnewsapi.net/v3/articles"
        //                   .GetJsonAsync<ICollection<SpaceflightNewDTO>>(completionOption: HttpCompletionOption.ResponseHeadersRead)
        //                   .ConfigureAwait(false));
        //}

        //[Benchmark]
        public async Task<ICollection<SpaceflightNewDTO>> GetSpaceflightNewsUsingHttpClientAsync()
        {
            var response = await _httpClient.GetAsync("https://api.spaceflightnewsapi.net/v3/articles", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            var serializer = new JsonSerializer();
            using var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            using var streamReader = new StreamReader(stream);
            using var jsonTextReader = new JsonTextReader(streamReader);
            return serializer.Deserialize<ICollection<SpaceflightNewDTO>>(jsonTextReader);
        }

        ////[Benchmark]
        //public async Task<ICollection<SpaceflightNewDTO>> GetSpaceflightNewsUsingRestSharpAsync()
        //{
        //    var client = new RestClient("https://api.spaceflightnewsapi.net/v3/articles");
        //    var request = new RestRequest();
        //    return await client.GetAsync<ICollection<SpaceflightNewDTO>>(request).ConfigureAwait(false);
        //}
    }
}
