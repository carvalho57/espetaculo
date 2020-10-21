using System;
using Espetaculos.Shared.Entities;
using Flunt.Validations;

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

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Poltrona.Ocupada, nameof(Poltrona), "Esta poltrona ja esta ocupada")
                .HasMinLen(NomeCliente,3, nameof(NomeCliente), "O nome deve conter no minímo 3 caracteres")
            );

            if(Valid)
                poltrona.Ocupar();
        }

        public string NomeCliente { get;private set; }           
        public Poltrona Poltrona { get; private set; }                
    }
}