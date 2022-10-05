namespace Api.Models;

public record UserGroup(string Id, string Name, IEnumerable<User> Users);