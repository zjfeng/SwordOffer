using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordOffer
{
    internal class RegularExpressionMatching
    {
        public bool Matching(string s, string p)
        {
            if (string.IsNullOrWhiteSpace(p))
            {
                Console.WriteLine("参数异常");
                return false;
            }

            int m = s.Length;
            int n = p.Length;

            /*
             * 存储str前i个字符和reg前j个字符的匹配情况
             * 比如str="aaa"，reg="aba"
             * dp[1,1]=true，表示str[0]=reg[0]（a=a）
             * dp[1,2]=false，表示str[0]!=reg[0]+reg[1]（a!=ab）
             * dp[2,2]=false，表示str[0]+str[1]!=reg[0]+reg[1]（aa!=ab）
             * 比如str="aaa"，reg="a*a"
             * dp[1,2]=true，表示str[0]=reg[0]+reg[1]（a=a*，当*匹配前一个字符0次时成立）
             */
            bool[,] dp = new bool[m + 1, n + 1]; // +1 是因为存在空字符的情况

            dp[0, 0] = true; // 空字符对上空模式，一定匹配

            /* 
             * 处理空字符匹配非空模式的情况
             * 只有出现*的情况才可能和空字符匹配上
             * 当出现*，假设匹配0次的情况，即*这个位置和*的前一位置为空，相当于和索引-2的位置匹配
             * str=""，reg="a*a*"，则dp[0,2]=dp[0,0]=true，dp[0,4]=dp[0,2]=true
             */
            for (int j = 1; j <= n; j++)
            {
                if (p[j - 1] == '*')
                {
                    dp[0, j] = dp[0, j - 2];
                }
            }

            /*
             * 填充其他情况
             * 情况1：s[i]=r[j]，或者r[j]='.'，则dp[i, j] = 前一个字符是否匹配，即dp[i - 1, j - 1]
             * 情况2：r[j]='*'
             * 情况2.1：*匹配前一个字符0次，则dp[i, j] = 索引-2的位置的匹配结果
             * 情况2.2：*匹配前一个字符至少1次
             */
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (p[j - 1] != '*')
                    {
                        if (p[j - 1] == '.' || s[i - 1] == p[j - 1])
                        {
                            dp[i, j] = dp[i - 1, j - 1];
                        }
                    }
                    else
                    {
                        // 子情况1：*让前一个字符出现0次
                        bool case1 = dp[i, j - 2];

                        /* 
                         * 子情况2：*让前一个字符出现至少1次（需先匹配前一个字符）
                         * 如s='aa'，p='a*'，当i=2，j=2的时候，如果要让*能匹配上a，则s[1]必须等于p[0]，
                         * 即s[i - 1] == p[j - 2]，或者p[0]='.'
                         * 只有这两种情况，s和p才能匹配上
                         * 一旦匹配上，他们的结果，就等于dp[i - 1, j]的匹配结果，
                         * 因为只有当s的前 1 个字符（"a"）与 p 的前 2 个字符（"a*"）匹配上，
                         * s的第二个字符才有可能匹配上，*是要匹配'a'的，不能匹配其他，
                         * 作为反例，假设：
                         * 字符串 s = "ba"（即 s[0] = 'b'，s[1] = 'a'）
                         * 模式 p = "a*"（即 p[0] = 'a'，p[1] = '*'）
                         * 我们来看 i=2（s的前 2 个字符"ba"）、j=2（p的前 2 个字符"a*"）时的情况：
                         * 当前字符匹配：s[i-1] = s[1] = 'a'，p[j-2] = p[0] = 'a'，满足 s[i-1] == p[j-2]（条件成立）。
                         * 但case2取决于dp[i-1, j]：
                         * i-1 = 1，j=2 → dp[1, 2] 表示：s的前 1 个字符（"b"）与p的前 2 个字符（"a*"）是否匹配？
                         * 显然，"b"与"a*"不匹配（*只能让'a'重复，而s[0]是'b'），因此 dp[1, 2] = false。
                         * 因此 case2 = dp[1, 2] = false，最终dp[2, 2]也为false（正确，因为"ba"与"a*"不匹配）。
                         */
                        bool case2 = false;
                        if (s[i - 1] == p[j - 2] || p[j - 2] == '.')
                        {
                            case2 = dp[i - 1, j];
                        }

                        dp[i, j] = case1 || case2;
                    }
                }
            }

            return dp[m, n];
        }
    }
}
