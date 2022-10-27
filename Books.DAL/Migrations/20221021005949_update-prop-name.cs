using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Books.DAL.Migrations
{
    public partial class updatepropname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Book",
                newName: "AuthorName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthorName",
                table: "Book",
                newName: "Author");
        }
    }
}
