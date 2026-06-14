using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlSalidas.API.Migrations
{
    /// <inheritdoc />
    public partial class totalImporte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Viaticos",
                table: "SalidaFuncionarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ImportePernoctes",
                table: "ResumenesMensuales",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ImporteTotal",
                table: "ResumenesMensuales",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Viaticos",
                table: "ResumenesMensuales",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Viaticos",
                table: "SalidaFuncionarios");

            migrationBuilder.DropColumn(
                name: "ImportePernoctes",
                table: "ResumenesMensuales");

            migrationBuilder.DropColumn(
                name: "ImporteTotal",
                table: "ResumenesMensuales");

            migrationBuilder.DropColumn(
                name: "Viaticos",
                table: "ResumenesMensuales");
        }
    }
}
