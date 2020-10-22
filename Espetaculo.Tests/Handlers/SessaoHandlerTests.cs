using Espetaculos.Domain.Handlers;
using Espetaculos.Domain.Repositories;
using Espetaculos.Domain.Commands;
using Espetaculos.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using Espetaculos.Domain.Entities;

namespace Espetaculos.Tests.Handlers
{
    [TestClass]
    public class SessaoHandlerTests
    {

        private readonly SessaoHandler _handler;
        private readonly IEspetaculoRepository _espetaculoRepository;
        private readonly ISessaoRepository _sessaoRepository;
        private readonly ISalaRepository _salaRepository;
        public SessaoHandlerTests()
        {
            _espetaculoRepository = new FakeEspetaculoRepository();
            _sessaoRepository = new FakeSessaoRepository();
            _salaRepository = new FakeSalaRepository();
            _handler = new SessaoHandler(_espetaculoRepository, _salaRepository, _sessaoRepository);
        }

        [TestMethod]
        public void Dado_um_command_valido_a_sessao_deve_ser_criada()
        {
            var _espetaculo = _espetaculoRepository.GetById(Guid.NewGuid());
            var _sala = _salaRepository.GetById(Guid.NewGuid());

            var command = new CreateSessaoCommand(_espetaculo.Id, new DateTime(2020, 11, 3, 19, 0, 0), _sala.Id, 30);
            var commandResult = (GenericCommandResult)_handler.Handle(command);
            Assert.IsTrue(commandResult.Sucess);
        }


        [TestMethod]
        public void Dado_um_command_invalido_a_sessao_nao_deve_ser_registrada()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Dado_duas_sessoes_cadastradas_no_mesmo_horario_a_segunda_deve_gerar_um_notificacao()
        {
            Assert.Fail();
        }

      
    }
}