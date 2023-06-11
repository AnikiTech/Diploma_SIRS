using Microsoft.Extensions.DependencyInjection;
using SIRS.RMT.ApplicationServices.Services.ColorsExercise;
using SIRS.RMT.ApplicationServices.Services.WordsExercise;

namespace SIRS.RMT.Web
{
    internal static partial class StartupExtensions
    {
        internal static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            _ = services.AddScoped<ColorsService>()
                    .AddScoped<ColorsExerciseService>()
                    .AddScoped<ColorsStatisticService>()
                    .AddScoped<WordExerciseService>()
                    .AddScoped<WordsStatisticService>()
                    ;

            return services;
        }
    }
}