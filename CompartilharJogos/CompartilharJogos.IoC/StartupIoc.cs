using System;
using CompartilharJogos.Data.Context;
using CompartilharJogos.Data.Repository;
using CompartilharJogos.Domain._Base;
using CompartilharJogos.Domain.SharedGames;
using CompartilharJogos.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompartilharJogos.IoC
{
    public static class StartupIoc
    {
        public static void ConfigureServices(IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration["ConnectionString"]));

            service.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            service.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            service.AddScoped(typeof(IShareGamesRepository), typeof(SharedGamesRepository));

            service.AddScoped(typeof(IUserRepository), typeof(UserRepository));

            service.AddScoped<SaveUser>();
            service.AddScoped<GetTolkenUser>();
            service.AddScoped<Share>();
            service.AddScoped<ListGamesUser>();
        }

        public static void Migrate(IServiceProvider serviceProvider)
        {
            serviceProvider.GetService<ApplicationDbContext>().RunMiGrate().Wait();
        }
    }
}
