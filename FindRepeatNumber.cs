using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordOffer
{
    internal class FindRepeatNumber
    {
        public bool Find(int[] ints)
        {
            Console.WriteLine("FindRepeatNumber.Find called with input: " + string.Join(", ", ints));

            if (ints == null || ints.Length == 0)
            {
                Console.WriteLine("Invalid input: array is null or empty.");
                return false;
            }

            for (int i = 0; i < ints.Length; i++)
            {
                if (ints[i] < 0 || ints[i] > ints.Length - 1)
                {
                    Console.WriteLine("Invalid input: " + ints[i] + " at index " + i);
                    return false;
                }
            }

            for (int i = 0; i < ints.Length; i++)
            {
                while (ints[i] != i)
                {
                    if (ints[i] == ints[ints[i]])
                    { 
                        Console.WriteLine("Duplicate found: " + ints[i]);
                        return true;
                    }

                    int temp = ints[i];
                    ints[i] = ints[temp];
                    ints[temp] = temp;
                }
            }

            Console.WriteLine("No duplicates found in the input array.");

            return false;
        }
    }
}
