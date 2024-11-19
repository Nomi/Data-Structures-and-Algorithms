using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T11_Graphs.P01_NumberOfIslands_LC200;

public class Solution {
    public int NumIslands(char[][] grid) {
        int numIslands = 0;
        for(int r = 0; r < grid.Length; r++)
        {
            for(int c = 0; c< grid[0].Length; c++)
            {
                if(grid[r][c] == '1')
                {
                    numIslands += 1;
                    dfs1_MarkIslandVisited(grid, r, c);
                }
            }
        }
        return numIslands;
    }

    char visited = '*'; //if not allowed to overwrite input array, we could use a seen (HashSet of tuples r,c),
    public void dfs1_MarkIslandVisited(char[][] grid, int r, int c) //marks connected parts of islands as visited.
    {
        if(r<0 || r>= grid.Length || c<0 || c>=grid[r].Length || grid[r][c] != '1')
            return;
        
        grid[r][c]=visited;

        dfs1_MarkIslandVisited(grid, r+1, c); //down
        dfs1_MarkIslandVisited(grid, r-1, c); //up
        dfs1_MarkIslandVisited(grid, r, c+1); //right
        dfs1_MarkIslandVisited(grid, r, c-1); //left
        return;
    }
}
