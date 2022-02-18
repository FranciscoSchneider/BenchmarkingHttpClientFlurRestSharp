using BenchmarkDotNet.Attributes;
using Flurl.Http;

namespace BenchmarkingHttpClientFlurRestSharp.Services
{
    public interface IFlurlService
    {
        Task<IEnumerable<SpaceflightNewDTO>> GetSpaceflightNewsAsync(CancellationToken cancellationToken = default);
    }

    [MemoryDiagnoser]
    public sealed class FlurlService : IFlurlService
    {
        [Benchmark]
        public async Task<IEnumerable<SpaceflightNewDTO>> GetSpaceflightNewsAsync(CancellationToken cancellationToken = default)
        {
            return await "https://api.spaceflightnewsapi.net/v3/articles"
                            .GetJsonAsync<IEnumerable<SpaceflightNewDTO>>(cancellationToken, HttpCompletionOption.ResponseHeadersRead)
                            .ConfigureAwait(false);
        }
    }
}
