using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConcessionaria.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class incluisãoVeiculoEmOpcional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OPCIONAL_IdVeiculo",
                table: "OPCIONAL",
                column: "IdVeiculo");

            migrationBuilder.AddForeignKey(
                name: "FK_OPCIONAL_VEICULO_IdVeiculo",
                table: "OPCIONAL",
                column: "IdVeiculo",
                principalTable: "VEICULO",
                principalColumn: "IDVEICULO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OPCIONAL_VEICULO_IdVeiculo",
                table: "OPCIONAL");

            migrationBuilder.DropIndex(
                name: "IX_OPCIONAL_IdVeiculo",
                table: "OPCIONAL");
        }
    }
}
