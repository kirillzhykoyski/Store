namespace Store.Data
{
    public class BookDto
    {
        // Идентификатор книги
        public int Id { get; set; }

        // Номер ISBN книги
        public string Isbn { get; set; }

        // Автор книги
        public string Author { get; set; }

        // Название книги
        public string Title { get; set; }

        // Описание книги
        public string Description { get; set; }

        // Цена книги
        public decimal Price { get; set; }
    }
}
