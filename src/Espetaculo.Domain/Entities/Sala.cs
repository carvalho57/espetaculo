using System;
using System.Collections.Generic;
using Espetaculos.Domain.Enums;
using Espetaculos.Shared.Entities;
using Flunt.Validations;

namespace Espetaculos.Domain.Entities
{
    public class Sala : Entidade
    {
        public Sala(string numero, int capacidadeTotal, int poltronasPorFila, EIdentificacaoPoltrona identificacaoPoltrona)
        {
            Numero = numero;
            CapacidadeTotal = capacidadeTotal;
            PoltronasPorFila = poltronasPorFila;
            IdentificacaoPoltronas = identificacaoPoltrona;

            AddNotifications(
                    new Contract()
                    .Requires()
                    .IsGreaterThan(CapacidadeTotal, 0, nameof(CapacidadeTotal), "A capacidade total da sala não pode ser menor ou igual a zero")
                    .IsGreaterThan(PoltronasPorFila, 0, nameof(PoltronasPorFila), "A quantidade de poltronas por fila não pode ser menor ou igual a zero")
            );
        }

        public string Numero { get; private set; }        
        public int CapacidadeTotal { get; private set; }            
        public int PoltronasPorFila { get; private set; }            
        public EIdentificacaoPoltrona IdentificacaoPoltronas {get;private set;}


        
    }
}