using System;
using System.Collections.Generic;
using Espetaculos.Domain.Entities;

namespace Espetaculos.Domain.Repositories {
    public interface ISessaoRepository {
        Sessao GetById(Guid id);        
        IEnumerable<Sessao> GetByDate(DateTime time);
        void Add(Sessao sessao);
        IEnumerable<Poltrona> GetPoltronasByIds(Guid sessao, IEnumerable<Guid> poltronas);
        bool IsHorarioNotFree(DateTime horarioInicio, DateTime horarioFim, Guid salaId);
    }
}