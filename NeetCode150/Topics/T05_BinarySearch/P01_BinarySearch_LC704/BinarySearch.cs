using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T05_BinarySearch.P01_BinarySearch_LC704;

public class Solution {
    public int Search(int[] nums, int target) {
        return attempt1(nums, target);
    }

    public int attempt1(int[] nums, int target) 
    {
        int l=0, r=nums.Length-1;
        while(l<=r)
        {
            var mid = l+(r-l)/2;
            var numMid = nums[mid];
            Console.WriteLine(numMid);
            //Be careful about checking the inequalities because I had them switched at first (and seems to happen often).
            //Basically, if numMid<target, it means number is on right and we can contract left to focus on that window.
            //And vice-versa.
            if(numMid<target)
            {
                l=mid+1; //+1 because we already checked mid.
            }
            else if(numMid>target)
            {
                r=mid-1;
            }
            else //==
            {
                return mid;
            }
        }
        return -1;
    }
}
