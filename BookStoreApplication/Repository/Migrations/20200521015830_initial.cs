using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreRepositoryLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressSpace",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    ContactNumber = table.Column<string>(nullable: false),
                    DeliveryAddress = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false),
                    CityTown = table.Column<string>(nullable: false),
                    LandMark = table.Column<string>(nullable: false),
                    AddressType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressSpace", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "BookStore",
                columns: table => new
                {
                    BookID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookTittle = table.Column<string>(nullable: false),
                    AuthorName = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Summary = table.Column<string>(nullable: false),
                    BookImage = table.Column<string>(nullable: false),
                    BookCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStore", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "CartTable",
                columns: table => new
                {
                    CartID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Book_ID = table.Column<int>(nullable: false),
                    SelectBookCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartTable", x => x.CartID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressSpace");

            migrationBuilder.DropTable(
                name: "BookStore");

            migrationBuilder.DropTable(
                name: "CartTable");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
