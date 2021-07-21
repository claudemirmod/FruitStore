using FruitStore.Application.Models.Fruta;

namespace FruitStore.Application.Models.Pedido
{
    public class PedidoItemModel
    {
        public int IdPedido { get; set; }
        public int IdFruta { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public FrutaModel Fruta { get; set; }
    }
}
