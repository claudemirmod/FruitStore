using System.Collections.Generic;

namespace FruitStore.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public int IdUsuario { get; set; }
        public int Total { get; set; }
        public Usuario Usuario { get; set; }
        public List<PedidoItem> Itens { get; set; }
    }
}
