using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T03_SlidingWindow.P04_PermutationInString_LC567;

public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        //check provided solution for more streamlined code?
        return attempt1(s1,s2);
    }

    public bool attempt1(string s1, string s2)
    {
        if(s1.Length>s2.Length)
            return false;
        int[] freq1 = new int[26]; //initialized to 0 by default.
        for(int i=0;i<s1.Length;i++)
        {
            freq1[s1[i]-'a']++;
        }

        int l=0;
        int[] freq2 = new int[26];
        bool found = false;
        for(int r=0;r<s2.Length;r++)
        {
            freq2[s2[r]-'a']++;
            //+1 gets length!
            if(r-l+1==s1.Length)//making sure the window is the size of s1, cuz we want to look for permutation of s1
            {
                found = true;
                for(int i=0;i<26;i++)
                {
                    if(freq1[i]!=freq2[i])
                    {
                        found = false;
                    }
                }
                if(found)
                    return true;
                
                freq2[s2[l]-'a']--;
                l++;
                continue;
            }
            //Here only if r-l+1>=S1.Length
                // continue;
            // if(r-l+1==s1.Length)
            // {

            // }
        }
        return false;
    }
}
