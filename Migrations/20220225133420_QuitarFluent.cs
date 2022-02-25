using Microsoft.EntityFrameworkCore.Migrations;

namespace Fifa2022.Migrations
{
    public partial class QuitarFluent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Equipos_Id_Equipo",
                table: "Jugadores");

            migrationBuilder.RenameColumn(
                name: "Id_Equipo",
                table: "Jugadores",
                newName: "EquipoId");

            migrationBuilder.RenameIndex(
                name: "IX_Jugadores_Id_Equipo",
                table: "Jugadores",
                newName: "IX_Jugadores_EquipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Equipos_EquipoId",
                table: "Jugadores",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Equipos_EquipoId",
                table: "Jugadores");

            migrationBuilder.RenameColumn(
                name: "EquipoId",
                table: "Jugadores",
                newName: "Id_Equipo");

            migrationBuilder.RenameIndex(
                name: "IX_Jugadores_EquipoId",
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
    }
}
