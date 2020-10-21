using System;
using System.Collections.Generic;
using Espetaculos.Domain.Entities;

namespace Espetaculos.Domain.Repositories {
    public interface ISessaoRepository {
        Sessao GetById(Guid id);
        bool IsPoltronasOcuped(IEnumerable<Guid> ids);

        IEnumerable<Poltrona> GetPoltronasByIds(IEnumerable<Guid> ids);
    }
}