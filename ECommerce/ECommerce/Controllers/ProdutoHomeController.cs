using ECommerce.DAL;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class ProdutoHomeController : Controller
    {
        ProdutoDAO produtoDAO = new ProdutoDAO();
        public ActionResult Index()
        {
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            ViewBag.Categorias = categoriaDAO.ListarCategorias();
            return View(produtoDAO.ListarProdutos());
        }
        public ActionResult FiltrarCategoria(int? categoriaID)
        {
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            ViewBag.Categorias = categoriaDAO.ListarCategorias();
            return View(produtoDAO.ListarProdutosPorCategoria(categoriaID));
        }
        public ActionResult DetalhesProduto(int? produtoID)
        {
            return View(produtoDAO.BuscarPorID(produtoID));
        }
    }
}