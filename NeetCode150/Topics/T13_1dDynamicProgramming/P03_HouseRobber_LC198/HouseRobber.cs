using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T13_1dDynamicProgramming.P03_HouseRobber_LC198;

public class Solution {
    public int Rob(int[] nums) {
        return dfsWrapper1(nums);
    }

    int dfsWrapper1(int[] nums)
    {
        var maxProfit = new int[nums.Length];
        Array.Fill(maxProfit, -1);
        return dfs(0, nums, maxProfit);
    }

    int dfs(int house, int[] nums, int[] maxProfit)
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
}
