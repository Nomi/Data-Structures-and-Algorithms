using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T13_1dDynamicProgramming.P01_ClimbingStairs_LC70;

//[IMPORTANT!] NOT REALLY HARD! MARKED/STARRED FOR BRINGING ATTENTION TO THESE NOTES ABOUT DP:

//## DP PATTERNS: {Get Grokking DP patterns course??}
//
// DP GENERALLY ONLY USED TO GET NUMERIC RESULTS? (like number of ways to do something than the ways themselves (which would generally require recursive backtracking))
//
// Got these (except Fibonacci) from Neetcode's Advanced Algorithms course videos about them.
//
//:::::::::::::::::::::::::::::
//### Fibonacci [to calculate a value]: {wrote this one on my own, so there might be some incorrect stuff}
//  - Memoization (Top-down):
//      Really just stores the result for each input (as 1D array).
//  - Tabulation (Bottom-Up):
//      Uses a similar array to Memoization and iteratively 
//      fills the array starting from before (the first k e.g. k==2 in actual fibonacci) are manually set (to values of base cases in memoization's recursion)
//  - Optimized Tabulation (Bottom-Up): 
//      Constant space you realize you only really need as many as last k values (the number of base cases) (e.g. k==2 in actual fibonacci), so you use an array to store them.
//:::::::::::::::::::::::::::::
//### 0/1 Knapsack (take / not take) [Optimitze cost-to-value] [More explanation: to maximize (or minimize?) cost/weight_or_count/population/profit within budget/storage/space/capacity limits]:
//  - Memoization (top-down):
//      Uses a 2D memo array that stores the result of the function call for each input pairing of indexOfElementConsidered and spaceLeft.
//      Since it is memoization, it is still based on a recursive backtracking take-or-not approach.
//  - Tabulation (Bottom-Up): 
//      Note that order of picking doesn't matter, but we will manually enforce one to make it work/efficient.
//      As usual, you use a similar array to the memoization soln where memo[itemIdx][capacity] stores the maximum profit possible only considering items from 0 to itemIdx (whether we take it or not) when `capacity` is the capacity left.
//      We start by manually filling the whole first row(it's base case) (maximum profit possible when only considering item at idx 0 for capacities 0 through maximum capacity (starting/original capacity of bag (empty bag)))
//      For each column in the rest of the rows, let row = r and c = col, we SET 
//          `memo[r][c]` TO THE MAXIMUM_OF `memo[r-1][c](skipping item at r: i.e. max profit using only items from [0,r-1] with capacity c)`
//          and `profit[r] (profit by picking only current element) + memo[r-1][c-weight[r]] (max profit possible by only considering items 0 to r-1 when capacity is the capacity left after picking current item)`
//      Clearly, at memo[N][C] where N is last item index and C is starting capacity (of empty bag),
//          we set `maximum profit when all items are being considered and the bag is empty (starting capacity)`
//          which is our answer. So, we can return it.
//  - Optimized Tabulation (Bottom-Up):
//      If you look at the above algorithm, you'll realize, for any given row, 
//      we only read values from the row prior to it,
//      and we only set values to the current row. 
//      Therefore, we can only use a two row array to get optimize SC from O(N*C) to O(2*C)==O(N)
//  - QUESTION: Does choosing the order of the indices of memo matter?
//:::::::::::::::::::::::::::::
//### Unbounded Knapsack [Optimized cost-to-value, but can pick same item unlimited times]
//  - Memoization (top-down):
//
//  - Tabulation (Bottom-Up):
//
//  - Optimized Tabulation (Bottom-Up):
//
//:::::::::::::::::::::::::::::
//### Longest Common Sequence:
//
//  - Memoization (top-down):
//
//  - Tabulation (Bottom-Up):
//
//  - Optimized Tabulation (Bottom-Up):
//
//:::::::::::::::::::::::::::::
//### Palindromes:
//  - Memoization (top-down):
//
//  - Tabulation (Bottom-Up):
//
//  - Optimized Tabulation (Bottom-Up):
//
//:::::::::::::::::::::::::::::

public class Solution {
    public int ClimbStairs(int n) {     
        if(n<3)
            return n;
        //Seems to be the Fibonacci pattern for DP.
        //at i==0 we are at the ground.
        int prevPrev = 1; //i==1 from i==0
        int prev = 2; //i==2 from i == 0 (two once or one twice)
        for(int i = 3; i < n+1; i++)
        {
            //curNumWays = (numWaysToGetAtPrev*numWaysFromPrev + numWaysToGetAtPrevPrev*numWaysFromPrevPrev). Here, as explained in the actual assignment, numWaysFromPrev == 1 & numWaysFromPrevPrev == 1.
            int curWays = 
                (prev) //Only one possible choice to get here from prev, so we don't need prev+1 or prev+2 as I tried doing earlier.
                + (prevPrev); //Only one possible choice to get here from prevPrev: two steps at once  (one step twice NOT INCLUDED because it is included in prev)
            prevPrev = prev;
            prev = curWays;

            //Note: at i-th iteration, prevPrev = {curWays at i-2th iteration} and prev = {curWays at idx i-1th iteration}
            //So, at i == (n-1), prev becomes == `curWaysAtN-1 = curWaysAtN-3 + curWaysAtN-2`
        }

        return prev; //for i==n
    }
}
