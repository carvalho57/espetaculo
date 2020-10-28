using System;
using Espetaculos.Domain.Entities;

namespace Espetaculos.Domain.Repositories {
    public interface ISalaRepository {    

        Sala GetById(Guid id);
        void Add(Sala sala);     
        void Delete(Sala sala);
    }
}