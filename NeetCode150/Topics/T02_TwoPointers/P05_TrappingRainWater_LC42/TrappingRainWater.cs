using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T02_TwoPointers.P05_TrappingRainWater_LC42;

public class Solution {
    //## TWO POINTER APPROACH:
    //# TC = O(N)
    //# SC = O(1)
    public int Trap(int[] height) {
        return attempt1(height);
    }

    //## TWO POINTER APPROACH:
    //# TC = O(N)
    //# SC = O(1)
    public int attempt1(int[] height)
    {
        if(height==null||height.Count()==0)
            return 0;

        // // NeetCode Video Assisted:
        int water = 0;
        int l=0, r=height.Count()-1;
        int lMax=height[l], rMax = height[r];
        while(l<r)
        {
            if(lMax<rMax)
            {
                l++;
                lMax= (int) Math.Max(lMax,height[l]);
                water += lMax-height[l]; //never negative because of the statement directly above!
            }
            else
            {
                r--;
                rMax= (int) Math.Max(rMax,height[r]);
                water += rMax-height[r]; //never negative because of the statement directly above!
            }
        }
        return water;


        ////My old attempt:
        // for(int l=1;l<-2-1+height.Count();l++)
        // {
        //     int r=l+1;
        //     // if(height[l]<height[r])
        //     //     continue;
        //     while(r+1<height.Count()&&height[r]<height[r+1])
        //         height++;
        //     int minHeight
        // }
    }
}
