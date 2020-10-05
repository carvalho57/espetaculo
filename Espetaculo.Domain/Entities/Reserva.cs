using System;
using System.Collections.Generic;
using System.Linq;
using Espetaculo.Domain.Enums;
using Espetaculo.Shared.Entities;
namespace Espetaculo.Domain.Entities
{
    public class Reserva : Entidade
    {
        private List<Ingresso> _ingressos { get; set; }
        public Reserva(Cliente pagador, Sessao sessao)
        {
            Pagador = pagador;
            Sessao = sessao;
            _ingressos = new List<Ingresso>();
            Status = EStatusReserva.Criada;
        }

        public Cliente Pagador { get; private set; }
        public Sessao Sessao { get; private set; }
        public EStatusReserva Status { get; private set; }
        public IReadOnlyCollection<Ingresso> Ingressos => _ingressos.ToArray();

        public void AdicionarIngresso(Ingresso ingresso)
        {
            _ingressos.Add(ingresso);
            Status = EStatusReserva.AguardandoPagamento;
        }

        public void Cancelar() {
            Status = EStatusReserva.Cancelada;
        }

        public void Pagar() {
            Status = EStatusReserva.PagamentoConcluido;
        }
        
        public decimal Total() {
            return _ingressos.Sum(ingresso => Sessao.ValorIngresso);
        }
    }
}