using System;
using Espetaculo.Shared.Entities;
namespace Espetaculo.Domain.Entities {
    public class Sessao  : Entidade{        
        public DateTime Horario { get; private set; }
        public Espetaculo Espetaculo { get; set; }
        public Sala Sala { get; set; }
        public decimal ValorIngresso { get; set; }
        
    }
}