using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlSalidas.API.Migrations
{
    /// <inheritdoc />
    public partial class comienzoSalidasNuevas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salidas_Funcionarios_funcionarioId",
                table: "Salidas");

            migrationBuilder.DropIndex(
                name: "IX_Salidas_funcionarioId",
                table: "Salidas");

            migrationBuilder.AddColumn<int>(
                name: "hospitalId",
                table: "Salidas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SalidaFuncionario",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    salidaId = table.Column<int>(type: "INTEGER", nullable: false),
                    funcionarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidaFuncionario", x => x.id);
                    table.ForeignKey(
                        name: "FK_SalidaFuncionario_Funcionarios_funcionarioId",
                        column: x => x.funcionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalidaFuncionario_Salidas_salidaId",
                        column: x => x.salidaId,
                        principalTable: "Salidas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salidas_hospitalId",
                table: "Salidas",
                column: "hospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_SalidaFuncionario_funcionarioId",
                table: "SalidaFuncionario",
                column: "funcionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_SalidaFuncionario_salidaId",
                table: "SalidaFuncionario",
                column: "salidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salidas_Hospitales_hospitalId",
                table: "Salidas",
                column: "hospitalId",
                principalTable: "Hospitales",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salidas_Hospitales_hospitalId",
                table: "Salidas");

            migrationBuilder.DropTable(
                name: "SalidaFuncionario");

            migrationBuilder.DropIndex(
                name: "IX_Salidas_hospitalId",
                table: "Salidas");

            migrationBuilder.DropColumn(
                name: "hospitalId",
                table: "Salidas");

            migrationBuilder.CreateIndex(
                name: "IX_Salidas_funcionarioId",
                table: "Salidas",
                column: "funcionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salidas_Funcionarios_funcionarioId",
                table: "Salidas",
                column: "funcionarioId",
                principalTable: "Funcionarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
