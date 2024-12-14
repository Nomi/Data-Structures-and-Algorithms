using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T05_BinarySearch.P02_SearchA2dMatrix_LC74;

public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        return attempt1(matrix, target);   
    }

    public bool attempt1(int[][] matrix, int target) 
    {
        int u = 0, d = matrix.Length-1;
        while(u<=d)
        {
            int mid = u+(d-u)/2;
            int[] midArr = matrix[mid];
            if(midArr[0]>target)
                d = mid-1;
            else if(midArr[midArr.Length-1]<target)
                u = mid+1;
            else //if it exists, it will be in here.
            {
                return bsHelper1(midArr, target);
            }
        }
        return false; //there wasn't even a matrix whose range this element belonged to.
    }
    public bool bsHelper1(int[] row, int target)
    {
        int l=0, r=row.Length-1;
        while(l<=r)
        {
            int mid = l+(r-l)/2;
            int midNum = row[mid];
            if(midNum<target)
                l = mid+1;
            else if(midNum>target)
                r = mid-1;
            else //==
                return true;
        }
        return false; //not found.
    }
}
