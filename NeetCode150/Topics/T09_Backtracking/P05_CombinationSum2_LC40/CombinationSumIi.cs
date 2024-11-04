using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T09_Backtracking.P05_CombinationSum2_LC40;

public class Solution {
    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        //CHECK THE HASHMAP AND OPTIMAL VERSIONS ON NEETCODEIO (written ones)?????
        //WATCH THE NEETCODE VIDEO MAYBE!!!!
        return backtrack1_PickOrNot(candidates, target);
    }


    public List<List<int>> backtrack1_PickOrNot(int[] candidates, int target) 
    {
        List<List<int>> res = new();
        Array.Sort(candidates);

        backtrack1_PickOrNotHelper(
            candidates,
            idx: 0,
            target,
            curSum: 0,
            subset: new(candidates.Length),
            res
        );
        return res;
    }

    public void backtrack1_PickOrNotHelper(int[] candidates, int idx,int target, int curSum, List<int> subset, List<List<int>> res)
    {
        if(target == curSum)
        {
            res.Add(subset.ToList());
            return;
        }
        if(curSum>target || idx == candidates.Length) //curSum>target => we can't get desired target because all elements >=1 according to constraints.
            return;

        //Case 1: Pick this
        subset.Add(candidates[idx]);
        backtrack1_PickOrNotHelper(candidates, idx+1, target, curSum+candidates[idx], subset, res);
        subset.RemoveAt(subset.Count-1);

        //Skip repetition of this element (since the above loop takes care of that and we don't want to do it twice(or more)!!!!)
        //This loop in conjunction with recursion helps do the following:
        //* Assume we start with array [1, 1, 1, 1, 2]
        //* First, above case considers [1], then [1,1], then [1,1,1], then [1,1,1,1], then [1,1,1,1,2]
        //* The loop below makes it so that for each of the above levels, respectively, we consider the following cases after not including current element:
        //* i.e. [2], [1,2], [1,1,2], [1,1,1,2], [1,1,1,2], and then []
        while((idx+1)<candidates.Length && candidates[idx]==candidates[(idx+1)])
            idx++;

        //Case 2: Don't pick this
        backtrack1_PickOrNotHelper(candidates, idx+1, target, curSum, subset, res);
        
        return;
    }
}
