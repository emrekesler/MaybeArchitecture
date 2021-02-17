using Microsoft.Extensions.DependencyInjection;

namespace MaybeArchitecture.Mapper.MapsterImp.IoC
{
    public static class ConfigureMapper
    {
        public static IServiceCollection RegisterMapper(this IServiceCollection services)
        {
            services.AddTransient<IMapper, Mapper>();

            return services;
        }
    }
}
