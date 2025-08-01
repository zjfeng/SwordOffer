using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordOffer
{
    internal class ReplaceSpace
    {
        public void Replace(string str)
        {
            if (str == null || str.Length == 0)
            { 
                Console.WriteLine("输入字符串为空或无效");
                return;
            }

            int spaceCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                { 
                    spaceCount++;
                }
            }

            if (spaceCount == 0)
            {
                Console.WriteLine("输入字符串中没有空格");
                return;
            }

            char[] newStr = new char[str.Length + spaceCount * 2];
            int p1 = str.Length - 1;
            int p2 = newStr.Length - 1;

            while (p1 >= 0)
            {
                if (str[p1] == ' ')
                {
                    newStr[p2--] = '0';
                    newStr[p2--] = '2';
                    newStr[p2--] = '%';
                    p1--;
                }
                else
                {
                    newStr[p2--] = str[p1--];
                }
            }

            Console.WriteLine("替换后的字符串: " + new string(newStr));
        }
    }
}
