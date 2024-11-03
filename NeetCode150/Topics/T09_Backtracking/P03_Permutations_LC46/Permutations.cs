using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T09_Backtracking.P03_Permutations_LC46;

public class Solution {
    public List<List<int>> Permute(int[] nums) {
        return backtrack1(nums);
    }

    public List<List<int>> backtrack1(int[] nums) 
    {
        List<List<int>> res = new();
        backtrack1Helper(nums, subset: new(nums.Length), hashset: new(nums.Length), res);
        return res;
    }

    public void backtrack1Helper(int[] nums, List<int> subset, HashSet<int> hashset, List<List<int>> res)
    {
        //Came up with the following condition after watching a short from GregHogg.
        if(subset.Count == nums.Length) //As discussed before, backtracking for fixed length without repetition somehow leads to uniqueness in the answers?
        {
            res.Add(subset.ToList());
        }

        for(int i=0; i<nums.Length; i++)
        {
            if(hashset.Contains(nums[i]))
                continue;
            
            subset.Add(nums[i]);
            hashset.Add(nums[i]);
            backtrack1Helper(nums, subset, hashset, res);
            subset.RemoveAt(subset.Count-1);
            hashset.Remove(nums[i]);
            //Since we MUST pick all of them at least once (by task description), we don't consider the case where we don't pick it, but just the cases for all possible numbers being at this position.
        }
    }
}
