using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;

namespace Store.Web.App
{
    public static class SessionExtensions
    {
        private const string key = "Cart";

        // Удаляет элемент "Cart" из сессии
        public static void RemoveCart(this ISession session)
        {
            session.Remove(key);
        }

        // Устанавливает значение элемента "Cart" в сессии
        public static void Set(this ISession session, Cart value)
        {
            if (value == null)
                return;

            // Сериализует объект Cart в массив байтов и сохраняет его в сессии
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
            {
                writer.Write(value.OrderId);
                writer.Write(value.TotalCount);
                writer.Write(value.TotalPrice);

                session.Set(key, stream.ToArray());
            }
        }

        // Пытаемся получить значение элемента "Cart" из сессии
        public static bool TryGetCart(this ISession session, out Cart value)
        {
            if (session.TryGetValue(key, out byte[] buffer))
            {
                // Десериализует массив байтов в объект Cart
                using (var stream = new MemoryStream(buffer))
                using (var reader = new BinaryReader(stream, Encoding.UTF8, true))
                {
                    var orderId = reader.ReadInt32();
                    var totalCount = reader.ReadInt32();
                    var totalPrice = reader.ReadDecimal();

                    value = new Cart(orderId, totalCount, totalPrice);
                    return true;
                }
            }

            value = null;
            return false;
        }
    }
}
