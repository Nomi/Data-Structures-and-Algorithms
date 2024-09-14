using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T02_TwoPointers.P01_ValidPalindrome_LC125;

public class Solution {
    public bool IsPalindrome(string s) {
        s=s.ToLower();
        int matched=0;
       for(int i=0, j=s.Length-1;i<=j;) //i<j because middle element  i==j
       {
            if(!Char.IsLetterOrDigit(s[i]))
            {
                i++;
                continue;
            }
            if(!Char.IsLetterOrDigit(s[j]))
            {
                j--;
                continue;
            }
            if(s[i]!=s[j])
                return false;
            i++; 
            j--;
       } 
       return true;
    }
}
