using System.Threading.Tasks;

namespace Store.Messages
{
    public interface INotificationService
    {
        // Отправка кода подтверждения
        void SendConfirmationCode(string cellPhone, int code);

        // Асинхронная отправка кода подтверждения
        Task SendConfirmationCodeAsync(string cellPhone, int code);

        // Начало обработки заказа
        void StartProcess(Order order);

        // Асинхронное начало обработки заказа
        Task StartProcessAsync(Order order);
    }
}
