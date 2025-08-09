using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordOffer
{
    internal class NumberOf1InBinary
    {
        public int Find(int num)
        {
            int count = 0;
            while (num != 0)
            {
                num &= (num - 1);
                count++;
            }

            return count;
        }
    }
}
