using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    [Table("ItemVenda")]
    public class ItemVenda
    {
        [Key]
        public int ItemVendaID { get; set; }
        public Produto ProdutoVenda { get; set; }
        public int Quantidade { get; set; }
        public double PrecoVenda { get; set; }
        public DateTime Data { get; set; }
        public string CarrinhoID { get; set; }
        public string NomeCliente { get; set; }
        public string EnderecoCliente { get; set; }
        public string TelefoneCliente { get; set; }
    }
}