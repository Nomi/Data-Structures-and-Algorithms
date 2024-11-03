using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T09_Backtracking.P02_CombinationSum_LC39;

public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) 
    {
        //:::IMPORTANT NOTES:::
        //READ THE COMMENTS!!!
        //WATCH THE NEETCODE VIDEO (just skim through it)
        //CHECK NEETCODEIO SOLNS (incl. the OPTIMAL verision!)

        //Check the sortedOptimalBacktrack1 approach too (aside from the normal backtrack1) 
        //backtrack1 is more important I guess? Just need to have a rough idea of how optimal backtrack works! (and remember it!)
        
        // return backtrack1(nums, target);
        return sortedOptimalBacktrack1(nums, target);
    }


    
    //Time complexity: O(2^ target) because the smallest possible number in nums is 1, so we can have at most target number of 1s as the height of our decision tree (depth of deepest branch) and for each branch there can only be 2 decisions USE or DISCARD, we get 2^target as MAX number of possible nodes in the decision tree..
    //Space complexity: O((2^target+1)/2) // L = (N + 1)/2 where L is number of leaves for a tree with N nodes.
    //CAN ALSO READ MORE ABOUT THIS IN NEETCODEIO SOLNS
    public List<List<int>> backtrack1(int[] nums, int target)
    {
        List<List<int>> res = new();

        backtrack1Helper(nums, idx: 0, target, sumThusFar: 0, subset: new(), res);
        
        return res;
    }
    //Time complexity: O(2^ target) because the smallest possible number in nums is 1, so we can have at most target number of 1s as the height of our decision tree (depth of deepest branch) and for each branch there can only be 2 decisions USE or DISCARD, we get 2^target as MAX number of possible nodes in the decision tree..
    //Space complexity: O((2^target+1)/2) // L = (N + 1)/2 where L is number of leaves for a tree with N nodes.
    //CAN ALSO READ MORE ABOUT THIS IN NEETCODEIO SOLNS
    public void backtrack1Helper(int[] nums, int idx, int target, int sumThusFar, List<int> subset, List<List<int>> res)
    {
        //WATCH NEETCODE VIDEO!!!

        if(sumThusFar>target || idx==nums.Length) //Almost forgot about the idx>nums.Length condition
            return;
        if(target==sumThusFar)
        {
            res.Add(new(subset)); // I KEEP FORGETTING TO ADD A COPY, NOT THE REFERENCE!!! (using the copy constructor)
            return;
        }

        //Case 1: We use current element
        subset.Add(nums[idx]);
        backtrack1Helper(nums, idx, target, sumThusFar+nums[idx], subset, res);

        //Case 2: We never use current element again
        subset.RemoveAt(subset.Count-1);
        backtrack1Helper(nums, idx+1, target, sumThusFar, subset, res);

        return;
    }


    //Time complexity: O(2^target) because the smallest possible number in nums is 1, so we can have at most target number of 1s as the height of our decision tree (depth of deepest branch) and for each branch there can only be 2 decisions USE or DISCARD, we get 2^target as MAX number of possible nodes in the decision tree..
    //Space complexity: O((2^target+1)/2) // L = (N + 1)/2 where L is number of leaves for a tree with N nodes.
    //CAN ALSO READ MORE ABOUT THIS IN NEETCODEIO SOLNS
    public List<List<int>> sortedOptimalBacktrack1(int[] nums, int target)
    {
        Array.Sort(nums); //default sort by ascending I think
        List<List<int>> res = new();

        sortedOptimalBacktrack1Helper(nums, idx: 0, target, sumThusFar: 0, subset: new(), res);
        
        return res;
    }
    public void sortedOptimalBacktrack1Helper(int[] nums, int idx, int target, int sumThusFar, List<int> subset, List<List<int>> res)
    {
        //SEARCH SPACE PRUNING!
        //BASED ON: https://blog.seancoughlin.me/solving-leetcodes-combination-sum-problem-optimized-techniques-for-efficient-solutions#heading-optimizing-the-backtracking-solution 
        //Archived URL: https://web.archive.org/web/*/https://blog.seancoughlin.me/solving-leetcodes-combination-sum-problem-optimized-techniques-for-efficient-solutions#heading-optimizing-the-backtracking-solution

        if(target==sumThusFar)
        {
            res.Add(new(subset)); // I KEEP FORGETTING TO ADD A COPY, NOT THE REFERENCE!!! (using the copy constructor)
            return;
        }

        for(int i=idx; i<nums.Length;i++)
        {
            if(sumThusFar+nums[i] > target)
                return; //No other branch under of this node from this point on will have the solution, so we can safely exclude/prune them from our search space!
            //Case: We pick the number at i-th index but none before that:
            subset.Add(nums[i]);
            sortedOptimalBacktrack1Helper(nums, i, target, sumThusFar+nums[i], subset, res);
            subset.RemoveAt(subset.Count-1);  //Removing from end of list is always complexity O(1)!!!
        }
        return;
    }


}
