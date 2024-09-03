using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T01_ArraysAndHashing.P04_GroupAnagrams_LC49;

public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, List<string>> map = new(); //we try to store sorted string as the key and the list stores that specific anagram instance
        foreach(var str in strs)
        {
            var srtdStr = String.Concat(str.OrderBy(c => c));
            map.TryAdd(srtdStr, new List<string>());
            map[srtdStr].Add(str);
        }
        return map.Values.ToList();
    }
}
