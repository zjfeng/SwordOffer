using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordOffer
{
    internal class MinInRotatedArray
    {
        public int Find(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Array is null or empty.");
                return -1;
            }

            int left = 0, right = arr.Length - 1;
            while (left != right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] > arr[right])
                {
                    left = mid + 1;
                }
                else if (arr[mid] < arr[right])
                {
                    right = mid;
                }
                else
                {
                    right--;
                }
            }
            
            Console.WriteLine($"Minimum element in rotated array is: {arr[left]}");
            return arr[left];
        }
    }
}
