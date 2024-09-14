using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T01_ArraysAndHashing.P08_ValidSudoku_LC36;

public class Solution {
    public bool IsValidSudoku(char[][] board) {
        return attempt1(board);
    }
    public bool attempt1(char[][] board) 
    {
        //Check horizontally:
        HashSet<char> hashSet;
        foreach(var row in board)
        {
            hashSet = new(9);
            foreach(char d in row)
            {
                if(d=='.')
                    continue;
                if(hashSet.Contains(d))
                    return false;
                hashSet.Add(d);
            }
        }

        //Vertically:
        for(int r=0; r<9;r++)
        {
            hashSet = new(9);
            for(int c = 0;c<9;c++)
            {
                var curr = board[c][r];
                if(curr=='.')
                        continue;
                if(hashSet.Contains(curr))
                    return false;
                hashSet.Add(curr);
            }
        }

        //3x3 sub-boxes:
        //north-west, north, north-east,
        //west, center, east,
        //south-west, south, south-east
        int[] dc = new[]{-1,-1,-1  ,0,0,0,  1,1,1};
        int[] dr = new[]{-1,0,1 ,-1,0,1, -1,0,1};
        for(int r=1;r<8;r+=3)
        {
            for(int c=1;c<8;c+=3)
            {
                hashSet = new(9);
                for(int i=0;i<9;i++)
                {
                    var curr = board[r+dr[i]][c+dc[i]];
                    if(curr=='.')
                        continue;
                    if(c==3&&r==2)
                        Console.WriteLine(curr);
                    if(hashSet.Contains(curr))
                        {
                            Console.WriteLine($"{curr} - {c+dc[i]} - {r+dr[i]} - {i} : {c},{r}");
                            return false;
                        }
                    hashSet.Add(curr);
                }
            }
        }
        return true;
    }
}
