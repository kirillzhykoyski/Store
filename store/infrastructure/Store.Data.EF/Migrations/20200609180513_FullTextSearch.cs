using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Data.EF.Migrations
{
    public partial class FullTextSearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Создание полнотекстового каталога "StoreFullTextCatalog" по умолчанию
            migrationBuilder.Sql("CREATE FULLTEXT CATALOG StoreFullTextCatalog AS DEFAULT", suppressTransaction: true);

            // Создание полнотекстового индекса на столбцах "Author" и "Title" в таблице "Books"
            // Используется индекс первичного ключа "PK_Books", а также стоп-список "SYSTEM"
            migrationBuilder.Sql("CREATE FULLTEXT INDEX ON Books(Author, Title) KEY INDEX PK_Books WITH STOPLIST = SYSTEM", suppressTransaction: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Удаление полнотекстового индекса на таблице "Books"
            migrationBuilder.Sql("DROP FULLTEXT INDEX ON Books", suppressTransaction: true);

            // Удаление полнотекстового каталога "StoreFullTextCatalog"
            migrationBuilder.Sql("DROP FULLTEXT CATALOG StoreFullTextCatalog", suppressTransaction: true);
        }
    }
}
