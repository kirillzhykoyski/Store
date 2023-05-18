using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Store.Data.EF
{
    // Репозиторий заказов
    class OrderRepository : IOrderRepository
    {
        private readonly DbContextFactory dbContextFactory;

        public OrderRepository(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        // Создание нового заказа
        public async Task<Order> CreateAsync()
        {
            var dbContext = dbContextFactory.Create(typeof(OrderRepository));

            // Создание нового DTO для заказа
            var dto = Order.DtoFactory.Create();
            dbContext.Orders.Add(dto);
            await dbContext.SaveChangesAsync();

            // Преобразование DTO в объект типа Order и возвращение результата
            return Order.Mapper.Map(dto);
        }

        // Получение заказа по идентификатору
        public async Task<Order> GetByIdAsync(int id)
        {
            var dbContext = dbContextFactory.Create(typeof(OrderRepository));

            // Получение DTO заказа с указанным идентификатором, включая связанные элементы заказа
            var dto = await dbContext.Orders
                                     .Include(order => order.Items)
                                     .SingleAsync(order => order.Id == id);

            // Преобразование DTO в объект типа Order и возвращение результата
            return Order.Mapper.Map(dto);
        }

        // Обновление заказа
        public async Task UpdateAsync(Order order)
        {
            var dbContext = dbContextFactory.Create(typeof(OrderRepository));

            // Сохранение изменений в контексте базы данных
            await dbContext.SaveChangesAsync();
        }
    }
}
