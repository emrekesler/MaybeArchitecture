using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace MaybeArchitecture.Mapper.AutoMapperImp.IoC
{
    public static class ConfigureMapper
    {
        public static IServiceCollection RegisterMapper(this IServiceCollection services, List<Profile> profiles)
        {
            services.AddTransient<IMapper, Mapper>();

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                profiles.ForEach(profile => cfg.AddProfile(profile));
            });

            services.AddSingleton(config.CreateMapper());

            Console.WriteLine("Auto Mapper Registered");

            return services;
        }
    }
}
