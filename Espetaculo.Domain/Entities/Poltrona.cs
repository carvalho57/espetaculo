using System;
using Espetaculos.Shared.Entities;
using Flunt.Validations;

namespace Espetaculos.Domain.Entities
{
    public class Poltrona : Entidade
    {
        public Poltrona(string identificador, Sala sala)
        {
            Identificador = identificador;
            Ocupada = false;
            Sala = sala;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Identificador, nameof(Identificador), "O identificador da poltrona não pode estar em branco")                                
            );
        }

        public string Identificador { get; private set; }
        public bool Ocupada { get; private set; }
        public Sala Sala { get; private set; }

        public void Ocupar() => Ocupada = true;
        public void Desocupar() => Ocupada = false;

        
    }
}