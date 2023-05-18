using Xunit;

namespace Store.Tests
{
    public class OrderItemCollectionTests
    {
        [Fact]
        // �������� ������ IsIsbn ��� �������� �������� null.
        public void IsIsbn_WithNull_ReturnFalse()
        {
            // �����������: �������, ��� ��������� ����� false.
            bool actual = Book.IsIsbn(null);

            // ��������: ��������, ��� ��������� ����� false.
            Assert.False(actual);
        }

        [Fact]
        // �������� ������ IsIsbn ��� �������� ������ ������.
        public void IsIsbn_WithBlankString_ReturnFalse()
        {
            // �����������: �������, ��� ��������� ����� false.
            bool actual = Book.IsIsbn("   ");

            // ��������: ��������, ��� ��������� ����� false.
            Assert.False(actual);
        }

        [Fact]
        // �������� ������ IsIsbn ��� �������� ������������� �������� ISBN.
        public void IsIsbn_WithInvalidIsbn_ReturnFalse()
        {
            // �����������: �������, ��� ��������� ����� false.
            bool actual = Book.IsIsbn("ISBN 123");

            // ��������: ��������, ��� ��������� ����� false.
            Assert.False(actual);
        }

        [Fact]
        // �������� ������ IsIsbn ��� �������� ����������� �������� ISBN-10.
        public void IsIsbn_WithIsbn10_ReturnTrue()
        {
            // �����������: �������, ��� ��������� ����� true.
            bool actual = Book.IsIsbn("IsBn 123-456-789 0");

            // ��������: ��������, ��� ��������� ����� true.
            Assert.True(actual);
        }

        [Fact]
        // �������� ������ IsIsbn ��� �������� ����������� �������� ISBN-13.
        public void IsIsbn_WithIsbn13_ReturnTrue()
        {
            // �����������: �������, ��� ��������� ����� true.
            bool actual = Book.IsIsbn("IsBn 123-456-789 0123");

            // ��������: ��������, ��� ��������� ����� true.
            Assert.True(actual);
        }

        [Fact]
        // �������� ������ IsIsbn ��� �������� �������� � ������������ ������� � ������.
        public void IsIsbn_WithTrashStart_ReturnFalse()
        {
            // �����������: �������, ��� ��������� ����� false.
            bool actual = Book.IsIsbn("xxx IsBn 123-456-789 0123 yyy");

            // ��������: ��������, ��� ��������� ����� false.
            Assert.False(actual);
        }
    }
}
