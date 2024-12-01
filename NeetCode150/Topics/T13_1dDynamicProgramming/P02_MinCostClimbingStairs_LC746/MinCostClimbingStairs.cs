using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T13_1dDynamicProgramming.P02_MinCostClimbingStairs_LC746;

public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        //This is like fibonacci, so the shared basecase would be right at the last step.
        //Also like my solution to `climbing stairs` so check that.
        //I HAD AN ERROR BECAUSE JUST PAST LAST INDEX IMPLIES nubCistAtiPlust2 = 0 and our loop starts from i = cost.Length-2
        int minCostAt_iPlus2 = cost[cost.Length - 1];
        int minCostAt_iPlus1 = cost[cost.Length - 2];
        
        for(int i = cost.Length - 3; i >= 0; i--)
        {
            int curCost = cost[i];
            curCost += (int)Math.Min(minCostAt_iPlus1, minCostAt_iPlus2);
            
            minCostAt_iPlus2 = minCostAt_iPlus1;
            minCostAt_iPlus1 = curCost;
        }
        
        //TOOK ME  20 MINUTES TO FIGURE OUT (and even chatGPT had to find it) that:
        //  After iterating through all steps, the minimum cost to reach the top can be achieved by starting either from step 0 or step 1. Therefore, the final return value should be the minimum of the costs associated with these two starting points.
        // SHOULD'VE READ THE DESCRIPTION BECAUSE IT STATES: You may choose to start at the index 0 or the index 1 floor.
        return (int)Math.Min(minCostAt_iPlus1, minCostAt_iPlus2);;
    }
}
