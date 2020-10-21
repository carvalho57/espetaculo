using System;
using Espetaculos.Domain.Entities;

namespace Espetaculos.Domain.Repositories {
    public interface IClienteRepository {
        Cliente GetById(Guid id);
    }
}