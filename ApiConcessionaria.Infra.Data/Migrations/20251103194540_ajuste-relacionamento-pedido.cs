using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConcessionaria.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ajusterelacionamentopedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "QUANTIDADE",
                table: "PEDIDO",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_IdOpcional",
                table: "PEDIDO",
                column: "IdOpcional");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_IdVeiculo",
                table: "PEDIDO",
                column: "IdVeiculo");

            migrationBuilder.AddForeignKey(
                name: "FK_PEDIDO_OPCIONAL_IdOpcional",
                table: "PEDIDO",
                column: "IdOpcional",
                principalTable: "OPCIONAL",
                principalColumn: "IDOPCIONAL",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PEDIDO_VEICULO_IdVeiculo",
                table: "PEDIDO",
                column: "IdVeiculo",
                principalTable: "VEICULO",
                principalColumn: "IDVEICULO",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PEDIDO_OPCIONAL_IdOpcional",
                table: "PEDIDO");

            migrationBuilder.DropForeignKey(
                name: "FK_PEDIDO_VEICULO_IdVeiculo",
                table: "PEDIDO");

            migrationBuilder.DropIndex(
                name: "IX_PEDIDO_IdOpcional",
                table: "PEDIDO");

            migrationBuilder.DropIndex(
                name: "IX_PEDIDO_IdVeiculo",
                table: "PEDIDO");

            migrationBuilder.AlterColumn<decimal>(
                name: "QUANTIDADE",
                table: "PEDIDO",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
