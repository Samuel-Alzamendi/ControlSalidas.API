using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlSalidas.API.Migrations
{
    /// <inheritdoc />
    public partial class hospitalesYfuncionariosAct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalidaFuncionarios_Funcionarios_funcionarioId",
                table: "SalidaFuncionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Salidas_Hospitales_hospitalId",
                table: "Salidas");

            migrationBuilder.DropIndex(
                name: "IX_Salidas_hospitalId",
                table: "Salidas");

            migrationBuilder.DropColumn(
                name: "hospitalId",
                table: "Salidas");

            migrationBuilder.RenameColumn(
                name: "funcionarioId",
                table: "SalidaFuncionarios",
                newName: "funcionarioid");

            migrationBuilder.RenameIndex(
                name: "IX_SalidaFuncionarios_funcionarioId",
                table: "SalidaFuncionarios",
                newName: "IX_SalidaFuncionarios_funcionarioid");

            migrationBuilder.AddColumn<int>(
                name: "Salidaid",
                table: "Hospitales",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hospitales_Salidaid",
                table: "Hospitales",
                column: "Salidaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitales_Salidas_Salidaid",
                table: "Hospitales",
                column: "Salidaid",
                principalTable: "Salidas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaFuncionarios_Funcionarios_funcionarioid",
                table: "SalidaFuncionarios",
                column: "funcionarioid",
                principalTable: "Funcionarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitales_Salidas_Salidaid",
                table: "Hospitales");

            migrationBuilder.DropForeignKey(
                name: "FK_SalidaFuncionarios_Funcionarios_funcionarioid",
                table: "SalidaFuncionarios");

            migrationBuilder.DropIndex(
                name: "IX_Hospitales_Salidaid",
                table: "Hospitales");

            migrationBuilder.DropColumn(
                name: "Salidaid",
                table: "Hospitales");

            migrationBuilder.RenameColumn(
                name: "funcionarioid",
                table: "SalidaFuncionarios",
                newName: "funcionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_SalidaFuncionarios_funcionarioid",
                table: "SalidaFuncionarios",
                newName: "IX_SalidaFuncionarios_funcionarioId");

            migrationBuilder.AddColumn<int>(
                name: "hospitalId",
                table: "Salidas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Salidas_hospitalId",
                table: "Salidas",
                column: "hospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaFuncionarios_Funcionarios_funcionarioId",
                table: "SalidaFuncionarios",
                column: "funcionarioId",
                principalTable: "Funcionarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salidas_Hospitales_hospitalId",
                table: "Salidas",
                column: "hospitalId",
                principalTable: "Hospitales",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
