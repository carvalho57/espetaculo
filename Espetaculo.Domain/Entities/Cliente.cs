using System;
using Espetaculo.Shared.Entities;

namespace Espetaculo.Domain.Entities
{
    public class Cliente : Entidade
    {
        public Cliente(string nome, string sobrenome, Usuario usuario)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Usuario = usuario;
        }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public Usuario Usuario { get; private set; }
    }
}