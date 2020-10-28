using System;
using Espetaculos.Shared.Entities;
using Flunt.Validations;

namespace Espetaculos.Domain.Entities
{
    public class Espetaculo : Entidade
    {
        public Espetaculo(string nome, string descricao, int duracaoMinutos)
        {
            Nome = nome;
            Descricao = descricao;
            DuracaoMinutos = duracaoMinutos;

            AddNotifications( new Contract()
                .Requires()
                .IsNotNullOrEmpty(Nome, nameof(Nome), "O nome do espetaculo não pode estar vazio")
                .IsNotNullOrEmpty(Descricao, nameof(Descricao), "A descrição do espetaculo não pode estar vazia")
                .IsGreaterThan(DuracaoMinutos,0, nameof(DuracaoMinutos), "A duração do espetaculo deve ter valor maior que zero")
            );
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