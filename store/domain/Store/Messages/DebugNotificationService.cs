using System.Diagnostics;
using System.Threading.Tasks;

namespace Store.Messages
{
    public class DebugNotificationService : INotificationService
    {
        // Отправка кода подтверждения через отладочный вывод
        public void SendConfirmationCode(string cellPhone, int code)
        {
            Debug.WriteLine("Cell phone: {0}, code: {1:0000}.", cellPhone, code);
        }

        // Асинхронная отправка кода подтверждения через отладочный вывод
        public Task SendConfirmationCodeAsync(string cellPhone, int code)
        {
            Debug.WriteLine("Cell phone: {0}, code: {1:0000}.", cellPhone, code);

            return Task.CompletedTask;
        }

        // Начало обработки заказа через отладочный вывод
        public void StartProcess(Order order)
        {
            Debug.WriteLine("Order ID {0}", order.Id);
            Debug.WriteLine("Delivery: {0}", (object)order.Delivery.Description);
            Debug.WriteLine("Payment: {0}", (object)order.Payment.Description);
        }

        // Асинхронное начало обработки заказа через отладочный вывод
        public Task StartProcessAsync(Order order)
        {
            StartProcess(order);

            return Task.CompletedTask;
        }
    }
}
