using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Store.Data.EF
{
    // Фабрика контекстов базы данных
    class DbContextFactory
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public DbContextFactory(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        // Создание контекста базы данных для указанного типа репозитория
        public StoreDbContext Create(Type repositoryType)
        {
            var services = httpContextAccessor.HttpContext.RequestServices;

            // Получение словаря контекстов базы данных из сервисов
            var dbContexts = services.GetService<Dictionary<Type, StoreDbContext>>();

            // Если контекста для указанного типа репозитория еще нет, создаем и добавляем его в словарь
            if (!dbContexts.ContainsKey(repositoryType))
                dbContexts[repositoryType] = services.GetService<StoreDbContext>();

            // Возвращаем контекст базы данных для указанного типа репозитория
            return dbContexts[repositoryType];
        }
    }
}
