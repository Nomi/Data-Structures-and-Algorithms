using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T02_TwoPointers.P03_3sum_LC15;

public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        //READ THIS: https://leetcode.com/problems/3sum/editorial/comments/1056876
        // return attemptNoSort1(nums);

        //Main Way to Solve:
        // return attemptTwoPtr1_NeetCodeSolnBasedAttempt(nums);
        return attemptTwoPtr2(nums);
    }

    //TC: O(n^2) // O(nlog(n)+n^2) but n^2 dominates nlog(n) asympotitcally
    //SC: O(1)
    public List<List<int>> attemptTwoPtr1_NeetCodeSolnBasedAttempt(int[] nums) 
    {
        List<List<int>> res = new();
        Array.Sort(nums);//TC: O(nlog(n))
        for(int i=0; i< nums.Count(); i++)//TC:(O(n^2))
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

    //TC: O(n^2)
    //SC: O(n)
    //This is only better when you're not allowed to change the nums array
    //as then you'd have to store a copy of nums array as well, 
    //at which point it'd be better to just use this method where you keep a hashset to keep track of duplicates partially.
    public List<List<int>> attemptNoSort1(int[] nums) 
    {
        List<List<int>> res = new();
        HashSet<string> used = new(); //could've used tuple?
        for(int i=0;i<nums.Count();i++) //TC: O(n^2)
        {
            HashSet<int> hs = new();
            int subSumTarget = -nums[i]; //target for the other two numbers.
            for(int j=i+1;j<nums.Count();j++) //this is pretty much twosum 2
            {
                if(hs.Contains(subSumTarget-nums[j])) //the only times duplicate numbers matter is when they're both the solution, which this condition helps with to make sure that the hashset doesn't affect our ability to handle that case by having the check be here.
                {
                    List<int> curr = new(){nums[i],subSumTarget-nums[j],nums[j]};

                    //Could've been used tuples here (instead of str)!
                    string str = string.Join(',',curr.OrderBy(x=>x).ToList()); //This sort is constant time because there's always 3 comparisons!
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

    public List<List<int>> attemptTwoPtr2(int[] nums)
    {
        List<List<int>> res = new();
        //For avoiding duplicates, this sorting is better because of space complexity being O(1).
        Array.Sort(nums);
        for(int i=0; i<nums.Count();i++)
        {
            if(i>0&&nums[i]==nums[i-1])
                continue; //Avoiding duplicates (cuz array sorted)
            int target = -nums[i];
            int l=i+1, r=nums.Count()-1;
            while(l<r)
            {
                var sum = nums[l]+nums[r];
                if(sum>target)
                    r--;
                else if(sum<target)
                    l++;
                else //==
                {
                    res.Add(new(){nums[i],nums[l],nums[r]});
                    l++;
                    r--;
                    while(l<r&&nums[r]==nums[r+1])
                        r--;
                    while(l<r&&nums[l]==nums[l-1])
                        l++;
                }
            }
        }
        return res;
    }
    
}
