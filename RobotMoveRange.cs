using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordOffer
{
    internal class RobotMoveRange
    {
        public void Find(int rows, int cols, int sub)
        {
            if (rows < 0 || cols < 0 || sub < 0)
            { 
                Console.WriteLine("Invalid input: rows, cols, and sub must be non-negative.");
                return;
            }

            bool[,] visited = new bool[rows, cols];
            Console.WriteLine($"机器人总共可以到达{IsValid(rows, cols, sub, 0, 0, visited)}个格子");
            return;
        }

        public int GetDigitSum(int row, int col)
        {
            return row % 10 + row / 10 + col % 10 + col / 10;
        }

        private int GetDigitSum(int num)
        {
            // 计算数字的各位之和，
            // 相比较上一种方法，用这种方式可以处理任意非负整数
            // 上一种方法只适用于两位数以内的整数
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }

        public int IsValid(int rows, int cols, int sub, int row, int col, bool[,] visited)
        {
            if (row < 0 || col < 0 ||
                row >= rows || col >= cols || visited[row, col] ||
                GetDigitSum(row) + GetDigitSum(col) > sub)
            {
                return 0;
            }

            visited[row, col] = true;

            return 1 + IsValid(rows, cols, sub, row - 1, col, visited) +
                           IsValid(rows, cols, sub, row + 1, col, visited) +
                           IsValid(rows, cols, sub, row, col - 1, visited) +
                           IsValid(rows, cols, sub, row, col + 1, visited);
        }
    }
}
