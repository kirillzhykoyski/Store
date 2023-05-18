using Microsoft.AspNetCore.Mvc;
using Store.Web.App;
using System.Threading.Tasks;

namespace Store.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService bookService;

        public BookController(BookService bookService)
        {
            this.bookService = bookService;
        }

        // Действие, которое будет обрабатывать запрос на URL /Book/Index
        // Принимает параметр id, указывающий идентификатор книги
        public async Task<IActionResult> Index(int id)
        {
            // Вызов сервиса bookService для получения информации о книге по указанному идентификатору
            var model = await bookService.GetByIdAsync(id);

            // Возвращает представление с моделью
            return View(model);
        }
    }
}
