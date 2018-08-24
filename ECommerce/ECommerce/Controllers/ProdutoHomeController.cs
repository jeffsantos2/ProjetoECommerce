using ECommerce.DAL;
using ECommerce.Models;
using ECommerce.Utils;
using System;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class ProdutoHomeController : Controller
    {
        ProdutoDAO produtoDAO = new ProdutoDAO();
        CategoriaDAO categoriaDAO = new CategoriaDAO();
        ItemVendaDAO itemVendaDAO = new ItemVendaDAO();

        public ActionResult Index(int? categoriaID)
        {
            ViewBag.Categorias = categoriaDAO.ListarCategorias();
            if (categoriaID != null) return View(produtoDAO.ListarProdutosPorCategoria(categoriaID));

            int? quantidade = 0;
            foreach(var item in itemVendaDAO.ListarItemVenda()) quantidade += item.Quantidade;
            ViewBag.TotalItens = quantidade;

            return View(produtoDAO.ListarProdutos());
        }
        public ActionResult DetalhesProduto(int? produtoID)
        {
            return View(produtoDAO.BuscarPorID(produtoID));
        }
        public ActionResult AdicionarAoCarrinho(int produtoID)
        {
            Produto produto = produtoDAO.BuscarPorID(produtoID);
            ItemVenda itemVenda = itemVendaDAO.ItemNoCarrinho(produto);

            if(itemVenda == null)
            {
                itemVenda = new ItemVenda();
                itemVenda.ProdutoVenda = produto;
                itemVenda.Quantidade = 1;
                itemVenda.PrecoVenda = produto.Preco;
                itemVenda.Data = System.DateTime.Now;
                itemVenda.CarrinhoID = Sessao.RetornarCarrinhoID().ToString();
                itemVendaDAO.Adicionar(itemVenda);
            }
            else
            {
                itemVenda.Quantidade++;
                itemVendaDAO.Atualizar(itemVenda);
            }
            
            return RedirectToAction("CarrinhoCompras");
        }
        public ActionResult CarrinhoCompras()
        {
            double CustoTotal = 0;
            foreach(var Item in itemVendaDAO.ListarItemVenda()) CustoTotal += Item.PrecoVenda * Item.Quantidade;
            ViewBag.Custo = CustoTotal;
            return View(itemVendaDAO.ListarItemVenda());
        }

        public ActionResult Remover(int? id)
        {
            ItemVenda item = itemVendaDAO.BuscarPorID(id);

            if(item != null)
            {
                if (item.Quantidade == 1) itemVendaDAO.Remover(id);
                else
                {
                    item.Quantidade--;
                    itemVendaDAO.Atualizar(item);
                }
            }

            return RedirectToAction("CarrinhoCompras");
        }

        public ActionResult Reduzir(int? id)
        {
            ItemVenda item = itemVendaDAO.BuscarPorID(id);

            if (item != null && item.Quantidade > 1)
            {
                item.Quantidade--;
                itemVendaDAO.Atualizar(item);
            }

            return RedirectToAction("CarrinhoCompras");
        }
        public ActionResult Aumentar(int? id)
        {
            ItemVenda item = itemVendaDAO.BuscarPorID(id);

            if (item != null)
            {
                item.Quantidade++;
                itemVendaDAO.Atualizar(item);
            }

            return RedirectToAction("CarrinhoCompras");
        }
    }
}