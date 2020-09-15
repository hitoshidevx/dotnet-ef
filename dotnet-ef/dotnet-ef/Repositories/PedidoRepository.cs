using dotnet_ef.Context;
using dotnet_ef.Domains;
using dotnet_ef.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_ef.Repositories
{
    public class PedidoRepository : IPedido
    {
        private readonly PedidoContext _ctx;

        public PedidoRepository()
        {
            _ctx = new PedidoContext();
        }

        public Pedido Adicionar(List<PedidoItem> pedidosItens)
        {
            try
            {
                Pedido pedido = new Pedido
                {
                    Status = "Pedido efetuado.",
                    OrderDate = DateTime.Now
                };

                foreach (var item in pedidosItens)
                {
                    pedido.PedidosItens.Add(new PedidoItem
                    {
                        IdPedido  = pedido.Id,
                        IdProduto = item.IdProduto
                    });
                }

                _ctx.Pedidos.Add(pedido);
                _ctx.SaveChanges();

                return pedido;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Pedido BuscarPorID(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
