using Espetaculos.Domain.Enums;
using Espetaculos.Domain.ValueObjects;
using Espetaculos.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Espetaculos.Domain.Commands
{
    public class RegisterClienteCommand : Notifiable, ICommand
    {
        public RegisterClienteCommand() { }
        public RegisterClienteCommand(string nome, string sobrenome, string email, string senha, ETipoUsuario papel)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Senha = senha;
            Papel = papel;
        }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public ETipoUsuario Papel { get; private set; }

        public bool Validate()
        {
            AddNotifications(new Contract()
                   .Requires()
                   .IsNotNullOrEmpty(Nome, nameof(Nome), "O nome não pode estar em branco")
                   .IsNotNull(Sobrenome, nameof(Sobrenome), "O sobrenome não pode estar em branco")
                   .HasMinLen(Senha, 6, nameof(Senha), "A senha ve ter no minimo 6 caracteres")
                   .IsEmail(Email, nameof(Email), "E-mail inválidio")
               );
            return Valid;
        }
    }
}