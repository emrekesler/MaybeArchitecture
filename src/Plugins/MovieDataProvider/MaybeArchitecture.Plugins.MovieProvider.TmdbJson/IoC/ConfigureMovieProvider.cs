using MaybeArchitecture.Plugins.MovieProvider.TmdbJson.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MaybeArchitecture.Plugins.MovieProvider.TmdbJson.IoC
{
    public static class ConfigureMovieProvider
    {
        public static IServiceCollection RegisterMovieProvider(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Settings>(options => configuration.GetSection("TmdbJson").Bind(options));
            services.AddTransient<IMovieProvider, MovieProvider>();

            return services;
        }
    }
}
