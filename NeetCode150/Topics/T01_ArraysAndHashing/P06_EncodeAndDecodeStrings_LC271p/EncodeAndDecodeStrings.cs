using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T01_ArraysAndHashing.P06_EncodeAndDecodeStrings_LC271p;

public class Solution {

    public string Encode(IList<string> strs) {
        StringBuilder res = new();

        foreach(var s in strs)
        {
            res.Append($"{s.Length}#{s}");
        }
        Console.WriteLine(res);

        return res.ToString();
    }

    public List<string> Decode(string s) {
        if(s.Length<3)
            return new();
        List<string> res = new();
        int numStart = -1;
        int shrp = -1;
        for(int i=0;i< s.Length;i++) //s.Substring has a complexity of O(N) WHERE N is length of the substr???
        {
            if(numStart==-1&&char.IsNumber(s[i]))
                numStart = i;
            else if(s[i]=='#'&&numStart!=-1)
                shrp = i;
            if(shrp==-1)
                continue;
            // int wLen;
            int.TryParse(s.Substring(numStart, shrp-numStart),out var wLen); //shrp-numStart gives the length from first digit of num to the last digit 
            i=shrp+wLen;
            wLen!=0 ? res.Add(s.Substring(shrp+1,wLen)) : res.Add("");
            numStart=-1;
            shrp=-1;
        }
        return res;
   }
}
