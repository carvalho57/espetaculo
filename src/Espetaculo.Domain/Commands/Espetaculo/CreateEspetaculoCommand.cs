using Espetaculos.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Espetaculos.Domain.Commands
{
    public class CreateEspetaculoCommand : Notifiable, ICommand
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int DuracaoMinutos { get; set; }

        public bool Validate()
        {
            AddNotifications( new Contract()
                .Requires()
                .IsNotNullOrEmpty(Nome, nameof(Nome), "O nome do espetaculo não pode estar vazio")
                .IsNotNullOrEmpty(Descricao, nameof(Descricao), "A descrição do espetaculo não pode estar vazia")
                .IsGreaterThan(DuracaoMinutos,0, nameof(DuracaoMinutos), "A duração do espetaculo deve ter valor maior que zero")
            );

            return Valid;
        }
    }
}