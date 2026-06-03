using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlSalidas.API.Migrations
{
    /// <inheritdoc />
    public partial class cambioEnSalidasFuncionarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Salidas_SalidaId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_SalidaFuncionarios_Funcionarios_FuncionarioId",
                table: "SalidaFuncionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_SalidaFuncionarios_Salidas_SalidaId",
                table: "SalidaFuncionarios");

            migrationBuilder.DropIndex(
                name: "IX_SalidaFuncionarios_FuncionarioId",
                table: "SalidaFuncionarios");

            migrationBuilder.DropIndex(
                name: "IX_SalidaFuncionarios_SalidaId",
                table: "SalidaFuncionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_SalidaId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "SalidaId",
                table: "Funcionarios");

            migrationBuilder.AddColumn<string>(
                name: "IdFuncionarios",
                table: "Salidas",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdFuncionarios",
                table: "Salidas");

            migrationBuilder.AddColumn<int>(
                name: "SalidaId",
                table: "Funcionarios",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalidaFuncionarios_FuncionarioId",
                table: "SalidaFuncionarios",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_SalidaFuncionarios_SalidaId",
                table: "SalidaFuncionarios",
                column: "SalidaId");

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
    }
}
