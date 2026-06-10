using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlSalidas.API.Migrations
{
    /// <inheritdoc />
    public partial class HorariosLaboralesEnSalida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitales_Salidas_SalidaId",
                table: "Hospitales");

            migrationBuilder.DropIndex(
                name: "IX_Hospitales_SalidaId",
                table: "Hospitales");

            migrationBuilder.DropColumn(
                name: "SalidaId",
                table: "Hospitales");

            migrationBuilder.AddColumn<string>(
                name: "HospitalesIds",
                table: "Salidas",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "HorarioLaboralEntrada",
                table: "Funcionarios",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "HorarioLaboralSalida",
                table: "Funcionarios",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HospitalesIds",
                table: "Salidas");

            migrationBuilder.DropColumn(
                name: "HorarioLaboralEntrada",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "HorarioLaboralSalida",
                table: "Funcionarios");

            migrationBuilder.AddColumn<int>(
                name: "SalidaId",
                table: "Hospitales",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hospitales_SalidaId",
                table: "Hospitales",
                column: "SalidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitales_Salidas_SalidaId",
                table: "Hospitales",
                column: "SalidaId",
                principalTable: "Salidas",
                principalColumn: "Id");
        }
    }
}
