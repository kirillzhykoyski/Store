using Xunit;

namespace Store.Tests
{
    public class BookTests
    {
        [Fact]
        // Проверка метода IsIsbn с null значением.
        public void IsIsbn_WithNull_ReturnsFalse()
        {
            // Вызов метода IsIsbn с null значением.
            bool actual = Book.IsIsbn(null);

            // Проверка: Ожидаем, что метод вернет false.
            Assert.False(actual);
        }

        [Fact]
        // Проверка метода IsIsbn с пустой строкой.
        public void IsIsbn_WithBlankString_ReturnsFalse()
        {
            // Вызов метода IsIsbn с пустой строкой.
            bool actual = Book.IsIsbn("   ");

            // Проверка: Ожидаем, что метод вернет false.
            Assert.False(actual);
        }

        [Fact]
        // Проверка метода IsIsbn с некорректным ISBN.
        public void IsIsbn_WithInvalidIsbn_ReturnsFalse()
        {
            // Вызов метода IsIsbn с некорректным ISBN.
            bool actual = Book.IsIsbn("ISBN 123");

            // Проверка: Ожидаем, что метод вернет false.
            Assert.False(actual);
        }

        [Fact]
        // Проверка метода IsIsbn с корректным ISBN-10.
        public void IsIsbn_WithIsbn10_ReturnsTrue()
        {
            // Вызов метода IsIsbn с корректным ISBN-10.
            bool actual = Book.IsIsbn("IsBn 123-456-789 0");

            // Проверка: Ожидаем, что метод вернет true.
            Assert.True(actual);
        }

        [Fact]
        // Проверка метода IsIsbn с корректным ISBN-13.
        public void IsIsbn_WithIsbn13_ReturnsTrue()
        {
            // Вызов метода IsIsbn с корректным ISBN-13.
            bool actual = Book.IsIsbn("IsBn 123-456-789 0123");

            // Проверка: Ожидаем, что метод вернет true.
            Assert.True(actual);
        }

        [Fact]
        // Проверка метода IsIsbn с некорректным префиксом и суффиксом.
        public void IsIsbn_WithTrashStart_ReturnsFalse()
        {
            // Вызов метода IsIsbn с некорректным префиксом и суффиксом.
            bool actual = Book.IsIsbn("xxx IsBn 123-456-789 0123 yyy");

            // Проверка: Ожидаем, что метод вернет false.
            Assert.False(actual);
        }
    }
}
