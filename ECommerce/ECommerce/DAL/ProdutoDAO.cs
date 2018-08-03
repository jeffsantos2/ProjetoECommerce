using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DAL
{
    public class ProdutoDAO
    {
        private static Context context = new Context();
        public void Adicionar(Produto produto)
        {
            context.Produtos.Add(produto);
            context.SaveChanges();
        }
        public void Atualizar(Produto produto)
        {
            context.Entry(produto).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public List<Produto> ListarProdutos()
        {
            return context.Produtos.ToList();
        }
        public void Remover(int id)
        {
            context.Produtos.Remove(BuscarPorID(id));
            context.SaveChanges();
        }
        public Produto BuscarPorID(int id)
        {
            return context.Produtos.Find(id);
        }
    }
}