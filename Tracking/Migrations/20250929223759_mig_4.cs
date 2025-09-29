using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tracking.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciRol_Rol_RollerId",
                table: "KullaniciRol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "Roller");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roller",
                table: "Roller",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciRol_Roller_RollerId",
                table: "KullaniciRol",
                column: "RollerId",
                principalTable: "Roller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciRol_Roller_RollerId",
                table: "KullaniciRol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roller",
                table: "Roller");

            migrationBuilder.RenameTable(
                name: "Roller",
                newName: "Rol");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciRol_Rol_RollerId",
                table: "KullaniciRol",
                column: "RollerId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
