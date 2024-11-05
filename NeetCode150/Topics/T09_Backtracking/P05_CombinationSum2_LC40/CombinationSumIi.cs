using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T09_Backtracking.P05_CombinationSum2_LC40;

public class Solution {
    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        //https://algo.monster/flowchart

        //CHECK THE HASHMAP AND OPTIMAL VERSIONS ON NEETCODEIO (written ones)?????
        //WATCH THE NEETCODE VIDEO !!!!
        return backtrack1_PickOrNot(candidates, target);
    }


    //TC: O(n*2^n) (length of subsets *  number of subsets) [we remove duplicates so it is not exactly 2^n subsets if there are duplicates]
    //SC: O(n) //subset
    public List<List<int>> backtrack1_PickOrNot(int[] candidates, int target) 
    {
        // FOR [2, 2] WE CAN HAVE SUBSETS [2, 2] (where each 2 is from different index) and [2]. Notice there's only ONE [2]. 
        //i.e. A subset may contain the duplicate values more than once, but each subset only appears once so ([2] and [2] are considered the same even if they're 2 from different indices).       
        
        //General note: 
        //We CAN (not must) use the binary decision tree when there's NO possibility of NOT picking for each element.
        //The n-nary decision tree (via iteration) HELPS when the elements MUST be picked (e.g. Permutations) (or we need to stop as soon as we can't pick up an element from all or unused-only options(like in "Combination Sum").

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
        while((idx+1)<candidates.Length && candidates[idx]==candidates[(idx+1)])
            idx++;

        //Case 2: Don't pick this
        backtrack1_PickOrNotHelper(candidates, idx+1, target, curSum, subset, res);
        
        return;
    }
}
