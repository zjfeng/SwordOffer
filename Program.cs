using System.Runtime.CompilerServices;

namespace SwordOffer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            NumberOf1InBinary numberOf1InBinary = new NumberOf1InBinary();
            Console.WriteLine($"找到1的个数为：{numberOf1InBinary.Find(-9)}");
        }
    }
}
