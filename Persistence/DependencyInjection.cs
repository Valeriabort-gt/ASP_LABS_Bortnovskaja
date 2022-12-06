using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = @"Server=LBOR\SQLEXPRESS;Database=Lab5;Trusted_Connection=True;";
            //var connectionString = @"Server=MUKHA;Database=lab5_lera;Trusted_Connection=True";

            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
            services.AddScoped<IDbContext>(provider =>
                provider.GetService<AppDbContext>());

            return services;
        }
    }
}
