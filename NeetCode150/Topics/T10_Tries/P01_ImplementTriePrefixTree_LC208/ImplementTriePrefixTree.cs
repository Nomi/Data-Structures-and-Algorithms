using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T10_Tries.P01_ImplementTriePrefixTree_LC208;

public class PrefixTree {
    IPrefixTree soln;
    public PrefixTree() {
        soln = new Attempt1();
    }
    
    public void Insert(string word) {
        soln.Insert(word);
    }
    
    public bool Search(string word) {
        return soln.Search(word);
    }
    
    public bool StartsWith(string prefix) {
        return soln.StartsWith(prefix);
    }
}

public interface IPrefixTree
{
    public void Insert(string word);
    
    public bool Search(string word);
    
    public bool StartsWith(string prefix);
}

public class Attempt1 : IPrefixTree
{
    private class TrieNode
    {
        // public string currChar;
        public TrieNode[] children = new TrieNode[26]; //could've used `Node[] children = new[26];` and it would have been faster and more time efficient. 
        public bool canBeEndOfWord = false;
    }
    
    TrieNode trieRoot;
    
    public Attempt1()
    {
        trieRoot = new();
    }
    
    public void Insert(string word) {

        var parent = trieRoot;

        for(int i=0;i<word.Length;i++)
        {
            // parent.children.TryAdd(curSubStr, new TrieNode());
            int targetChildIdx = word[i] - 'a';
            parent.children[targetChildIdx] ??= new TrieNode();
            parent = parent.children[targetChildIdx];
        }

        parent.canBeEndOfWord = true;
    }
    
    public bool Search(string word) {

        var parent = trieRoot;

        for(int i=0;i<word.Length;i++)
        {
            int targetChildIdx = word[i] - 'a';
            // if(parent.ContainsKey(word[i]) is false)
            //     return false;
            if(parent.children[targetChildIdx] is null)
                return false;
            parent = parent.children[targetChildIdx];
        }

        return parent.canBeEndOfWord;
    }
    
    public bool StartsWith(string prefix) {
        var parent = trieRoot;

        for(int i=0;i<prefix.Length;i++)
        {
            int targetChildIdx = prefix[i] - 'a';
            // if(parent.children.ContainsKey(word[i]) is false)
            //     return false;
            if(parent.children[targetChildIdx] is null)
                return false;
            parent = parent.children[targetChildIdx];
        }

        return true;
    }
}