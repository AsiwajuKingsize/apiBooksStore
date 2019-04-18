using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiBooksStore.Migrations
{
    public partial class FirstEntityandDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BooksInventory");

            migrationBuilder.EnsureSchema(
                name: "Logging");

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "BooksInventory",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "BookSale",
                schema: "BooksInventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    SaleDate = table.Column<DateTime>(nullable: false),
                    Buyer = table.Column<string>(nullable: true),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                schema: "Logging",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(nullable: true),
                    MessageTemplate = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Exception = table.Column<string>(nullable: true),
                    LogEvent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "BooksInventory",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "BooksInventory",
                        principalTable: "Author",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "BooksInventory",
                table: "Author",
                columns: new[] { "AuthorId", "AuthorName", "Email", "Phone", "Website" },
                values: new object[,]
                {
                    { 1, "Ifeanyi Chukwu", "chukwu@async.ae", "+234018977655", "www.async.com" },
                    { 2, "William Shakespeare", "Shakespeare@gmail.com", "+234018977655", "www.williamsShakespeareBooks.com" },
                    { 3, "Joseph Okeke", "Okeke@gmail.com", "+234018977655", "www.OkekeBooks.com" }
                });

            migrationBuilder.InsertData(
                schema: "BooksInventory",
                table: "BookSale",
                columns: new[] { "Id", "BookId", "Buyer", "Quantity", "SaleDate" },
                values: new object[,]
                {
                    { 1, 1, "Igwe Obi", 6, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "Chied Titus", 6, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, "Osun Temidayo", 6, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "BooksInventory",
                table: "Book",
                columns: new[] { "BookId", "AuthorId", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, 0.0, null, "IT Systems" },
                    { 3, 1, 0.0, null, "WEB PI Systems and Security" },
                    { 2, 2, 0.0, null, "King Lear" },
                    { 4, 3, 0.0, null, "Things Fall In Place" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                schema: "BooksInventory",
                table: "Book",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book",
                schema: "BooksInventory");

            migrationBuilder.DropTable(
                name: "BookSale",
                schema: "BooksInventory");

            migrationBuilder.DropTable(
                name: "Log",
                schema: "Logging");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "BooksInventory");
        }
    }
}
