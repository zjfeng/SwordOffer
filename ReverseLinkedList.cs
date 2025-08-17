using SwordOffer.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordOffer
{
    public class ReverseLinkedList
    {
        public ListNode Reverse(ListNode head)
        {
            if (head == null || head.next == null)
            {
                Console.WriteLine("Empty or single node list, no need to reverse.");
                return head;
            }

            ListNode current = head;
            ListNode prev = null;
            while (current != null)
            {
                ListNode next = current.next;
                current.next = prev;

                prev = current;
                current = next;
            }

            return prev;
        }
    }
}
