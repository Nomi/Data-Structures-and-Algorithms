using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T09_Backtracking.P07_PalindromePartitioning_LC131;

public class Solution {
    //HAD TO WATCH THE VIDEO TO DO IT! STILL DON'T FULLY UNDERSTAND
    //this helps: https://www.geeksforgeeks.org/given-a-string-print-all-possible-palindromic-partition/
    
    public List<List<string>> Partition(string s) {
        //** GENERAL TIPS: **
        //SIZE OF INPUT IS A GREAT CLARIFYING QUESTION! (and other constraints)
        //ALSO CONFIRM EXPECTED TIME COMPLEXITY 
        //(say your solution, say the complexity and ask them if that's what they're looking for or I should think more)
        
        //Notice that no matter the string given (as long as it is not ""), you can partition it in this because at least you will have each individual character as a palindrome.
        return (new Backtrack1(s)).Solve();
    }
}

public class Backtrack1
{
    List<List<string>> res; //all partitions
    List<string> part; //current partition
    //This solution MIGHT POSSIBLY improve by using ReadOnlySpan<Char> but the result and partitions contain the strings themselves
    string s;
    public Backtrack1(string s)
    {
        res = new(1<<s.Length); //O(2^n) [where n==s.Length]
        part = new(s.Length); //O(n) because min partition is each element by itself
        this.s = s;
    }
    public List<List<string>> Solve()
    {
        dfs(0);
        return res;
    } 
    public void dfs(int idx)
    {
        if(idx==s.Length)
        {
            res.Add(new(part));
            return;
        }

        for(int j = idx;j<s.Length;j++) //is every possible substring (starting at idx) a palindrome
        {
            if(isPalindrome(s, idx, j))
            {
                part.Add(s[idx..(j+1)]);
                dfs(j+1);       //dfs is in this loop because all divisions in a partition need to be palindromes, so any set that contains this substring would not fulfil the criteria so no need to go any further and we can stop/prune the search off.
                part.RemoveAt(part.Count-1);
            }
        }
    }

    public bool isPalindrome(string s, int i, int j)
    {
        for(;i<j;i++, j--)
        {
            if(s[i]!=s[j])
                return false;
        }
        return true;
    }
}
