using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConcessionaria.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class opcionaisajuste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdOpcional",
                table: "PEDIDO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdOpcional",
                table: "PEDIDO",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
