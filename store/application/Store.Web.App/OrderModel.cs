using System.Collections.Generic;

namespace Store.Web.App
{
    public class OrderModel
    {
        public int Id { get; set; } // Идентификатор заказа

        public OrderItemModel[] Items { get; set; } = new OrderItemModel[0]; // Массив элементов заказа

        public int TotalCount { get; set; } // Общее количество товаров в заказе

        public decimal TotalPrice { get; set; } // Общая стоимость товаров в заказе

        public string CellPhone { get; set; } // Номер мобильного телефона для связи с клиентом

        public string DeliveryDescription { get; set; } // Описание способа доставки

        public string PaymentDescription { get; set; } // Описание способа оплаты

        public Dictionary<string, string> Errors { get; set; } = new Dictionary<string, string>(); // Словарь ошибок при обработке заказа
    }
}
