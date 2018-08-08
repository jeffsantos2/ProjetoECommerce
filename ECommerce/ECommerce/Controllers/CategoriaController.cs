using ECommerce.DAL;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        CategoriaDAO categoriaDAO = new CategoriaDAO();
        // GET: Produto
        public ActionResult Index()
        {
            return View(categoriaDAO.ListarCategorias());
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoriaDAO.Adicionar(categoria)) return RedirectToAction("Index", "Categoria");
                else
                {
                    ModelState.AddModelError("", "Já existe uma categoria com este nome!");
                    return View(categoria);
                }
            }
            return View(categoria);
        }

        public ActionResult Remover(int id)
        {
            categoriaDAO.Remover(id);
            return RedirectToAction("Index", "Categoria");
        }

        public ActionResult Alterar(int id)
        {
            return View(categoriaDAO.BuscarPorID(id));
        }

        [HttpPost]
        public ActionResult Alterar(Categoria categoria)
        {
            Categoria categoriaOriginal = categoriaDAO.BuscarPorID(categoria.CategoriaID);
            categoriaOriginal.Nome = categoria.Nome;
            categoriaOriginal.Descricao = categoria.Descricao;
            categoriaDAO.Atualizar(categoriaOriginal);

            return RedirectToAction("Index", "Categoria");
        }
    }
}