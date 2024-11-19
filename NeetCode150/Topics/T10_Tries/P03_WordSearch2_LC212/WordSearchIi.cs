using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T10_Tries.P03_WordSearch2_LC212;

public class Solution {
    public List<string> FindWords(char[][] board, string[] words) {
        return Attempt1.FindWords(board, words);
    }
}


public static class Attempt1
{
    private class TrieNode
    {
        public Dictionary<char, TrieNode> children = new(26);
        public bool isWord = false;
    }

	static char visited = '*';
	static TrieNode root;
    static int maxWordLen;
	
    public static List<string> FindWords(char[][] board, string[] words) {
        root = new TrieNode();
        maxWordLen = 0;
        
        foreach(var word in words)
        {
            AddWord(word, root);
        }

        List<string> res = new();
        List<char> wordSoFar = new(maxWordLen);

        for(int r=0; r<board.Length;r++)
        {
            for(int c=0; c<board[0].Length;c++)
            {
                dfs(board, r, c, root, wordSoFar, res);
            }
        }

        return res;
    }

    private static void dfs(char[][] board, int r, int c, TrieNode prevNode, List<char> wordSoFar, List<string> res)
    {
        Console.WriteLine($"r:{r} / {board.Length-1}, c:{c} / {board[0].Length-1}");

        if(r<0||r>=board.Length||c<0||c>=board[0].Length||board[r][c]==visited||wordSoFar.Count==maxWordLen) //im dumb cuz I spend so long debugging just to realize I was using r > length and c > length instead of >= !!!
            return;

        if(!prevNode.children.ContainsKey(board[r][c]))
            return;

        Console.WriteLine($"--> {board[r][c]}, {wordSoFar.Count} / {maxWordLen}         {string.Concat(wordSoFar)}");
        
        var curChar = board[r][c];
        board[r][c] = visited;
        wordSoFar.Add(curChar);

        var curNode = prevNode.children[curChar];
        if(curNode.isWord) Console.WriteLine($"-----------------------------{string.Concat(wordSoFar)}");
        if(curNode.isWord) res.Add(string.Concat(wordSoFar));

        dfs(board, r-1, c, root, wordSoFar, res);
        dfs(board, r+1, c, root, wordSoFar, res);
        dfs(board, r, c-1, root, wordSoFar, res);
        dfs(board, r, c+1, root, wordSoFar, res);

        wordSoFar.RemoveAt(wordSoFar.Count-1);
        board[r][c] = curChar;
    }


    private static void AddWord(string word, TrieNode root)
    {
        if(maxWordLen < word.Length) maxWordLen = word.Length;

        var parent = root;

        foreach(char c in word)
        {
            parent.children.TryAdd(c, new TrieNode());
            parent = parent.children[c];
        }

        parent.isWord = true;
    }
}
