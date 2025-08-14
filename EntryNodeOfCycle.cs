using SwordOffer.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SwordOffer
{
    public class EntryNodeOfCycle
    {
        public ListNode FindEntry(ListNode head)
        {
            if (head == null || head.next == null)
            {
                Console.WriteLine("头节点为空或只有一个节点");
                return null;
            }

            // 确认是否存在环
            ListNode first = head;
            ListNode second = head;
            while (second != null && second.next != null)
            {
                first = first.next;
                second = second.next.next;
                if (first == second)
                {
                    Console.WriteLine("存在环");

                    int count = 1;

                    // 再遍历一遍，确认环的节点个数
                    ListNode node = second.next;
                    while (node != second)
                    {
                        count++;
                        node = node.next;
                    }

                    // 确认环的入口
                    first = head;
                    second = head;
                    for (int i = 0; i < count; i++)
                    {
                        first = first.next;
                    }

                    while (first != second)
                    {
                        first = first.next;
                        second = second.next;
                    }

                    Console.WriteLine($"环的入口为：{second.val}");
                    return second;
                }
            }

            Console.WriteLine("不存在环");
            return null;
        }
    }
}
