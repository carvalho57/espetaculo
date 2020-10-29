using System;
using System.Linq;
using Espetaculos.ConsoleUI.Pages;
using Espetaculos.Domain.Entities;
using Espetaculos.Domain.Enums;
using Espetaculos.Domain.ValueObjects;

namespace Espetaculos.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var option = new MainMenu().GetOption();
            option.Action();
        }
    }
}
