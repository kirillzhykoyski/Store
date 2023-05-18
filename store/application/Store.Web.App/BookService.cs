using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.App
{
    public class BookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<BookModel> GetByIdAsync(int id)
        {
            var book = await bookRepository.GetByIdAsync(id); // Получаем книгу из репозитория по указанному идентификатору

            return Map(book); // Преобразуем объект Book в BookModel и возвращаем его
        }

        public async Task<IReadOnlyCollection<BookModel>> GetAllByQueryAsync(string query)
        {
            var books = Book.IsIsbn(query) // Проверяем, является ли запрос ISBN'ом
                      ? await bookRepository.GetAllByIsbnAsync(query) // Если да, то получаем книги по ISBN из репозитория
                      : await bookRepository.GetAllByTitleOrAuthorAsync(query); // Если нет, то получаем книги по названию или автору из репозитория

            return books.Select(Map) // Преобразуем каждую книгу в BookModel с помощью метода Map
                        .ToArray(); // Преобразуем коллекцию книг в массив и возвращаем его
        }

        private BookModel Map(Book book)
        {
            return new BookModel
            {
                Id = book.Id,
                Isbn = book.Isbn,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Price = book.Price,
            };
        }
    }
}
