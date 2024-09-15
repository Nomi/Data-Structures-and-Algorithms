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
        // return attempt1(height); //PREFER LOOP STYLE FROM HERE!

        return attempt2(height); //USE ATTEMPT1 LOOP STILE RATHER THAN THIS!!
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

    public int attempt2(int[] height)
    {
        if(height==null||height.Count()==0)
            return 0;
        
        int l = 0, r = height.Count()-1;
        int lMax = 0, rMax = 0;
        int water=0;
        while(l<=r) //the way I have written this, it wouldn't work with l<r
        {
            //it doesn't work with l<r because we would not
            //calculate the water on the middle block (for odd numbered blocks).
            Console.Write($"{l},{r} : {lMax},{rMax} :");
            if(lMax<rMax)
            {
                int temp = (int)Math.Min(lMax,rMax)-height[l];
                if(temp>0) //The current bar is not higher than water level (i.e. not negative ot zero)
                    water+=temp;
                lMax = (int)Math.Max(lMax,height[l]);
                l++;
                Console.WriteLine($"l - {temp} : total_water - {water}");
            }
            else
            {
                int temp = (int)Math.Min(lMax,rMax)-height[r];
                if(temp>0) //The current bar is not higher than water level (i.e. not negative ot zero)
                    water+=temp;
                rMax = (int)Math.Max(rMax,height[r]);
                r--;
                Console.WriteLine($"r - {temp} : total_water - {water}");
            }
        }
        return water;
    }

}
