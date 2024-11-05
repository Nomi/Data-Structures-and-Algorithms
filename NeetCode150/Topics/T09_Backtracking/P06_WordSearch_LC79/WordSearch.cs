using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T09_Backtracking.P06_WordSearch_LC79;

public class Solution {
    public bool Exist(char[][] board, string word) {
        //DID IT ALL ON MY OWN, LET'S GOOOO!!!
        return backtrack1Wrapper(board, word); //Read the ONE comment I left on it :P
    }

    public bool backtrack1Wrapper(char[][] board, string word)
    {
        for(int i=0;i<board.Length;i++)
        {
            for(int j=0; j<board[i].Length;j++)
            {
                if(word[0]==board[i][j] && backtrack1(board, word, 0, i, j))
                    return true;
            }
        }
        return false;
    }
    public bool backtrack1(char[][]board, string word, int idx, int x, int y)
    {
        if(idx==word.Length)
            return true;
        if(x==-1||y==-1||x==board.Length||y==board[x].Length||word[idx]!=board[x][y])
            return false;
        
        char curr = board[x][y];
        board[x][y] = '*'; //COULD'VE USED A SET OF TUPLES IF MODIFYING ARRAY WAS NOT ALLOWED OR THERE WAS NO UNALLOWED CHARACTER.

        bool isFound = 
            backtrack1(board, word, idx+1, x+1, y) ||
            backtrack1(board, word, idx+1, x-1, y) ||
            backtrack1(board, word, idx+1, x, y+1) ||
            backtrack1(board, word, idx+1, x, y-1);

        board[x][y] = curr;

        return isFound;
    }
}
