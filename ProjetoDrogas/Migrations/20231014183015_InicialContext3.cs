using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoDrogas.Migrations
{
    /// <inheritdoc />
    public partial class InicialContext3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Quantidade",
                table: "tbItemVenda",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "tbItemVenda");
        }
    }
}
