using System;
using System.Collections.Generic;
using Espetaculo.Shared.Entities;

namespace Espetaculo.Domain.Entities
{
    public class Sala : Entidade
    {
        public Sala(string numero, int capacidade)
        {
            Numero = numero;
            Capacidade = capacidade;
        }

        public string Numero { get; private set; }        
        public int Capacidade { get; private set; }        
    }
}