using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotekUppgift.Migrations
{
    public partial class members2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pnr",
                table: "MemberDetails",
                newName: "PNR");

            migrationBuilder.AlterColumn<long>(
                name: "PNR",
                table: "MemberDetails",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MemberDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "MemberDetails",
                columns: new[] { "ID", "Name", "PNR" },
                values: new object[] { 1, "Sami", 8383948292L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MemberDetails",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "PNR",
                table: "MemberDetails",
                newName: "Pnr");

            migrationBuilder.AlterColumn<int>(
                name: "Pnr",
                table: "MemberDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MemberDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
