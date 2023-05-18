namespace Store.Data
{
    public class OrderItemDto
    {
        // Идентификатор позиции заказа
        public int Id { get; set; }

        // Идентификатор книги
        public int BookId { get; set; }

        // Цена позиции
        public decimal Price { get; set; }

        // Количество позиции
        public int Count { get; set; }

        // Заказ, к которому относится позиция
        public OrderDto Order { get; set; }
    }
}
