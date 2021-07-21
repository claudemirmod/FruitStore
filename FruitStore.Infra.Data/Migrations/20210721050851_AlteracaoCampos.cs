using Microsoft.EntityFrameworkCore.Migrations;

namespace FruitStore.Infra.Data.Migrations
{
    public partial class AlteracaoCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItem_Pedido_PedidoId",
                table: "PedidoItem");

            migrationBuilder.DropIndex(
                name: "IX_PedidoItem_PedidoId",
                table: "PedidoItem");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "PedidoItem");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "PedidoItem",
                newName: "Valor");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItem_Pedido_IdFruta",
                table: "PedidoItem",
                column: "IdFruta",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItem_Pedido_IdFruta",
                table: "PedidoItem");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "PedidoItem",
                newName: "Total");

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "PedidoItem",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_PedidoId",
                table: "PedidoItem",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItem_Pedido_PedidoId",
                table: "PedidoItem",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
