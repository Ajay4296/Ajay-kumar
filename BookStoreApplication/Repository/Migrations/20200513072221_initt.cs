using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class initt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartTable_BookStore_Book_ID",
                table: "CartTable");

            migrationBuilder.DropIndex(
                name: "IX_CartTable_Book_ID",
                table: "CartTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CartTable_Book_ID",
                table: "CartTable",
                column: "Book_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartTable_BookStore_Book_ID",
                table: "CartTable",
                column: "Book_ID",
                principalTable: "BookStore",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
