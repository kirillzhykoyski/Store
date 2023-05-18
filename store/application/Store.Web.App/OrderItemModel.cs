namespace Store.Web.App
{
    public class OrderItemModel
    {
        public int BookId { get; set; } // Идентификатор книги

        public string Title { get; set; } // Название книги

        public string Author { get; set; } // Автор книги

        public int Count { get; set; } // Количество экземпляров книги

        public decimal Price { get; set; } // Цена за один экземпляр книги
    }
}
