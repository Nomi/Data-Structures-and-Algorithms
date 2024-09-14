using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T02_TwoPointers.P02_TwoSum2InputArrayIsSorted_LC167;

public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        // return attempt1(numbers, target);
        return attempt2(numbers, target);
    }

    public int[] attempt1(int[] numbers, int target)
    {
        int l=0;
        int r=numbers.Count()-1;
        while(true)
        {
            var sum = numbers[l]+numbers[r];
            if(target>sum)
                l++;
            else if(target<sum)
                r--;
            else //==
                return new int[2]{1+l,1+r}; //1-indexed
        }
        //GIVEN: There will always be exactly one valid solution.
        //So we don't need to bother considering quitting out of the loop and stuff.
    }

    public int[] attempt2(int[] numbers, int target)
    {
        int l=0, r=numbers.Count()-1;
        while(true)
        {
            if(l>r)
                return new int[]{-1,-1};
            int sum = numbers[l] + numbers[r];
            if(sum>target)
            {
                r--;
            }
            else if(sum<target)
            {
                l++;
            }
            else //==
            {
                return new int[]{l+1,r+1};
            }
        }
    }
}
