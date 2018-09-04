using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerce.Models;
using ECommerce.DAL;

namespace ECommerce.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            return View(UsuarioDAO.RetornarUsuarios());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioID,Nome,Email,Senha,ConfirmarSenha")] Usuario usuario)
        {

            if (ModelState.IsValid)
            {
                UsuarioDAO usuarioDAO = new UsuarioDAO();

                if (usuarioDAO.Adicionar(usuario))
                {
                    return RedirectToAction("Index", "Usuario");
                }
                ModelState.AddModelError("", "Esse usuário já existe!");
                return View(usuario);

            }

            return View(usuario);
        }
    }
}
