using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoID { get; set; }
        [Required(ErrorMessage ="Campo Obrigatório!")]
        [Display(Name = "Preço do Produto")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(50, ErrorMessage ="O nome pode ter no máximo 50 caracteres!")]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Categoria do Produto")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Descrição do Produto")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        public string Imagem { get; set; }
    }
}