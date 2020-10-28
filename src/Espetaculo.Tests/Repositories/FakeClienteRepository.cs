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
        public Cliente GetById(Guid id)
        {
            if(id == Guid.Empty)
                return null;
            return _cliente;
        }
    }
}