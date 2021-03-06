using System;
using Espetaculos.Domain.Entities;
using Espetaculos.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Espetaculos.Domain.Commands
{
    public class CreateSessaoCommand : Notifiable, ICommand
    {
        public CreateSessaoCommand() { }
        public CreateSessaoCommand(Guid espetaculoId, DateTime horario, Guid salaId, decimal valorIngresso)
        {
            EspetaculoId = espetaculoId;
            Horario = horario;
            SalaId = salaId;
            ValorIngresso = valorIngresso;
        }

        public Guid EspetaculoId { get; set; }
        public DateTime Horario { get; private set; }
        public Guid SalaId { get; set; }
        public decimal ValorIngresso { get; set; }
        public bool Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(EspetaculoId, Guid.Empty, nameof(Espetaculo), "Identificador invalido para espetaculo")
                .AreNotEquals(SalaId, Guid.Empty, nameof(Sala), "Identificador invalido para uma sala")
                .IsGreaterThan(Horario, DateTime.Now, nameof(Horario), "O horario deve ser maior do que o horario atual")
                .IsGreaterThan(ValorIngresso, 0, nameof(ValorIngresso), "O valor do ingresso deve ser maior do que zero")
            );
            return Valid;
        }
    }
}