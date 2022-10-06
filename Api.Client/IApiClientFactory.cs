namespace Api.Client;

public interface IApiClientFactory
{
    ApiClient CreateClient(string baseUrl);
}