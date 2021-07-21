namespace FruitStore.Domain.Entities
{
    public class PedidoItem : BaseEntity
    {
        public int IdPedido { get; set; }
        public int IdFruta { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }

        public Fruta Fruta { get; set; }
        public Pedido Pedido { get; set; }
    }
}
