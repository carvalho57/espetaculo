using System;
using Espetaculo.Shared.Entities;

namespace Espetaculo.Domain.Entities
{
    public class Espetaculo : Entidade
    {
        public Espetaculo(string nome, string descricao, int duracaoMinutos)
        {
            Nome = nome;
            Descricao = descricao;
            DuracaoMinutos = duracaoMinutos;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public int DuracaoMinutos { get; private set; }

        public void MudarInformacoes(string nome, string descricao, int duracaoMinutos) {
            Nome = nome;
            Descricao = descricao;
            DuracaoMinutos = duracaoMinutos;
        }
    }
}