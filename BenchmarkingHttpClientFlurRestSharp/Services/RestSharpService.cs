using BenchmarkDotNet.Attributes;
using RestSharp;

namespace BenchmarkingHttpClientFlurRestSharp.Services
{
    public interface IRestSharpService
    {
        Task<IEnumerable<SpaceflightNewDTO>> GetSpaceflightNewsAsync(CancellationToken cancellationToken = default);
    }

    [MemoryDiagnoser]
    public sealed class RestSharpService : IRestSharpService
    {
        [Benchmark]
        public async Task<IEnumerable<SpaceflightNewDTO>> GetSpaceflightNewsAsync(CancellationToken cancellationToken = default)
        {
            var client = new RestClient("https://api.spaceflightnewsapi.net/v3/articles");
            var request = new RestRequest();
            return await client.GetAsync<IEnumerable<SpaceflightNewDTO>>(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
