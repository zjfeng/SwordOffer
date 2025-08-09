using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordOffer
{
    internal class PrintNumbersFrom1
    {
        public void Print(int n)
        {
            if (n < 1)
            {
                Console.WriteLine("输入参数异常，不能小于1");
                return;
            }

            char[] chars = new char[n];
            int index = 0;
            Print(chars, index);
        }

        private void Print(char[] numbers, int index)
        {
            if (index == numbers.Length)
            {
                Console.WriteLine();
                Console.WriteLine("生成结束，开始打印");
                Print(numbers);

                return;
            }

            for (int i = 0; i < 10; i++)
            {
                numbers[index] = (char)('0' + i);
                Print(numbers, index + 1);
            }
        }

        private void Print(char[] numbers)
        {
            bool leadingZero = true;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (leadingZero && numbers[i] != '0')
                    leadingZero = false;
                if (!leadingZero)
                    Console.Write(numbers[i]);
            }
            if (!leadingZero)
                Console.WriteLine();
        }

    }
}
