using System;
using Espetaculo.Shared.Entities;

namespace Espetaculo.Domain.Entities {
    public class Ingresso  : Entidade{
        public Ingresso(string cliente, Poltrona poltrona)
        {
            Cliente = cliente;
            Poltrona = poltrona;                        
            poltrona.Ocupar();
        }

        public string Cliente { get;private set; }           
        public Poltrona Poltrona { get; private set; }                
    }
}