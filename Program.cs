using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace SwordOffer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ChangeOrder changer = new ChangeOrder();
            Console.WriteLine($"chenged:{string.Join(", ", changer.Change(new int[] { 1,1,2,3,4,5,2,1,3}))}");
        }
    }
}
