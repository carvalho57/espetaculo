using System;
using System.Linq;
using Espetaculos.Domain.Entities;
using Espetaculos.Domain.Enums;
using Espetaculos.Domain.ValueObjects;

namespace Espetaculos.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new Usuario(new Email("gabriel@carvalho.com"), "carvalho67", ETipoUsuario.Cliente);
            var cliente = new Cliente("gabriel", "carvalho", user);
            var espetaculo = new Espetaculo("homem aranha", "Um filme legal", 130);
            var sala1 = new Sala("sala 1", 30, 10, EIdentificacaoPoltrona.Numerico);
            var sessao = new Sessao(DateTime.Now.AddDays(15), espetaculo, sala1, 30M);
            var sessao2 = new Sessao(DateTime.Now.AddDays(16), espetaculo, sala1, 10M);

            var reserva = new Reserva(cliente, sessao2);
            var poltronas = sessao.Poltrona;
            int count = 0;
            string[] names = { "Gabriel", "Eduardo", "Camilie" };
            foreach (var poltrona in poltronas)
            {
                if (count >= 3)
                    break;

                reserva.AdicionarIngresso(new Ingresso(names[count], poltrona));
                count++;
            }

            Console.WriteLine("Reserva");
            Console.WriteLine("Espetaculo");
            Console.WriteLine($"Nome : {reserva.Sessao.Espetaculo.Nome}");
            Console.WriteLine($"Valor Ingresso: {reserva.Sessao.ValorIngresso}");
            Console.WriteLine("Poltronas");
            reserva.Ingressos.ToList().ForEach(ingresso => Console.WriteLine($"Nome: {ingresso.NomeCliente} Poltrona: {ingresso.Poltrona.Identificador}"));
            Console.WriteLine($"Total: {reserva.Total()}");

        }
    }
}
