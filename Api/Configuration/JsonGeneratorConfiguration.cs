namespace Api.Configuration;

public class JsonGeneratorConfiguration : IJsonGeneratorConfiguration
{
    private readonly IConfiguration configuration;

    public JsonGeneratorConfiguration(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public string AccessToken => configuration.GetValue<string>("JsonGenerator:AccessToken");

    public string BaseUrl => configuration.GetValue<string>("JsonGenerator:BaseUrl");
    
    public string UserGroupsUrl => configuration.GetValue<string>("JsonGenerator:UserGroupsUrl");
}