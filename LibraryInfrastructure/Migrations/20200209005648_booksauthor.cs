using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotekUppgift.Migrations
{
    public partial class booksauthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopy_BookDetails_BookDetailsID",
                table: "BookCopy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCopy",
                table: "BookCopy");

            migrationBuilder.RenameTable(
                name: "BookCopy",
                newName: "bookCopies");

            migrationBuilder.RenameIndex(
                name: "IX_BookCopy_BookDetailsID",
                table: "bookCopies",
                newName: "IX_bookCopies_BookDetailsID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookCopies",
                table: "bookCopies",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "booksFromAuthor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NumberOfCopies = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booksFromAuthor", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_bookCopies_BookDetails_BookDetailsID",
                table: "bookCopies",
                column: "BookDetailsID",
                principalTable: "BookDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookCopies_BookDetails_BookDetailsID",
                table: "bookCopies");

            migrationBuilder.DropTable(
                name: "booksFromAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookCopies",
                table: "bookCopies");

            migrationBuilder.RenameTable(
                name: "bookCopies",
                newName: "BookCopy");

            migrationBuilder.RenameIndex(
                name: "IX_bookCopies_BookDetailsID",
                table: "BookCopy",
                newName: "IX_BookCopy_BookDetailsID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCopy",
                table: "BookCopy",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopy_BookDetails_BookDetailsID",
                table: "BookCopy",
                column: "BookDetailsID",
                principalTable: "BookDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
