using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T03_SlidingWindow.P03_LongestRepeatingCharacterReplacement_LC424;

public class Solution {
    public int CharacterReplacement(string s, int k) {
        //Used NeetCode's video 
        //to speed my progress because I was stuck without 
        //much of an idea!:
        // return attempt1OverEngineered(s,k); 
        

        //More realistic and the MAIN way of doing it for me? Maybe?
        return attempt2Realistic(s,k);
    }
    // public void fillArr(T[] arr, T val)
    // {
    //     for(int i=0;i<arr.Count();i++)
    //     {
    //         arr[i] = val;
    //     }
    // }


    //OverEngineered variant
    //TC: O(N)
    //SC: O(1)
    //NOTE: This only works because not decrementing maxFreq
    // does not affect the result because in order to have
    // a better max result (window length), we need more
    // elements of the same kind (=> bigger maxFreq) to
    // ensure we have bigger window while having same/constant
    // replacements. 
    public int attempt1OverEngineered(string s, int k) //based on second part of neetcode's solution
    {
        if(s.Length<2)
            return s.Length;
        
        int[] charFreq = new int[26]; //initialized to 0s by default.
        //Used NeetCode's video (shortform) to speed my progress because I was stuck without much of an idea!
        
        int maxLen = 0;
        int l=0;
        int maxFreq = 0;
        for(int r=0;r<s.Length;r++)
        {
            charFreq[s[r]-'A']++;
            if(charFreq[s[r]-'A']>maxFreq)
                maxFreq = charFreq[s[r]-'A'];
            
            int lettersToChange = (r-l+1) - maxFreq;
            if(lettersToChange>k)
            {
                charFreq[s[l]-'A']--;
                l++;
            }
            if((r-l+1)>maxLen)//because of needing to include right
                maxLen=(r-l+1);
        }
        return maxLen;
        ////My previous attempt:
        // while(r<s.Length)
        // {
        //     if(++charFreq[s[r]-'A']>maxFreq)
        //         maxFreq = charFreq[s[r]-'A'];
        //     //r-l == window length (sliding window)
        //     //window length - maxFreq == number of characters to replace.
        //     while(r<s.Length&&k>r-l-maxFreq)
        //     {
        //         r++;
        //         if(++charFreq[s[r]-'A']>maxFreq)
        //             maxFreq = charFreq[s[r]-'A'];
        //     }
        //     if(r-l>maxLen)
        //         maxLen = r-l;
        //     while()
        //     {
        //         //
        //         if
        //         l++;
        //     }
        // }
    }

    //Realistic algorithm
    //TC: O(N)  //O(26*N) but asymptotically bounded by O(N) //i.e. there exists another line (cuz linear) that is higher than it for all input sizes.
    //SC: O(1)
    public int attempt2Realistic(string s, int k) 
    {
        var freq = new int[26]; //initialized to 0 by default C# behavior.
        int maxLen=0;
        int l = 0;
        for(int r=0;r<s.Length;r++) //NOTE freq.Max() = O(26) cuz it always contains 26 elements.
        {
            freq[s[r]-'A']++;
            //freq.Max() is equivalent to the following: (this is what I was trying before)
            // int maxFreq = 0;
            // for(int i=0;i<26;i++)
            // {
            //     if(maxFreq<freq[i])
            //         maxFreq=freq[i];
            // }
            
            int windowLength = r-l+1; //+1 for including r itself.
            int lettersToReplace = windowLength - freq.Max(); // == number of occurences of any character other than the one with max freq.
            while((r-l+1-freq.Max())>k) //while because there may be max frequent element at front, which would make an if statement ineffective at decreasing number of replacements.
            {
                freq[s[l]-'A']--;
                l++;
                windowLength--; //obviously the same as recalculating via r-l+1; cuz we just incremented l so it'd be r-(l+1)+1==r-l-1+1
                lettersToReplace = windowLength-freq.Max();
            }
            
            if(windowLength>maxLen)
                maxLen=windowLength;
        }
        return maxLen;
    }
}