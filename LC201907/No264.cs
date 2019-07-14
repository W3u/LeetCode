/*
 279. Perfect Squares
Medium

Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.

Example 1:

Input: n = 12
Output: 3 
Explanation: 12 = 4 + 4 + 4.
Example 2:

Input: n = 13
Output: 2
Explanation: 13 = 4 + 9.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC201907
{
    public class No264
    {
        public int NthUglyNumber(int n)
        {
            if (n == 0)
                return 0;
            int t2 = 0, t3 = 0, t5 = 0;
            int[] uglyNum = new int[n + 1];
            uglyNum[0] = 1;
            for (int i = 1; i < n; i++)
            {
                uglyNum[i] = Math.Min(uglyNum[t2] * 2, Math.Min(uglyNum[t3] * 3, uglyNum[t5] * 5));
                if (uglyNum[i] == uglyNum[t2] * 2)
                    t2++;
                if (uglyNum[i] == uglyNum[t3] * 3)
                    t3++;
                if (uglyNum[i] == uglyNum[t5] * 5)
                    t5++;
            }
            return uglyNum[n - 1];
        }

    }
}
