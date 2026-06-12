using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlSalidas.API.Migrations
{
    /// <inheritdoc />
    public partial class agregarHorariosFuncionarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorarioLaboralEntrada",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "HorarioLaboralSalida",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "cantidadHorasExtra",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "cantidadHorasPertenecientes",
                table: "Funcionarios");

            migrationBuilder.CreateTable(
                name: "HorarioLaboral",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiaSemana = table.Column<int>(type: "INTEGER", nullable: false),
                    HoraEntrada = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    HoraSalida = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioLaboral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorarioLaboral_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HorarioLaboral_FuncionarioId",
                table: "HorarioLaboral",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorarioLaboral");

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

            migrationBuilder.AddColumn<int>(
                name: "cantidadHorasExtra",
                table: "Funcionarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "cantidadHorasPertenecientes",
                table: "Funcionarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
