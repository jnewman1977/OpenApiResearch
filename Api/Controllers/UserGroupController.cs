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
        ILogger<UserGroupController> logger,
        IHostEnvironment hostEnvironment,
        IUserGroupService userGroupService)
    {
        this.logger = logger;
        this.hostEnvironment = hostEnvironment;
        this.userGroupService = userGroupService;
    }

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
}