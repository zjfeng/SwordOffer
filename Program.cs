using System.Runtime.CompilerServices;
using System.Threading.Channels;
using SwordOffer.Structure;

namespace SwordOffer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(6);
            head.next.next.next.next.next.next = head.next.next;

            EntryNodeOfCycle find = new EntryNodeOfCycle();
            find.FindEntry(head);
        }
    }
}
