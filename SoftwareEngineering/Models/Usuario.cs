using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoftwareEngineering.Models
{
    public class Usuario
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Voce deve inserir uma senha", AllowEmptyStrings = false)]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "A senhe e a confirmação da senha são diferentes")]
        public string ConfirmaSenha { get; set; }

        [Required(ErrorMessage = "Informe um e-mail", AllowEmptyStrings = false)]
        public string Email { get; set; }

        
        public string Telefone { get; set; }

        public bool RecebeNotificacao { get; set; }

        public string Image { get; set; }

        public string Sobre { get; set; }




    }
}