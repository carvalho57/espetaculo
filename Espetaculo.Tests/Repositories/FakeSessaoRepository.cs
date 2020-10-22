using System;
using System.Collections.Generic;
using System.Linq;
using Espetaculos.Domain.Entities;
using Espetaculos.Domain.Repositories;


namespace Espetaculos.Tests.Repositories
{
    public class FakeSessaoRepository : ISessaoRepository
    {
        private readonly List<Sessao> _sessoes;

        public FakeSessaoRepository()
        {
            _sessoes = new List<Sessao>();
            _sessoes.Add(
                    new Sessao(
                            new DateTime(2020,11,3,15,0,0),
                            new Espetaculo("Homem Aranha", "Aranha verso", 130),
                            new Sala("00", 200, 20, Domain.Enums.EIdentificacaoPoltrona.AlfaNumerico),
                            30
                    )
            );
        }

        public void Add(Sessao sessao)
        {
            _sessoes.Add(sessao);
        }

        public IEnumerable<Sessao> GetByDate(DateTime time)
        {
            return _sessoes.Where(sessao => sessao.Horario == time).ToList();
        }

        public Sessao GetById(Guid id)
        {
            return _sessoes.FirstOrDefault(ses => ses.Id == id) ?? _sessoes[0];
        }

        public IEnumerable<Poltrona> GetPoltronasByIds(Guid sessao, IEnumerable<Guid> poltronas)
        {
            var poltronasSessao = _sessoes
                            .FirstOrDefault(ses => ses.Id == sessao)
                            .Poltrona.ToList();
           return poltronas.Join(poltronasSessao, x => x, poltrona => poltrona.Id, (x,poltrona) => poltrona).ToList();
        }

        public bool IsHorarioFree(DateTime horario, Guid salaId)
        {
            var result = _sessoes.Any(x => x.Sala.Id == salaId && x.Horario == horario);
            return  result;
            // foreach(var sessao in _sessoes.ToList()) {
            //     var horarioConfirmed = sessao.Horario == horario;
            //     var salaConfirmed = sessao.Id == salaId;

            //     if(horarioConfirmed && salaConfirmed) 
            //         return true;
            // }
            // return false;
        }
    }
}