using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotekUppgift.Migrations
{
    public partial class numberofcopies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopy_BookDetails_DetailsID",
                table: "BookCopy");

            migrationBuilder.DropIndex(
                name: "IX_BookCopy_DetailsID",
                table: "BookCopy");

            migrationBuilder.DropColumn(
                name: "DetailsID",
                table: "BookCopy");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfCopies",
                table: "BookDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookDetailsID",
                table: "BookCopy",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookCopy_BookDetailsID",
                table: "BookCopy",
                column: "BookDetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopy_BookDetails_BookDetailsID",
                table: "BookCopy",
                column: "BookDetailsID",
                principalTable: "BookDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopy_BookDetails_BookDetailsID",
                table: "BookCopy");

            migrationBuilder.DropIndex(
                name: "IX_BookCopy_BookDetailsID",
                table: "BookCopy");

            migrationBuilder.DropColumn(
                name: "NumberOfCopies",
                table: "BookDetails");

            migrationBuilder.DropColumn(
                name: "BookDetailsID",
                table: "BookCopy");

            migrationBuilder.AddColumn<int>(
                name: "DetailsID",
                table: "BookCopy",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookCopy_DetailsID",
                table: "BookCopy",
                column: "DetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopy_BookDetails_DetailsID",
                table: "BookCopy",
                column: "DetailsID",
                principalTable: "BookDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
