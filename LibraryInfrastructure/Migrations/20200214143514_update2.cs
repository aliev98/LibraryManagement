using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotekUppgift.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookCopies_BookDetails_BookDetailsID",
                table: "bookCopies");

            migrationBuilder.DropForeignKey(
                name: "FK_BookDetails_Authors_AuthorID",
                table: "BookDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BookDetails_MemberDetails_MemberDetailsID",
                table: "BookDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_bookCopies_aLoanID",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_MemberDetails_aMemberID",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_aLoanID",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_aMemberID",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_BookDetails_MemberDetailsID",
                table: "BookDetails");

            migrationBuilder.DropColumn(
                name: "BookDetailsID",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "aLoanID",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "aMemberID",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "MemberDetailsID",
                table: "BookDetails");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "MemberDetails",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Loans",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "BookDetails",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "BookDetails",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_BookDetails_AuthorID",
                table: "BookDetails",
                newName: "IX_BookDetails_AuthorId");

            migrationBuilder.RenameColumn(
                name: "BookDetailsID",
                table: "bookCopies",
                newName: "BookDetailsId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "bookCopies",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_bookCopies_BookDetailsID",
                table: "bookCopies",
                newName: "IX_bookCopies_BookDetailsId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Authors",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "BookCopyId",
                table: "Loans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MemberDetailsId",
                table: "Loans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "bookCopies",
                columns: new[] { "Id", "BookDetailsId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookCopyId",
                table: "Loans",
                column: "BookCopyId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_MemberDetailsId",
                table: "Loans",
                column: "MemberDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookCopies_BookDetails_BookDetailsId",
                table: "bookCopies",
                column: "BookDetailsId",
                principalTable: "BookDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetails_Authors_AuthorId",
                table: "BookDetails",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_bookCopies_BookCopyId",
                table: "Loans",
                column: "BookCopyId",
                principalTable: "bookCopies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_MemberDetails_MemberDetailsId",
                table: "Loans",
                column: "MemberDetailsId",
                principalTable: "MemberDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookCopies_BookDetails_BookDetailsId",
                table: "bookCopies");

            migrationBuilder.DropForeignKey(
                name: "FK_BookDetails_Authors_AuthorId",
                table: "BookDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_bookCopies_BookCopyId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_MemberDetails_MemberDetailsId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_BookCopyId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_MemberDetailsId",
                table: "Loans");

            migrationBuilder.DeleteData(
                table: "bookCopies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "bookCopies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "bookCopies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "bookCopies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "BookCopyId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "MemberDetailsId",
                table: "Loans");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MemberDetails",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Loans",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "BookDetails",
                newName: "AuthorID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BookDetails",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_BookDetails_AuthorId",
                table: "BookDetails",
                newName: "IX_BookDetails_AuthorID");

            migrationBuilder.RenameColumn(
                name: "BookDetailsId",
                table: "bookCopies",
                newName: "BookDetailsID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "bookCopies",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_bookCopies_BookDetailsId",
                table: "bookCopies",
                newName: "IX_bookCopies_BookDetailsID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Authors",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "BookDetailsID",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MemberID",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "aLoanID",
                table: "Loans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "aMemberID",
                table: "Loans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberDetailsID",
                table: "BookDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_aLoanID",
                table: "Loans",
                column: "aLoanID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_aMemberID",
                table: "Loans",
                column: "aMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_BookDetails_MemberDetailsID",
                table: "BookDetails",
                column: "MemberDetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_bookCopies_BookDetails_BookDetailsID",
                table: "bookCopies",
                column: "BookDetailsID",
                principalTable: "BookDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetails_Authors_AuthorID",
                table: "BookDetails",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetails_MemberDetails_MemberDetailsID",
                table: "BookDetails",
                column: "MemberDetailsID",
                principalTable: "MemberDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_bookCopies_aLoanID",
                table: "Loans",
                column: "aLoanID",
                principalTable: "bookCopies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_MemberDetails_aMemberID",
                table: "Loans",
                column: "aMemberID",
                principalTable: "MemberDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
