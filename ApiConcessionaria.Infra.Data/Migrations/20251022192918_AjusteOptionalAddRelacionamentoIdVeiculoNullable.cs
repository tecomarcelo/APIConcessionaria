using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConcessionaria.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AjusteOptionalAddRelacionamentoIdVeiculoNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdVeiculo",
                table: "OPCIONAL",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.AlterColumn<Guid>(
                name: "IdVeiculo",
                table: "OPCIONAL",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OPCIONAL_VEICULO_IdVeiculo",
                table: "OPCIONAL",
                column: "IdVeiculo",
                principalTable: "VEICULO",
                principalColumn: "IDVEICULO",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
