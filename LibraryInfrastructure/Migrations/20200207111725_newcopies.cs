using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotekUppgift.Migrations
{
    public partial class newcopies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "copies",
                table: "BookDetails");

            migrationBuilder.CreateTable(
                name: "BookCopy",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopy", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookCopy_BookDetails_DetailsID",
                        column: x => x.DetailsID,
                        principalTable: "BookDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCopy_DetailsID",
                table: "BookCopy",
                column: "DetailsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCopy");

            migrationBuilder.AddColumn<int>(
                name: "copies",
                table: "BookDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
