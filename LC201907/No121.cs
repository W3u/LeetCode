using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC201907
{
    class No121
    {
        public int MaxProfit(int[] prices)
        {
            int left = 0, right = 0;
            //int minIdx, maxIdx;
            int maxProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[left] > prices[i])
                {
                    left = i;
                }
                if (prices[i] > prices[right] || left > right)
                {
                    right = i;
                }
                if (prices[right] - prices[left] > maxProfit)
                {
                    maxProfit = prices[right] - prices[left];
                    //minIdx = left;
                    //maxIdx = right;
                }
            }
            return maxProfit;
        }
    }
}
