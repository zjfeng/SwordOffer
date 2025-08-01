using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SwordOffer
{
    internal class SearchIn2DArray
    {
        public void Find(int[][] array, int search)
        {
            if (array == null || array.Length == 0 || array[0].Length == 0)
            {
                Console.WriteLine("数组为空或无效");
                return;
            }

            int rows = array.Length;
            int cols = array[0].Length;
            int row = 0;
            int col = cols - 1;
            int number = array[row][col];
            while (row < rows && col >= 0)
            {
                if (number == search)
                {
                    // 找到元素
                    Console.WriteLine($"找到元素 {search} 在位置 ({row}, {col})");
                    return;
                }
                else if (number > search)
                {
                    // 向左移动
                    col--;
                }
                else if (number < search)
                {
                    // 向下移动
                    row++;
                }
                number = array[row][col];
            }
        }
    }
}
