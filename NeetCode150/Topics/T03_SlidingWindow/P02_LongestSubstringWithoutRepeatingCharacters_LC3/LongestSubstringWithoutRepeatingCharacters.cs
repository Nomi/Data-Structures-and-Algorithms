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
        ///READ COMMENTS FROM THIS FOR TIPS IN GENERAL 
        ///WITH WHILE LOOPS AND SLIDING WINDOW/TWO POINTERS!:
        // return attempt1(s);

        //USE FOR MAIN REFERENCE:
        return NeetCodeProvidedSoln(s);


        //PRACTICE ATTEMPTS:
        //return attempt2(string s);
    }

    public int attempt1(string s)
    {
        if(s.Length<2)
            return s.Length;
        HashSet<char> hs = new();
        int l=0;int r=1;
        hs.Add(s[l]);
        int maxLength=1;
        while(r<s.Length)
        {
            // THIS WAS HERE EARLIER BUT THAT'S DUMB AND BAD
            // because it only updates max if there's a duplicate
            // which won't trigger if the string reaches the end 
            // for the last substring.
            // maxLength=(int)Math.Max(r-l+1, maxLength);
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
            
            //THIS NEEDS TO BE HERE AND NOT ABOVE (like I had it earlier)
            //AS EXPLAINED ABOVE!
            maxLength=(int)Math.Max(r-l+1, maxLength);
            r++;
        }
        return maxLength;
    }

    public int NeetCodeProvidedSoln(string s)
    {
                HashSet<char> charSet = new HashSet<char>();
        int l = 0;
        int res = 0;

        for (int r = 0; r < s.Length; r++) {
            while (charSet.Contains(s[r])) {
                charSet.Remove(s[l]);
                l++;
            }
            charSet.Add(s[r]);
            res = Math.Max(res, r - l + 1);
        }
        return res;
    }

    // public int attempt1(string s)
    // {

    // }
}
