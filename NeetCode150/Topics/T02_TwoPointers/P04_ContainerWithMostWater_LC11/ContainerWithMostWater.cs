using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T02_TwoPointers.P04_ContainerWithMostWater_LC11;

public class Solution {
    public int MaxArea(int[] heights) {
        return attempt1(heights);
    }

    public int attempt1(int[] heights)
    {
        int maxAr = -1;
        int l=0, r=heights.Count()-1;
        while(l<r)//not == because there'd be no space for water
        {
            int ar = (int)Math.Min(heights[l],heights[r])*(r-l);
            maxAr = ar>maxAr ? ar : maxAr;
            //It is better to make the smaller bar bigger than
            //messing with the bigger of the two.
            if(heights[l]>heights[r])
            {
                r--;
            }
            else
            {
                l++;
            }
        }
        return maxAr;
    }
}
