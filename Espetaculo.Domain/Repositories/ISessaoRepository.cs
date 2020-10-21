using System;
using System.Collections.Generic;
using Espetaculos.Domain.Entities;

namespace Espetaculos.Domain.Repositories {
    public interface ISessaoRepository {
        Sessao GetById(Guid id);        
        void Add(Sessao sessao);
        IEnumerable<Poltrona> GetPoltronasByIds(IEnumerable<Guid> ids);
        bool IsHorarioFree(DateTime horario, Guid salaId);
    }
}