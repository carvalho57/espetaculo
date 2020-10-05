using System;
using Espetaculo.Shared.Entities;

namespace Espetaculo.Domain.Entities {

    /*        
        Colocar valor do ingresso no proprio ingresso baseado no tipo
        que pode ser inteira, meia
    */
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