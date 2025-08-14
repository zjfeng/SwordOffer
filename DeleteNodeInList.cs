using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwordOffer.Structure;

namespace SwordOffer
{
    internal class DeleteNodeInList
    {
        public void Delete(ListNode pHead, ListNode pNode)
        {
            if (pHead == null || pNode == null)
            { 
                Console.WriteLine("Invalid input: pHead or pNode is null.");
                return;
            }

            if (pNode == pHead)
            {
                pHead = null;
                pNode = null;
                Console.WriteLine("Deleted the head node.");
            }
            else if (pNode.next != null)
            {
                Console.WriteLine($"Deleting node with value: {pNode.val}");
                var nextNode = pNode.next;
                pNode.next = nextNode.next;
                pNode.val = nextNode.val;
                nextNode.next = null;
            }
            else
            {
                Console.WriteLine("Cannot delete the last node using this method.");

                // 遍历链表找到倒数第二个节点
                var current = pHead;
                while (current.next != pNode)
                {
                    current = current.next;
                }

                current.next = null;
            }

            return;
        }
    }
}
