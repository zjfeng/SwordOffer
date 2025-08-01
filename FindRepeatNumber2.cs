using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordOffer
{
    internal class FindRepeatNumber2
    {
        public bool Find(int[] ints)
        {
            if (ints.Length == 0 || ints == null)
            {
                return false;
            }

            for (int i = 0; i < ints.Length; i++)
            {
                if (ints[i] < 1 || ints[i] > ints.Length - 1)
                {
                    return false;
                }
            }

            int left = 1, right = ints.Length - 1;

            while (left < right)
            {
                /*
                 * middle的计算：
                 * 通过先计算 right - left（差值通常远小于 left + right），
                 * 避免了 left + right 可能导致的整数溢出（尤其当 left 和 right 接近整数最大值时），
                 * 同时保持了数学结果的等价性。
                 */
                int middle = left + (right - left) / 2;
                
                int count = 0;

                foreach (var item in ints)
                {
                    if (item <= middle)
                    {
                        count++;
                    }
                }

                if (count > middle)
                {
                    // 存在重复
                    right = middle;
                }
                else
                {
                    // 暂时安全，看另一边
                    left = middle + 1;
                }
            }

            Console.WriteLine($"找到重复数字：{left}");

            return true;
        }
    }
}
