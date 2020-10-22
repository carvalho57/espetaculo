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

        public void AdicionarIngresso(Ingresso ingresso)
        {
            AddNotifications(new Contract()
                 .Requires()
                 .Join(ingresso)
            );
            if (Valid)
            {
                _ingressos.Add(ingresso);
                Status = EStatusReserva.AguardandoPagamento;
            }
        }

        public void AdicionarIngresso(IEnumerable<Ingresso> ingressos)
        {
            foreach (var ingresso in ingressos)
                AdicionarIngresso(ingresso);
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