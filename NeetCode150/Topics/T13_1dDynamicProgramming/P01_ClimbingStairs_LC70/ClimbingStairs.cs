using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T13_1dDynamicProgramming.P01_ClimbingStairs_LC70;

//[IMPORTANT!] NOT REALLY HARD! MARKED/STARRED FOR BRINGING ATTENTION TO THESE NOTES ABOUT DP:

//## DP PATTERNS: {Get Grokking DP patterns course??}
//
// For the interview just do memoization first then explain how you might create tabulation?
//
// DP GENERALLY ONLY USED TO GET NUMERIC RESULTS? (like number of ways to do something than the ways themselves (which would generally require recursive backtracking))
//
// Got these (except Fibonacci) from Neetcode's Advanced Algorithms course videos about them.
//
// My observation: Non-optimized tabulation ends up with a similar array to the memo we would have otherwise built for memoization (even what's inside / how to build it). 
//      (I think this can make solving tabulation based DP easier because now you know exactly what kind of array you want to build, and you have a general idea of how to build it.)
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
//### 0/1 Knapsack (take / not take) [Optimitze cost-to-value] [More explanation: to maximize (or minimize?) cost/weight_or_count/population/profit within budget/storage/space/capacity limits]: {WROTE THIS MOSTLY, if not fully, ON MY OWN!!!}
//  - Memoization (top-down):
//      Uses recursive backtracking where for each item we consider adding it or not adding it (then moving onto the next one).
//          Our conditions to stop are 1. going over the weight limit or 2. running out of items.
//      We only calculate (and return) the final number of ways for each item with given capacity in POST ORDER.
//      Uses a 2D memo array that stores the result of the function call for each input pairing of indexOfElementConsidered and spaceLeft
//      Since it is memoization, it is still based on a recursive backtracking take-or-not approach.
//  - Tabulation (Bottom-Up): 
//      (??? [IMP!] Since in bruteforce or memoization we only calculate (and return) the final number of ways for each item with given capacity in POST ORDER RECURSIVE BACKTRACKING, our memo's bottom rows are filled first. ???)
//      (???    As such we use a similar approach when creating the table here. The first row ???)
//      Note that order of picking doesn't matter, but we will manually enforce one to make it work/efficient.
//      As usual, you use a similar array to the memoization soln where memo[itemIdx][capacity] stores the maximum profit possible only considering items from 0 to itemIdx (whether we take it or not) when `capacity` is the capacity left.
//      We start by manually filling the whole first row(its base case) (maximum profit possible when only considering item at idx 0 for capacities 0 through maximum capacity (starting/original capacity of bag (empty bag)))
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
//
//:::::::::::::::::::::::::::::
//### [2D] For Number of Unique Paths type problems [num unique paths from (0,0) to (ROWS-1,COLS-1) of matrix]: {WROTE THIS ON MY OWN!}
//  - It is kinda similar to 0/1 Knapsack (BOUNDED) because you can only choose 1 out of 2 nodes (down or right) for each unique path.
//  - However, the differences are that:
//      * We start from computing the only the last row first (each node from there has only one way to go, which is right, so everything == 1) [Because 1. We sort of inverted the problem to: How many ways from each node can we get to the ending, because that makes it easier/possible to calculate what we want 2. The recursive backtracking solution was post-order ??]
//      * Then for each node, number of ways to get from there to original node is the number of ways to get to the destination is the 
//          sum of number of ways to get to destination from the node to the right and node to the left (this is where DP saves us).
//      * Recursion based solution also uses similar approach just using recursion to do it and memoization just memoizes these results.
//
//:::::::::::::::::::::::::::::
//### Unbounded Knapsack [Optimized cost-to-value, but can pick same item unlimited times (unlimited quantities of items)] {wrote all of this on my own LET'S GOOO!!! Will watch neetcode video anyway, but won't edit notes unless something new comes up,}
//  {Like 0/1 Knapsack. Seems to be more common in interviews (according to NeetCode).}
//  - Memoization (top-down):
//      Uses Post-Order Recursive Backtracking to decide whether to add current item or not, BUT
//          there are more than n+2 branches in each recursion where n is the number of times this item can be kept with the current capacity: 
//              1. {RECURSIVELY} Do not pick item and move to next index. 
//              3. `FOR i=1; i*curItm.Weight <= capacityAtCurrentBranch; i++`:
//                      Inside Loop: {RECURSIVELY} Pick item for i-th time and move to next index. 
//                  LIKE WE STUDIED IN BACKTRACKING SECTION: 
//                      HERE, CLEARLY THE ORDER WE PICK ITEMS IN DOESN'T MATTER (so it's fine to pick all of this item we will be taking at once)
//                      THIS LOOP WILL COVER ALL POSSIBLE NUMBER OF TIMES WE CAN PICK THIS ITEM.
//      Here, an interesting observation would be, if we have already computed MAX PROFIT FOR EACH (curItemIdx, capacity), we can just cache that and return everytime this question is asked.
//          This is where the memo/cache comes in.
//  - Tabulation (Bottom-Up):
//      As always, non-optimized tabulation ends up with a similar array to memoization, therefore, let's think of how we can build it iteratively.
//      (Notice how the last level of post-order recursive calls in the backtracking solution will basically (since it has no context of total profit in the above recursive level) calculate max profit we can get if we only consider adding the current level any number of times given the current capacity)
//      (Our tabulation based approach uses the above idea, but since the order of items doesn't really matter, we can start from any item, so we start from the first row)
//      Since memoization used a solution, we start from the first sub array and generate it as:
//          First, foreach capacity in [0, COLS): table[0][capacity] = max profit if we can only include first item unlimited times for given capacity. (should be easy)
//          Then, foreach i-th row(1 row for each item), starting from i = 1:
//                      table[i][1] = table[i]
//                      foreach capacity in [1, COLS): //we start form 1 because 0 capacity is invalid.
//                          table[i][capacity] = MAX_PROFIT_AT_CURRENT_CAPACITY_IF_WE_ONLY_CONSIDER_CURRENT_ITEMS_OR_ONES_BEFORE_IT
//                          Here, MAX_PROFIT_AT_CURRENT_CAPACITY_IF_WE_ONLY_CONSIDER_CURRENT_ITEMS_OR_ONES_BEFORE_IT =
//                          MAX
//                          (
//                              table[i-1][capacity], //MAX CAPACITY IF WE DON'T INCLUDE CURRENT ITEM
//                              profit[i] + table[i][capacity-weight[i]] 
//                              //The above line is Different from Bounded Knapsack 
//                              //It is == profit of including current item once + table[i][capacity-weight[i]]
//                              //Where table[i][capacity-weight[i]] == Max Profit if we could include any items from [0, i] with the remaining capacity after including i-th item once.
//                                  (notice i can be used again here, unlike in Bounded Knapsack)
//                          )
//          Then the result is in the final column of the final row of the table, because it STORES MAXIMUM PROFIT IF WE CAN CONSIDER ALL COMBINATION OF
//              ITEMS ([0,numAllItems]), FOR THE FULL CAPACITY (capacity of empty knapsack).
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
//### DP on strings, bitmask, and digits???
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
