using Microsoft.EntityFrameworkCore.Migrations;

namespace Fifa2022.Migrations
{
    public partial class migracion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Estados_EstadoId",
                table: "Equipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Equipos_EquipoId",
                table: "Jugadores");

            migrationBuilder.DropIndex(
                name: "IX_Jugadores_EquipoId",
                table: "Jugadores");

            migrationBuilder.DropColumn(
                name: "EquipoId",
                table: "Jugadores");

            migrationBuilder.RenameColumn(
                name: "EstadoId",
                table: "Equipos",
                newName: "EstadoID");

            migrationBuilder.RenameIndex(
                name: "IX_Equipos_EstadoId",
                table: "Equipos",
                newName: "IX_Equipos_EstadoID");

            migrationBuilder.AlterColumn<int>(
                name: "EstadoID",
                table: "Equipos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Estados_EstadoID",
                table: "Equipos",
                column: "EstadoID",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Estados_EstadoID",
                table: "Equipos");

            migrationBuilder.RenameColumn(
                name: "EstadoID",
                table: "Equipos",
                newName: "EstadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipos_EstadoID",
                table: "Equipos",
                newName: "IX_Equipos_EstadoId");

            migrationBuilder.AddColumn<int>(
                name: "EquipoId",
                table: "Jugadores",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstadoId",
                table: "Equipos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_EquipoId",
                table: "Jugadores",
                column: "EquipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Estados_EstadoId",
                table: "Equipos",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Equipos_EquipoId",
                table: "Jugadores",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
