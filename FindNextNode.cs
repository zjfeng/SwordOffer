using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SwordOffer
{
    internal class FindNextNode
    {
        public TreeNode Find(TreeNode node)
        {
            if (node == null)
            {
                Console.WriteLine("Node is null.");
                return null;
            }

            if (node.right != null)
            {
                TreeNode next = node.right;
                while (next.left != null)
                {
                    next = next.left;
                }
                Console.WriteLine($"Next node is: {next.val}");
                return next;
            }
            else
            { 
                TreeNode current = node;
                while (current.parent != null)
                {
                    if (current.parent.left == current)
                    { 
                        Console.WriteLine($"Next node is: {current.parent.val}");
                        return current.parent;
                    }
                    current = current.parent;
                }
            }

            return null;
        }
    }
}
