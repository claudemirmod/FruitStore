using Microsoft.EntityFrameworkCore.Migrations;

namespace FruitStore.Infra.Data.Migrations
{
    public partial class AddPedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idUsuario = table.Column<int>(type: "integer", nullable: false),
                    idFruta = table.Column<int>(type: "integer", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}
