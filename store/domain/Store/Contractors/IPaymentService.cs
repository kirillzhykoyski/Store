using System.Collections.Generic;

namespace Store.Contractors
{
    public interface IPaymentService
    {
        string Name { get; }  // Название службы оплаты

        string Title { get; }  // Заголовок службы оплаты

        Form FirstForm(Order order);  // Метод для получения первой формы оплаты

        Form NextForm(int step, IReadOnlyDictionary<string, string> values);  // Метод для получения следующей формы оплаты

        OrderPayment GetPayment(Form form);  // Метод для получения информации об оплате из формы
    }
}
