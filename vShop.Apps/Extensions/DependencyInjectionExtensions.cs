using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using vShop.Apps.Application.Behaviors;
using vShop.Apps.Application.Commands;
using vShop.Apps.Application.Profiles;
using vShop.Apps.Application.Validations;
using vShop.Domain.Repositories;
using vShop.Infrastructure;
using vShop.Infrastructure.Repositories;

namespace vShop.Apps.Extensions
{
    public static class DependencyInjectionExtensions
    {

        public static IServiceCollection AddDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EFContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("MySQL"), new MySqlServerVersion("9.1.0"));
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }

        public static IServiceCollection AddMediator(this IServiceCollection services)
        {

            services.AddMediatR(options =>
            {
                options.AddOpenBehavior(typeof(TransactionBehavior<,>));
                options.AddOpenBehavior(typeof(ValidationBehavior<,>));
                options.RegisterServicesFromAssemblyContaining<ICommand>();
            });
            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfile));
            return services;
        }

        public static IServiceCollection AddRedisCache(this IServiceCollection services)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "127.0.0.1:6379";
                options.InstanceName = "vShop";
            });
            return services;
        }

        public static IServiceCollection AddValidations(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateProduceValidation>();
            return services;
        }
    }
}
