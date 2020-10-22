using System;
using System.Collections.Generic;
using Espetaculos.Domain.Entities;
using Espetaculos.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System.Linq;

namespace Espetaculos.Domain.Commands
{
    public class CreateReservaCommand : Notifiable, ICommand
    {
        public CreateReservaCommand()  { }
        public CreateReservaCommand(Guid clienteId, Guid sessaoId, IEnumerable<CreateIngressoCommand> ingressos)
        {
            ClienteId = clienteId;
            SessaoId = sessaoId;
            Ingressos = ingressos;
        }

        public Guid ClienteId { get; set; }
        public Guid SessaoId { get; set; }
        public IEnumerable<CreateIngressoCommand> Ingressos { get; set; }

        public bool Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(ClienteId, Guid.Empty, nameof(Cliente), "Identificador invalido para um cliente")
                .AreNotEquals(SessaoId, Guid.Empty, nameof(Sessao), "Identificador invalido para uma sessão")
                .IfNotNull(Ingressos, entity => entity.IsGreaterThan(Ingressos.Count(),0, nameof(Ingressos), "A reserva deve conter pelo menos um ingresso para ser concluida"))
                .Join(Ingressos.ToArray())
            );
            return Valid;
        }
    }
}