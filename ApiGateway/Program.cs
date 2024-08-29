using CacheManager.Core;
using MMLib.Ocelot.Provider.AppConfiguration;
using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddOcelotWithSwaggerSupport(opt =>
{
    opt.Folder = "OcelotConfiguration";
});

builder.Services
    .AddOcelot(builder.Configuration)
    .AddAppConfiguration()
    .AddCacheManager(x =>
    {
        x.WithRedisConfiguration("redis",
            config =>
            {
                config.WithAllowAdmin()
                .WithDatabase(0)
                .WithEndpoint("localhost", 6379);
            })
        .WithJsonSerializer()
        .WithRedisCacheHandle("redis");
    });
builder.Services.AddSwaggerForOcelot(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";

});

await app.UseOcelot();

await app.RunAsync();