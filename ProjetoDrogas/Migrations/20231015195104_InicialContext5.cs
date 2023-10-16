using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoDrogas.Migrations
{
    /// <inheritdoc />
    public partial class InicialContext5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrecoTotal",
                table: "tbItemVenda",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoTotal",
                table: "tbItemVenda");
        }
    }
}
