using System;
using Flunt.Notifications;

namespace Espetaculos.Shared.Entities
{
    public class Entidade : Notifiable
    {
        protected Entidade()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
