using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DAL
{
    public class CategoriaDAO
    {
        private static Context context = new Context();
        public bool Adicionar(Categoria categoria)
        {
            if (BuscarPorNome(categoria) == null)
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public void Atualizar(Categoria categoria)
        {
            context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public List<Categoria> ListarCategorias()
        {
            return context.Categorias.ToList();
        }
        public void Remover(int id)
        {
            context.Categorias.Remove(BuscarPorID(id));
            context.SaveChanges();
        }
        public Categoria BuscarPorID(int id)
        {
            return context.Categorias.Find(id);
        }
        public Categoria BuscarPorNome(Categoria categoria)
        {
            return context.Categorias.FirstOrDefault(p => p.Nome.Equals(categoria.Nome));
        }
    }
}