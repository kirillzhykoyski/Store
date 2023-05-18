namespace Store.Web.App
{
    public class BookModel
    {
        public int Id { get; set; } // Идентификатор книги

        public string Isbn { get; set; } // ISBN книги

        public string Author { get; set; } // Автор книги

        public string Title { get; set; } // Название книги

        public string Description { get; set; } // Описание книги

        public decimal Price { get; set; } // Цена книги
    }
}
