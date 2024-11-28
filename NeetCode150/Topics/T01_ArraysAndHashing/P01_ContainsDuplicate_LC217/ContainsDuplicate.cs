using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T01_ArraysAndHashing.P01_ContainsDuplicate_LC217;

public class Solution {
    public bool hasDuplicate(int[] nums) {
        HashSet<int> seen = new();
        for(int i=0;i<nums.Count();i++)
        {
            if(!seen.Add(nums[i]))
                return true;
        }
        return false;
    }
}
