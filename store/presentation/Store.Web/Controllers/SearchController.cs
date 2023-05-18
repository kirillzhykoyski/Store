using Microsoft.AspNetCore.Mvc;
using Store.Web.App;
using System.Threading.Tasks;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly BookService bookService;

        public SearchController(BookService bookService)
        {
            this.bookService = bookService;
        }

        // Действие, которое будет обрабатывать GET-запрос на URL /Search/Index с параметром query
        public async Task<IActionResult> Index(string query)
        {
            // Вызов сервиса bookService для получения списка книг по заданному запросу
            var books = await bookService.GetAllByQueryAsync(query);

            // Передача списка книг в представление "Index" для отображения
            return View("Index", books);
        }
    }
}
