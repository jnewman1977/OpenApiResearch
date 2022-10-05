using Api.Models;

namespace Api.Services;

public interface IUserGroupService
{
    Task<IEnumerable<UserGroup>> GetUserGroupsAsync();
}