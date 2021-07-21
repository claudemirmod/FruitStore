using Microsoft.EntityFrameworkCore.Migrations;

namespace FruitStore.Infra.Data.Migrations
{
    public partial class AlteracaoPedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "idFruta",
                table: "Pedido");

            migrationBuilder.RenameColumn(
                name: "idUsuario",
                table: "Pedido",
                newName: "IdUsuario");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                table: "Pedido",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "PedidoItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdPedido = table.Column<int>(type: "int", nullable: false),
                    IdFruta = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "numeric", nullable: false),
                    PedidoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoItem_Fruta_IdFruta",
                        column: x => x.IdFruta,
                        principalTable: "Fruta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoItem_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdUsuario",
                table: "Pedido",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_IdFruta",
                table: "PedidoItem",
                column: "IdFruta");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_PedidoId",
                table: "PedidoItem",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Usuario_IdUsuario",
                table: "Pedido",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Usuario_IdUsuario",
                table: "Pedido");

            migrationBuilder.DropTable(
                name: "PedidoItem");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_IdUsuario",
                table: "Pedido");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Pedido",
                newName: "idUsuario");

            migrationBuilder.AlterColumn<int>(
                name: "idUsuario",
                table: "Pedido",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idFruta",
                table: "Pedido",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
