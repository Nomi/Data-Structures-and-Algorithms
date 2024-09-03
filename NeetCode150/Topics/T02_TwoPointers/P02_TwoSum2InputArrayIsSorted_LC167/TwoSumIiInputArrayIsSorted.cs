using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T02_TwoPointers.P02_TwoSum2InputArrayIsSorted_LC167;

public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
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
}
