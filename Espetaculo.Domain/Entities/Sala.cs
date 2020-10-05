using System;
using System.Collections.Generic;
using Espetaculo.Domain.Enums;
using Espetaculo.Shared.Entities;

namespace Espetaculo.Domain.Entities
{
    public class Sala : Entidade
    {
        public Sala(string numero, int capacidade, EIdentificacaoPoltrona identificacaoPoltrona)
        {
            Numero = numero;
            Capacidade = capacidade;
            IdentificacaoPoltronas = identificacaoPoltrona;
        }

        public string Numero { get; private set; }        
        public int Capacidade { get; private set; }            
        public EIdentificacaoPoltrona IdentificacaoPoltronas {get;private set;}
    }
}