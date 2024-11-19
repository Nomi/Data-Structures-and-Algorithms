using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T11_Graphs.P01_NumberOfIslands_LC200;

public class Solution {
    public int NumIslands(char[][] grid) {
        
        // return dfs1Wrapper(grid);
        return bfs1_MarkIslandVisited(grid);
        
    }

    ////////// DFS:
    public int dfs1Wrapper(char[][] grid)
    {
        //TC: O(ROWS*COLUMNS) SC: O(ROWS*COLUMNS)
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


    ////////// BFS (WITHOUT overwriting input array)
    HashSet<(int r, int c)> seen;
    public int bfs1_MarkIslandVisited(char[][] grid) //marks connected parts of islands as visited.
    {
        int numIslands = 0;
        seen = new();
        for(int r=0; r<grid.Length;r++)
        {
            for(int c=0; c<grid[0].Length;c++)
            {
                (int r, int c) rc = (r,c);
                // Console.WriteLine(seen.Contains(rc));
                if(grid[rc.r][rc.c]=='1' && !seen.Contains(rc))
                {
                    // Console.WriteLine(seen.Count);
                    numIslands++;
                    bfs1_Helper(grid, rc);
                }
            }
        }
        return numIslands;
    }

    public void bfs1_Helper(char[][] grid, (int r, int c) _rc)
    {
        Queue<(int r, int c)> q = new();
        q.Enqueue(_rc);
        while(q.Count>0)
        {
            var rc = q.Dequeue();
            if(rc.r<0 || rc.r>= grid.Length || rc.c<0 || rc.c>=grid[rc.r].Length || grid[rc.r][rc.c] != '1' || seen.Contains(rc))
                continue;
            (int r, int c) = rc;
            // Console.WriteLine($"{_rc.r},{_rc.c} : {r},{c}");
            seen.Add((r, c));
            q.Enqueue((r-1, c));
            q.Enqueue((r+1, c));
            q.Enqueue((r, c-1));
            q.Enqueue((r, c+1));
        }
    }
}
