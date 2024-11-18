using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T10_Tries.P02_DesignAddAndSearchWordsDataStructure_LC211;

public class WordDictionary {
    IWordDictionary soln;

    public WordDictionary() {
        soln =  new Attempt1();    
    }
    
    public void AddWord(string word) {
        soln.AddWord(word);
    }
    
    public bool Search(string word) {
        return soln.Search(word);
    }
}


public interface IWordDictionary
{
    public void AddWord(string word);
    
    public bool Search(string word);
}


public class Attempt1 : IWordDictionary
{
    private class TrieNode 
    {
        public bool canBeEndOfWord = false;
        public Dictionary<char, TrieNode> children = new(26);
    }

    TrieNode root;
    char wildcard = '.';

    public Attempt1()
    {
        root = new();
    }

    public void AddWord(string word)
    {
        var cur = root;
        
        foreach(char c in word)
        {
            cur.children.TryAdd(c, new TrieNode());

            cur = cur.children[c];
        }

        cur.canBeEndOfWord = true;
    }

    public bool Search(string word)
    {
        return dfs(word, 0, root);
    }

    private bool dfs(string word, int idx, TrieNode parent)
    {
        if(idx==word.Length)
            return parent.canBeEndOfWord;
        
        if(word[idx]!=wildcard)
        {
            if(!parent.children.ContainsKey(word[idx]))
                return false;
            return dfs(word, idx+1, parent.children[word[idx]]);
        }
        
        //Else: (current char in word is the wildcard character)
        foreach(char c in parent.children.Keys)
        {
            if(dfs(word, idx+1, parent.children[c]))
                return true; //As soon as we find a possible match, we stop and return true;
        }
        return false; //if no possible match is found after considering each and every child as the wildcard.
    }
}