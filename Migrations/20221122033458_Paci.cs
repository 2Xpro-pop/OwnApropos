using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OwnApropos.Migrations
{
    /// <inheritdoc />
    public partial class Paci : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PalateId",
                table: "Pacients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PalatelId",
                table: "Pacients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "Pacients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pacients_PalateId",
                table: "Pacients",
                column: "PalateId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacients_PersonalId",
                table: "Pacients",
                column: "PersonalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacients_Palates_PalateId",
                table: "Pacients",
                column: "PalateId",
                principalTable: "Palates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacients_Personals_PersonalId",
                table: "Pacients",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacients_Palates_PalateId",
                table: "Pacients");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacients_Personals_PersonalId",
                table: "Pacients");

            migrationBuilder.DropIndex(
                name: "IX_Pacients_PalateId",
                table: "Pacients");

            migrationBuilder.DropIndex(
                name: "IX_Pacients_PersonalId",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "PalateId",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "PalatelId",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "Pacients");
        }
    }
}
