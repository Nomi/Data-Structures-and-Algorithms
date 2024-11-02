using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T09_Backtracking.P01_Subsets_LC78;

public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        List<List<int>> res = new(1<<nums.Length); // 1 << nums.Length == 2^nums.Length (which is number of possible subsets (because there are max n numbers and two choices for each of them: pick it or not))
        
        backtrack1(
            nums: nums,
            subset: new(nums.Length), // Min subset length = 0, Max subset length = nums.Length
            idx: 0,
            res: res);
        
        return res;
    }

    public void backtrack1(int[] nums, int idx, List<int> subset, List<List<int>> res)
    {
        if(idx==nums.Length) //We're at the leaf node (just think about it. Watching neetcodeio video might help visualize!)
        {
            res.Add(new(subset)); //We use the copy constructor to avoid messing up the reference
            return;
        }

        // int numSubsets = 1 << nums.Length; //==2^nums.Length
        
        // IMPORTANT NOTE: 
        // Min subset length = 0, Max subset length = nums.Length
        // => Time complexity = n*(2^n)
        // GIVEN THE CONSTRAINTS OF THE PROBLEMS, (since we want subsets and not just the count),
        // THIS IS THE BEST TIME COMPLEXITY WE CAN ACHIEVE.
        // HERE, WE USE BACKTRACKING BECAUSE IT IS MOST EFFICIENT HERE, EVEN THOUGH IT IS THE BRUTEFORCE SOLUTION.
        // (thankfully, the constraints given to us show that the input will be small so it's fine!)

        //IMPORTANT NOTE: BACKTRACKING GIVES US ONLY UNIQUE SUBSETS HERE BECAUSE THE INPUT HAS UNIQUE VALUES (no duplicates).

        // CASE 2: WE DO NOT USE THE CURRENT ELEMENT
        backtrack1(nums, idx+1, subset, res);

        // CASE 2: WE USE THE CURRENT ELEMENT
        subset.Add(nums[idx]);//Adding current to the end!
        backtrack1(nums, idx+1,subset, res);
        subset.RemoveAt(subset.Count - 1); //remove last element. //NEED TO REMOVE THIS BECAUSE IT WILL BE USED ON THE LEVEL ABOVE THIS (cuz it is shared via reference)

        return;
    }
}
