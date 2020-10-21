using System;
using Espetaculos.Domain.Entities;

namespace Espetaculos.Domain.Repositories {
    public interface IEspetaculoRepository {    

        Espetaculo GetById(Guid id);
        void Add(Espetaculo espetaculo);
        void Update(Espetaculo espetaculo);
        void Delete(Espetaculo espetaculo);
    }
}