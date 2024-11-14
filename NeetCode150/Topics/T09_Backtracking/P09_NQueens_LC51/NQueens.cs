using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T09_Backtracking.P09_NQueens_LC51;

public class Solution {
    public List<List<string>> SolveNQueens(int n) { 
        //IMPORTANT!!! : WATCH NEETCODE VIDEO AND CHECK MY 1ST ATTEMPT (WaysToPlaceNQueens, recBacktrackHelper)!!
        //I also had to check the solution a little before writing this and I checked for a little help many times, but it is still not hard!
        return WaysToPlaceNQueens(n);
    }

    public const char Queen = 'Q';
    public const char EmptyPlace = '.';

    private static char[] GetEmptyRow(int n) => new string(EmptyPlace, n).ToCharArray();

    public List<List<string>> WaysToPlaceNQueens(int n)
    {
        List<List<string>> res = new();

        recBacktrackHelper(
            row: 0,
            n: n,
            usedCols: new(n),
            usedPositiveDiag: new(),
            usedNegativeDiag: new(),
            curState: new(),
            res: res
        );

        return res;
    }

    public void recBacktrackHelper(int row, int n, HashSet<int> usedCols, HashSet<int> usedPositiveDiag, HashSet<int> usedNegativeDiag, List<string> curState, List<List<string>> res)
    {
        //NOTE: We don't need to check if the row has been used before because we will start from 0th row and then 
        // place each queen on the next row. (we don't need to care about placing same queen on other rows because 
        // the queens are INDISTINGUISHABLE from each other).
        //Also clearly not possible to skip a row or column because n queens and n rows and n columns.
        if(row==n)
        {
            res.Add(new(curState)); //new creates A COPY of the list.
            return;
        }

        var curRow = GetEmptyRow(n);
        
        for(int col=0; col<n; col++)
        {
            if(usedCols.Contains(col))
                continue;
            //for each element on A positive diagonal (bottom-left to top-right), 
            //the following remains constant on THAT positive diagonal (check neetcode video illustration)
            int posDiag = row+col;

            //for each element on A negative diagonal(top-left to bottom-right),
            // the following remains constant on THAT negative diagonal (check neetcode video illustration)
            int negDiag = col-row; //row-col; //or col-row, same thing.

            if(usedPositiveDiag.Contains(posDiag)||usedNegativeDiag.Contains(negDiag))
            {
                continue;
            }

            usedCols.Add(col);
            usedPositiveDiag.Add(posDiag);
            usedNegativeDiag.Add(negDiag);

            curRow[col] = Queen; // == 'Q'
            curState.Add(new string(curRow));

            recBacktrackHelper(row+1, n, usedCols, usedPositiveDiag, usedNegativeDiag, curState, res);

            curState.RemoveAt(curState.Count-1);
            curRow[col] = EmptyPlace;

            usedNegativeDiag.Remove(negDiag);
            usedPositiveDiag.Remove(posDiag);
            usedCols.Remove(col);
        }
    }
}