using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OwnApropos.Migrations
{
    /// <inheritdoc />
    public partial class PalatesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Palates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    FillialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Palates_Fillials_FillialId",
                        column: x => x.FillialId,
                        principalTable: "Fillials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Palates_FillialId",
                table: "Palates",
                column: "FillialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Palates");
        }
    }
}
