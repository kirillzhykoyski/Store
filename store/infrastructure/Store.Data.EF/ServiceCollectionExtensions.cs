using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Store.Data.EF
{
    // Расширение служб для добавления EF репозиториев
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfRepositories(this IServiceCollection services, string connectionString)
        {
            // Добавление контекста базы данных StoreDbContext в службы
            services.AddDbContext<StoreDbContext>(
                options =>
                {
                    options.UseSqlServer(connectionString);
                },
                ServiceLifetime.Transient
            );

            // Добавление словаря типов контекстов базы данных в службы с временем жизни Scoped
            services.AddScoped<Dictionary<Type, StoreDbContext>>();

            // Добавление фабрики контекстов базы данных в службы с временем жизни Singleton
            services.AddSingleton<DbContextFactory>();

            // Добавление репозиториев книг и заказов в службы с временем жизни Singleton
            services.AddSingleton<IBookRepository, BookRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
