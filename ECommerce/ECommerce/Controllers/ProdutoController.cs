using ECommerce.DAL;
using ECommerce.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class ProdutoController : Controller
    {
        ProdutoDAO produtoDAO = new ProdutoDAO();
        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Produtos = produtoDAO.ListarProdutos();
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(string txtNome, string txtDescricao, string txtPreco, string txtCategoria)
        {
            Produto produto = new Produto
            {
                Nome = txtNome,
                Descricao = txtDescricao,
                Preco = Convert.ToDouble(txtPreco),
                Categoria = txtCategoria
            };
            produtoDAO.Adicionar(produto);

            return RedirectToAction("Index", "Produto");
        }

        public ActionResult Remover(int id)
        {
            produtoDAO.Remover(id);
            return RedirectToAction("Index", "Produto");
        }

        public ActionResult Alterar(int id)
        {
            ViewBag.Produto = produtoDAO.BuscarPorID(id);
            return View();
        }

        [HttpPost]
        public ActionResult Alterar(int produtoID, string txtNome, string txtDescricao, string txtPreco, string txtCategoria)
        {
            Produto produto = produtoDAO.BuscarPorID(produtoID);
            produto.Nome = txtNome;
            produto.Descricao = txtDescricao;
            produto.Preco = Convert.ToDouble(txtPreco);
            produto.Categoria = txtCategoria;
            produtoDAO.Atualizar(produto);

            return RedirectToAction("Index", "Produto");
        }
    }
}