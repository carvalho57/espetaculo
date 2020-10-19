using System;
using System.Collections.Generic;
using System.Linq;
using Espetaculos.Domain.Enums;
using Espetaculos.Shared.Entities;
using Flunt.Validations;

namespace Espetaculos.Domain.Entities
{
    public class Sessao : Entidade
    {
        private readonly char PrimeiraLetraDaColuna = 'A';
        public Sessao(DateTime horario, Espetaculo espetaculo, Sala sala, decimal valorIngresso)
        {
            Horario = horario;
            Espetaculo = espetaculo;
            Sala = sala;
            ValorIngresso = valorIngresso;
            _poltronas = new List<Poltrona>();

            AddNotifications(new Contract()
                    .Requires()
                    .IsGreaterThan(Horario, DateTime.Now, nameof(Horario), "Horario não pode ser menor do que a data de hoje")
                    .IsGreaterThan(ValorIngresso, 0, nameof(ValorIngresso), "O valor do ingresso não pode ser menor ou igual a zero")                    
            );

            if(Valid)
                InicializarPoltronas(sala);
        }
        // Para mudar necessita saber se não ha outro no mesmo horário
        // mesmas validaçẽos para sala
        public DateTime Horario { get; private set; }
        public Espetaculo Espetaculo { get; private set; }
        public Sala Sala { get; private set; }
        private List<Poltrona> _poltronas { get; set; }
        public IReadOnlyList<Poltrona> Poltrona => _poltronas.ToArray();

        // Encerrado sera se o horario  e dia atual e maior
        private void InicializarPoltronas(Sala sala)
        {
            if (sala.IdentificacaoPoltronas == EIdentificacaoPoltrona.AlfaNumerico)
            {
                for (int numeroPoltrona = 0; numeroPoltrona < sala.CapacidadeTotal; numeroPoltrona++)
                    _poltronas.Add(new Poltrona(numeroPoltrona.ToString(), sala));
            }
            else
            {
                char letra = PrimeiraLetraDaColuna;
                int capacidadePorFila = 0;
                int numeroPoltronas = 0;
                do
                {

                    _poltronas.Add(new Poltrona((letra + (capacidadePorFila + 1).ToString()), sala));
                    capacidadePorFila++;
                    numeroPoltronas++;
                    if (capacidadePorFila >= sala.PoltronasPorFila)
                    {
                        letra++;
                        capacidadePorFila = 0;
                    }
                } while (numeroPoltronas < sala.CapacidadeTotal);
            }
        }

        public bool Encerrada
        {
            get
            {
                return DateTime.Now > Horario;
            }
        }
        public decimal ValorIngresso { get; private set; }


    }
}