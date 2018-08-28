using ECommerce.Controllers;
using ECommerce.Models;
using ECommerce.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DAL
{
    public class ItemVendaDAO
    {
        private static Context context = Singleton.Instance();
        private string CarrinhoID = Sessao.RetornarCarrinhoID().ToString();

        public bool Adicionar(ItemVenda item)
        {
            if(item != null)
            {
                context.ItensVenda.Add(item);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Atualizar(ItemVenda item)
        {
            if (item != null)
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Remover(int? id)
        {
            context.ItensVenda.Remove(BuscarPorID(id));
            context.SaveChanges();
        }
        public ItemVenda BuscarPorID(int? id)
        {
            return context.ItensVenda.Find(id);
        }

        public List<ItemVenda> ListarItemVenda()
        {
            return context.ItensVenda.Include("ProdutoVenda").Where(item => item.CarrinhoID.Equals(CarrinhoID)).ToList();
        }

        public ItemVenda ItemNoCarrinho(Produto produto)
        {
            return context.ItensVenda.Include("ProdutoVenda").FirstOrDefault(item => item.ProdutoVenda.ProdutoID == produto.ProdutoID && item.CarrinhoID.Equals(CarrinhoID));
        }

        public int RetornarQuantidade()
        {
            int TotalItensCarrinho = 0;
            foreach (var item in ListarItemVenda()) TotalItensCarrinho += item.Quantidade;
            return TotalItensCarrinho;
        }
    }
}