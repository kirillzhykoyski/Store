namespace Store.Web.App
{
    public class Cart
    {
        public int OrderId { get; } // Идентификатор заказа

        public int TotalCount { get; } // Общее количество товаров в корзине

        public decimal TotalPrice { get; } // Общая стоимость товаров в корзине

        public Cart(int orderId, int totalCount, decimal totalPrice)
        {
            OrderId = orderId; // Устанавливаем идентификатор заказа при создании объекта Cart

            TotalCount = totalCount; // Устанавливаем общее количество товаров в корзине при создании объекта Cart

            TotalPrice = totalPrice; // Устанавливаем общую стоимость товаров в корзине при создании объекта Cart
        }
    }
}
