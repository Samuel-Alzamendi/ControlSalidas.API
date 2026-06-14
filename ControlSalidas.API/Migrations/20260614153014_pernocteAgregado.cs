using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlSalidas.API.Migrations
{
    /// <inheritdoc />
    public partial class pernocteAgregado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ImportePernoctes",
                table: "SalidaFuncionarios",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Pernoctes",
                table: "SalidaFuncionarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorPernocte",
                table: "Funcionarios",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImportePernoctes",
                table: "SalidaFuncionarios");

            migrationBuilder.DropColumn(
                name: "Pernoctes",
                table: "SalidaFuncionarios");

            migrationBuilder.DropColumn(
                name: "ValorPernocte",
                table: "Funcionarios");
        }
    }
}
