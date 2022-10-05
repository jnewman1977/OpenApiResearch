using Api.Models;

namespace Api.Services;

public sealed class UserGroupService : IUserGroupService
{
    private readonly IHostEnvironment hostEnvironment;
    private readonly HttpClient httpClient;
    private readonly ILogger<UserGroupService> logger;

    public UserGroupService(
        IHostEnvironment hostEnvironment,
        HttpClient httpClient,
        ILogger<UserGroupService> logger)
    {
        this.hostEnvironment = hostEnvironment;
        this.httpClient = httpClient;
        this.logger = logger;
    }

    public async Task<IEnumerable<UserGroup>> GetUserGroupsAsync()
    {
        logger.LogDebug("{MethodName} | Http Base Address: {BaseUrl}",
            nameof(GetUserGroupsAsync), httpClient.BaseAddress);
        logger.LogDebug("{MethodName} | Http Auth Header: {AuthHeader}",
            nameof(GetUserGroupsAsync), httpClient.DefaultRequestHeaders.Authorization);

        var response = await httpClient
            .GetFromJsonAsync<List<UserGroup>>(string.Empty)
            .ConfigureAwait(!hostEnvironment.IsEnvironment("Testing"));

        return response != null
            ? response.ToArray()
            : Array.Empty<UserGroup>();
    }
}