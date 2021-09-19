using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotekUppgift.Migrations
{
    public partial class newcopies2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookDetails",
                keyColumn: "ID",
                keyValue: 1,
                column: "NumberOfCopies",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BookDetails",
                keyColumn: "ID",
                keyValue: 2,
                column: "NumberOfCopies",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BookDetails",
                keyColumn: "ID",
                keyValue: 3,
                column: "NumberOfCopies",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookDetails",
                keyColumn: "ID",
                keyValue: 1,
                column: "NumberOfCopies",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookDetails",
                keyColumn: "ID",
                keyValue: 2,
                column: "NumberOfCopies",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookDetails",
                keyColumn: "ID",
                keyValue: 3,
                column: "NumberOfCopies",
                value: 0);
        }
    }
}
