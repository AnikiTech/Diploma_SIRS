using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Filters;
using SIRS.RMT.Config;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SIRS.RMT.Web
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            try
            {
                Log.Logger = CreateGlobalLogger();

                // Run web host
                await CreateWebHostBuilder(args).Build()
                                                .InitializeDatabase()
                                                .SeedDatabase()
                                                .RunAsync();
                return 0;
            }
            catch (Exception exception)
            {
                Log.Fatal(exception, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
                //TODO: temporary solution to determine console app. Environment.UserIneractive does not work anymore
                try
                {
                    if (Console.IsInputRedirected && Console.IsOutputRedirected) _ = Console.ReadKey();
                }
                catch (Exception)
                { }
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                          .ConfigureAppConfiguration((context, builder) =>
                          {
                              var environment = context.HostingEnvironment;

                              _ = builder.SetBasePath(environment.ContentRootPath)
                                     .AddJsonFile("appsettings.json", false, true)
                                     .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
                                     .AddJsonFile($"appsettings.{ReadingMemoryThinkingConfiguration.AppCodeSuffix}.json", false, true)
                                     .AddJsonFile($"appsettings.{ReadingMemoryThinkingConfiguration.AppCodeSuffix}.{environment.EnvironmentName}.json", true, true)
                                     .AddEnvironmentVariables()
                                     .AddCommandLine(args);
                          })
                          .UseSerilog(ConfigureSerilog())
                          .UseStartup<Startup>();
        }

        private static ILogger CreateGlobalLogger()
        {
            return new LoggerConfiguration().WriteTo
                                            .Console()
                                            .CreateLogger();
        }

        private static Action<WebHostBuilderContext, LoggerConfiguration> ConfigureSerilog()
        {
            return (hostingContext, loggerConfiguration) =>
            {
                var config = hostingContext.Configuration.Get<ReadingMemoryThinkingConfiguration>();
                var (basePath, template, retainedFileCountLimit) = config.SerilogAdditionalParameters;

                _ = loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration)
                                   .Enrich.FromLogContext()
                                   .Enrich.WithThreadId()
                                   .WriteTo.RollingFile(Path.Combine(basePath, "{Date}.log"),
                                                        outputTemplate: template,
                                                        retainedFileCountLimit: retainedFileCountLimit)
                                   .WriteTo.RollingFile(Path.Combine(basePath, "errors", "{Date}.log"),
                                                        outputTemplate: template,
                                                        retainedFileCountLimit: retainedFileCountLimit,
                                                        restrictedToMinimumLevel: LogEventLevel.Error)
                                   .WriteTo.Logger(x =>
                                   {
                                       _ = x.Filter.ByIncludingOnly(Matching.FromSource($"{nameof(Microsoft)}.{nameof(Microsoft.EntityFrameworkCore)}"))
                                                   .WriteTo.File(Path.Combine(basePath, "database/.log"),
                                                                 LogEventLevel.Verbose,
                                                                 outputTemplate: template,
                                                                 retainedFileCountLimit: retainedFileCountLimit,
                                                                 rollingInterval: RollingInterval.Day);
                                   });
            };
        }
    }
}