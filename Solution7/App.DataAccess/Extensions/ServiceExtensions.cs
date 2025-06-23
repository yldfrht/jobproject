using App.DataAccess.Abstract;
using App.DataAccess.Concrete;
using App.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace App.DataAccess.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDataAccessExt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PostgreContext>(options =>
            {
                options.UseNpgsql(migrationOptions =>
                {
                    migrationOptions.MigrationsAssembly(typeof(DataAccessAssembly).Assembly.FullName);
                });
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IBransRepository, BransRepository>();
            services.AddScoped<IRandevuRepository, RandevuRepository>();
            services.AddScoped<IHekimRepository, HekimRepository>();
            services.AddScoped<IHastaRepository, HastaRepository>();
            services.AddScoped<IHastaneRepository, HastaneRepository>();

            return services;
        }
    }
}
