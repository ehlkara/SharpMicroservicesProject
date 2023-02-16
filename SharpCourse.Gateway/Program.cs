using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddJwtBearer("GatewayAuthenticationScheme", options =>
{
    options.Authority = builder.Configuration["IdentityServerURL"];
    options.Audience = "resource_gateway";
    options.RequireHttpsMetadata = false;
});


IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile($"configuration.{builder.Environment.EnvironmentName.ToLower()}.json", true, true)
                            .Build();
builder.Services.AddOcelot(configuration);

var app = builder.Build();

await app.UseOcelot();

app.Run();

