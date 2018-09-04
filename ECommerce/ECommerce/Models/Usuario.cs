using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "E-mail do usuário")]
        [EmailAddress(ErrorMessage ="E-mail inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Senha do usuário")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage ="Os campos não coincidem!")]
        [Display(Name = "Confirmar Senha")]
        [NotMapped]
        public string ConfirmarSenha { get; set; }

    }
}