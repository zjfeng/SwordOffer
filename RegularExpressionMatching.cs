using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordOffer
{
    internal class RegularExpressionMatching
    {
        public void Matching(string str, string reg)
        {
            if (string.IsNullOrWhiteSpace(str) ||
                string.IsNullOrWhiteSpace(reg))
            {
                Console.WriteLine("参数异常");
                return;
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (reg[i] != '*')
                {
                    if (str[i] == reg[i] || reg[i] == '.')
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("匹配失败1");
                        return;
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        Console.WriteLine("匹配失败2");
                        return;
                    }
                    else
                    {

                    }
                }
            }
        }
    }
}
