using System;
using System.Collections.Generic;

namespace Store.Contractors
{
    public class CashPaymentService : IPaymentService
    {
        public string Name => "Cash";  // Название сервиса оплаты - наличные

        public string Title => "Оплата наличными";  // Заголовок сервиса оплаты - Оплата наличными

        public Form FirstForm(Order order)
        {
            // Создает первую форму для оплаты наличными, добавляет параметр "orderId" со значением Id заказа
            return Form.CreateFirst(Name)
                       .AddParameter("orderId", order.Id.ToString());
        }

        public Form NextForm(int step, IReadOnlyDictionary<string, string> values)
        {
            if (step != 1)
                throw new InvalidOperationException("Invalid cash payment step.");  // Некорректный шаг оплаты наличными

            // Создает последующую форму для оплаты наличными, увеличивает шаг на 1 и использует переданные значения
            return Form.CreateLast(Name, step + 1, values);
        }

        public OrderPayment GetPayment(Form form)
        {
            if (form.ServiceName != Name || !form.IsFinal)
                throw new InvalidOperationException("Invalid payment form.");  // Некорректная форма оплаты

            // Создает объект OrderPayment для оплаты наличными, используя название сервиса, описание и параметры формы
            return new OrderPayment(Name, "Оплата наличными", form.Parameters);
        }
    }
}
