using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T02_TwoPointers.P03_3sum_LC15;

public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        // return attempt1(nums);
        return NeetCodeSolnBasedAttempt(nums);
    }

    //TC: O(nlog(n))
    public List<List<int>> NeetCodeSolnBasedAttempt(int[] nums) 
    {
        List<List<int>> res = new();
        Array.Sort(nums);//TC: O(nlog(n))
        for(int i=0; i< nums.Count(); i++)//TC:(O(nlog(n)))
        {
            if(i>0&&nums[i]==nums[i-1])
            {
                continue; 
                /// [IMPORANT] My explanation:
                //Avoids duplicates in a sorted set because 
                //there's never a common starting point/element
                // As long as we can discard all the non-distinct 
                // pairs of numbers that we add to the first element 
                //for the triplet to sum to 0.

                ////// [optional] More detailed explanation/continuation:
                //so when our result array contains these outputs sorted,
                //making starting numbers distinct (no duplicate first elem in the 3 sum elems),
                //ensures that there will never be another similar pair (even with different order)
                //because sorting cements the order.
                //Also, another interesting fact is that the two numbers that sum together will also never be together again due to the fact that their sum was only usable once, and it kind of becomes like those two sum up to one number (because we consider them together) and as such the only other option as an element would be the one we have already considered and have skipped since.
            }
            int target = -nums[i];
            int l=i+1, r=nums.Count()-1;
            while(l<r)
            {
                int cur2Sum = nums[l]+nums[r];
                if(cur2Sum>target)
                    r--;
                else if(cur2Sum<target)
                    l++;
                else //==
                {
                    res.Add(new(){nums[i],nums[l],nums[r]});
                    r--;
                    while(r>l&&nums[r]==nums[r+1])
                        r--;
                    l++;
                    while(l<r&&nums[l]==nums[l-1])
                        l++;
                    continue;
                }
            }
        }
        return res;
    }

    public List<List<int>> attempt1(int[] nums) 
    {
        List<List<int>> res = new();
        // HashSet<string> used = new();
        for(int i=0;i<nums.Count();i++)
        {
            HashSet<int> hs = new();
            int subSumTarget = -nums[i]; //target for the other two numbers.
            for(int j=i+1;j<nums.Count();j++)
            {
                if(hs.Contains(subSumTarget-nums[j])) //the only times duplicate numbers matter is when they're both the solution, which this condition helps with to make sure that the hashset doesn't affect our ability to handle that case by having the check be here.
                {
                    List<int> curr = new(){nums[i],subSumTarget-nums[j],nums[j]};
                    // string str = string.Join(',',curr.OrderBy(x=>x).ToList());
                    // if(used.Contains(str))
                    //     continue;
                    // used.Add(str);
                    res.Add(curr);
                }
                hs.Add(nums[j]);
            }
        }
        return res;
    }
    
}
