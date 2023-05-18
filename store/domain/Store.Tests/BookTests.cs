using Xunit;

namespace Store.Tests
{
    public class OrderItemCollectionTests
    {
        [Fact]
        // Проверка метода IsIsbn при передаче значения null.
        public void IsIsbn_WithNull_ReturnFalse()
        {
            // Утверждение: Ожидаем, что результат будет false.
            bool actual = Book.IsIsbn(null);

            // Проверка: Убедимся, что результат равен false.
            Assert.False(actual);
        }

        [Fact]
        // Проверка метода IsIsbn при передаче пустой строки.
        public void IsIsbn_WithBlankString_ReturnFalse()
        {
            // Утверждение: Ожидаем, что результат будет false.
            bool actual = Book.IsIsbn("   ");

            // Проверка: Убедимся, что результат равен false.
            Assert.False(actual);
        }

        [Fact]
        // Проверка метода IsIsbn при передаче некорректного значения ISBN.
        public void IsIsbn_WithInvalidIsbn_ReturnFalse()
        {
            // Утверждение: Ожидаем, что результат будет false.
            bool actual = Book.IsIsbn("ISBN 123");

            // Проверка: Убедимся, что результат равен false.
            Assert.False(actual);
        }

        [Fact]
        // Проверка метода IsIsbn при передаче корректного значения ISBN-10.
        public void IsIsbn_WithIsbn10_ReturnTrue()
        {
            // Утверждение: Ожидаем, что результат будет true.
            bool actual = Book.IsIsbn("IsBn 123-456-789 0");

            // Проверка: Убедимся, что результат равен true.
            Assert.True(actual);
        }

        [Fact]
        // Проверка метода IsIsbn при передаче корректного значения ISBN-13.
        public void IsIsbn_WithIsbn13_ReturnTrue()
        {
            // Утверждение: Ожидаем, что результат будет true.
            bool actual = Book.IsIsbn("IsBn 123-456-789 0123");

            // Проверка: Убедимся, что результат равен true.
            Assert.True(actual);
        }

        [Fact]
        // Проверка метода IsIsbn при передаче значения с некорректным началом и концом.
        public void IsIsbn_WithTrashStart_ReturnFalse()
        {
            // Утверждение: Ожидаем, что результат будет false.
            bool actual = Book.IsIsbn("xxx IsBn 123-456-789 0123 yyy");

            // Проверка: Убедимся, что результат равен false.
            Assert.False(actual);
        }
    }
}
