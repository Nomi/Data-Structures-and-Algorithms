using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T02_TwoPointers.P04_ContainerWithMostWater_LC11;

public class Solution {
    public int MaxArea(int[] heights) {
        return attempt1(heights); //TC: O(N) //READ THE COMMENTS??
    }

    //TC: O(N)
    //Since width has to decrease as we change heights, we want to make sure the bar we swap is the smaller one and make it bigger.
    //almost like having pre-sorted width because we start from max width and decrease it by 1 with every change of bars.
    public int attempt1(int[] heights)
    {
        int maxAr = -1;
        int l=0, r=heights.Count()-1; //we start from max width and decrease it as a tradeoff for height from hereonforth.
        while(l<r)//not == because that's just one bar.
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
