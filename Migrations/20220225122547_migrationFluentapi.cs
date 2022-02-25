using Microsoft.EntityFrameworkCore.Migrations;

namespace Fifa2022.Migrations
{
    public partial class migrationFluentapi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Equipos_Equipo_idId",
                table: "Jugadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Estados_Estado_idId",
                table: "Jugadores");

            migrationBuilder.DropIndex(
                name: "IX_Jugadores_Equipo_idId",
                table: "Jugadores");

            migrationBuilder.DropColumn(
                name: "Equipo_idId",
                table: "Jugadores");

            migrationBuilder.RenameColumn(
                name: "Estado_idId",
                table: "Jugadores",
                newName: "EstadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Jugadores_Estado_idId",
                table: "Jugadores",
                newName: "IX_Jugadores_EstadoId");

            migrationBuilder.AlterColumn<string>(
                name: "Pasporte",
                table: "Jugadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Estado_id",
                table: "Jugadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_Estado_id",
                table: "Jugadores",
                column: "Estado_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Equipos_Estado_id",
                table: "Jugadores",
                column: "Estado_id",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Estados_EstadoId",
                table: "Jugadores",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Equipos_Estado_id",
                table: "Jugadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Estados_EstadoId",
                table: "Jugadores");

            migrationBuilder.DropIndex(
                name: "IX_Jugadores_Estado_id",
                table: "Jugadores");

            migrationBuilder.DropColumn(
                name: "Estado_id",
                table: "Jugadores");

            migrationBuilder.RenameColumn(
                name: "EstadoId",
                table: "Jugadores",
                newName: "Estado_idId");

            migrationBuilder.RenameIndex(
                name: "IX_Jugadores_EstadoId",
                table: "Jugadores",
                newName: "IX_Jugadores_Estado_idId");

            migrationBuilder.AlterColumn<string>(
                name: "Pasporte",
                table: "Jugadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Equipo_idId",
                table: "Jugadores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_Equipo_idId",
                table: "Jugadores",
                column: "Equipo_idId");

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
    }
}
