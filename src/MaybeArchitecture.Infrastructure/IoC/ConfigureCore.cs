using MaybeArchitecture.Core.Interfaces.Repositories;
using MaybeArchitecture.Core.Interfaces.Services;
using MaybeArchitecture.Core.Services;
using MaybeArchitecture.Infrastructure.Data.EF.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace MaybeArchitecture.Infrastructure.IoC
{
    public static class ConfigureCore
    {
        public static IServiceCollection RegisterCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<ICommentService, CommentService>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();

            return services;
        }
    }
}
