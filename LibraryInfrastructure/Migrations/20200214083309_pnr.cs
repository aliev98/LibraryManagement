using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotekUppgift.Migrations
{
    public partial class pnr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PNR",
                table: "MemberDetails",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 12);

            migrationBuilder.UpdateData(
                table: "MemberDetails",
                keyColumn: "ID",
                keyValue: 1,
                column: "PNR",
                value: "847582-7382");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PNR",
                table: "MemberDetails",
                type: "bigint",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 12);

            migrationBuilder.UpdateData(
                table: "MemberDetails",
                keyColumn: "ID",
                keyValue: 1,
                column: "PNR",
                value: 847582738L);
        }
    }
}
