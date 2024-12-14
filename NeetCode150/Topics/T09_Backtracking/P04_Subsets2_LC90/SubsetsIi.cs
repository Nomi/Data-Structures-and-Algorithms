using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T09_Backtracking.P04_Subsets2_LC90;

public class Solution {
    public List<List<int>> SubsetsWithDup(int[] nums) {
        //READ COMMENTS!!
        //WATCH NEETCODE VIDEO! (I had to read the written one on neetcodeio)
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

    //TC: O(n*2^n) (length of subsets *  number of subsets)
    //SC: O(n) //subset
    public void backtrack1Helper(int[] nums, int idx, List<int> subset, List<List<int>> res)
    {
        //FOR [2, 2] WE CAN HAVE SUBSETS [2, 2] (where each 2 is from different index) and [2]. Notice there's only ONE [2]. 
        //i.e. A subset may contain the duplicate values more than once, but each subset only appears once so ([2] and [2] are considered the same even if they're 2 from different indices).       
        
        //General note: 
        //We CAN (not must) use the binary decision tree when there's NO possibility of NOT picking for each element.
        //The n-nary decision tree (USING THIS IS ALMOST A MUST WHEN WE MUST PICK AT LEAST ONE ELEMENT FROM THE LIST AT ANY STAGE)

        if(idx == nums.Length)
        {
            res.Add(new(subset)); //Use copy constructor to create new reference but same data
            return;
        }

        //Case 1: Adding current element
        subset.Add(nums[idx]);
        backtrack1Helper(nums, idx+1, subset, res);
        subset.RemoveAt(subset.Count-1);

        //**IMPORTANT PART:** SKIP ALL FUTURE INSTANCES OF THIS DIGIT (because the backtrack1Helper recursive call above will deal with those, 
        // we simply use the next case to when NONE of this digit (from ANY index after current index) is used)
        //This loop in conjunction with recursion helps do the following:
        //* Assume we start with array [1, 2, 2, 3]
        //* First, above case considers L: [1], LL: [1,2], LLL: [1,2,2], LLLL: [1,2,2,3]
        //* The loop below makes it so that for each of the above levels/nodes, respectively, we consider the following cases after not including current element:
        //* i.e. 
        // R: [2], LR: [1, 3], LRL: [1,3], LRR: [1], .......
        // LLR:[1, 2, 3], LLRL: ..., LLRR: ...
        // LLLR: [1, 1, 1, 2], ......
        //(watch Neetcode video for full chart)
        // RRRR: [] //Here, idx+1 == nums.Length (because last element), so the loop is skipped, and upon further recursion, we get our empty set back.
        while(idx+1 < nums.Length && nums[idx] == nums[idx+1])
            idx++;

        //Case 2: We do not use the current element
        backtrack1Helper(nums, idx+1, subset, res);
        
        return;
    }
}
