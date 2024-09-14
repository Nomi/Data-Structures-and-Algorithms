using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T02_TwoPointers.P03_3sum_LC15;

public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        return attempt1(nums);
    }

    public List<List<int>> attempt1(int[] nums) 
    {
        List<List<int>> res = new();
        HashSet<string> used = new();
        for(int i=0;i<nums.Count();i++)
        {
            HashSet<int> hs = new();
            int subSumTarget = -nums[i]; //target for the other two numbers.
            for(int j=i+1;j<nums.Count();j++)
            {
                if(hs.Contains(subSumTarget-nums[j])) //the only times duplicate numbers matter is when they're both the solution, which this condition helps with to make sure that the hashset doesn't affect our ability to handle that case by having the check be here.
                {
                    List<int> curr = new(){nums[i],subSumTarget-nums[j],nums[j]};
                    string str = string.Join(',',curr.OrderBy(x=>x).ToList());
                    if(used.Contains(str))
                        continue;
                    used.Add(str);
                    res.Add(curr);
                }
                hs.Add(nums[j]);
            }
        }
        return res;
    }
    
}
