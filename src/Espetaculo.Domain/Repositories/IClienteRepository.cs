using System;
using Espetaculos.Domain.Entities;

namespace Espetaculos.Domain.Repositories {
    public interface IClienteRepository {
        Cliente GetById(Guid id);
        bool UserExist(string email);
        Cliente GetByEmail(string email);

        void Save(Cliente cliente);
    }
}