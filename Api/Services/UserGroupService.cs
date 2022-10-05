using Api.Configuration;
using Api.Models;

namespace Api.Services;

public class UserGroupService : IUserGroupService
{
    private readonly ILogger<UserGroupService> logger;
    private readonly IHostEnvironment hostEnvironment;
    private readonly IHttpClientFactory httpClientFactory;
    private readonly IJsonGeneratorConfiguration jsonGeneratorConfiguration;

    public UserGroupService(
        ILogger<UserGroupService> logger,
        IHostEnvironment hostEnvironment,
        IHttpClientFactory httpClientFactory,
        IJsonGeneratorConfiguration jsonGeneratorConfiguration)
    {
        this.logger = logger;
        this.hostEnvironment = hostEnvironment;
        this.httpClientFactory = httpClientFactory;
        this.jsonGeneratorConfiguration = jsonGeneratorConfiguration;
    }

    public async Task<IEnumerable<UserGroup>> GetUserGroupsAsync()
    {
        logger.LogDebug("Executing {MethodName}",nameof(GetUserGroupsAsync));

        var client = httpClientFactory.CreateClient(ConfigurationConstants.DefaultHttpClientName);
        
        logger.LogDebug("{MethodName} {BaseUrl}", 
            nameof(GetUserGroupsAsync), client.BaseAddress);
        logger.LogDebug("{MethodName} {AuthHeader}", 
            nameof(GetUserGroupsAsync), client.DefaultRequestHeaders.Authorization);
        logger.LogDebug("{MethodName} {RequestUrl}", 
            nameof(GetUserGroupsAsync), jsonGeneratorConfiguration.UserGroupsUrl);
        
        var response = await client.GetAsync(jsonGeneratorConfiguration.UserGroupsUrl);

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(response.ReasonPhrase);
        }

        var result = await response.Content
            .ReadFromJsonAsync<List<UserGroup>>()
            .ConfigureAwait(!hostEnvironment.IsEnvironment("Testing"));

        if (result == null)
        {
            return Array.Empty<UserGroup>();
        }

        return result;
    }
}