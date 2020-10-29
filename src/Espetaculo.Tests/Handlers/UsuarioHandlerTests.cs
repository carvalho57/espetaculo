using Espetaculos.Domain.Handlers;
using Espetaculos.Domain.Repositories;
using Espetaculos.Domain.Commands;
using Espetaculos.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using Espetaculos.Domain.Entities;
using Espetaculos.Domain.Enums;

namespace Espetaculos.Tests.Handlers
{
    [TestClass]
    public class UsuarioHandlerTests
    {
        
        private readonly IClienteRepository _clientRepository;
        private readonly UsuarioHandler _handler;
        public UsuarioHandlerTests()
        {
            _clientRepository = new FakeClienteRepository();
            
            _handler = new UsuarioHandler(_clientRepository);
        }

        [TestMethod]
        public void Dado_um_email_e_senha_validos_o_usuario_deve_ser_autenticado()
        {            
            var _email = "jose@email.com";
            var _senha ="P@ssw0rd";
            var command = new LoginCommand(_email,_senha);
            var commandResult = (GenericCommandResult)_handler.Handle(command);
            Assert.IsTrue(commandResult.Sucess);
        }


        [TestMethod]
        public void Dado_um_email_invalido_usuario_nao_deve_ser_autenticado()
        {            
            var _email = "jose@com";
            var _senha ="P@ssw0rd";
            var command = new LoginCommand(_email,_senha);
            var commandResult = (GenericCommandResult)_handler.Handle(command);
            Assert.IsTrue(commandResult.Sucess);
        }

        [TestMethod]
        public void Dado_informacoes_corretas_o_usuario_deve_ser_cadastrado()
        {  
            var _nome = "Gabriel";
            var _sobrenome = "Carvalho";
            var _email = "gabriel@email.com";
            var _password = "P@ssw0rd";
            var command = new RegisterClienteCommand(_nome, _sobrenome,_email, _password, ETipoUsuario.Cliente);

            var commandResult = (GenericCommandResult)_handler.Handle(command);
            
            Assert.IsTrue(commandResult.Sucess);
        }

    }
}