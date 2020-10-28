using System;
using System.Linq;
using System.Collections.Generic;
using Espetaculos.Domain.Entities;
using Espetaculos.Domain.Enums;
using Espetaculos.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Espetaculos.Tests.Entities
{
    [TestClass]
    public class ReservaTests
    {
        private Usuario _user { get; set; }
        private Cliente _cliente { get; set; }
        private Espetaculo _espetaculo { get; set; }
        private Sala _sala { get; set; }
        private Sessao _sessao { get; set; }
        private List<Poltrona> _poltronas { get; set; }

        public ReservaTests()
        {
            _user = new Usuario(new Email("gabriel@carvalho.com"), "carvalho67", ETipoUsuario.Cliente);
            _cliente = new Cliente("gabriel", "carvalho", _user);
            _espetaculo = new Espetaculo("homem aranha", "Um filme legal", 130);
            _sala = new Sala("sala 1", 30, 10, EIdentificacaoPoltrona.Numerico);
            _sessao = new Sessao(DateTime.Now.AddDays(15), _espetaculo, _sala, 30M);
            _poltronas = _sessao.Poltrona.ToList();
        }

        [TestMethod]
        public void Quando_a_reserva_for_criada_o_status_deve_ser_Criada()
        {
            var reserva = new Reserva(_cliente, _sessao);
            Assert.AreEqual(reserva.Status, EStatusReserva.Criada);
        }

        [TestMethod]
        public void Dado_um_ingresso_adicionado_o_status_deve_ser_AguardandoPagamento()
        {
            var sessao = new Sessao(DateTime.Now.AddDays(15), _espetaculo, _sala, 30M);
            var reserva = new Reserva(_cliente, sessao);
            var poltronas = sessao.Poltrona.ToList();

            var ingresso = new Ingresso("Gabriel", poltronas[0]);
            reserva.AdicionarIngresso(ingresso);

            Assert.AreEqual(reserva.Status, EStatusReserva.AguardandoPagamento);
        }

        [TestMethod]
        public void Dado_dois_ingressos_no_valor_de_30_o_total_deve_ser_60()
        {
            var sessao = new Sessao(DateTime.Now.AddDays(15), _espetaculo, _sala, 30M);
            var reserva = new Reserva(_cliente, sessao);
            var poltronas = sessao.Poltrona.ToList();

            var primeiroIngresso = new Ingresso("Gabriel", poltronas[0]);
            var segundoIngresso = new Ingresso("Jose", poltronas[1]);
            reserva.AdicionarIngresso(primeiroIngresso);
            reserva.AdicionarIngresso(segundoIngresso);
            Assert.AreEqual(reserva.Total(), 60);
        }


        [TestMethod]
        public void Dado_um_poltrona_ja_ocupada_o_ingresso_nao_pode_ser_adicionada()
        {
            var sessao = new Sessao(DateTime.Now.AddDays(15), _espetaculo, _sala, 30M);
            var reserva = new Reserva(_cliente, sessao);
            var poltronas = sessao.Poltrona.ToList();
            var ingresso = new Ingresso("Gabriel", poltronas[0]);
            reserva.AdicionarIngresso(ingresso);
            var mesmoIngresso = new Ingresso("Jose", poltronas[0]);
            reserva.AdicionarIngresso(mesmoIngresso);
            Assert.AreEqual(reserva.Ingressos.Count(), 1);
            Assert.IsTrue(reserva.Invalid);
        }

        
    }
}
