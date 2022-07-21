using Data.Models;
using Data.Repositories;
using Data.Repositories.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Infrastructure
{
    public static class RepositoryInjector
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Movie>, BaseRepository<Movie>>();
        }
    }
}
