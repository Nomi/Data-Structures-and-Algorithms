using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T03_SlidingWindow.P01_BestTimeToBuyAndSellStock_LC121;

public class Solution {
    public int MaxProfit(int[] prices) {
        if(prices.Count()<2)
            return 0;
        int maxProfit = 0;
        int l=0; int r=1;
        while(r<prices.Count())
        {
            if(prices[r]>prices[l])
                maxProfit=(int)Math.Max(maxProfit, prices[r]-prices[l]);
            else
                l=r;
            r++;
        }
        return maxProfit;
    }
}
