using System;
using Espetaculos.Shared.Entities;

namespace Espetaculos.Domain.Entities {

    /*        
        Colocar valor do ingresso no proprio ingresso baseado no tipo
        que pode ser inteira, meia
    */
    public class Ingresso  : Entidade{
        public Ingresso(string nomeCliente, Poltrona poltrona)
        {
            NomeCliente = nomeCliente;
            Poltrona = poltrona;                        

            if(poltrona.Ocupada)
                AddNotification(nameof(Poltrona), "Esta poltrona ja esta ocupada");
            poltrona.Ocupar();
        }

        public string NomeCliente { get;private set; }           
        public Poltrona Poltrona { get; private set; }                
    }
}