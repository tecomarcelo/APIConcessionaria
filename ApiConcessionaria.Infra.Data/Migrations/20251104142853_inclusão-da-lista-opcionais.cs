using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConcessionaria.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class inclusãodalistaopcionais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PEDIDO_OPCIONAL_IdOpcional",
                table: "PEDIDO");

            migrationBuilder.DropIndex(
                name: "IX_PEDIDO_IdOpcional",
                table: "PEDIDO");

            migrationBuilder.CreateTable(
                name: "PEDIDO_OPCIONAL",
                columns: table => new
                {
                    IdPedido = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOpcional = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDO_OPCIONAL", x => new { x.IdPedido, x.IdOpcional });
                    table.ForeignKey(
                        name: "FK_PEDIDO_OPCIONAL_OPCIONAL_IdOpcional",
                        column: x => x.IdOpcional,
                        principalTable: "OPCIONAL",
                        principalColumn: "IDOPCIONAL",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PEDIDO_OPCIONAL_PEDIDO_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "PEDIDO",
                        principalColumn: "IDPEDIDO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_OPCIONAL_IdOpcional",
                table: "PEDIDO_OPCIONAL",
                column: "IdOpcional");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PEDIDO_OPCIONAL");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_IdOpcional",
                table: "PEDIDO",
                column: "IdOpcional");

            migrationBuilder.AddForeignKey(
                name: "FK_PEDIDO_OPCIONAL_IdOpcional",
                table: "PEDIDO",
                column: "IdOpcional",
                principalTable: "OPCIONAL",
                principalColumn: "IDOPCIONAL",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
