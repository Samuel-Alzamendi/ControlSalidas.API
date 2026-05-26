using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlSalidas.API.Migrations
{
    /// <inheritdoc />
    public partial class salidaFuncionarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalidaFuncionario_Funcionarios_funcionarioId",
                table: "SalidaFuncionario");

            migrationBuilder.DropForeignKey(
                name: "FK_SalidaFuncionario_Salidas_salidaId",
                table: "SalidaFuncionario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalidaFuncionario",
                table: "SalidaFuncionario");

            migrationBuilder.DropColumn(
                name: "funcionarioId",
                table: "Salidas");

            migrationBuilder.RenameTable(
                name: "SalidaFuncionario",
                newName: "SalidaFuncionarios");

            migrationBuilder.RenameIndex(
                name: "IX_SalidaFuncionario_salidaId",
                table: "SalidaFuncionarios",
                newName: "IX_SalidaFuncionarios_salidaId");

            migrationBuilder.RenameIndex(
                name: "IX_SalidaFuncionario_funcionarioId",
                table: "SalidaFuncionarios",
                newName: "IX_SalidaFuncionarios_funcionarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalidaFuncionarios",
                table: "SalidaFuncionarios",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaFuncionarios_Funcionarios_funcionarioId",
                table: "SalidaFuncionarios",
                column: "funcionarioId",
                principalTable: "Funcionarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaFuncionarios_Salidas_salidaId",
                table: "SalidaFuncionarios",
                column: "salidaId",
                principalTable: "Salidas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalidaFuncionarios_Funcionarios_funcionarioId",
                table: "SalidaFuncionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_SalidaFuncionarios_Salidas_salidaId",
                table: "SalidaFuncionarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalidaFuncionarios",
                table: "SalidaFuncionarios");

            migrationBuilder.RenameTable(
                name: "SalidaFuncionarios",
                newName: "SalidaFuncionario");

            migrationBuilder.RenameIndex(
                name: "IX_SalidaFuncionarios_salidaId",
                table: "SalidaFuncionario",
                newName: "IX_SalidaFuncionario_salidaId");

            migrationBuilder.RenameIndex(
                name: "IX_SalidaFuncionarios_funcionarioId",
                table: "SalidaFuncionario",
                newName: "IX_SalidaFuncionario_funcionarioId");

            migrationBuilder.AddColumn<int>(
                name: "funcionarioId",
                table: "Salidas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalidaFuncionario",
                table: "SalidaFuncionario",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaFuncionario_Funcionarios_funcionarioId",
                table: "SalidaFuncionario",
                column: "funcionarioId",
                principalTable: "Funcionarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaFuncionario_Salidas_salidaId",
                table: "SalidaFuncionario",
                column: "salidaId",
                principalTable: "Salidas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
