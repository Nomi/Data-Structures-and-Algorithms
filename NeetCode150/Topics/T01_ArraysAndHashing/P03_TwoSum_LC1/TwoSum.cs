using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T01_ArraysAndHashing.P03_TwoSum_LC1;

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        //if not sorted then we can't use twopointers and we use hashing!
        Dictionary<int,int> map = new(); //value to idx
        for(int i=0; i<nums.Count();i++)
        {
            var num = nums[i];
            //we can't return the number itself so we will add it to the map after checking(e.g. need 4 and current is first 2, so we need to be sure we don't return this back)
            if(map.ContainsKey(target-num))
                return new int[] {map[target-num],i};
            map.TryAdd(num, i); //we don't check if it is actually added (as it is tryadd) because even if it repeats, it doesn't really matter since it failed the above condition and just one of it is fine. And since every input has exactly one pair of indices that satisfy the condition, it probably isn't even the answer.
        }
        throw new Exception("Should never get here because there's exactly one such solution.");
    }
}
