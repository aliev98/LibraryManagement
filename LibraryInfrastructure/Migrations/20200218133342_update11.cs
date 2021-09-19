using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotekUppgift.Migrations
{
    public partial class update11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "bookCopies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "bookCopies",
                keyColumn: "Id",
                keyValue: 3,
                column: "BookDetailsId",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "bookCopies",
                keyColumn: "Id",
                keyValue: 3,
                column: "BookDetailsId",
                value: 2);

            migrationBuilder.InsertData(
                table: "bookCopies",
                columns: new[] { "Id", "BookDetailsId" },
                values: new object[] { 4, 1 });
        }
    }
}
