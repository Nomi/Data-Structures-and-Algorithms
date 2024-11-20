using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T11_Graphs.P02_MaxAreaOfIsland_LC695;

public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        return dfs1(grid);
    }

    /////// DFS (NO INPUT ARRAY OVERWRITE)
    HashSet<(int r, int c)> seen;
    int dfs1(int[][] grid)
    {
        seen=new();

        int maxArea = 0;
        for(int r=0; r<grid.Length; r++)
        {
            for(int c=0; c<grid[0].Length; c++)
            {
                var rc = (r,c);
                if(grid[r][c]==1 && !seen.Contains(rc))
                {
                    var curArea = dfs1Helper(grid, rc);
                    if(maxArea < curArea)
                        maxArea = curArea;
                }
            }
        }
        return maxArea;
    }

    int dfs1Helper(int[][] grid, (int r, int c) rc)
    {
        if(rc.r<0||rc.r>=grid.Length||rc.c<0||rc.c>=grid[rc.r].Length||grid[rc.r][rc.c]==0 || seen.Contains(rc)) //keep forgetting to add 'rc.' before r and c here. Could try (int r, int c) = rc above this line for easy fix.
            return 0;

        int sum = 1;
        seen.Add(rc);

        sum += dfs1Helper(grid, (rc.r-1, rc.c)); //Up
        sum += dfs1Helper(grid, (rc.r+1, rc.c)); //Down
        sum += dfs1Helper(grid, (rc.r, rc.c-1)); //Left
        sum += dfs1Helper(grid, (rc.r, rc.c+1)); //Right

        return sum;
    }
}
