using App.Business.Abstract;
using App.Business.Concrete;
using App.Core.Caching;
using App.DataAccess;
using App.DataAccess.Abstract;
using App.DataAccess.Concrete;
using App.DataAccess.Context;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Reflection;

namespace App.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //Core
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICacheService, RedisService>();
            services.AddSingleton<IConnectionMultiplexer>(options =>
                ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection"))
            );

            //DataAccess
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<PostgreContext>(options =>
                options.UseNpgsql(migrationOptions =>
                    migrationOptions.MigrationsAssembly(typeof(DataAccessAssembly).Assembly.FullName)
                )
            );

            //Business
            services.AddFluentValidationAutoValidation(options =>
                options.DisableDataAnnotationsValidation = true
            );
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(IProductService), typeof(ProductManager));
            services.AddScoped(typeof(ICategoryService), typeof(CategoryManager));

            //Api
            services.AddCors(options =>
            {
                options.AddPolicy("Cors", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
