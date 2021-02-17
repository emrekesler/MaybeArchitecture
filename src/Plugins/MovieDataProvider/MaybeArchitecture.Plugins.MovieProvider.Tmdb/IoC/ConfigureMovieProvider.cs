using Microsoft.Extensions.DependencyInjection;

namespace MaybeArchitecture.Plugins.MovieProvider.Tmdb.IoC
{
    public static class ConfigureMovieProvider
    {
        public static IServiceCollection RegisterMovieProvider(this IServiceCollection services)
        {
            services.AddTransient<IMovieProvider, MovieProvider>();
            services.AddHttpClient();
            return services;
        }
    }
}
