using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordOffer
{
    internal class CutTheRope
    {
        public void Cut(int len)
        {
            if (len < 2)
            {
                Console.WriteLine("The length of the rope must be at least 2 to cut it into pieces.");
                return;
            }

            int[] deps = new int[len + 1];
            deps[0] = 0;
            deps[1] = 0;
            deps[2] = 1;
            deps[3] = 2;

            if (len == 2)
            {
                Console.WriteLine("乘积最大为1");
                return;
            }
            else if (len == 3)
            {
                Console.WriteLine("乘积最大为2");
                return;
            }

            for (int i = 4; i <= len; i++)
            {
                int max = int.MinValue;
                for (int j = 1; j <= i / 2; j++) // j只需到i/2，因为过了一半之后，后面都是重复的（对称重复）
                {
                    int current = Math.Max(j, deps[j]) * Math.Max(i - j, deps[i - j]);
                    max = Math.Max(max, current);
                }
                deps[i] = max;
            }

            Console.WriteLine($"长度为{len}的绳子，剪短后每段的长度的最大乘积为：{deps[len]}");
        }
    }

    internal class CutTheRope2
    {
        public void Cut(int len)
        {
            if (len < 2)
            {
                Console.WriteLine("The length of the rope must be at least 2 to cut it into pieces.");
                return;
            }

            if (len == 2)
            {
                Console.WriteLine("乘积最大为1");
                return;
            }
            else if (len == 3)
            {
                Console.WriteLine("乘积最大为2");
                return;
            }

            int timesOf3 = len / 3;
            int remainder = len % 3;

            if (remainder == 1)
            { 
                timesOf3 -= 1; // 如果余数为1，减少一个3，增加一个4（3+1=4）
                remainder = 4;
            }
            else if (remainder == 0)
            {
                remainder = 1; // 如果余数为0，直接使用3的乘积
            }

            int maxProduct = (int)Math.Pow(3, timesOf3) * remainder;
            Console.WriteLine($"长度为{len}的绳子，剪短后每段的长度的最大乘积为：{maxProduct}");
            return;
        }
    }
}
