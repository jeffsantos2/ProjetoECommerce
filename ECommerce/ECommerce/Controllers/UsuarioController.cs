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
using System.Web.Security;

namespace ECommerce.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioDAO usuarioDAO = new UsuarioDAO();

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
                if (usuarioDAO.Adicionar(usuario))
                {
                    return RedirectToAction("Index", "Usuario");
                }
                ModelState.AddModelError("", "Esse usuário já existe!");
                return View(usuario);

            }

            return View(usuario);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include ="Email, Senha")] Usuario usuario)
        {
            Usuario user = usuarioDAO.Autenticar(usuario);
            if(user == null)
            {
                ModelState.AddModelError("", "Usuário ou senha inválido!");
                return View(usuario);
            }
            //Autenticar
            FormsAuthentication.SetAuthCookie(user.Email, true);
            return RedirectToAction("Index", "ProdutoHome");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "ProdutoHome");
        }

    }
}
