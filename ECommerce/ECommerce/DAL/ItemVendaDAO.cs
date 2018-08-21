﻿using ECommerce.Controllers;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DAL
{
    public class ItemVendaDAO
    {
        private static Context context = Singleton.Instance();

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
        public void Remover(int id)
        {
            context.ItensVenda.Remove(BuscarPorID(id));
            context.SaveChanges();
        }
        public ItemVenda BuscarPorID(int id)
        {
            return context.ItensVenda.Find(id);
        }

        public List<ItemVenda> ListarItemVenda(string CarrinhoID)
        {
            return context.ItensVenda.Where(item => item.CarrinhoID.Equals(CarrinhoID)).ToList();
        }
    }
}