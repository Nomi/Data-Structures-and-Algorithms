using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T05_BinarySearch.P03_KokoEatingBananas_LC875;

public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        return attempt1(piles, h);
    }
    const int MAX_BANANAS_IN_PILE = 1000000000;
    public int attempt1(int[] piles, int h)
    {
        int l = 1; //min you'd need to eat 1 banana per hour (UNLESS BANANAS IN ALL PILES CAN BE 0, WHICH CONSTRAINTS SPECIFY THEY CANNOT!)
        int r = MAX_BANANAS_IN_PILE; //[ASSUMING] WE EAT AT MOST MAX_BANANAS_IN_PILE

        int minIntEatingRate = MAX_BANANAS_IN_PILE;
        while(l<=r)
        {
            int midEatingRate = l + (r-l)/2;
            var numHoursEatingBananas = 0;
            for(int i=0;i<piles.Length;i++)
            {
                // if(midEatingRate<=2)
                // {
                //     Console.WriteLine($"l:{l}, r:{r}, midEatingRate: {midEatingRate}");
                // }
                numHoursEatingBananas += (int)Math.Ceiling((double)piles[i]/midEatingRate);
            }
            if(numHoursEatingBananas>h)
                l = midEatingRate+1;
            else if (numHoursEatingBananas<=h)
            {
                r = midEatingRate-1;
                // minIntEatingRate = (int) Math.Min(midEatingRate, minIntEatingRate)
                //Due to how binary search works, we don't need Math.Min
                minIntEatingRate = midEatingRate;
            }
        }
        if(minIntEatingRate == MAX_BANANAS_IN_PILE)
            return -1;
        return minIntEatingRate;
    }
}
