using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T03_SlidingWindow.P05_MinimumWindowSubstring_LC76;

public class Solution {
    public string MinWindow(string s, string t) {
        return attempt1(s,t);
    }

    public string attempt1(string s, string t)
    {
        // if(s.Length==0||t.Length==0||s.Length<t.Length)
        // {
        //     return "";
        // }

        var tfreq = new Dictionary<char,int>();
        foreach(char c in t)
        {
            tfreq.TryAdd(c,0);
            tfreq[c]++;
        }
        int need = tfreq.Keys.Count();
        int have = 0;
        int minStrL = 0, minStrR = int.MaxValue;
        int l=0;
        var sfreq = new Dictionary<char,int>();
        for(int r=0;r<s.Length;r++)
        {
            sfreq.TryAdd(s[r],0);
            sfreq[s[r]]++;
            if(tfreq.ContainsKey(s[r])&&sfreq[s[r]]==tfreq[s[r]])
                have++;
            if(have==need)
            {
                while(l<=r&&(!tfreq.ContainsKey(s[l])||sfreq[s[l]]>tfreq[s[l]]))
                {
                    if(--sfreq[s[l]]==0)
                        sfreq.Remove(s[l]);
                    l++;
                }
                if(minStrR-minStrL>r-l)
                {
                    minStrR=r;
                    minStrL=l;
                }
                //Move l to start looking for next matching window.
                if(--sfreq[s[l]]==0)
                        sfreq.Remove(s[l]);
                have--; //because we discareded left even if it was in t as long as s still had == the number of that elements as in t, without keeping any more from the left.
                l++;
            }
        }
        if(minStrR-minStrL+1<0)
            return "";
        return s.Substring(minStrL, minStrR-minStrL+1);
    }
}
