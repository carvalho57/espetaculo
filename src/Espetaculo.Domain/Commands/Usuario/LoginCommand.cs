using Espetaculos.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Espetaculos.Domain.Commands
{
    public class LoginCommand : Notifiable, ICommand
    {
        public LoginCommand() { }
        public LoginCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; private set; }
        public string Senha { get; private set; }

        public bool Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Email, nameof(Email), "E-mail inválidio")
                .HasMinLen(Senha, 6, nameof(Senha), "A senha ve ter no minimo 6 caracteres")
            );
            return Valid;
        }
    }
}