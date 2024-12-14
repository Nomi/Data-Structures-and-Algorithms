using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T01_ArraysAndHashing.P02_ValidAnagram_LC242;

public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s.Length!=t.Length)
            return false;
        Dictionary<char, int> sMap = new();
        Dictionary<char, int> tMap = new();
        foreach(char c in s)
        {
            if(!sMap.TryAdd(c,1))
                sMap[c]++;
        }
        foreach(char c in t)
        {
            if(!tMap.TryAdd(c,1))
                tMap[c]++;
        }
        if(tMap.Count!=sMap.Count)
            return false;
        foreach(char key in tMap.Keys)
        {
            if(!sMap.ContainsKey(key)||sMap[key]!=tMap[key])
                return false;
        }
        return true;
    }
}
