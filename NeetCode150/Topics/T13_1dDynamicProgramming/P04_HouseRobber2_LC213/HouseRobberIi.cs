using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T13_1dDynamicProgramming.P04_HouseRobber2_LC213;

public class Solution {
    public int Rob(int[] nums) {
        //MY FIRST IDEA: WE JUST ROB UNTIL WE GET TO THE END AND THEN FOR THE LAST HOUSE WE DECIDE WHETHER TO ROB IT OR NOT BASED ON IF THE FIRST HOUSE WAS ROBBED.
        //WE ONLY NEED TO ENSURE ONE THING (im not fully sure, so watch neetcode or greghogg or striver video afterwards):
        //  IF WE ROB FIRST HOUSE, DON'T ROB LAST HOUSE.
        return dfsWrapper1(nums);

        //Actually, Bottom-Up and Space Optimized Bottom-Up solutions were easier for me to concieve here because you could have separate arrays for each (robbing first house and not robbing).
        //I checked the neetcodeio solutions and it's basically the same thing. Though, they did do them in a smarter way I guess. (creating a helper and calculate for each robbing first house and not robbing and then return the max among them) 
        //As such, in interest of time, I'll just take another good look at them and move to the next problem!  [ my interview is in 2 days :'( ]

        //DO MAKE SURE TO DO THEM WHEN DONE WITH THE INTERVIEW (and practice the memoized solution!)!!
    }
    int dfsWrapper1(int[] nums)
    {
        var maxProfit = new int[nums.Length][]; //2 for bool;
        for (int i = 0; i < nums.Length; i++) 
        {
            maxProfit[i] = new int[] {-1, -1};//neetcodeio doesn't support yet: [-1, -1];
        }
        return dfs(0, nums, maxProfit);
    }
    //Had to take a look at the neetcodeio soln to see exactly how to do this (after trying a little, but hadn't added the flag as second argument of memo (TBF, I was thinking whether I should are not))
    int dfs(int house, int[] nums, int[][] maxProfit, int wasFirstHouseRobbed = 0) // MEMOIZED TC: O(HOUSES) (each house computed only once) MEMOIZED SC: O(HOUSES) (because max stored for each house) //BRUTEFORCE (no memo) TC: O(2^HOUSES)
    {
        if(house >= nums.Length || (house == nums.Length-1 && wasFirstHouseRobbed == 1))
            return 0;
        if(maxProfit[house][wasFirstHouseRobbed] == -1)
        {
            int dontRobCur = dfs(house+1, nums, maxProfit, wasFirstHouseRobbed);

            int robCur = nums[house] + dfs(house+2, nums, maxProfit, (house == 0 || wasFirstHouseRobbed ==  1? 1 : 0));//can't rob next house
            
            maxProfit[house][wasFirstHouseRobbed] = robCur > dontRobCur ? robCur : dontRobCur; //remember, before first house is robbed, it isn't robbed so flag should be 0/false then too.
        }

        return maxProfit[house][wasFirstHouseRobbed];
    }

}
