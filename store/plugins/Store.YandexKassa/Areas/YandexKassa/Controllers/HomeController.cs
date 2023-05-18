using Microsoft.AspNetCore.Mvc;
using Store.YandexKassa.Areas.YandexKassa.Models;

namespace Store.YandexKassa.Areas.YandexKassa.Controllers
{
    [Area("YandexKassa")]
    public class HomeController : Controller
    {
        // Метод действия для отображения главной страницы оплаты
        public IActionResult Index(int orderId, string returnUri)
        {
            // Создание модели данных для передачи в представление
            var model = new ExampleModel
            {
                OrderId = orderId,
                ReturnUri = returnUri,
            };

            // Возвращение представления с моделью данных
            return View(model);
        }

        // Метод действия для обработки обратного вызова от платежного сервиса
        public IActionResult Callback(int orderId, string returnUri)
        {
            // Создание модели данных для передачи в представление
            var model = new ExampleModel
            {
                OrderId = orderId,
                ReturnUri = returnUri,
            };

            // Возвращение представления с моделью данных
            return View(model);
        }
    }
}
