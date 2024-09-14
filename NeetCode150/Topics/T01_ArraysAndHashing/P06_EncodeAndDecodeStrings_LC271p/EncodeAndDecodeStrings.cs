using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T01_ArraysAndHashing.P06_EncodeAndDecodeStrings_LC271p;

public class Solution {
    //This encoding is interesting! (also, use while loops like they did?)

    public string Encode(IList<string> strs) {
        // return enc1(strs);
        return enc2(strs);
    }

    public List<string> Decode(string s) {
        // return dec1(s);
        return dec2(s);
    }

/////////////////////////--ATTEMPT_1--//////////////////////////////////
    // public string enc1(IList<string> strs)
    // {
    //     StringBuilder res = new();

    //     foreach(var s in strs)
    //     {
    //         res.Append($"{s.Length}#{s}");
    //     }
    //     return res.ToString();
    // }

    // public string dec1(IList<string> strs)
    // {
    //     if(s.Length<2)
    //         return new();
    //     List<string> res = new();
    //     int numStart = -1;
    //     int shrp = -1;
    //     for(int i=0;i< s.Length;i++) //s.Substring has a complexity of O(N) WHERE N is length of the substr???
    //     {
    //         if(numStart==-1&&char.IsNumber(s[i]))
    //             numStart = i;
    //         else if(s[i]=='#'&&numStart!=-1)
    //             shrp = i;
    //         if(shrp==-1)
    //             continue;
    //         // int wLen;
    //         int.TryParse(s.Substring(numStart, shrp-numStart),out var wLen); //shrp-numStart gives the length from first digit of num to the last digit 
    //         i=shrp+wLen;
    //         res.Add(s.Substring(shrp+1,wLen));
    //         numStart=-1;
    //         shrp=-1;
    //     }
    //     return res;
    // }

/////////////////////////--ATTEMPT_2--//////////////////////////////////
    public string enc2(IList<string> strs) {
        StringBuilder res = new();
        foreach(var str in strs)
        {
            res.Append($"{str.Length}#{str}");
        }
        return res.ToString();
    }

    public List<string> dec2(string s) {
        List<string> res = new();
        for(int i=0; i<s.Length;)
        {
            // if(!s[i].IsDigit)
            //     throw new Exception("Encoded string is invalid.");
            int numLen=1;
            while(s[i+numLen]!='#')
                numLen++;
            int wordLen = int.Parse(s.Substring(i,numLen));
            i+=1+numLen; //we add 1 to skip the # right after the number.
            res.Add(s.Substring(i,wordLen));
            i+=wordLen;
        }
        return res;
    }

/////////////////////////--ATTEMPT_--//////////////////////////////////
}
