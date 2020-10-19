using System;
using Espetaculos.Shared.Entities;
using Flunt.Validations;

namespace Espetaculos.Domain.Entities
{
    public class Cliente : Entidade
    {
        public Cliente(string nome, string sobrenome, Usuario usuario)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Usuario = usuario;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Nome, nameof(Nome), "O nome não pode estar em branco")
                .IsNotNull(Sobrenome, nameof(Sobrenome), "O sobrenome não pode estar em branco")
                .Join(Usuario)
            );
        }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public Usuario Usuario { get; private set; }
    }
}