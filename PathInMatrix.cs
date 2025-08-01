using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordOffer
{
    internal class PathInMatrix
    {
        public bool Find(char[][] chars, string str)
        { 
            int rows = chars.Length;
            int cols = chars[0].Length;
            if (rows == 0 || cols == 0)
            {
                Console.WriteLine("Matrix is empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("String is null or empty.");
                return false;
            }

            bool[,] visited = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Find(chars, str, i, j, 0, visited))
                    {
                        Console.WriteLine("找到路径");
                        return true; // 找到路径
                    }
                }
            }

            Console.WriteLine("没有找到路径");
            return false; // 没有找到路径
        }

        public bool Find(char[][] chars, string str, int row, int col, int index, bool[,] visited)
        {
            // 全字匹配成功
            if (index >= str.Length)
            { 
                Console.WriteLine("All characters matched.");
                return true;
            }

            // 越界或字符不匹配或已访问过
            if (row < 0 || row >= chars.Length ||
                col < 0 || col >= chars[0].Length ||
                chars[row][col] != str[index] ||
                visited[row, col])
            {
                return false;
            }

            // 标记当前字符为已访问
            visited[row, col] = true;

            bool found = Find(chars, str, row - 1, col, index + 1, visited) || // 上
                Find(chars, str, row, col + 1, index + 1, visited) || // 右
                Find(chars, str, row + 1, col, index + 1, visited) || // 下
                Find(chars, str, row, col - 1, index + 1, visited); // 左

            // 标记当前字符为未访问
            visited[row, col] = false;

            return found;
        }
    }
}
