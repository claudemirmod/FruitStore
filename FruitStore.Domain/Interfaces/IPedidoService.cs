using FruitStore.Application.Models.Pedido;

namespace FruitStore.Domain.Interfaces
{
    public interface IPedidoService
    {
        PedidoModel NovoPedido(CreatePedidoModel pedido);
        void Excluir(int id);
    }
}
