namespace Api.Configuration;

public interface IJsonGeneratorConfiguration
{
    string AccessToken { get; }
    string BaseUrl { get; }
    string UserGroupsUrl { get; }
}