using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T03_SlidingWindow.P02_LongestSubstringWithoutRepeatingCharacters_LC3;

public class Solution {
    //# Sliding Window:
    //      TC: O(N)
    //      SC: O(N) (or O(k) where k is the length of longest substring, which is <=N and as such this is asymptotically bounded by O(N))
    public int LengthOfLongestSubstring(string s) {
        if(s.Length<2)
            return s.Length;
        HashSet<char> hs = new();
        int l=0;int r=1;
        hs.Add(s[l]);
        int maxLength=1;
        while(r<s.Length)
        {
            if(hs.Contains(s[r]))
            {
                while(hs.Contains(s[r]))
                {
                    hs.Remove(s[l]);
                    l++;
                }
                if(l==r)
                {
                    hs.Add(s[l]);
                    r++;
                    continue;
                }
            }
            hs.Add(s[r]);
            maxLength=(int)Math.Max(r-l+1, maxLength);
            r++;
        }
        return maxLength;
    }
}
