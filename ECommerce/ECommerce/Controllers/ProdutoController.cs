using ECommerce.DAL;
using ECommerce.Models;
using System.IO;
using System.Web;
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
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            ViewBag.Categorias = new SelectList(categoriaDAO.ListarCategorias(), "CategoriaID", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Produto produto, int? Categorias, HttpPostedFileBase ImagemProduto)
        {
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            ViewBag.Categorias = new SelectList(categoriaDAO.ListarCategorias(), "CategoriaID", "Nome");
            if (ModelState.IsValid)
            {
                if(Categorias == null)
                {
                    ModelState.AddModelError("", "Você deve selecionar uma categoria!");
                    return View(produto);
                }


                if (ImagemProduto != null)
                {
                    //string nomeImagem = produto.Nome + ".jpg";//Path.GetFileName(ImagemProduto.FileName);
                    string nomeImagem = Path.GetFileName(ImagemProduto.FileName);
                    string caminho = Path.Combine(Server.MapPath("~/Imagens/"), nomeImagem);

                    ImagemProduto.SaveAs(caminho);
                    produto.Imagem = nomeImagem;
                }
                else produto.Imagem = "SemImagem.png";

                produto.Categoria = categoriaDAO.BuscarPorID(Categorias);
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