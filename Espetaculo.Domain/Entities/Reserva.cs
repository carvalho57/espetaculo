using System.Collections.Generic;
using System.Linq;
using Espetaculos.Shared.Entities;
using Espetaculos.Domain.Enums;
using Flunt.Validations;

namespace Espetaculos.Domain.Entities
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

            AddNotifications(new Contract()
                .IfNotNull(Pagador, entidade => entidade.Join(Pagador))
                .IfNotNull(Sessao, entidade => entidade.Join(Sessao))
            );
        }

        public Cliente Pagador { get; private set; }
        public Sessao Sessao { get; private set; }
        public EStatusReserva Status { get; private set; }
        public IReadOnlyCollection<Ingresso> Ingressos => _ingressos.ToArray();
        
        public bool AdicionarIngresso(Ingresso ingresso)
        {
            if (ingresso.Invalid)
            {
                AddNotifications(ingresso);
                return false;
            }

            _ingressos.Add(ingresso);
            Status = EStatusReserva.AguardandoPagamento;
            return true;
        }
        //Quando a reserva for cancelada, so não persistir
        public void Cancelar()
        {
            Status = EStatusReserva.Cancelada;
        }

        public void Pagar()
        {
            Status = EStatusReserva.PagamentoConcluido;
        }

        public decimal Total()
        {
            return _ingressos.Sum(ingresso => Sessao.ValorIngresso);
        }
    }
}