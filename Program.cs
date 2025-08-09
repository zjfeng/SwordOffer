using System.Runtime.CompilerServices;

namespace SwordOffer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            PrintNumbersFrom1 printNumbersFrom1 = new PrintNumbersFrom1();
            printNumbersFrom1.Print(2);

        }
    }
}
