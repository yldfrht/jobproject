using App.Business.Abstract;
using App.Business.Caching;
using App.Business.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using StackExchange.Redis;
using App.Business.Mapping;
using AutoMapper;
using App.DataAccess;
using FluentValidation.AspNetCore;
using App.Business.Validation;

namespace App.Business.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBusinessExt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRandevuService, RandevuService>();
            services.AddScoped<IBransService, BransService>();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddSingleton<IConnectionMultiplexer>(sp =>
                ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection"))
            );
            //services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = configuration.GetConnectionString("Redis");
            //});
            services.AddScoped<ICacheService, RedisService>();

            return services;
        }
    }
}