using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(50, ErrorMessage = "O nome pode ter no máximo 50 caracteres!")]
        [Display(Name = "Nome da Categoria")]
        public string Nome { get; set; }

        [Display(Name = "Descrição da Categoria")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
    }
}