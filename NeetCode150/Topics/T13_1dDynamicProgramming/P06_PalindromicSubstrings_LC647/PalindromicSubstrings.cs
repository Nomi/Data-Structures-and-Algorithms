using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T13_1dDynamicProgramming.P06_PalindromicSubstrings_LC647;

public class Solution {
    public int CountSubstrings(string s) {
        return attempt1(s);
    }

    int attempt1(string s)
    {
        //I had forgot the problem (I read it a day ago so not 100% my fault this time except should've read again)
        //This was pretty easy, actually.
        int count = 0;
        for(int i = 0; i<s.Length; i++)
        {
            //ODD LENGTH PALINDROMES:
            int l = i;
            int r = i;
            for(; l>=0 && r<s.Length; l--, r++)
            {
                if(s[l]!=s[r]) //This is DP part because we cull the search space here. Because `a{palindrome}b` is not a palindrome. //Also handles the basecase of single letter for odd pallindromic subtrings loop.
                    break;
                //Since `a{palindrome}a` and `a` are palindromic this loop will break only when the first non palindromic string is found.
                count++;
            }

            //EVEN LENGTH PALINDROMES:
            l = i;
            r = i+1;
            for(; l>=0 && r<s.Length; l--, r++)
            {
                if(s[l]!=s[r]) //This is DP part because we cull the search space here. Because `a{palindrome}b` is not a palindrome.
                    break;
                //Since `a{palindrome}a` and `a` are palindromic this loop will break only when the first non palindromic string is found.
                count++;
            }
        }

        return count;
    }

    // int attempt1(string s)
    // {
    //     //FCK I MISREAD THE PROBLEM (but this time it was due to reading it yesterday and doing it now.)
    //     // if(s.Length<1)
    //     //     return s.Length;

    //     // (int l, int r) max = (0,0);
    //     int maxLen = 0; //DEPRECATED: //=1;//could do 0 and it'd still work since we return above for empty str anyway.

    //     for(int i = 0; i<s.Length; i++)
    //     {
    //         //ODD LENGTH PALINDROMES:
    //         int l = i;
    //         int r = i;
    //         for(; l>=0 && r<s.Length; l--, r++)
    //         {
    //             Console.WriteLine($"ODD Candidate ?? {l},{r}");
    //             if(s[l]!=s[r]) //This is DP part because we cull the search space here. Because `a{palindrome}b` is not a palindrome. //Also handles the basecase of single letter for odd pallindromic subtrings loop.
    //                 break;
    //             Console.WriteLine($"ODD Palindrome == {l},{r}");
    //             //Since `a{palindrome}a` and `a` are palindromic this loop will break only when the first non palindromic string is found.
    //         }
    //         r--; l++; //Because the current position of these are not palindromes (since we broke out of the loop), but the one right before it should be (because of above loop)
    //         if(maxLen < r-l+1)
    //         {
    //             // max = (r, l);
    //             maxLen = r-l+1;
    //         }

    //         //EVEN LENGTH PALINDROMES:
    //         l = i;
    //         r = i+1;
    //         for(; l>=0 && r<s.Length; l--, r++)
    //         {
    //             if(s[l]!=s[r]) //This is DP part because we cull the search space here. Because `a{palindrome}b` is not a palindrome.
    //                 break;
    //             //Since `a{palindrome}a` and `a` are palindromic this loop will break only when the first non palindromic string is found.
    //         }
    //         r--; l++; //Because the current position of these are not palindromes (since we broke out of the loop), but the one right before it should be (because of above loop)
    //         if(maxLen < r-l+1)
    //         {
    //             // max = (r, l);
    //             maxLen = r-l+1;
    //         }
    //     }

    //     return maxLen;
    // }
}
