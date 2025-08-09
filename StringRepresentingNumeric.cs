using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordOffer
{
    internal class StringRepresentingNumeric
    {
        public bool Check(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                Console.WriteLine("输入字符串为空或仅包含空格。");
                return false;
            }

            s = s.Trim();

            /* 
             * row=状态
             * - 状态0：未处理
             * - 状态1：处理了符号位
             * - 状态2：处理了整数位
             * - 状态3：处理了整数后的小数点
             * - 状态4：处理了小数点（无整数）
             * - 状态5：处理了小数部分
             * - 状态6：处理了指数符号
             * - 状态7：处理了指数后的符号位
             * - 状态8：处理了指数的数字部分
             * col=字符类型
             * 0 - 数字
             * 1 - 正负号
             * 2 - 小数点
             * 3 - 指数符号
             * 4 - 其他字符
            */
            int[,] route = new int[,] {
                {2, 1, 4, -1, -1},  // 状态0
                {2, -1, 4, -1, -1},  // 状态1
                {2, -1, 3, 6, -1},   // 状态2
                {5, -1, -1, 6, -1},  // 状态3
                {5, -1, -1, -1, -1}, // 状态4
                {5, -1, -1, 6, -1},  // 状态5
                {8, 7, -1, -1, -1},  // 状态6
                {8, -1, -1, -1, -1}, // 状态7
                {8, -1, -1, -1, -1}  // 状态8
            };

            // 遍历字符串中的每个字符
            int state = 0; // 初始状态为0
            for (int i = 0; i < s.Length; i++)
            {
                int type = GetCharType(s[i]);
                state = route[state, type];
                if (state == -1)
                { 
                    return false; // 如果状态变为-1，表示不合法
                }
            }

            return state == 2 || state == 3 || state == 5 || state == 8; // 合法状态为2、3、5或8
        }

        private int GetCharType(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return 0;
            }
            else if (c == '-' || c == '+')
            {
                return 1;
            }
            else if (c == '.')
            {
                return 2;
            }
            else if (c == 'e' || c == 'E')
            {
                return 3;
            }
            else             
            {
                return 4; // 其他字符
            }
        }
    }
}
