using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
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
    /// Sample Response:
    /// 
    ///     GET /UserGroup
    ///     {
    ///         "data":
    ///             [
    ///                 {
    ///                     "id": "633df04e03cb9fd96d1f696b",
    ///                     "name": "Group Qualitern",
    ///                     "users": [
    ///                         {
    ///                             "id": "633df04ed221191ceadbffdf",
    ///                             "name": "Rivas Keith",
    ///                             "email": "rkeith@gmail.com",
    ///                             "firstName": "Rivas",
    ///                             "lastName": "Keith"
    ///                         }
    ///                     ]
    ///                 }
    ///             ]
    ///     }
    /// </remarks>
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]    
    public async Task<IEnumerable<UserGroup>> Get()
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
    /// Sample Response:
    /// 
    ///     GET /UserGroup/{id}/Users
    ///     {
    ///         "data":
    ///             [
    ///                     {
    ///                         "id": "633df04ed221191ceadbffdf",
    ///                         "name": "Rivas Keith",
    ///                         "email": "rkeith@gmail.com",
    ///                         "firstName": "Rivas",
    ///                         "lastName": "Keith"
    ///                     }
    ///             ]
    ///     } 
    /// </remarks>
    [HttpGet]
    [Route("{id}/users")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]    
    public async Task<IEnumerable<User>> GetUsers(string id)
    {
        logger.LogDebug("Getting User Groups");

        try
        {
            var result = await userGroupService
                .GetUserGroupsAsync()
                .ConfigureAwait(!hostEnvironment.IsEnvironment("Testing"));

            var data = result.FirstOrDefault(grp =>
                grp.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase));

            logger.LogDebug("Users returned = {UserCount}", data?.Users.Count());

            return data?.Users;
        }
        catch (Exception e)
        {
            logger.LogError(e, "There was a problem retrieving user groups.");
            throw;
        }
    }

    /// <summary>
    /// Creates a new user in the given user group.
    /// </summary>
    /// <param name="id">The <see cref="string"/> id of the user group.</param> 
    /// <param name="user">The <see cref="User"/> to create.</param>
    /// <remarks>
    /// Sample Request:
    ///
    ///     POST /UserGroup/{id}/Create
    ///     {
    ///         "name": "Fred Flinstone",
    ///         "email": "FredFlinstone@gmail.com",
    ///         "firstName": "Fred",
    ///         "lastName": "Flinstone"
    ///     }
    /// </remarks>
    /// <returns>The <see cref="User"/> record which was created.</returns>
    /// <response code="200">User created successfully with no errors.</response>
    /// <response code="400">Bad request.</response>
    /// <response code="401">Unauthorized.</response>
    [HttpPost]
    [Route("{id}/create")]
    public async Task<IActionResult> CreateUser(string id, [FromBody] User user)
    {
        return Ok(user);
    }
}
