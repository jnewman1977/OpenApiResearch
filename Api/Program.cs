using Api.Configuration;
using Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddLogging()
    .AddSingleton<IJsonGeneratorConfiguration, JsonGeneratorConfiguration>()
    .AddSingleton<IUserGroupService, UserGroupService>();

builder.Services
    .AddHttpClient<IUserGroupService, UserGroupService>((services, client) =>
    {
        var config = services.GetRequiredService<IJsonGeneratorConfiguration>();
        client.BaseAddress = new Uri(config.BaseUrl);
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {config.AccessToken}");
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();