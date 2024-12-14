using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T11_Graphs.P06_PacificAtlanticWaterFlow_LC417;

public class Solution {
    IPacificAtlanticWaterflowSolver solver;
    public List<List<int>> PacificAtlantic(int[][] heights) {
        //IMPORTANT:
        // - Read comments.
        // - Had to watch GregHogg's short about this
        // - Also skimmed through some (NOT-implementation-related) parts of its Neetcode video
        // - Sneaked a few peeks at the solution on neetcodeio for a general idea on how to implement
        // - [EXTRA IMPORTANT] the idea of one dfs function for both of the oceans did not come to me until I saw it in the given solutions (on neetcodeio), but I might have come up with it? Maybe?
        // - could've done BFS (in fact, check BFS solution on Neetcodeio (the Python version cuz C# version doesn't use HashSet but a weird bool m*n matrix, but sets might be marginally better in space because they only have what can be reached from the ocean that set belongs to))
        // - [EXTRA IMPORTANT] TAKE A LOOK AT THIS AGAIN AND SKIM THROUGH IT AT LEAST
        // - [EXTRA IMPORTANT] The bool[] m*n solution on neetcode works because we can mark every node we reach as visited and so it can serve purposes of both tracking what was visited and all places we can reach
        //      + [EXTRA IMPORTANT] We can't discard nodes we visit from current node but water can't flow from there because a path without current node/cell might also exist.
        // - Had to check soln on neetcodeio to see previous value was provided as an int from the argument
        // - Took me like 40 minutes even with all the above help (was my first time), so might need to practice? (or maybe I can already do it faster?)
        // - Maybe you should watch the full neetcode video now?
        solver = new DfsAttempt1();
        return solver.Solve(heights);
    }
}

public interface IPacificAtlanticWaterflowSolver
{
    List<List<int>> Solve(int[][] heights);
}

public class DfsAttempt1 : IPacificAtlanticWaterflowSolver
{
    HashSet<(int r, int c)> pacificSet;
    HashSet<(int r, int c)> atlanticSet;

    public List<List<int>> Solve(int[][] heights)
    {
        pacificSet = new();
        atlanticSet = new();

        //1. DFS from the each tile in the horizontal rows with direct connection to Pacific ocean OR Atlantic ocean to get all tiles FROM which water can get here (the tile where we run dfs from)
        for(int c = 0; c < heights[0].Length; c++)
        {
            dfs(0, c, heights, pacificSet, int.MinValue);
            dfs(heights.Length-1, c, heights, atlanticSet, int.MinValue);
        }

        //2. DFS from the each tile in the Vertical columns with direct connection to Pacific ocean OR Atlantic ocean to get all tiles FROM which water can get here (the tile where we run dfs from)
        for(int r=0; r<heights.Length;r++)
        {
            dfs(r, 0, heights, pacificSet, int.MinValue);
            dfs(r, heights[0].Length-1, heights, atlanticSet, int.MinValue);
        }

        //3. Find all the ones that are common for both and return them as result
        List<List<int>> result = new();
        foreach(var rc in pacificSet)
        {
            if(atlanticSet.Contains(rc))
                result.Add(new List<int>{rc.r, rc.c});
        }

        return result;
    }

    private void dfs(int r, int c, int[][]heights, HashSet<(int r, int c)> oceanSet, int prevVal) //the idea of one dfs function for both of the oceans did not come to me until I saw it in the given solutions (on neetcodeio), but I might have come up with it? Maybe?
    {
        var rc = (r,c);
        if( r<0 || c<0 || r >= heights.Length || c >= heights[0].Length || oceanSet.Contains(rc))
            return;

        if(heights[r][c] >= prevVal) //Water can flow!!
        {
            oceanSet.Add(rc); //we only add it here because the water might be able to get to others from a different path without going through the node with prevVal
            dfs(r-1, c, heights, oceanSet, heights[r][c]);
            dfs(r+1, c, heights, oceanSet, heights[r][c]);
            dfs(r, c-1, heights, oceanSet, heights[r][c]);
            dfs(r, c+1, heights, oceanSet, heights[r][c]);
        }
    }
}