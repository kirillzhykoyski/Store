using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store
{
    public interface IBookRepository
    {
        // Асинхронно извлекает массив книг по указанному ISBN.
        // Возвращает задачу (Task<Book[]>), представляющую асинхронную операцию извлечения книг.
        Task<Book[]> GetAllByIsbnAsync(string isbn);

        // Асинхронно извлекает массив книг по указанному заголовку или автору.
        // Возвращает задачу (Task<Book[]>), представляющую асинхронную операцию извлечения книг.
        Task<Book[]> GetAllByTitleOrAuthorAsync(string titleOrAuthor);

        // Асинхронно извлекает книгу по указанному идентификатору.
        // Возвращает задачу (Task<Book>), представляющую асинхронную операцию извлечения книги.
        Task<Book> GetByIdAsync(int id);

        // Асинхронно извлекает массив книг по указанным идентификаторам.
        // Возвращает задачу (Task<Book[]>), представляющую асинхронную операцию извлечения книг.
        Task<Book[]> GetAllByIdsAsync(IEnumerable<int> bookIds);
    }
}
