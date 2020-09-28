using System;
using Espetaculo.Shared.Entities;

namespace Espetaculo.Domain.Entities {
    public class Usuario  : Entidade{
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Papel { get; set; }
    }
}