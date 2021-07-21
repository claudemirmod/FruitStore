using FruitStore.Application.Models.Usuario;
using System.Collections.Generic;

namespace FruitStore.Application.Models.Pedido
{
    public class CreatePedidoModel
    {
        public int IdUsuario { get; set; }
        public int Total { get; set; }
        public UsuarioModel Usuario { get; set; }
        public List<PedidoItemModel> Itens { get; set; }
    }
}
