using System;
using Espetaculos.Domain.Entities;
using Espetaculos.Domain.Enums;
using Espetaculos.Domain.Repositories;
using Espetaculos.Domain.ValueObjects;

namespace Espetaculos.Tests.Repositories {
    public class FakeClienteRepository : IClienteRepository
    {
        private readonly Cliente _cliente;
        public FakeClienteRepository() {
            _cliente = new Cliente(
                        "jose",
                        "celverino",
                        new Usuario(
                                new Email("email@mail.com"),
                                "P@ssw0rd",
                                ETipoUsuario.Cliente
                        ));
        }

        public Cliente GetByEmail(string email)
        {
            if(!string.IsNullOrEmpty(email))
                return _cliente;
            return null;
        }

        public Cliente GetById(Guid id)
        {
            if(id == Guid.Empty)
                return null;
            return _cliente;
        }

        public void Save(Cliente cliente)
        {
         
        }

        public bool UserExist(string email)
        {
            return string.IsNullOrEmpty(email) ? false : true;
        }
    }
}