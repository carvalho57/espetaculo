using System;
using System.Collections.Generic;
using Espetaculo.Domain.Entities;
using Espetaculo.Domain.Enums;
using Espetaculo.Domain.ValueObjects;



namespace Espetaculo.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            var user = new Usuario(new Email("gabriel@carvalho.com"), "carvalho67", ETipoUsuario.Cliente);
            var cliente = new Cliente("gabriel", "carvalho", user);
            var espetaculo = new Espetaculo.Domain.Entities.Espetaculo("homem aranha", "Um filme legal", 130);
            var sala1 = new Sala("sala 1", 30);
            var sessao = new Sessao(DateTime.Now.AddDays(15), espetaculo, sala1, 10.50M);
            var sessao2 = new Sessao(DateTime.Now.AddDays(16), espetaculo, sala1, 10.50M);
            
            var reserva = new Reserva(cliente, sessao2);
            var poltronas = sessao.Poltrona;
            int count = 0;
            foreach(var poltrona in poltronas) {
                if(count >= 2)
                    break;
                
                reserva.AdicionarIngresso( new Ingresso("Gustavo", poltrona));        
                count ++;
            }
        
            Console.ReadKey();
        }
    }
}
