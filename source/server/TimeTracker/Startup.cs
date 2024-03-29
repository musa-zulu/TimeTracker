using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using Serilog;
using System;
using System.IO;
using TimeTracker.Infrastructure.Extension;
using TimeTracker.Persistence;
using TimeTracker.Service;

namespace TimeTracker;
public class Startup
{
    private readonly IConfigurationRoot configRoot;
    public Startup(IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
        Configuration = configuration;

        IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
        configRoot = builder.Build();
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddController();

        services.AddDbContext(Configuration, configRoot);

        services.AddIdentityService(Configuration);

        services.AddAutoMapper();

        services.AddScopedServices();

        services.AddTransientServices();

        services.AddSwaggerOpenAPI();

        services.AddMailSetting(Configuration);

        services.AddServiceLayer();

        services.AddVersion();


        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>(name: "Application DB Context", failureStatus: HealthStatus.Degraded)
            .AddUrlGroup(new Uri("https://musa-zulu.github.io/mypage/"), name: "My personal website", failureStatus: HealthStatus.Degraded)
            .AddSqlServer(Configuration.GetConnectionString("TimeTrackerConn"));

        //services.AddHealthChecksUI(setupSettings: setup =>
        //{
        //    setup.AddHealthCheckEndpoint("Basic Health Check", $"/healthz");
        //});

        services.AddFeatureManagement();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory log, IServiceProvider service)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors(options =>
             options.WithOrigins("http://localhost:3000")
             .AllowAnyHeader()
             .AllowAnyMethod());

        app.ConfigureCustomExceptionMiddleware();

        log.AddSerilog();

        //app.ConfigureHealthCheck();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();
        app.ConfigureSwagger();
        app.UseHealthChecks("/healthz", new HealthCheckOptions
        {
            Predicate = _ => true,
            // ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
            ResultStatusCodes =
                {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
                    [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
                },
        }).UseHealthChecksUI(setup =>
          {
              setup.ApiPath = "/healthcheck";
              setup.UIPath = "/healthcheck-ui";
              // setup.AddCustomStylesheet("Customization/custom.css");
          });

        RunMigrations(service);

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    private void RunMigrations(IServiceProvider service)
    {
        // This returns the context.
        using var context = service.GetService<ApplicationDbContext>();
        context.Database.Migrate();
    }
}
