using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserGroupController : ControllerBase
{
    private readonly IHostEnvironment hostEnvironment;
    private readonly ILogger<UserGroupController> logger;
    private readonly IUserGroupService userGroupService;

    public UserGroupController(
        IHostEnvironment hostEnvironment,
        ILogger<UserGroupController> logger,
        IUserGroupService userGroupService)
    {
        this.hostEnvironment = hostEnvironment;
        this.logger = logger;
        this.userGroupService = userGroupService;
    }

    /// <summary>
    /// Gets a list of user groups.
    /// </summary>
    /// <remarks>
    /// [
    ///     {
    ///         "id": "633df04e03cb9fd96d1f696b",
    ///         "name": "Group Qualitern",
    ///         "users": [
    ///             {
    ///                 "id": "633df04ed221191ceadbffdf",
    ///                 "name": "Rivas Keith",
    ///                 "email": "rkeith@gmail.com",
    ///                 "firstName": "Rivas",
    ///                 "lastName": "Keith"
    ///             }
    ///         ]
    ///     }
    /// ]
    /// </remarks>
    [HttpGet]
    public async Task<IEnumerable<UserGroup>?> Get()
    {
        logger.LogDebug("Getting User Groups");

        try
        {
            var result = await userGroupService
                .GetUserGroupsAsync()
                .ConfigureAwait(!hostEnvironment.IsEnvironment("Testing"));

            var data = result.ToArray();

            logger.LogDebug("Users returned = {UserCount}", data.Length);

            return data;
        }
        catch (Exception e)
        {
            logger.LogError(e, "There was a problem retrieving user groups.");
            throw;
        }
    }

    /// <summary>
    /// Gets a list of users for the given group.
    /// </summary>
    /// <param name="id">The group id.</param>
    /// <remarks>
    ///     [
    ///             {
    ///                 "id": "633df04ed221191ceadbffdf",
    ///                 "name": "Rivas Keith",
    ///                 "email": "rkeith@gmail.com",
    ///                 "firstName": "Rivas",
    ///                 "lastName": "Keith"
    ///             }
    ///     ] 
    /// </remarks>
    [HttpGet("{id}/users")]
    public async Task<IEnumerable<User>?> GetUsers(string id)
    {
        logger.LogDebug("Getting User Groups");

        try
        {
            var result = await userGroupService
                .GetUserGroupsAsync()
                .ConfigureAwait(!hostEnvironment.IsEnvironment("Testing"));

            var data = result.FirstOrDefault(grp =>
                grp.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase));

            logger.LogDebug("Users returned = {UserCount}", data?.Users?.Count());

            return data?.Users;
        }
        catch (Exception e)
        {
            logger.LogError(e, "There was a problem retrieving user groups.");
            throw;
        }
        
    }
}