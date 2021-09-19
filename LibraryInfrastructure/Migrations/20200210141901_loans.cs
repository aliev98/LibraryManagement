using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotekUppgift.Migrations
{
    public partial class loans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberDetailsID",
                table: "BookDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: false),
                    MemberID = table.Column<int>(nullable: false),
                    aMemberID = table.Column<int>(nullable: true),
                    BookDetailsID = table.Column<int>(nullable: false),
                    aLoanID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Loans_bookCopies_aLoanID",
                        column: x => x.aLoanID,
                        principalTable: "bookCopies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loans_MemberDetails_aMemberID",
                        column: x => x.aMemberID,
                        principalTable: "MemberDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookDetails_MemberDetailsID",
                table: "BookDetails",
                column: "MemberDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_aLoanID",
                table: "Loans",
                column: "aLoanID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_aMemberID",
                table: "Loans",
                column: "aMemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetails_MemberDetails_MemberDetailsID",
                table: "BookDetails",
                column: "MemberDetailsID",
                principalTable: "MemberDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDetails_MemberDetails_MemberDetailsID",
                table: "BookDetails");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_BookDetails_MemberDetailsID",
                table: "BookDetails");

            migrationBuilder.DropColumn(
                name: "MemberDetailsID",
                table: "BookDetails");
        }
    }
}
