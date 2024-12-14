using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T04_Stack.P04_GenerateParentheses_LC22;

public class Solution {  
    public List<string> GenerateParenthesis(int n) {
        // int openingRemaining = n;
        // int closingRemaining = n;

        //only 1 type of bracket means we
        //don't need a stack to check and we can
        //just use the count of open and closed brackets
        //to figure out if it is valid!
        
        List<string> res = new();
        recur1(n, 0, 0, "", res); //USE THE SECOND IF CONDITION FROM THE PROVIDED SOLUTION ON NC.IO
        return res;
    }
    void recur1(int n, int opn, int cls, string current, List<string> res)
    {
        if(cls==n&&opn==n) //used all brackets.
        {
            res.Add(current);
            return;
        }

        if(opn<n)
            recur1(n, opn+1, cls, current+"(",res);
        if(cls<opn) //(it is this simple because only one type of brackets!)
            recur1(n, opn, cls+1, current+")",res);
    }
}
