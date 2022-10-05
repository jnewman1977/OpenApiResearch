namespace Api.Configuration;

public interface IJsonGeneratorConfiguration
{
    string AccessToken { get; }
    string UserGroupsUrl { get; }
}