using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwordOffer.Structure;

namespace SwordOffer
{
    internal class PrintLinkFromTailToHead
    {
        public void Print(ListNode node)
        {
            // 使用栈实现从尾到头打印链表
            Stack<int> stack = new Stack<int>();
            while (node != null)
            {
                stack.Push(node.val);
                node = node.next;
            }

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

            //// 使用递归实现从尾到头打印链表
            //if (node == null) return;
            //Print(node.next);
            //Console.WriteLine(node.val);
        }
    }
}
