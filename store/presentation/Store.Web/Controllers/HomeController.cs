using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class HomeController : Controller
    {
        // Действие, которое будет обрабатывать запрос на URL /Home/Index
        public IActionResult Index()
        {
            // Возвращает представление без модели
            return View();
        }

        // Действие, которое будет обрабатывать запрос на URL /Home/Error
        // Отвечает за обработку ошибок
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Создание объекта ErrorViewModel для передачи информации об ошибке в представление
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
