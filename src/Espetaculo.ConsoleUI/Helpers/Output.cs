using System;
using System.Threading.Tasks;

namespace Espetaculos.ConsoleUI.Helpers
{
    public static class Output
    {
        private const short SecondInMilliseconds = 1000;
        public static void Write(string output)
        {
            Console.WriteLine(output);
        }

        public static void WriteAndWait(string output, double timeSeconds)
        {
            Write(output);
            Task.Delay(Convert.ToInt32(timeSeconds) * SecondInMilliseconds);
        }
        public static void SkipLines(int number)  {
            for(int i = 0; i < number; i++) 
                Console.WriteLine();
        }

    }
}