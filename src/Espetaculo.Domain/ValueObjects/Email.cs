
using System.Text.RegularExpressions;
using Flunt.Notifications;
using Flunt.Validations;

namespace Espetaculos.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string endereco)
        {
            Endereco = endereco;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Endereco, nameof(Endereco), "E-mail inválidio")
            );
        }

        public string Endereco { get; private set; }

        // private bool ValidarEmail()
        // {
        //     var regex = new Regex(@"[\w\.\-]+@\w{1,}.\w{1,}.?[\w]{2}");
        //     return regex.IsMatch(Endereco);
        // }
    }
}