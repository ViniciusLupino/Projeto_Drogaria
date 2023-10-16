using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoDrogas.Migrations
{
    /// <inheritdoc />
    public partial class InicialContext2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbCompra_tbCliente_ClienteId",
                table: "tbCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_tbVenda_tbFornecedor_FornecedorId",
                table: "tbVenda");

            migrationBuilder.RenameColumn(
                name: "FornecedorId",
                table: "tbVenda",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_tbVenda_FornecedorId",
                table: "tbVenda",
                newName: "IX_tbVenda_ClienteId");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "tbCompra",
                newName: "FornecedorId");

            migrationBuilder.RenameIndex(
                name: "IX_tbCompra_ClienteId",
                table: "tbCompra",
                newName: "IX_tbCompra_FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbCompra_tbFornecedor_FornecedorId",
                table: "tbCompra",
                column: "FornecedorId",
                principalTable: "tbFornecedor",
                principalColumn: "FornecedorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbVenda_tbCliente_ClienteId",
                table: "tbVenda",
                column: "ClienteId",
                principalTable: "tbCliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbCompra_tbFornecedor_FornecedorId",
                table: "tbCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_tbVenda_tbCliente_ClienteId",
                table: "tbVenda");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "tbVenda",
                newName: "FornecedorId");

            migrationBuilder.RenameIndex(
                name: "IX_tbVenda_ClienteId",
                table: "tbVenda",
                newName: "IX_tbVenda_FornecedorId");

            migrationBuilder.RenameColumn(
                name: "FornecedorId",
                table: "tbCompra",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_tbCompra_FornecedorId",
                table: "tbCompra",
                newName: "IX_tbCompra_ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbCompra_tbCliente_ClienteId",
                table: "tbCompra",
                column: "ClienteId",
                principalTable: "tbCliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbVenda_tbFornecedor_FornecedorId",
                table: "tbVenda",
                column: "FornecedorId",
                principalTable: "tbFornecedor",
                principalColumn: "FornecedorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
