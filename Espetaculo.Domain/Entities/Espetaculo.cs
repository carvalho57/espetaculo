using System;
using Espetaculo.Shared.Entities;;

namespace Espetaculo.Domain.Entities {
    public class Espetaculo : Entidade
    {    
        public string Nome {get; set;}
        public string Descricao { get; set; }       
        public int DuracaoMinutos { get; set; } 
    }
}