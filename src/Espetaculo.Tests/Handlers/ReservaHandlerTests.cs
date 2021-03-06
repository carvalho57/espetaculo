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
    public class ReservaHandlerTests
    {

        private readonly ReservaHandler _handler;
        private readonly IClienteRepository _clientRepository;
        private readonly ISessaoRepository _sessaoRepository;
        private readonly IReservaRepository _reservaRepository;
        public ReservaHandlerTests()
        {
            _clientRepository = new FakeClienteRepository();
            _sessaoRepository = new FakeSessaoRepository();
            _reservaRepository = new FakeReservaRepository();
            _handler = new ReservaHandler(_clientRepository, _sessaoRepository, _reservaRepository);
        }

        [TestMethod]
        public void Dado_um_CreateReservaCommand_valido_a_reserva_deve_ser_criada()
        {
            var sessao = _sessaoRepository.GetById(Guid.NewGuid());
            var poltronas = sessao.Poltrona.ToList();

            var ingressos = new List<CreateIngressoCommand>()
            {
                new CreateIngressoCommand("Jose", poltronas[0].Id),
                new CreateIngressoCommand("Amanda", poltronas[1].Id),
                new CreateIngressoCommand("Erika", poltronas[2].Id)
            };

            var command = new CreateReservaCommand(Guid.NewGuid(), sessao.Id, ingressos);
            var commandResult = (GenericCommandResult)_handler.Handle(command);
            Assert.IsTrue(commandResult.Sucess);
        }

        [TestMethod]
        public void Dado_um_ConfirmeReservaCommand_valido_a_reserva_deve_ser_confirmada()
        {
            var cliente = _clientRepository.GetById(Guid.NewGuid());
            var sessao = _sessaoRepository.GetById(Guid.NewGuid());
            var reserva = new Reserva(cliente, sessao);
            reserva.AdicionarIngresso(new Ingresso("Jose", sessao.Poltrona[0]));
            _reservaRepository.Add(reserva);

            var command = new ConfirmeReservaCommand(reserva.Id);
            var commandResult = (GenericCommandResult)_handler.Handle(command);
            Assert.IsTrue(commandResult.Sucess);
            Assert.AreEqual(reserva.Status, EStatusReserva.PagamentoConcluido);
        }

        [TestMethod]
        public void Dado_um_CancelReservaCommand_valido_a_reserva_deve_ser_confirmada()
        {
            var cliente = _clientRepository.GetById(Guid.NewGuid());
            var sessao = _sessaoRepository.GetById(Guid.NewGuid());
            var reserva = new Reserva(cliente, sessao);
            reserva.AdicionarIngresso(new Ingresso("Jose", sessao.Poltrona[0]));
            _reservaRepository.Add(reserva);

            var command = new CancelReservaCommand(reserva.Id);
            var commandResult = (GenericCommandResult)_handler.Handle(command);

            Assert.IsTrue(commandResult.Sucess);
            Assert.AreEqual(_reservaRepository.GetByCliente(cliente.Id).Count(), 0);
        }

        [TestMethod]
        public void Dado_um_CreateReservaCommand_sem_ingressos_a_reserva_nao_deve_ser_criada()
        {
            var sessao = _sessaoRepository.GetById(Guid.NewGuid());
            var poltronas = sessao.Poltrona.ToList();
            var ingressos = new List<CreateIngressoCommand>();
            var cliente = _clientRepository.GetById(Guid.NewGuid());
            var command = new CreateReservaCommand(cliente.Id, sessao.Id, ingressos);
            var commandResult = (GenericCommandResult)_handler.Handle(command);
            Assert.IsFalse(commandResult.Sucess);
            Assert.AreEqual(_reservaRepository.GetByCliente(cliente.Id).Count(), 0);
        }

        [TestMethod]
        public void Dado_um_CreateReservaCommand_com_poltronas_que_nao_existem_a_reserva_nao_deve_ser_criada()
        {
            var sessao = _sessaoRepository.GetById(Guid.NewGuid());
            var poltronas = sessao.Poltrona.ToList();
            var ingressos = new List<CreateIngressoCommand>(){
                new CreateIngressoCommand("Jose", Guid.NewGuid())
            };
            var cliente = _clientRepository.GetById(Guid.NewGuid());
            var command = new CreateReservaCommand(cliente.Id, sessao.Id, ingressos);
            var commandResult = (GenericCommandResult)_handler.Handle(command);
            Assert.IsFalse(commandResult.Sucess);
            Assert.AreEqual(_reservaRepository.GetByCliente(cliente.Id).Count(), 0);
        }

        [TestMethod]
        public void Dado_um_CreateReservaCommand_com_cliente_que_nao_existe_a_reserva_nao_deve_ser_criada()
        {
            var sessao = _sessaoRepository.GetById(Guid.NewGuid());
            var poltronas = sessao.Poltrona.ToList();

            var ingressos = new List<CreateIngressoCommand>()
            {
                new CreateIngressoCommand("Jose", poltronas[0].Id)
            };

            var command = new CreateReservaCommand(Guid.Empty, sessao.Id, ingressos);
            var commandResult = (GenericCommandResult)_handler.Handle(command);
            Assert.IsFalse(commandResult.Sucess);
        }

    }
}