using dotnet_ef.Context;
using dotnet_ef.Domains;
using dotnet_ef.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace dotnet_ef.Repositories
{
    public class ProdutoRepositoy : IProduto
    {
        private readonly PedidoContext _ctx;

        public ProdutoRepositoy()
        {
            _ctx = new PedidoContext();
        }

        public void Adicionar(Produto produto)
        {
            try
            {
                _ctx.Produtos.Add(produto);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Produto BuscarPorID(Guid id)
        {
            try
            {
                Produto produto = _ctx.Produtos.Find(id);
                return produto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                List<Produto> produtos = _ctx.Produtos.Where(c => c.NomeProduto.Contains(nome)).ToList();
                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Produto produto)
        {
            try
            {
                //Busco um produto pelo seu Id
                Produto produtoTemp = BuscarPorID(produto.Id);

                //Verifica se o produto existe, caso não exista gera uma exception
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //Altera as propriedades do produto
                produtoTemp.NomeProduto = produto.NomeProduto;
                produtoTemp.Preco = produto.Preco;

                //Altera o produto no contexto
                _ctx.Produtos.Update(produtoTemp);
                //Salva o produto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Excluir(Guid id)
        {
            try
            {
                Produto produto = BuscarPorID(id);

                if (produto == null)
                    throw new Exception("Produto não encontrado.");

                _ctx.Produtos.Remove(produto); 
            
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Produto> Listar()
        {
            try
            {
                List<Produto> produtos = _ctx.Produtos.ToList();
                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
