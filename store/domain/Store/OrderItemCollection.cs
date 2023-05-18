using Store.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Store
{
    public class OrderItemCollection : IReadOnlyCollection<OrderItem>
    {
        private readonly OrderDto orderDto;
        private readonly List<OrderItem> items;

        /// Конструктор коллекции элементов заказа.
        /// <param name="orderDto">DTO заказа.</param>
        public OrderItemCollection(OrderDto orderDto)
        {
            if (orderDto == null)
                throw new ArgumentNullException(nameof(orderDto));

            this.orderDto = orderDto;

            // Создание списка элементов заказа из DTO-элементов
            items = orderDto.Items
                            .Select(OrderItem.Mapper.Map)
                            .ToList();
        }

        /// <summary>
        /// Количество элементов в коллекции.
        /// </summary>
        public int Count => items.Count;

        /// Получить перечислитель для элементов коллекции.
        /// <returns>Перечислитель для элементов коллекции.</returns>
        public IEnumerator<OrderItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        /// <summary>
        /// Получить перечислитель для элементов коллекции.
        /// </summary>
        /// <returns>Перечислитель для элементов коллекции.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (items as IEnumerable).GetEnumerator();
        }

        /// Получить элемент заказа по идентификатору книги.
        /// <param name="bookId">Идентификатор книги.</param>
        /// <returns>Элемент заказа с указанным идентификатором книги.</returns>
        public OrderItem Get(int bookId)
        {
            if (TryGet(bookId, out OrderItem orderItem))
                return orderItem;

            throw new InvalidOperationException("Book not found.");
        }

        /// Попытаться получить элемент заказа по идентификатору книги.
        /// <param name="bookId">Идентификатор книги.</param>
        /// <param name="orderItem">Элемент заказа с указанным идентификатором книги (если найден).</param>
        /// <returns>Значение true, если элемент заказа был найден; в противном случае — значение false.</returns>
        public bool TryGet(int bookId, out OrderItem orderItem)
        {
            var index = items.FindIndex(item => item.BookId == bookId);
            if (index == -1)
            {
                orderItem = null;
                return false;
            }

            orderItem = items[index];
            return true;
        }

        /// Добавить элемент в заказ.
        /// <param name="bookId">Идентификатор книги.</param>
        /// <param name="price">Цена элемента.</param>
        /// <param name="count">Количество элементов.</param>
        /// <returns>Добавленный элемент заказа.</returns>
        public OrderItem Add(int bookId, decimal price, int count)
        {
            if (TryGet(bookId, out OrderItem orderItem))
                throw new InvalidOperationException("Book already exists.");

            var orderItemDto = OrderItem.DtoFactory.Create(orderDto, bookId, price, count);
            orderDto.Items.Add(orderItemDto);

            orderItem = OrderItem.Mapper.Map(orderItemDto);
            items.Add(orderItem);

            return orderItem;
        }

        /// Удалить элемент из заказа по идентификатору книги.
        /// <param name="bookId">Идентификатор книги.</param>
        public void Remove(int bookId)
        {
            var index = items.FindIndex(item => item.BookId == bookId);
            if (index == -1)
                throw new InvalidOperationException("Can't find book to remove from order.");

            orderDto.Items.RemoveAt(index);
            items.RemoveAt(index);
        }
    }
}
