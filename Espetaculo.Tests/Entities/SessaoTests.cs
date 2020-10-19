using System;
using Espetaculos.Domain.Entities;
using Espetaculos.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Espetaculos.Tests.Entities
{
    [TestClass]
    public class SessaoTests
    {
        private Espetaculo _espetaculo { get; set; }
        private Sala _sala { get; set; }

        public SessaoTests()
        {
            _espetaculo = new Espetaculo("homem aranha", "Um filme legal", 130);
            _sala = new Sala("sala 1", 30, 10, EIdentificacaoPoltrona.Numerico);
        }

        [TestMethod]
        public void Dado_uma_data_menor_do_que_o_dia_de_hoje_a_sessao_deve_ser_invalida()
        {
            var sessao = new Sessao(DateTime.Now.AddDays(-3), _espetaculo, _sala, 30);
            Assert.IsTrue(sessao.Invalid);
        }

        [TestMethod]
        public void Dado_um_valor_de_ingresso_menor_que_zero_a_sessao_deve_ser_invalida()
        {
            var sessao = new Sessao(DateTime.Now.AddDays(3), _espetaculo, _sala, 0);
            Assert.IsTrue(sessao.Invalid);
        }

        [TestMethod]
        public void Dado_um_sala_com_CapacidadeTotal_de_100_deve_gerar_100_poltronas()
        {
            int TotalPoltronas = 100;
            int NumeroPoltronasPorFila = 10;
            var sala = new Sala("Sala 2", TotalPoltronas,NumeroPoltronasPorFila, EIdentificacaoPoltrona.Numerico);
            var sessao = new Sessao(DateTime.Now.AddDays(3), _espetaculo, sala, 10);

            Assert.AreEqual(sessao.Poltrona.Count, TotalPoltronas);
        }
    }
}
