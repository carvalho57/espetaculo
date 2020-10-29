using System;

namespace Espetaculos.ConsoleUI.Helpers
{
    public static class Input
    {

        public static int ReadInt(string message)
        {
            Console.Write(message);
            var value = Console.ReadLine();
            var sucess = int.TryParse(value, out int result);
            if (!sucess)
                throw new ArgumentException("Não foi possiveu converter o número");
            return result;
        }
        public static string ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}