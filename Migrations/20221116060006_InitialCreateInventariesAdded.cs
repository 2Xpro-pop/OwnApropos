using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OwnApropos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateInventariesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FillialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Fillials_FillialId",
                        column: x => x.FillialId,
                        principalTable: "Fillials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personals_FillialId",
                table: "Personals",
                column: "FillialId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_FillialId",
                table: "Inventories",
                column: "FillialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personals_Fillials_FillialId",
                table: "Personals",
                column: "FillialId",
                principalTable: "Fillials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personals_Fillials_FillialId",
                table: "Personals");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Personals_FillialId",
                table: "Personals");
        }
    }
}
