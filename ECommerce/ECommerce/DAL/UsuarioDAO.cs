using ECommerce.Controllers;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DAL
{
    public class UsuarioDAO
    {
        private static Context contexto = Singleton.Instance(); 

        public static List<Usuario> RetornarUsuarios()
        {
            return contexto.Usuarios.ToList();
        }

        public bool Adicionar(Usuario usuario)
        {
            if(BuscarUsuarioPorEmail(usuario) == null)
            {
                contexto.Usuarios.Add(usuario);
                contexto.SaveChanges();
                return true; 
            }
            return false;
        }
        
        public static Usuario BuscarUsuarioPorEmail(Usuario usuario)
        {
            return contexto.Usuarios.FirstOrDefault(x => x.Email.Equals(usuario.Email));
        }


        
    }
}