using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlSalidas.API.Migrations
{
    /// <inheritdoc />
    public partial class horasExtraCalculadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HorasSalidaFuncionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    SalidaId = table.Column<int>(type: "INTEGER", nullable: false),
                    HorasNormales = table.Column<double>(type: "REAL", nullable: false),
                    HorasExtra = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorasSalidaFuncionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorasSalidaFuncionarios_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorasSalidaFuncionarios_Salidas_SalidaId",
                        column: x => x.SalidaId,
                        principalTable: "Salidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumenesMensuales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    Anio = table.Column<int>(type: "INTEGER", nullable: false),
                    Mes = table.Column<int>(type: "INTEGER", nullable: false),
                    HorasNormales = table.Column<double>(type: "REAL", nullable: false),
                    HorasExtra = table.Column<double>(type: "REAL", nullable: false),
                    CantidadSalidas = table.Column<int>(type: "INTEGER", nullable: false),
                    DiasFuera = table.Column<int>(type: "INTEGER", nullable: false),
                    Noches = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumenesMensuales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumenesMensuales_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HorasSalidaFuncionarios_FuncionarioId",
                table: "HorasSalidaFuncionarios",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_HorasSalidaFuncionarios_SalidaId",
                table: "HorasSalidaFuncionarios",
                column: "SalidaId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumenesMensuales_FuncionarioId",
                table: "ResumenesMensuales",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorasSalidaFuncionarios");

            migrationBuilder.DropTable(
                name: "ResumenesMensuales");
        }
    }
}
