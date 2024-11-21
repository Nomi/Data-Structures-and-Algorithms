using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T11_Graphs.P07_SurroundedRegions_LC130;

public class Solution {

    ISurroundedRegionsSolver solver;
    public void Solve(char[][] board) {
        solver = new Dfs1();
        solver.Solve(board);
    }
}

public interface ISurroundedRegionsSolver
{
    void Solve(char[][] board);
}

public class Dfs1 : ISurroundedRegionsSolver
{
    //COULDN'T COME UP WITH THE SOLUTION ON MY OWN (did think about trying to invert the problem but I did not invert it correctly enough)

    const char O = 'O';
    const char X = 'X';
    const char NOT_SURROUNDED = '#';

    public void Solve(char[][] board) 
    {
        //Clearly, for an edge to be NOT SURROUNDED, it needs to connect directly OR indirectly to the outer boundaries of the array.

        //1. MARK SURROUNDED TILES
        for(int rc=0; rc<board.Length; rc++) //Assumes NUM ROWS == NUM COLS
        {
            markNotSurroundedIfVistedDfs(rc, 0, board);//LEFT EDGE
            markNotSurroundedIfVistedDfs(0, rc, board);//TOP EDGE
            markNotSurroundedIfVistedDfs(rc, board.Length-1, board);//RIGHT EDGE
            markNotSurroundedIfVistedDfs(board.Length-1, rc, board);//BOTTOM EDGE
        }

        //2. TURN NOT_SURROUNDED TILES BACK TO `O`s AND SURROUNDED TO `X`s.
        for(int r=0; r<board.Length; r++)
        {
            for(int c=0; c<board[0].Length; c++) //assumes every row is of same length
            {
                if(board[r][c] == O)
                    board[r][c] = X;
                else if(board[r][c]==NOT_SURROUNDED)
                    board[r][c] = O;
            }
        }
    }

    public void markNotSurroundedIfVistedDfs(int r, int c, char[][] board)
    {
        if(r<0 || c<0 || r>= board.Length || c>= board[0].Length || board[r][c] != O)
            return;
        
        board[r][c] = NOT_SURROUNDED;

        markNotSurroundedIfVistedDfs(r-1, c, board);//up
        markNotSurroundedIfVistedDfs(r+1, c, board);//down
        markNotSurroundedIfVistedDfs(r, c-1, board);//left
        markNotSurroundedIfVistedDfs(r, c+1, board);//right
    }
}