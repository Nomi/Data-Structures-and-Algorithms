using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T09_Backtracking.P01_Subsets_LC78;

public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        
    }

    public List<List<int>> backtrack1(int[] nums)
    {
        int numSubsets = 1 << nums.Length; //==2^nums.Length
        
        // IMPORTANT NOTE: 
        // Min subset length = 0, Max subset length = nums.Length
        // => Time complexity = n*(2^n)
        // GIVEN THE CONSTRAINTS OF THE PROBLEMS, (since we want subsets and not just the count),
        // THIS IS THE BEST TIME COMPLEXITY WE CAN ACHIEVE.
        // HERE, WE USE BACKTRACKING BECAUSE IT IS MOST EFFICIENT HERE, EVEN THOUGH IT IS THE BRUTEFORCE SOLUTION.
        // (thankfully, the constraints given to us show that the input will be small so it's fine!)

        //IMPORTANT NOTE: BACKTRACKING GIVES US ONLY UNIQUE SUBSETS HERE BECAUSE THE INPUT HAS UNIQUE VALUES (no duplicates).
    }
}
