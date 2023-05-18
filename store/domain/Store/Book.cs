using Store.Data;
using System;
using System.Text.RegularExpressions;

namespace Store
{
    public class Book
    {
        private readonly BookDto dto;

        public int Id => dto.Id;

        public string Isbn
        {
            get => dto.Isbn;
            set
            {
                if (TryFormatIsbn(value, out string formattedIsbn))
                    dto.Isbn = formattedIsbn;

                throw new ArgumentException(nameof(Isbn));
            }
        }

        public string Author
        {
            get => dto.Author;
            set => dto.Author = value?.Trim();
        }

        public string Title
        {
            get => dto.Title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(Title));

                dto.Title = value.Trim();
            }
        }

        public string Description
        {
            get => dto.Description;
            set => dto.Description = value;
        }

        public decimal Price
        {
            get => dto.Price;
            set => dto.Price = value;
        }

        internal Book(BookDto dto)
        {
            this.dto = dto;
        }

        /// Форматирования ISBN.
        /// <param name="isbn">Исходный ISBN.</param>
        /// <param name="formattedIsbn">Форматированный ISBN.</param>
        /// <returns>True, если форматирование прошло успешно; в противном случае - false.</returns>
        public static bool TryFormatIsbn(string isbn, out string formattedIsbn)
        {
            if (isbn == null)
            {
                formattedIsbn = null;
                return false;
            }

            formattedIsbn = isbn.Replace("-", "")
                                .Replace(" ", "")
                                .ToUpper();

            return Regex.IsMatch(formattedIsbn, @"^ISBN\d{10}(\d{3})?$");
        }


        /// Проверяет, является ли переданный ISBN допустимым.
        /// <param name="isbn">Исходный ISBN.</param>
        /// <returns>True, если ISBN допустим; в противном случае - false.</returns>
        public static bool IsIsbn(string isbn)
            => TryFormatIsbn(isbn, out _);

        public static class DtoFactory
        {
            /// <summary>
            /// Создает новый объект BookDto на основе переданных параметров.
            /// </summary>
            /// <param name="isbn">ISBN книги.</param>
            /// <param name="author">Автор книги.</param>
            /// <param name="title">Заголовок книги.</param>
            /// <param name="description">Описание книги.</param>
            /// <param name="price">Цена книги.</param>
            /// <returns>Объект BookDto.</returns>
            public static BookDto Create(string isbn, string author, string title, string description, decimal price)
            {
                if (TryFormatIsbn(isbn, out string formattedIsbn))
                    isbn = formattedIsbn;
                else
                    throw new ArgumentException(nameof(isbn));

                if (string.IsNullOrWhiteSpace(title))
                    throw new ArgumentException(nameof(title));

                return new BookDto
                {
                    Isbn = isbn,
                    Author = author?.Trim(),
                    Title = title.Trim(),
                    Description = description?.Trim(),
                    Price = price,
                };
            }
        }

        public static class Mapper
        {
            public static Book Map(BookDto dto) => new Book(dto);

            public static BookDto Map(Book domain) => domain.dto;
        }
    }
}
