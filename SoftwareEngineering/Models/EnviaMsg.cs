using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareEngineering.Models
{
    public class EnviaMsg
    {
        public string Mensagem { get; set; }
        public string IdUsuario { get; set; }
        public int IdSala { get; set; }
        public int sequencia { get; set; }
        public string DataMensagem { get; set; }
    }
}