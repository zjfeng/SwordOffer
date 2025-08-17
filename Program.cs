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

            ListNode head1 = new ListNode(1);
            head1.next = new ListNode(3);
            head1.next.next = new ListNode(5);

            ListNode head2 = new ListNode(2);
            head2.next = new ListNode(4);
            head2.next.next = new ListNode(6);

            MergeTwoSortedLinkedLists find = new MergeTwoSortedLinkedLists();
            var ne = find.Merge(head1, head2);
            while (ne.next != null)
            { 
                Console.WriteLine(ne.val);
                ne = ne.next;
            }
        }
    }
}
