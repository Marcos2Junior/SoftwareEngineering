using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoftwareEngineering.Models
{
    public class Sala 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Sua sala deve possuir um nome!", AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage ="Nome deve ter entre 5 a 20 caracteres.", MinimumLength = 5)]
        public string Nome { get; set; }

        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe a quantidade de jogadores que irão participar", AllowEmptyStrings = false)]
        [Range(2,1000,ErrorMessage = "Quantidade de jogadores inválido.")]
        public int QntJogadores { get; set; }

        [Required(ErrorMessage = "Informe o nome da cidade do evento", AllowEmptyStrings = false)]
        public string Local { get; set; }

        [Required(ErrorMessage = "Seu evento deve possuir uma data", AllowEmptyStrings = false)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime DataJogo { get; set; }

        public DateTime DataInicio { get; set; }

        public string Categoria { get; set; }

        [Required(ErrorMessage = "Sua sala deve possuir uma descrição", AllowEmptyStrings = false)]
        [StringLength(maximumLength: 100, ErrorMessage = "Adicione uma descrição de 15 a 100 caracteres", MinimumLength = 15)]
        public string  Descricao { get; set; }

        public string Usuario { get; set; }

        public string Image { get; set; }

    }
}