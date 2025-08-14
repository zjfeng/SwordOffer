using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwordOffer.Structure;

namespace SwordOffer
{
    internal class TheK_thNodeFromTheEndInLink
    {
        public int Find(ListNode head, int k)
        {
            if (head == null || k < 1)
            {
                Console.WriteLine("参数异常");
                return -1;
            }

            ListNode first = head;
            ListNode second = head;

            for (int i = 0; i < k; i++)
            {
                if (first == null)
                {
                    Console.WriteLine("链表不存在倒数第k位元素，因为长度不足");
                    return -1;
                }
                
                first = first.next;
            }

            while (first != null)
            {
                first = first.next;
                second = second.next;
            }

            return second.val;
        }
    }
}
