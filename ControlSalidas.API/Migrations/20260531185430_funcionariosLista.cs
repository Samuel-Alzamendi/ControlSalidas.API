using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlSalidas.API.Migrations
{
    /// <inheritdoc />
    public partial class funcionariosLista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitales_Salidas_Salidaid",
                table: "Hospitales");

            migrationBuilder.DropForeignKey(
                name: "FK_SalidaFuncionarios_Funcionarios_funcionarioId",
                table: "SalidaFuncionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_SalidaFuncionarios_Salidas_salidaId",
                table: "SalidaFuncionarios");

            migrationBuilder.RenameColumn(
                name: "salidasCalculadas",
                table: "Salidas",
                newName: "SalidasCalculadas");

            migrationBuilder.RenameColumn(
                name: "noches",
                table: "Salidas",
                newName: "Noches");

            migrationBuilder.RenameColumn(
                name: "fechaSalida",
                table: "Salidas",
                newName: "FechaSalida");

            migrationBuilder.RenameColumn(
                name: "fechaLlegada",
                table: "Salidas",
                newName: "FechaLlegada");

            migrationBuilder.RenameColumn(
                name: "dias",
                table: "Salidas",
                newName: "Dias");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Salidas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "salidaId",
                table: "SalidaFuncionarios",
                newName: "SalidaId");

            migrationBuilder.RenameColumn(
                name: "funcionarioId",
                table: "SalidaFuncionarios",
                newName: "FuncionarioId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SalidaFuncionarios",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_SalidaFuncionarios_salidaId",
                table: "SalidaFuncionarios",
                newName: "IX_SalidaFuncionarios_SalidaId");

            migrationBuilder.RenameIndex(
                name: "IX_SalidaFuncionarios_funcionarioId",
                table: "SalidaFuncionarios",
                newName: "IX_SalidaFuncionarios_FuncionarioId");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Hospitales",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "departamento",
                table: "Hospitales",
                newName: "Departamento");

            migrationBuilder.RenameColumn(
                name: "ciudad",
                table: "Hospitales",
                newName: "Ciudad");

            migrationBuilder.RenameColumn(
                name: "Salidaid",
                table: "Hospitales",
                newName: "SalidaId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Hospitales",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Hospitales_Salidaid",
                table: "Hospitales",
                newName: "IX_Hospitales_SalidaId");

            migrationBuilder.AddColumn<int>(
                name: "SalidaId",
                table: "Funcionarios",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_SalidaId",
                table: "Funcionarios",
                column: "SalidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Salidas_SalidaId",
                table: "Funcionarios",
                column: "SalidaId",
                principalTable: "Salidas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitales_Salidas_SalidaId",
                table: "Hospitales",
                column: "SalidaId",
                principalTable: "Salidas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaFuncionarios_Funcionarios_FuncionarioId",
                table: "SalidaFuncionarios",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaFuncionarios_Salidas_SalidaId",
                table: "SalidaFuncionarios",
                column: "SalidaId",
                principalTable: "Salidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Salidas_SalidaId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitales_Salidas_SalidaId",
                table: "Hospitales");

            migrationBuilder.DropForeignKey(
                name: "FK_SalidaFuncionarios_Funcionarios_FuncionarioId",
                table: "SalidaFuncionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_SalidaFuncionarios_Salidas_SalidaId",
                table: "SalidaFuncionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_SalidaId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "SalidaId",
                table: "Funcionarios");

            migrationBuilder.RenameColumn(
                name: "SalidasCalculadas",
                table: "Salidas",
                newName: "salidasCalculadas");

            migrationBuilder.RenameColumn(
                name: "Noches",
                table: "Salidas",
                newName: "noches");

            migrationBuilder.RenameColumn(
                name: "FechaSalida",
                table: "Salidas",
                newName: "fechaSalida");

            migrationBuilder.RenameColumn(
                name: "FechaLlegada",
                table: "Salidas",
                newName: "fechaLlegada");

            migrationBuilder.RenameColumn(
                name: "Dias",
                table: "Salidas",
                newName: "dias");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Salidas",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SalidaId",
                table: "SalidaFuncionarios",
                newName: "salidaId");

            migrationBuilder.RenameColumn(
                name: "FuncionarioId",
                table: "SalidaFuncionarios",
                newName: "funcionarioId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SalidaFuncionarios",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_SalidaFuncionarios_SalidaId",
                table: "SalidaFuncionarios",
                newName: "IX_SalidaFuncionarios_salidaId");

            migrationBuilder.RenameIndex(
                name: "IX_SalidaFuncionarios_FuncionarioId",
                table: "SalidaFuncionarios",
                newName: "IX_SalidaFuncionarios_funcionarioId");

            migrationBuilder.RenameColumn(
                name: "SalidaId",
                table: "Hospitales",
                newName: "Salidaid");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Hospitales",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Departamento",
                table: "Hospitales",
                newName: "departamento");

            migrationBuilder.RenameColumn(
                name: "Ciudad",
                table: "Hospitales",
                newName: "ciudad");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Hospitales",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Hospitales_SalidaId",
                table: "Hospitales",
                newName: "IX_Hospitales_Salidaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitales_Salidas_Salidaid",
                table: "Hospitales",
                column: "Salidaid",
                principalTable: "Salidas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaFuncionarios_Funcionarios_funcionarioId",
                table: "SalidaFuncionarios",
                column: "funcionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaFuncionarios_Salidas_salidaId",
                table: "SalidaFuncionarios",
                column: "salidaId",
                principalTable: "Salidas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
