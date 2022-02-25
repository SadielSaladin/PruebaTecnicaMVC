using Microsoft.EntityFrameworkCore.Migrations;

namespace Fifa2022.Migrations
{
    public partial class migracionconRelaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Equipo_idId",
                table: "Jugadores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado_idId",
                table: "Jugadores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Equipos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_Equipo_idId",
                table: "Jugadores",
                column: "Equipo_idId");

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_Estado_idId",
                table: "Jugadores",
                column: "Estado_idId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_EstadoId",
                table: "Equipos",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Estados_EstadoId",
                table: "Equipos",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Equipos_Equipo_idId",
                table: "Jugadores",
                column: "Equipo_idId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Estados_Estado_idId",
                table: "Jugadores",
                column: "Estado_idId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Estados_EstadoId",
                table: "Equipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Equipos_Equipo_idId",
                table: "Jugadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Estados_Estado_idId",
                table: "Jugadores");

            migrationBuilder.DropIndex(
                name: "IX_Jugadores_Equipo_idId",
                table: "Jugadores");

            migrationBuilder.DropIndex(
                name: "IX_Jugadores_Estado_idId",
                table: "Jugadores");

            migrationBuilder.DropIndex(
                name: "IX_Equipos_EstadoId",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "Equipo_idId",
                table: "Jugadores");

            migrationBuilder.DropColumn(
                name: "Estado_idId",
                table: "Jugadores");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Equipos");
        }
    }
}
