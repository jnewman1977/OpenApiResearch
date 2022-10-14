using System.Reflection;
using Api.Configuration;
using Api.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.OpenApi.Models;

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
        client.BaseAddress = new Uri(config.UserGroupsUrl);
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {config.AccessToken}");
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Open API Research",
        Description = "An ASP.NET Core Web API for research"
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddCors(x => x.AddDefaultPolicy(new CorsPolicy { Origins = { "*" } }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();