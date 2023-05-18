using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Data.EF
{
    // Класс контекста базы данных StoreDbContext
    public class StoreDbContext : DbContext
    {
        public DbSet<BookDto> Books { get; set; } // Коллекция книг

        public DbSet<OrderDto> Orders { get; set; } // Коллекция заказов

        public DbSet<OrderItemDto> OrderItems { get; set; } // Коллекция элементов заказа

        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildBooks(modelBuilder); // Создание схемы для книг
            BuildOrders(modelBuilder); // Создание схемы для заказов
            BuildOrderItems(modelBuilder); // Создание схемы для элементов заказа
        }

        private void BuildOrderItems(ModelBuilder modelBuilder)
        {
            // Определение схемы для элементов заказа
            modelBuilder.Entity<OrderItemDto>(action =>
            {
                action.Property(dto => dto.Price)
                      .HasColumnType("money");

                action.HasOne(dto => dto.Order)
                      .WithMany(dto => dto.Items)
                      .IsRequired();
            });
        }

        private static void BuildOrders(ModelBuilder modelBuilder)
        {
            // Определение схемы для заказов
            modelBuilder.Entity<OrderDto>(action =>
            {
                action.Property(dto => dto.CellPhone)
                      .HasMaxLength(20);

                action.Property(dto => dto.DeliveryUniqueCode)
                      .HasMaxLength(40);

                action.Property(dto => dto.DeliveryPrice)
                      .HasColumnType("money");

                action.Property(dto => dto.PaymentServiceName)
                      .HasMaxLength(40);

                action.Property(dto => dto.DeliveryParameters)
                      .HasConversion(
                          value => JsonConvert.SerializeObject(value),
                          value => JsonConvert.DeserializeObject<Dictionary<string, string>>(value))
                      .Metadata.SetValueComparer(DictionaryComparer);

                action.Property(dto => dto.PaymentParameters)
                      .HasConversion(
                          value => JsonConvert.SerializeObject(value),
                          value => JsonConvert.DeserializeObject<Dictionary<string, string>>(value))
                      .Metadata.SetValueComparer(DictionaryComparer);
            });
        }

        private static readonly ValueComparer DictionaryComparer =
            new ValueComparer<Dictionary<string, string>>(
                (dictionary1, dictionary2) => dictionary1.SequenceEqual(dictionary2),
                dictionary => dictionary.Aggregate(
                    0,
                    (a, p) => HashCode.Combine(HashCode.Combine(a, p.Key.GetHashCode()), p.Value.GetHashCode())
                )
            );

        private static void BuildBooks(ModelBuilder modelBuilder)
        {
            // Определение схемы для книг
            modelBuilder.Entity<BookDto>(action =>
            {
                action.Property(dto => dto.Isbn)
                      .HasMaxLength(17)
                      .IsRequired();

                action.Property(dto => dto.Title)
                      .IsRequired();

                action.Property(dto => dto.Price)
                      .HasColumnType("money");

                // Инициализация данных книг
                action.HasData(
                    new BookDto
                    {
                        Id = 1,
                        Isbn = "ISBN0201038013",
                        Author = "D. Knuth",
                        Title = "Art Of Programming, Vol. 1",
                        Description = "This volume begins with basic programming concepts and techniques, then focuses more particularly on information structures-the representation of information inside a computer, the structural relationships between data elements and how to deal with them efficiently.",
                        Price = 7.19m,
                    },
                    new BookDto
                    {
                        Id = 2,
                        Isbn = "ISBN0201485672",
                        Author = "M. Fowler",
                        Title = "Refactoring",
                        Description = "As the application of object technology--particularly the Java programming language--has become commonplace, a new problem has emerged to confront the software development community.",
                        Price = 12.45m,
                    },
                    new BookDto
                    {
                        Id = 3,
                        Isbn = "ISBN0131101633",
                        Author = "B. W. Kernighan, D. M. Ritchie",
                        Title = "C Programming Language",
                        Description = "Known as the bible of C, this classic bestseller introduces the C programming language and illustrates algorithms, data structures, and programming techniques.",
                        Price = 14.98m,
                    }
                );
            });
        }
    }
}
