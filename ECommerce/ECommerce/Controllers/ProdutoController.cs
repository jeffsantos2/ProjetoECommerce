using ECommerce.DAL;
using ECommerce.Models;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class ProdutoController : Controller
    {
        private static ProdutoDAO produtoDAO = new ProdutoDAO();
        // GET: Produto
        public ActionResult Index()
        {
            return View(produtoDAO.ListarProdutos());
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                if(produtoDAO.Adicionar(produto)) return RedirectToAction("Index", "Produto");
                else
                {
                    ModelState.AddModelError("", "Já existe um produto com este nome!");
                    return View(produto);
                }
            }
            return View(produto);
        }

        public ActionResult Remover(int id)
        {
            produtoDAO.Remover(id);
            return RedirectToAction("Index", "Produto");
        }

        public ActionResult Alterar(int id)
        {
            return View(produtoDAO.BuscarPorID(id));
        }

        [HttpPost]
        public ActionResult Alterar(Produto produto)
        {
            Produto produtoOriginal = produtoDAO.BuscarPorID(produto.ProdutoID);

            produtoOriginal.Nome = produto.Nome;
            produtoOriginal.Descricao = produto.Descricao;
            produtoOriginal.Preco = produto.Preco;
            produtoOriginal.Categoria = produto.Categoria;
            produtoDAO.Atualizar(produtoOriginal);

            return RedirectToAction("Index", "Produto");
        }
    }
}