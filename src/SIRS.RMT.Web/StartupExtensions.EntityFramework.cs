using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SIRS.Infrastructure.EntityFramework;
using SIRS.RMT.Config;
using SIRS.RMT.Domain.EntityFramework;

namespace SIRS.RMT.Web
{
    internal static partial class StartupExtensions
    {
        internal static IServiceCollection AddSirsAppEntityFramework(this IServiceCollection services, ReadingMemoryThinkingConfiguration configuration)
        {
            return services
                    .AddScoped(p =>
                    {
                        var options = p.GetService<DbContextOptions<ReadingMemoryThinkingDbContext>>();
                        return new ReadingMemoryThinkingDbContextFactory(options, configuration);
                    })
                    .AddDbContext<ReadingMemoryThinkingDbContext>(options => options.UseNpgsql(configuration.ConnectionString.DefaultConnection))
                    .AddScoped<ISirsDbContextOptions>(provider =>
                    {
                        return new SirsDbContextOptions(() =>
                        {
                            //var contextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
                            //var activityLogName = contextAccessor.HttpContext?.User?.GetActivityLogName();
                            //return activityLogName ?? configuration.Application.Name;

                            return "sirs-user";
                        });
                    })
                    ;
        }
    }
}