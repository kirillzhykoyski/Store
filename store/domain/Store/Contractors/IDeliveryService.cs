using System.Collections.Generic;

namespace Store.Contractors
{
    public interface IDeliveryService
    {
        string Name { get; }  // Название службы доставки

        string Title { get; }  // Заголовок службы доставки

        Form FirstForm(Order order);  // Метод для получения первой формы доставки

        Form NextForm(int step, IReadOnlyDictionary<string, string> values);  // Метод для получения следующей формы доставки

        OrderDelivery GetDelivery(Form form);  // Метод для получения информации о доставке из формы
    }
}
