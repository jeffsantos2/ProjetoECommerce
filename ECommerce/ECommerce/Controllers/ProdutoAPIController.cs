using ECommerce.DAL;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ECommerce.Controllers
{
    [RoutePrefix("api/Produto")]
    public class ProdutoAPIController : ApiController
    {
        static ProdutoDAO produtoDAO = new ProdutoDAO();
        [Route("Produtos")]
        public List<Produto> GetProdutos()
        {
            return produtoDAO.ListarProdutos();
        }

        [Route("ProdutosPorCategoria/{CategoriaID}")]
        public List<Produto> GetProdutosPorCategoria(int CategoriaID)
        {
            return produtoDAO.ListarProdutosPorCategoria(CategoriaID);
        }

        [Route("ProdutosPorID/{ProdutoID}")]
        public dynamic GetProdutosPorID(int ProdutoID)
        {
            Produto produto =  produtoDAO.BuscarPorID(ProdutoID);
            if(produto != null)
            {
                dynamic ProdutoDinamico = new
                {
                    Nome = produto.Nome,
                    Preco = produto.Preco.ToString("C2"),
                    Categoria = produto.Categoria.Nome,
                    DataEnvio = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
                };
                return ProdutoDinamico;
            }
            return NotFound();
        }

        [Route("CadastrarProduto")]
        public IHttpActionResult PostCadastrarProduto(Produto produto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(produtoDAO.Adicionar(produto))
            {
                return Created("", produto);
            }
            else
            {
                return Conflict();
            }
        }
    }
}
