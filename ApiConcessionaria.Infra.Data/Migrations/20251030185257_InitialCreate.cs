using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConcessionaria.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    IDCLIENTE = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.IDCLIENTE);
                });

            migrationBuilder.CreateTable(
                name: "OPCIONAL",
                columns: table => new
                {
                    IDOPCIONAL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ITEM = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PRECO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdVeiculo = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPCIONAL", x => x.IDOPCIONAL);
                });

            migrationBuilder.CreateTable(
                name: "VEICULO",
                columns: table => new
                {
                    IDVEICULO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MARCA = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PRECO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ANOVEICULO = table.Column<int>(type: "int", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEICULO", x => x.IDVEICULO);
                });

            migrationBuilder.CreateTable(
                name: "PEDIDO",
                columns: table => new
                {
                    IDPEDIDO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VALOR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QUANTIDADE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdVeiculo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOpcional = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDO", x => x.IDPEDIDO);
                    table.ForeignKey(
                        name: "FK_PEDIDO_CLIENTE_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "CLIENTE",
                        principalColumn: "IDCLIENTE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTE_CPF",
                table: "CLIENTE",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_IdCliente",
                table: "PEDIDO",
                column: "IdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OPCIONAL");

            migrationBuilder.DropTable(
                name: "PEDIDO");

            migrationBuilder.DropTable(
                name: "VEICULO");

            migrationBuilder.DropTable(
                name: "CLIENTE");
        }
    }
}
