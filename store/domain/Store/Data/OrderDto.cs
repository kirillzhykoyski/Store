using System.Collections.Generic;

namespace Store.Data
{
    public class OrderDto
    {
        // Идентификатор заказа
        public int Id { get; set; }

        // Номер телефона для связи с клиентом
        public string CellPhone { get; set; }

        // Уникальный код доставки
        public string DeliveryUniqueCode { get; set; }

        // Описание доставки
        public string DeliveryDescription { get; set; }

        // Стоимость доставки
        public decimal DeliveryPrice { get; set; }

        // Параметры доставки
        public Dictionary<string, string> DeliveryParameters { get; set; }

        // Название сервиса оплаты
        public string PaymentServiceName { get; set; }

        // Описание оплаты
        public string PaymentDescription { get; set; }

        // Параметры оплаты
        public Dictionary<string, string> PaymentParameters { get; set; }

        // Список позиций заказа
        public IList<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }
}
