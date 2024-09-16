using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T04_Stack.P01_ValidParentheses_LC20;

public class Solution {
    public bool IsValid(string s) {
        return attempt1(s);
    }
    
    public bool attempt1(string s)
    {
        Stack<char> stack = new();
        Dictionary<char,char> openToClose = new(){
            {'(',')'},
            {'{','}'},
            {'[',']'}};
        HashSet<char> close = new(){')','}',']'};

        for(int i=0;i<s.Length;i++)
        {
            char c = s[i];
            if(stack.Count==0||openToClose.ContainsKey(c))
            {
                if(close.Contains(c))
                    return false;
                stack.Push(c);
                continue;
            }
            char lastChar = stack.Pop();
            if(!openToClose.ContainsKey(lastChar))
                return false;
            if(c!=openToClose[lastChar])
                return false;
        }
        if(stack.Count>0)
            return false;
        return true;
    }
}
