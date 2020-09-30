using System;
using Espetaculo.Domain.Enums;
using Espetaculo.Domain.ValueObjects;
using Espetaculo.Shared.Entities;

namespace Espetaculo.Domain.Entities
{
    public class Usuario : Entidade
    {
        public Usuario(Email email, string senha, ETipoUsuario papel)
        {
            Email = email;
            Senha = senha;
            Papel = papel;
        }

        public Email Email { get; private set; }
        public string Senha { get; private set; }
        public ETipoUsuario Papel { get; private set; }
    }
}