using Microsoft.Extensions.Logging;

namespace Api.Client;

public class ApiClientFactory : IApiClientFactory
{
    private readonly ILogger<ApiClientFactory> logger;
    private readonly IHttpClientFactory httpClientFactory;

    public ApiClientFactory(
        ILogger<ApiClientFactory> logger,
        IHttpClientFactory httpClientFactory)
    {
        this.logger = logger;
        this.httpClientFactory = httpClientFactory;
    }

    public ApiClient CreateClient(string baseUrl)
    {
        return new ApiClient(baseUrl, httpClientFactory.CreateClient());
    }
}