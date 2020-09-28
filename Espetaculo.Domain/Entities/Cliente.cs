using System;
using Espetaculo.Shared.Entities;

namespace Espetaculo.Domain.Entities {
    public class Cliente : Entidade {    
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public Usuario Usuario { get; set; }
    }
}