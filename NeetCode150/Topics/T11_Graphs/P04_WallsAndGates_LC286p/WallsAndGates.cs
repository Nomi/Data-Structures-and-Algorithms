using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T11_Graphs.P04_WallsAndGates_LC286p;

public class Solution {
    const int INF = 2147483647;

    public void islandsAndTreasure(int[][] grid) {
        //GO THROUGH THIS!!! (multi-source BFS is kinda fkn nifty!!)
        multisourceBfs1(grid);
    }

    public void multisourceBfs1(int[][] grid)
    {
        Queue<(int r, int c)> q = new();
        
        //// Add the multiple sources from where we start our bfs:
        for(int r=0; r<grid.Length; r++)
        {
            for(int c=0; c<grid[0].Length; c++)
            {
                if(grid[r][c]==0)
                    q.Enqueue((r,c));
            }
        }

        //// Start BFS:
        // int curDistFromGates = 1; //Due to how bfs works and since we put all treasures in the queue already and are starting bfs from there, each neighbor is exactly the same distance away from each gate. //Each element in the queue is at the same level
        while(q.Count>0)
        {
            var rc = q.Dequeue();
            msBfsHelper(rc.r-1, rc.c, rc, grid, q);
            msBfsHelper(rc.r+1, rc.c, rc, grid, q);
            msBfsHelper(rc.r, rc.c-1, rc, grid, q);
            msBfsHelper(rc.r, rc.c+1, rc, grid, q);
        }
    }

    public void msBfsHelper(int r, int c, (int r, int c) prevRC, int[][] grid, Queue<(int r, int c)> q)
    {
        //prevRC is the node from which we got to current node/neighbor.
        if(r<0||c<0||r>=grid.Length||c>=grid[0].Length||grid[r][c]!=INF) //grid[0] to avoid cache misses?
            return;
        
        q.Enqueue((r,c));

        grid[r][c] = 1+grid[prevRC.r][prevRC.c]; //Each tile is 1 away from the previous one. (We can start from treasure chests because they are marked by 0)
    }
}
