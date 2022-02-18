using BenchmarkDotNet.Running;
using BenchmarkingHttpClientFlurRestSharp.Services;

//var builder = new ServiceCollection();
//builder.AddHttpClient<IHttpClientService, HttpClientService>();
//var serviceProvider = builder.BuildServiceProvider();

//var service = serviceProvider.GetService<IHttpClientService>();

BenchmarkRunner.Run<HttpClientService>();