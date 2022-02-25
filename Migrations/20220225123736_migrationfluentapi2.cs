using Microsoft.EntityFrameworkCore.Migrations;

namespace Fifa2022.Migrations
{
    public partial class migrationfluentapi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Equipos_Id_author",
                table: "Jugadores");

            migrationBuilder.RenameColumn(
                name: "Id_author",
                table: "Jugadores",
                newName: "Id_Equipo");

            migrationBuilder.RenameIndex(
                name: "IX_Jugadores_Id_author",
                table: "Jugadores",
                newName: "IX_Jugadores_Id_Equipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Equipos_Id_Equipo",
                table: "Jugadores",
                column: "Id_Equipo",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Equipos_Id_Equipo",
                table: "Jugadores");

            migrationBuilder.RenameColumn(
                name: "Id_Equipo",
                table: "Jugadores",
                newName: "Id_author");

            migrationBuilder.RenameIndex(
                name: "IX_Jugadores_Id_Equipo",
                table: "Jugadores",
                newName: "IX_Jugadores_Id_author");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Equipos_Id_author",
                table: "Jugadores",
                column: "Id_author",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
