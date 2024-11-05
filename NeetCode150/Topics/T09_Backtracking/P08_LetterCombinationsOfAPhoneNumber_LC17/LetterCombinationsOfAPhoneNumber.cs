using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T09_Backtracking.P08_LetterCombinationsOfAPhoneNumber_LC17;

public class Solution {
    public List<string> LetterCombinations(string digits) {
        return backtrack1(digits);
    }

    public List<string> backtrack1(string digits)
    {
        if(digits.Length == 0) //WHY DID I NOT THINK OF THIS??? (had to look at example to get it!) //GOOD EXAMPLE OF CLARIFICATION QUESTIONS!!
            return new();

        //THE SECOND CONSTRAINT IS ALSO A GOOD CLARIFICATION QUESTION! (will there be 1 or any other number that doesn't have representation, how about 0??)
        //ALSO, MAYBE SHOULD ASK IF THE OUTPUT SHOULD BE UPPERCASE OR LOWERCASE (had used uppercase so I had to change after looking at example output)
        Dictionary<char, List<string>> map = new(){
            {'2', new(){"a", "b", "c"}},
            {'3', new(){"d", "e", "f"}},
            {'4', new(){"g", "h", "i"}},
            {'5', new(){"j", "k", "l"}},
            {'6', new(){"m", "n", "o"}},
            {'7', new(){"p", "q", "r", "s"}},
            {'8', new(){"t", "u", "v"}},
            {'9', new(){"x", "y", "z"}},
        };
        List<string> res = new(1<<digits.Length);

        backtrack1Helper(digits, idx: 0, map, curStr: "", res);

        return res;
    }

    public void backtrack1Helper(string digits, int idx, Dictionary<char, List<string>> map, String curStr, List<string> res)
    {
        if(idx == digits.Length)
        {
            res.Add(curStr);
            return;
        }
        
        foreach(var c in map[digits[idx]])
        {
            //curStr.Append() is O(m) where m is max length of digits string, here 4, so very small impact.
            backtrack1Helper(digits, idx+1, map, string.Concat(curStr,c), res);
        }
        return;
    }
}
