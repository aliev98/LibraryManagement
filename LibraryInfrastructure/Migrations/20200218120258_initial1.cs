using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotekUppgift.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfCopies",
                table: "BookDetails");

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "BookCopyId", "LoanDate", "MemberDetailsId", "ReturnDate" },
                values: new object[] { 1, 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "bookCopies",
                keyColumn: "Id",
                keyValue: 1,
                column: "BookDetailsId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "bookCopies",
                keyColumn: "Id",
                keyValue: 2,
                column: "BookDetailsId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "bookCopies",
                keyColumn: "Id",
                keyValue: 3,
                column: "BookDetailsId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "bookCopies",
                keyColumn: "Id",
                keyValue: 4,
                column: "BookDetailsId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfCopies",
                table: "BookDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "BookDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "NumberOfCopies",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BookDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "NumberOfCopies",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BookDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "NumberOfCopies",
                value: 1);

            migrationBuilder.UpdateData(
                table: "bookCopies",
                keyColumn: "Id",
                keyValue: 1,
                column: "BookDetailsId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "bookCopies",
                keyColumn: "Id",
                keyValue: 2,
                column: "BookDetailsId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "bookCopies",
                keyColumn: "Id",
                keyValue: 3,
                column: "BookDetailsId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "bookCopies",
                keyColumn: "Id",
                keyValue: 4,
                column: "BookDetailsId",
                value: 2);
        }
    }
}
