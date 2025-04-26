using Aula02.Domain.Interfaces;
using Aula02.Domain.Models;

namespace Aula02.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoService(IPedidoRepository pedidoRepository) 
        { 
            _pedidoRepository = pedidoRepository;
        }

        public async Task<bool> AtualizarPedido(Pedido pPedido)
        {
            try
            {
                Pedido pedido = await _pedidoRepository.RetornaPedidoPorIdAsync(pPedido.Id);

                if (pedido == null)
                    return false;

                pedido.DataPedido = pPedido.DataPedido;
                pedido.ValorTotal = pPedido.ValorTotal;
                pedido.ClienteId = pPedido.ClienteId;

                await _pedidoRepository.AtualizarPedidoAsync(pPedido);
            }
            catch (Exception ex) 
            {
                throw;
            }

            return true;
        }

        public async Task<Pedido> CriarPedido(Pedido pPedido)
        {
            try
            {
                await _pedidoRepository.CriarPedidoAsync(pPedido);

                return pPedido;
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        public async Task<bool> ExcluirPedido(Pedido pPedido)
        {
            try
            {
                Pedido pedido = await _pedidoRepository.RetornaPedidoPorIdAsync(pPedido.Id);

                if (pedido == null)
                    return false;

                await _pedidoRepository.ExcluirPedidoAsync(pedido);

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Pedido>> RetornaTodosPedidosAsync()
        {
            try
            {
                IEnumerable<Pedido> pedidos = await _pedidoRepository.RetornaTodosPedidosAsync();

                return pedidos;
            }
            catch (Exception ex) 
            {
                throw;
            }
        }
    }
}
