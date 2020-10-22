using System;
using System.Collections.Generic;
using Espetaculos.Domain.Entities;
using Espetaculos.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System.Linq;

namespace Espetaculos.Domain.Commands
{
    public class ConfirmeReservaCommand : Notifiable, ICommand
    {
        public ConfirmeReservaCommand() { }
        public ConfirmeReservaCommand(Guid reservaId)
        {
            ReservaId = reservaId;
        }

        public Guid ReservaId { get; set; }

        public bool Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(ReservaId, Guid.Empty, nameof(Reserva), "O identificador ReservaID é invalido para uma reserva")
            );
            return Valid;
        }
    }
}