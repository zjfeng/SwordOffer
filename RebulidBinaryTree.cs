using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SwordOffer
{
    internal class TreeNode
    {
        public object val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode parent;
        public TreeNode(object x) { val = x; }
    }

    internal class RebulidBinaryTree
    {
        public void Rebuild(int[] preOrder, int[] inOrder)
        {
            if (preOrder == null || preOrder.Length == 0 || inOrder == null || inOrder.Length == 0)
            {
                return;
            }

            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < inOrder.Length; i++)
            {
                map[inOrder[i]] = i; // 建立索引，避免重复对数组多次切片导致的性能问题（不含重复数字才可以这样做）
            }

            int root = preOrder[0];
            TreeNode rootNode = Rebuild(map, preOrder, 0, preOrder.Length - 1, inOrder, 0, inOrder.Length - 1);

            Visualize(rootNode);
        }

        public TreeNode Rebuild(Dictionary<int, int> map, int[] preOrder, int preStart, int preEnd, int[] inOrder, int inStart, int inEnd)
        {
            if (preStart > preEnd || inStart > inEnd)
            {
                return null;
            }

            int root = preOrder[preStart];
            TreeNode rootNode = new TreeNode(root);
            int rootIndexInInOrder = 0;
            map.TryGetValue(root, out rootIndexInInOrder);

            int leftSubLength = rootIndexInInOrder - inStart;
            rootNode.left = Rebuild(map, preOrder, preStart + 1, preStart + leftSubLength, inOrder, inStart, rootIndexInInOrder - 1);
            rootNode.right = Rebuild(map, preOrder, preStart + leftSubLength + 1, preEnd, inOrder, rootIndexInInOrder + 1, inEnd);

            return rootNode;
        }

        public void Visualize(TreeNode root)
        {
            PrintTreeVertical(root, "", true);
        }

        private void PrintTreeVertical(TreeNode node, string indent, bool isLeft)
        {
            if (node == null)
                return;

            if (node.right != null)
            {
                PrintTreeVertical(node.right, indent + (isLeft ? "        " : "│       "), false);
            }

            Console.Write(indent);
            if (isLeft)
            {
                Console.Write("└── ");
            }
            else
            {
                Console.Write("┌── ");
            }
            Console.WriteLine(node.val);

            if (node.left != null)
            {
                PrintTreeVertical(node.left, indent + (isLeft ? "│       " : "        "), true);
            }
        }
    }
}
