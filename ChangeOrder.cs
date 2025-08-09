using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordOffer
{
    internal class ChangeOrder
    {
        public int[] Change(int[] ints)
        {
            if (ints == null || ints.Length == 0)
            {
                return new int[0];
            }

            int p1 = 0, p2 = ints.Length - 1;

            while (p1 < p2)
            {
                while (p1 < p2 && ints[p1] % 2 != 0) p1++;
                while (p1 < p2 && ints[p2] % 2 == 0) p2--;

                if (p1 < p2)
                {
                    int temp = ints[p1];
                    ints[p1] = ints[p2];
                    ints[p2] = temp;
                }
            }

            return ints;
        }
    }
}
