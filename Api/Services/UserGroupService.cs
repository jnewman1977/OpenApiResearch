using Api.Configuration;
using Api.Models;

namespace Api.Services;

public sealed class UserGroupService : IUserGroupService
{
    private readonly IHostEnvironment hostEnvironment;
    private readonly HttpClient httpClient;
    private readonly IJsonGeneratorConfiguration jsonGeneratorConfiguration;
    private readonly ILogger<UserGroupService> logger;

    public UserGroupService(
        IHostEnvironment hostEnvironment,
        HttpClient httpClient,
        IJsonGeneratorConfiguration jsonGeneratorConfiguration,
        ILogger<UserGroupService> logger)
    {
        this.logger = logger;
        this.hostEnvironment = hostEnvironment;
        this.httpClient = httpClient;
        this.jsonGeneratorConfiguration = jsonGeneratorConfiguration;
    }

    public async Task<IEnumerable<UserGroup>> GetUserGroupsAsync()
    {
        logger.LogDebug("{MethodName} | Http Base Address: {BaseUrl}",
            nameof(GetUserGroupsAsync),  httpClient.BaseAddress);
        logger.LogDebug("{MethodName} | Http Auth Header: {AuthHeader}",
            nameof(GetUserGroupsAsync),  httpClient.DefaultRequestHeaders.Authorization);
        logger.LogDebug("{MethodName} | Http Request Url: {RequestUrl}",
            nameof(GetUserGroupsAsync),  jsonGeneratorConfiguration.UserGroupsUrl);

        var response = await httpClient
            .GetFromJsonAsync<List<UserGroup>>(jsonGeneratorConfiguration.UserGroupsUrl)
            .ConfigureAwait(!hostEnvironment.IsEnvironment("Testing"));

        return response != null
            ? response.ToArray()
            : Array.Empty<UserGroup>();
    }
}