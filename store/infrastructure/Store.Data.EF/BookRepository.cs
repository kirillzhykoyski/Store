using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data.EF
{
    // Репозиторий книг, реализующий интерфейс IBookRepository
    class BookRepository : IBookRepository
    {
        private readonly DbContextFactory dbContextFactory;

        public BookRepository(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        // Получить все книги по их идентификаторам
        public async Task<Book[]> GetAllByIdsAsync(IEnumerable<int> bookIds)
        {
            var dbContext = dbContextFactory.Create(typeof(BookRepository));

            // Запрос на получение книг по идентификаторам
            var dtos = await dbContext.Books
                                      .Where(book => bookIds.Contains(book.Id))
                                      .ToArrayAsync();

            // Преобразование книг из DTO в модель Book
            return dtos.Select(Book.Mapper.Map)
                       .ToArray();
        }

        // Получить все книги по ISBN
        public async Task<Book[]> GetAllByIsbnAsync(string isbn)
        {
            var dbContext = dbContextFactory.Create(typeof(BookRepository));

            if (Book.TryFormatIsbn(isbn, out string formattedIsbn))
            {
                // Запрос на получение книг по отформатированному ISBN
                var dtos = await dbContext.Books
                                          .Where(book => book.Isbn == formattedIsbn)
                                          .ToArrayAsync();

                // Преобразование книг из DTO в модель Book
                return dtos.Select(Book.Mapper.Map)
                           .ToArray();
            }

            return new Book[0];
        }

        // Получить все книги по названию или автору
        public async Task<Book[]> GetAllByTitleOrAuthorAsync(string titleOrAuthor)
        {
            var dbContext = dbContextFactory.Create(typeof(BookRepository));

            var parameter = new SqlParameter("@titleOrAuthor", titleOrAuthor);

            // Запрос на получение книг по названию или автору с помощью полнотекстового поиска
            var dtos = await dbContext.Books
                                      .FromSqlRaw("SELECT * FROM Books WHERE CONTAINS((Author, Title), @titleOrAuthor)",
                                                  parameter)
                                      .ToArrayAsync();

            // Преобразование книг из DTO в модель Book
            return dtos.Select(Book.Mapper.Map)
                       .ToArray();
        }

        // Получить книгу по ее идентификатору
        public async Task<Book> GetByIdAsync(int id)
        {
            var dbContext = dbContextFactory.Create(typeof(BookRepository));

            // Запрос на получение книги по идентификатору
            var dto = await dbContext.Books
                                     .SingleAsync(book => book.Id == id);

            // Преобразование книги из DTO в модель Book
            return Book.Mapper.Map(dto);
        }
    }
}
