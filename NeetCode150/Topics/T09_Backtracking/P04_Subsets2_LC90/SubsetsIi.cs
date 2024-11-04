using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T09_Backtracking.P04_Subsets2_LC90;

public class Solution {
    public List<List<int>> SubsetsWithDup(int[] nums) {
        //READ COMMENTS!!
        //And watch Leetcode soln? (I had to read the written one on leetcodeio)
        //LOOK AT THE LEETCODEIO SOLN THAT MAKES THIS ITERATIVE!!
        
        return backtrack1(nums);
    }
    
    public List<List<int>> backtrack1(int[] nums)
    {
        List<List<int>> res = new(1 << nums.Length); //1<<n == 2^n //https://stackoverflow.com/a/10983207
        
        //IMPORTANT PART:
        Array.Sort(nums);

        backtrack1Helper(
            nums: nums,
            idx: 0,
            subset: new(nums.Length),
            res: res
        );

        return res;
    }

    public void backtrack1Helper(int[] nums, int idx, List<int> subset, List<List<int>> res)
    {
        // EACH DUPLICATE IN THE SET IS TREATED AS ITS OWN UNIQUE ENTITY (so subset can contain multiple of same value but not from the same index)! (I assume they wanted us to use a hashset for the first problem?)
        //We CAN (not must) use the binary decision tree when there's NO possibility of NOT picking for each element.
        //The n-nary decision tree (via iteration) helps when the elements MUST be picked (e.g. Permutations) (or we need to stop as soon as we can't pick up an element from all or unused-only options(like in "Combination Sum").

        if(idx == nums.Length)
        {
            res.Add(new(subset)); //Use copy constructor to create new reference but same data
            return;
        }

        //Case 1: Adding current element (only if it's not a duplicate / been encountered before.)
        subset.Add(nums[idx]);
        backtrack1Helper(nums, idx+1, subset, res);
        subset.RemoveAt(subset.Count-1);

        //IMPORTANT PART: SKIP ALL INSTANCES OF THIS DIGIT (because the backtrack1Helper recursive call above will deal with those, 
        // we simply use the next case to when NONE of ANY of this digit is used)
        //This loop in conjunction with recursion helps do the following:
        //* Assume we start with array [1, 1, 1, 1, 2]
        //* First, above case considers [1], then [1,1], then [1,1,1], then [1,1,1,1], then [1,1,1,1,2]
        //* The loop below makes it so that for each of the above levels, respectively, we consider the following cases after not including current element:
        //* i.e. [2], [1,2], [1,1,2], [1,1,1,2], and then [1,1,1,2] where ".." represents not choosing the element that could have been there.
        while(idx+1 < nums.Length && nums[idx] == nums[idx+1])
            idx++;

        //Case 2: We do not use the current element
        backtrack1Helper(nums, idx+1, subset, res);
        
        return;
    }
}
