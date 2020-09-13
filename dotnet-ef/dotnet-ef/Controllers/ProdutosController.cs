using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ef.Domains;
using dotnet_ef.Interface;
using dotnet_ef.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_ef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        private readonly IProduto _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }
        
        // GET: api/<ProdutosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var produtos = _produtoRepository.Listar();

                if (produtos.Count == 0)
                    return NoContent();

                return Ok(produtos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Produto produto = _produtoRepository.BuscarPorID(id);

                if (produto == null)
                    return NotFound();

                return Ok(produto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public void Post(Produto produto)
        {
            _produtoRepository.Adicionar(produto);
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, Produto produto)
        {
            produto.Id = id;
            _produtoRepository.Editar(produto);
        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _produtoRepository.Excluir(id);
        }
    }
}
