using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T09_Backtracking.P07_PalindromePartitioning_LC131;

public class Solution {
    //**NOTE:** WATCH TakeUForward's L17. Palindrome Partitioning video to learn how this works. (4:00 to 14:00, can watch most of it on 2x).
    //** {OR CHECK THE EXAMPLE RUN AT THE END OF Backtrack1's dfs funtion} **

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

        for(int j = idx;j<s.Length;j++) //is every possible substring (starting at idx) a palindrome //Go through through all the substrings to find all the ones that can be in THIS partition. e.g. For aabb, on first level: a|abb, aa|bb. aabb| but NOTaab|b because the chosen partition doesn't create a palindrome on the left.
        {
            if(isPalindrome(s, idx, j))
            {
                part.Add(s[idx..(j+1)]);
                dfs(j+1);       //dfs is in this loop because all divisions in a partition need to be palindromes, so any set that contains this substring would not fulfil the criteria so no need to go any further and we can stop/prune the search off.
                part.RemoveAt(part.Count-1);
            }
        }

        //Example run: ([*] means * is a valid, complete parition we can add to output.)
        //For aabb, on first level: a|abb, aa|bb, but NOTaab|b ORaabb because the chosen partition doesn't create a palindrome on the left.
        //On second level: a|a|bb, aa|b|b, [aa|bb|].
        //On third level:  a|a|b|b, [a|a|bb|], [aa|b|b|]
        //On fourth level: [a|a|b|b|].
        //Therefore, the result = [a|a|b|b|, a|a|bb|, aa|b|b|, aa|bb|].
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
