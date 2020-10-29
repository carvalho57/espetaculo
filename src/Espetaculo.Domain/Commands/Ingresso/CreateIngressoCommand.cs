using System;
using Espetaculos.Domain.Entities;
using Espetaculos.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Espetaculos.Domain.Commands
{
    public class CreateIngressoCommand : Notifiable, ICommand
    {
        public CreateIngressoCommand() { }
        public CreateIngressoCommand(string nomeCliente, Guid poltronaId)
        {
            NomeCliente = nomeCliente;
            PoltronaId = poltronaId;
        }

        public string NomeCliente { get; set; }
        public Guid PoltronaId { get; set; }

        public bool Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(NomeCliente, 3, nameof(NomeCliente), "O nome deve conter no minímo 3 caracteres")
                .AreNotEquals(PoltronaId, Guid.Empty, nameof(Poltrona), "Identificador invalido para uma poltrona")
            );
            return Valid;
        }
    }
}