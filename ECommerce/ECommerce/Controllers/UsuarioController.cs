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
using System.Text;
using Newtonsoft.Json;

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
            if (TempData["Mensagem"] != null)
            {
                ModelState.AddModelError("", TempData["Mensagem"].ToString());
            }
            return View((Usuario)TempData["Usuario"]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioID,Nome,Email,Senha,ConfirmarSenha,CEP,Logradouro,Localidade,Bairro,UF")] Usuario usuario)
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

        [HttpPost]
        public ActionResult PesquisarCEP(Usuario usuario)
        {
            try
            {
                //consultar o cep
                string url = "https://viacep.com.br/ws/" + usuario.CEP + "/json/";
                //string url = "http://apps.widenet.com.br/busca-cep/api/cep/" + usuario.CEP + ".json";

                //string url = "https://buscarcep.com.br/?cep=" + usuario.CEP + "&formato=string&chave=Chave_Gratuita_BuscarCep";


                WebClient client = new WebClient();
                string json = client.DownloadString(url);

                //converter pra utf-8
                byte[] bytes = Encoding.Default.GetBytes(json);
                json = Encoding.UTF8.GetString(bytes);

                //converter o json para objeto
                usuario = JsonConvert.DeserializeObject<Usuario>(json);

                //passar informação para qualquer action do controller
                TempData["Usuario"] = usuario;
            }
            catch(Exception)
            {
                TempData["Mensagem"] = "CEP Inválido!";
            }

            return RedirectToAction("Create", "Usuario");
        }

    }
}
