using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T04_Stack.P01_ValidParentheses_LC20;

public class Solution {
    public bool IsValid(string s) {
        //USE NEETCODE BASED ATTEMPT FOR ACTUAL REFERENCE!!!
        // return attempt1(s);

        //USE THIS FOR ACTUAL REFERENCE:
        return NeetCodeBasedSoln(s); // (also, uses the nifty trick of using the HashMap closingToOpen instead of openingToClosing)
    }
    
    //USE THIS FOR ACTUAL REFERENCE:
    // (also, uses the nifty trick of using the HashMap
    // closingToOpen instead of openingToClosing)
    public bool NeetCodeBasedSoln(string s) 
    {
        Stack<char> stack = new();
        Dictionary<char,char> closeToOpen = new(){
            {')','('},
            {'}','{'},
            {'}','{'}};

        foreach(char c in s)
        {
            if(!closeToOpen.ContainsKey(c)) //not closing bracket //I guess we don't need to consider wrong input otherwise the hashmap would break on using them as key if not checked for containing it as key
            {
                //by if: it is not a closing bracket
                stack.Push(c);
            }
            else if(stack.Count==0 || stack.Pop() != pairs[c])
            {
                //by else: it is a closing bracket
                //by if: 
                //      1. there were no opening brackets before this.
                //      2. the last opening bracket was of a different type than this closing bracket.
                return false;
            }
        }
        return (0==stack.Count);
    }

    public bool attempt1(string s) //USE NEETCODE BASED ATTEMPT FOR ACTUAL REFERENCE
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
            if(!openToClose.ContainsKey(lastChar)) //I guess we don't need this and we can assume it input will always contain only the provided chars???
                return false;
            if(c!=openToClose[lastChar])
                return false;
        }
        if(stack.Count>0)
            return false;
        return true;
    }
}
