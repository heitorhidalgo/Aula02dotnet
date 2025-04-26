using Aula02.Domain.Models;

namespace Aula02.Domain.Interfaces
{
    public interface IPedidoService
    {
        Task<Pedido> RetornaPedidoPorId(int pId);
        Task<IEnumerable<Pedido>> RetornaTodosPedidosAsync();

        Task<Pedido> CriarPedidoAsync(Pedido pPedido);

        Task<bool> AtualizarPedidoAsync(Pedido pPedido);

        Task<bool> ExcluirPedidoAsync(int pId);

    }
}
