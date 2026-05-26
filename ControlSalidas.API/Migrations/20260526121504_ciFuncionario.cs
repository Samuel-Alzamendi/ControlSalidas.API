using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlSalidas.API.Migrations
{
    /// <inheritdoc />
    public partial class ciFuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalidaFuncionarios_Funcionarios_funcionarioid",
                table: "SalidaFuncionarios");

            migrationBuilder.RenameColumn(
                name: "funcionarioid",
                table: "SalidaFuncionarios",
                newName: "funcionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_SalidaFuncionarios_funcionarioid",
                table: "SalidaFuncionarios",
                newName: "IX_SalidaFuncionarios_funcionarioId");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Funcionarios",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "noches",
                table: "Funcionarios",
                newName: "Noches");

            migrationBuilder.RenameColumn(
                name: "diasFuera",
                table: "Funcionarios",
                newName: "DiasFuera");

            migrationBuilder.RenameColumn(
                name: "cargo",
                table: "Funcionarios",
                newName: "Cargo");

            migrationBuilder.RenameColumn(
                name: "cantidadSalidas",
                table: "Funcionarios",
                newName: "CantidadSalidas");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Funcionarios",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Ci",
                table: "Funcionarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaFuncionarios_Funcionarios_funcionarioId",
                table: "SalidaFuncionarios",
                column: "funcionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalidaFuncionarios_Funcionarios_funcionarioId",
                table: "SalidaFuncionarios");

            migrationBuilder.DropColumn(
                name: "Ci",
                table: "Funcionarios");

            migrationBuilder.RenameColumn(
                name: "funcionarioId",
                table: "SalidaFuncionarios",
                newName: "funcionarioid");

            migrationBuilder.RenameIndex(
                name: "IX_SalidaFuncionarios_funcionarioId",
                table: "SalidaFuncionarios",
                newName: "IX_SalidaFuncionarios_funcionarioid");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Funcionarios",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Noches",
                table: "Funcionarios",
                newName: "noches");

            migrationBuilder.RenameColumn(
                name: "DiasFuera",
                table: "Funcionarios",
                newName: "diasFuera");

            migrationBuilder.RenameColumn(
                name: "Cargo",
                table: "Funcionarios",
                newName: "cargo");

            migrationBuilder.RenameColumn(
                name: "CantidadSalidas",
                table: "Funcionarios",
                newName: "cantidadSalidas");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Funcionarios",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaFuncionarios_Funcionarios_funcionarioid",
                table: "SalidaFuncionarios",
                column: "funcionarioid",
                principalTable: "Funcionarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
