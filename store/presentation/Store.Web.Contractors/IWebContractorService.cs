using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Web.Contractors
{
    public interface IWebContractorService
    {
        string Name { get; } // Название веб-контрактора

        Uri StartSession(IReadOnlyDictionary<string, string> parameters, Uri returnUri); // Начать сессию веб-контрактора и получить URL-адрес перенаправления

        Task<Uri> StartSessionAsync(IReadOnlyDictionary<string, string> parameters, Uri returnUri); // Асинхронно начать сессию веб-контрактора и получить URL-адрес перенаправления
    }
}
