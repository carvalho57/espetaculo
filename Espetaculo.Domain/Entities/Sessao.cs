using System;
using System.Collections.Generic;
using System.Linq;
using Espetaculo.Shared.Entities;
namespace Espetaculo.Domain.Entities
{
    public class Sessao : Entidade
    {
        public Sessao(DateTime horario, Espetaculo espetaculo, Sala sala, decimal valorIngresso)
        {
            Horario = horario;
            Espetaculo = espetaculo;
            Sala = sala;
            ValorIngresso = valorIngresso;
            Encerrada = false;            
            InicializarPoltronas(sala);
        }
        // Para mudar necessita saber se não ha outro no mesmo horário
        // mesmas validaçẽos para sala

        public DateTime Data {get;private set;}
        public DateTime Horario { get; private set; }
        public Espetaculo Espetaculo { get; private set; }
        public Sala Sala { get; private set; }
        private List<Poltrona> _poltronas {get;set;}
        public IReadOnlyList<Poltrona> Poltrona => _poltronas.ToArray();
        
        // Encerrado sera se o horario  e dia atual e maior
        private void InicializarPoltronas(Sala sala)  {
            _poltronas = new List<Poltrona>();
            for(int i = 0; i < sala.Capacidade; i++) {
                _poltronas.Add(new Poltrona(i.ToString(),sala));
            }            
        }
        public bool Encerrada { get; private set; }
        public decimal ValorIngresso { get; private set; }


    }
}