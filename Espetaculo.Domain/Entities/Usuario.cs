using System;
using Espetaculos.Domain.Enums;
using Espetaculos.Domain.ValueObjects;
using Espetaculos.Shared.Entities;
using Flunt.Validations;

namespace Espetaculos.Domain.Entities
{
    public class Usuario : Entidade
    {
        public Usuario(Email email, string senha, ETipoUsuario papel)
        {
            Email = email;
            Senha = senha;
            Papel = papel;

            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Senha, 6, nameof(Senha), "A senha ve ter no minimo 6 caracteres")
                .Join(email)
            );           
        }

        public Email Email { get; private set; }
        public string Senha { get; private set; }
        public ETipoUsuario Papel { get; private set; }
    }
}