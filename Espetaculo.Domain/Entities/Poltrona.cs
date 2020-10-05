using System;
using Espetaculo.Shared.Entities;

namespace Espetaculo.Domain.Entities
{
    public class Poltrona : Entidade
    {
        public Poltrona(int numero, Sala sala)
        {
            Numero = numero;
            Ocupada = false;
            Sala = sala;
        }

        public int Numero { get; private set; }
        public bool Ocupada { get; private set; }
        public Sala Sala { get; private set; }

        public void Ocupar() => Ocupada = true;
        public void Desocupar() => Ocupada = false;
    }
}