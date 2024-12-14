using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T13_1dDynamicProgramming.P03_HouseRobber_LC198;

public class Solution {
    public int Rob(int[] nums) {
        // return dfsWrapper1(nums);
        return optimizedBottomUp(nums);
    }

    int dfsWrapper1(int[] nums)
    {
        var maxProfit = new int[nums.Length];
        Array.Fill(maxProfit, -1);
        return dfs(0, nums, maxProfit);
    }

    int dfs(int house, int[] nums, int[] maxProfit) // MEMOIZED TC: O(HOUSES) (each house computed only once) MEMOIZED SC: O(HOUSES) (because max stored for each house) //BRUTEFORCE (no memo) TC: O(2^HOUSES)
    {
        if(house >= nums.Length) //HAD > earlier
            return 0;
        
        if(maxProfit[house] == -1)
        {
            int dontRobCur = dfs(house+1, nums, maxProfit);

            int robCur = nums[house] + dfs(house+2, nums, maxProfit);//cant rob next house
            
            maxProfit[house] = robCur > dontRobCur ? robCur : dontRobCur;
        }

        return maxProfit[house];
    }

    int optimizedBottomUp(int[] nums) //TC: O(HOUSES), SC: O(1) 
    {
        //DIDN'T EVEN THINK OF THESE EDGE CASES UNTIIL ENCOUNTERING THEM!!!
        if(nums.Length==1)
            return nums[0];
        else if (nums.Length == 0)
            return 0;


        int maxProfitAt_hPlus2 = nums[nums.Length-1];
        int maxProfitAt_hPlus1 = nums[nums.Length-2];

        for(int h=nums.Length-3; h>=0; h--)
        {
            int curMaxProfit = (int) Math.Max(nums[h]+maxProfitAt_hPlus2, maxProfitAt_hPlus1);
            maxProfitAt_hPlus2 = maxProfitAt_hPlus1;
            maxProfitAt_hPlus1 = curMaxProfit;
        }

        return (int) Math.Max(maxProfitAt_hPlus1, maxProfitAt_hPlus2); //h==-1 after last loop
    }
}
