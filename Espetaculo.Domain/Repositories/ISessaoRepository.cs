using System;
using System.Collections.Generic;
using Espetaculos.Domain.Entities;

namespace Espetaculos.Domain.Repositories {
    public interface ISessaoRepository {
        Sessao GetById(Guid id);        
        void Add(Sessao sessao);
        IEnumerable<Poltrona> GetPoltronasByIds(Guid sessao, IEnumerable<Guid> poltronas);
        bool IsHorarioFree(DateTime horario, Guid salaId);
    }
}