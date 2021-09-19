using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotekUppgift.Migrations
{
    public partial class pnrlong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MemberDetails",
                keyColumn: "ID",
                keyValue: 1,
                column: "PNR",
                value: 847582738L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MemberDetails",
                keyColumn: "ID",
                keyValue: 1,
                column: "PNR",
                value: 8383948292L);
        }
    }
}
