using Microsoft.AspNetCore.Http;
using Store.Contractors;
using Store.Web.Contractors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.YandexKassa
{
    public class YandexKassaPaymentService : IPaymentService, IWebContractorService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public YandexKassaPaymentService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        // Получение текущего HTTP-запроса из контекста
        private HttpRequest Request => httpContextAccessor.HttpContext.Request;

        // Имя сервиса оплаты
        public string Name => "YandexKassa";

        // Название сервиса оплаты
        public string Title => "Оплата банковской картой";

        // Создание первой формы для оплаты
        public Form FirstForm(Order order)
        {
            return Form.CreateFirst(Name)
                       .AddParameter("orderId", order.Id.ToString());
        }

        // Создание следующей формы для оплаты
        public Form NextForm(int step, IReadOnlyDictionary<string, string> values)
        {
            if (step != 1)
                throw new InvalidOperationException("Invalid Yandex.Kassa payment step.");

            return Form.CreateLast(Name, step + 1, values);
        }

        // Получение информации о платеже на основе формы оплаты
        public OrderPayment GetPayment(Form form)
        {
            if (form.ServiceName != Name || !form.IsFinal)
                throw new InvalidOperationException("Invalid payment form.");

            return new OrderPayment(Name, "Оплатой картой", form.Parameters);
        }

        // Начало сессии оплаты и формирование URI-адреса для перехода
        public Uri StartSession(IReadOnlyDictionary<string, string> parameters, Uri returnUri)
        {
            var queryString = QueryString.Create(parameters);
            queryString += QueryString.Create("returnUri", returnUri.ToString());

            var builder = new UriBuilder(Request.Scheme, Request.Host.Host)
            {
                Path = "YandexKassa/",
                Query = queryString.ToString(),
            };

            if (Request.Host.Port != null)
                builder.Port = Request.Host.Port.Value;

            return builder.Uri;
        }

        // Асинхронное начало сессии оплаты и формирование URI-адреса для перехода
        public Task<Uri> StartSessionAsync(IReadOnlyDictionary<string, string> parameters, Uri returnUri)
        {
            var uri = StartSession(parameters, returnUri);

            return Task.FromResult(uri);
        }
    }
}
