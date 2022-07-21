using AutoMapper;
using Business.Infrastructure;
using Business.Services;
using Business.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.Infrastructure
{
    public static class ServiceInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //
            services.AddHttpContextAccessor();

            // Auto Mapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Register Repositories
            services.RegisterRepositories();
           
            //Register Services
            services.AddTransient<IMovieService, MovieService>();
        }
    }
}
