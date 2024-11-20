using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T11_Graphs.P05_RottingOranges_LC994;

public class Solution {
    public int OrangesRotting(int[][] grid) {
        //READ COMMENTS!!
        return msbfs1(grid);
    }

    const int empty = 0;
    const int fresh = 1;
    const int rotten = 2;

    //TC: O(r*c)
    //SC: O(r*c) //worst case being when every cell is a rotten fruit.
    public int msbfs1(int[][]grid)
    {
        //IMPOTTANT NOTES:
        // - Coming up with the freshFruitCount was(or seems like) a happy accident.
        // - I FORGOT TO READ THE QUESTION AGAIN AND DIDN'T REALIZE I NEEDED TO RETURN A -1
        // - I NEED TO MAKE SURE TO NOT JUST ASSUME STUFF IN THE INTERVIEWS (WHERE THIS KIND OF STUFF ISN'T EVEN LISTED, BUT YOU'RE REQUIRED TO ASK OR STATE YOUR ASSUMPTIONS)
        // - FORGOT ABOUT THE EDGE CASE WHERE THERE ARE ALREADY NO FRESH FRUITS UNTIL FAILED A TEST CASE!!! NEED TO HANDLE THAT (OR SHOULD JUST MOVE THE -2 FROM THE FINAL RETURN TO WHEN ASSIGNING maxSeconds EACH TIME AND INITIALIZE maxSeconds TO 0)
        // - TURNS OUT THE GRID DOESN'T NEED TO BE n*n IN SIZE (not neccessarily a square grid). (found this out after exception in a test case)

        int maxSeconds = 0;
        int freshFruitCount = 0;
        Queue<(int r, int c)> q = new();

        //Add the starting points (sources)
        for(int r=0; r<grid.Length; r++) //TC: O(r*c)
        {
            for(int c=0; c<grid[0].Length; c++)
            {
                if(grid[r][c]==rotten)
                    q.Enqueue((r,c));
                else if(grid[r][c]==fresh)
                    freshFruitCount++;
            }
        }
        if(freshFruitCount==0)
            return 0;

        //BFS
        while(q.Count>0) //TC: O(r*c)
        {
            (int r, int c) = q.Dequeue();
            handleCurrent1(r-1, c, r, c, ref maxSeconds, ref freshFruitCount, grid, q);
            handleCurrent1(r+1, c, r, c, ref maxSeconds, ref freshFruitCount, grid, q);
            handleCurrent1(r, c-1, r, c, ref maxSeconds, ref freshFruitCount, grid, q);
            handleCurrent1(r, c+1, r, c, ref maxSeconds, ref freshFruitCount, grid, q);
        }
        if(freshFruitCount!=0) //check handleCurrent1 comments.
            return -1;
        return maxSeconds-2; //-2 to remove the initial 2 we add from the rotten fruit start.
    }
    public void handleCurrent1(int r, int c, int prevR, int prevC, ref int maxSeconds, ref int freshFruitCount, int[][] grid, Queue<(int r, int c)> q)
    {
        if(r<0 || c<0 || r>=grid.Length || c>=grid[0].Length || grid[r][c]!=fresh)
            return;
        freshFruitCount--; //due to the condition, each fresh fruit will be processed only once and that too by its nearest rotten fruit (or whichever ends up in being first in the queue if there are multiple same distance away).
        grid[r][c] += grid[prevR][prevC]; //think about it. it works out to place number of minutes required for the rot to reach current place.
        if(grid[r][c]>maxSeconds) maxSeconds = grid[r][c];
        q.Enqueue((r,c));
    }
}
