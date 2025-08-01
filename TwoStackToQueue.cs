using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SwordOffer
{
    public class CQueue
    {
        public void appendTail(object node) 
        {
            if (node == null)
            {
                return;
            }

            stack1.Push(node);
            PrintQueue();
        }

        public void deleteHead() 
        {
            if (stack2.Count == 0)
            {
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }
            if (stack2.Count > 0)
            {
                stack2.Pop();
            }
            PrintQueue();
        }

        public void PrintQueue()
        {
            // 输出 stack2（从顶到底）
            foreach (var item in stack2)
            {
                Console.Write(item + " ");
            }

            // 输出 stack1（从底到顶）
            var arr = stack1.ToArray();
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        private Stack<object> stack1 = new Stack<object>();
        private Stack<object> stack2= new Stack<object>();
    }

    internal class TwoStackToQueue
    {
        public void Test()
        {
            CQueue queue = new CQueue();
            queue.appendTail(1);
            queue.appendTail(2);
            queue.appendTail(3);
            queue.deleteHead(); // 删除头部元素
            queue.appendTail(4);
            queue.deleteHead(); // 再次删除头部元素
        }
    }
}
