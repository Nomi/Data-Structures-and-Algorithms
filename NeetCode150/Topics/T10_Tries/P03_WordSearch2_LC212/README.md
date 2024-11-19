# ⭐ | Word Search II

|   | Difficulty | Tricky |
|---|------------|--------|
| <big>⭐<big> | <big>**🟥 Hard**</big> | <big></big> |


---

## Table of Contents

- [Prerequisites](#prerequisites)
- [Problem Description](#problem-description)
- [Patterns or Tricks](#patterns-or-tricks)
- [My Notes](#my-notes)
- [Resources](#resources)
- [Video Explanation (NeetCode)](#video-explanation-neetcode)
- [Solutions (NeetCode.io)](#solutions-neetcodeio)
    


## Prerequisites
- [Matrix DFS](https://neetcode.io/courses/dsa-for-beginners/29) [from NeetCode's Course(s)]
- [Trie](https://neetcode.io/courses/advanced-algorithms/6) [from NeetCode's Course(s)]


## Problem Description
Given a 2-D grid of characters `board` and a list of strings `words`, return all words that are present in the grid.

For a word to be present it must be possible to form the word with a path in the board with horizontally or vertically neighboring cells. The same cell may not be used more than once in a word.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/06435c8e-bac3-49f5-5df7-77fd5dd42800/public)

```java
Input:
board = [
  ["a","b","c","d"],
  ["s","a","a","t"],
  ["a","c","k","e"],
  ["a","c","d","n"]
],
words = ["bat","cat","back","backend","stack"]

Output: ["cat","back","backend"]
```

**Example 2:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/6f244a10-78bf-4a30-0a5f-b8f3e03ce000/public)

```java
Input:
board = [
  ["x","o"],
  ["x","o"]
],
words = ["xoxo"]

Output: []
```

**Constraints:**
* `1 <= board.length, board[i].length <= 10`
* `board[i]` consists only of lowercase English letter.
* `1 <= words.length <= 100`
* `1 <= words[i].length <= 10`
* `words[i]` consists only of lowercase English letters.
* All strings within `words` are distinct.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(m * n * 4 * (3^(t-1)) + s)</code> time and <code>O(s)</code> space, where <code>m</code> is the number of rows, <code>n</code> is the number of columns, <code>t</code> is the maximum length of any word and <code>s</code> is the sum of the lengths of all the words.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    To search for a word in the grid, we can use backtracking by starting at each cell, simultaneously iterating through the word and matching the characters with the cells, recursively visiting the neighboring cells. However, if we are given a list of words and need to search for each one, it becomes inefficient to iterate through each word and run backtracking for each. Can you think of a better way? Perhaps a data structure could help with more efficient word search and insertion.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
   We can use a Trie to efficiently search for multiple words. After inserting all words into the Trie, we traverse the grid once. For each character in the grid, we check if it exists in the current Trie node. If not, we prune the search. If we encounter an "end of word" flag in the Trie node, we know a valid word has been found. But how can we add that word to the result list? Maybe you should think about what additional information you can store in the Trie node.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    When we insert a word into the Trie, we can store the word's index. Why? Because when we want to add the word to the result list after finding a valid word, we can easily add it using the index. After adding that word, we put <code>index = -1</code> as we shouldn't add the word multiple times to the result list. How can you implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We insert all the words into the Trie with their indices marked. Then, we iterate through each cell in the grid. At each cell, we start at the root of the Trie and explore all possible paths. As we traverse, we match characters in the cell with those in the Trie nodes. If we encounter the end of a word, we take the index at that node and add the corresponding word to the result list. Afterward, we unmark that index and continue exploring further paths.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/asbcE9mZz_U/0.jpg)](https://www.youtube.com/watch?v=asbcE9mZz_U)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=asbcE9mZz_U)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/search-for-word-ii)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Backtracking






```csharp
public class Solution {
    public List<string> FindWords(char[][] board, string[] words) {
        int ROWS = board.Length, COLS = board[0].Length;
        List<string> res = new List<string>();

        foreach (string word in words) {
            bool flag = false;
            for (int r = 0; r < ROWS && !flag; r++) {
                for (int c = 0; c < COLS; c++) {
                    if (board[r][c] != word[0]) continue;
                    if (Backtrack(board, r, c, word, 0)) {
                        res.Add(word);
                        flag = true;
                        break;
                    }
                }
            }
        }
        return res;
    }

    private bool Backtrack(char[][] board, int r, int c, string word, int i) {
        if (i == word.Length) return true;
        if (r < 0 || c < 0 || r >= board.Length || 
            c >= board[0].Length || board[r][c] != word[i])
            return false;

        board[r][c] = '*';
        bool ret = Backtrack(board, r + 1, c, word, i + 1) ||
                   Backtrack(board, r - 1, c, word, i + 1) ||
                   Backtrack(board, r, c + 1, word, i + 1) ||
                   Backtrack(board, r, c - 1, word, i + 1);
        board[r][c] = word[i];
        return ret;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n * 4 ^ t + s)$
* Space complexity: $O(t)$

> Where $m$ is the number of rows, $n$ is the number of columns, $t$ is the maximum length of any word in the array $words$ and $s$ is the sum of the lengths of all the words. 

---

### 2. Backtracking (Trie + Hash Set)






```csharp
public class TrieNode {
    public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
    public bool IsWord = false;

    public void AddWord(string word) {
        TrieNode cur = this;
        foreach (char c in word) {
            if (!cur.Children.ContainsKey(c)) {
                cur.Children[c] = new TrieNode();
            }
            cur = cur.Children[c];
        }
        cur.IsWord = true;
    }
}

public class Solution {
    private HashSet<string> res = new HashSet<string>();
    private bool[,] visit;
    public List<string> FindWords(char[][] board, string[] words) {
        TrieNode root = new TrieNode();
        foreach (string word in words) {
            root.AddWord(word);
        }

        int ROWS = board.Length, COLS = board[0].Length;
        visit = new bool[ROWS, COLS];

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                Dfs(board, r, c, root, "");
            }
        }
        return new List<string>(res);
    }

    private void Dfs(char[][] board, int r, int c, TrieNode node, string word) {
        int ROWS = board.Length, COLS = board[0].Length;
        if (r < 0 || c < 0 || r >= ROWS || 
            c >= COLS || visit[r, c] || 
            !node.Children.ContainsKey(board[r][c])) {
            return;
        }

        visit[r, c] = true;
        node = node.Children[board[r][c]];
        word += board[r][c];
        if (node.IsWord) {
            res.Add(word);
        }

        Dfs(board, r + 1, c, node, word);
        Dfs(board, r - 1, c, node, word);
        Dfs(board, r, c + 1, node, word);
        Dfs(board, r, c - 1, node, word);

        visit[r, c] = false;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n * 4 * 3 ^ {t - 1} + s)$
* Space complexity: $O(s)$

> Where $m$ is the number of rows, $n$ is the number of columns, $t$ is the maximum length of any word in the array $words$ and $s$ is the sum of the lengths of all the words. 

---

### 3. Backtracking (Trie)






```csharp
class TrieNode {
    public TrieNode[] children = new TrieNode[26];
    public int idx = -1;
    public int refs = 0;

    public void AddWord(string word, int i) {
        TrieNode cur = this;
        cur.refs++;
        foreach (char c in word) {
            int index = c - 'a';
            if (cur.children[index] == null) {
                cur.children[index] = new TrieNode();
            }
            cur = cur.children[index];
            cur.refs++;
        }
        cur.idx = i;
    }
}

public class Solution {
    private List<string> res = new List<string>();

    public List<string> FindWords(char[][] board, string[] words) {
        TrieNode root = new TrieNode();
        for (int i = 0; i < words.Length; i++) {
            root.AddWord(words[i], i);
        }

        for (int r = 0; r < board.Length; r++) {
            for (int c = 0; c < board[0].Length; c++) {
                Dfs(board, root, r, c, words);
            }
        }

        return res;
    }

    private void Dfs(char[][] board, TrieNode node, int r, int c, string[] words) {
        if (r < 0 || c < 0 || r >= board.Length || 
            c >= board[0].Length || board[r][c] == '*' || 
            node.children[board[r][c] - 'a'] == null) {
            return;
        }

        char temp = board[r][c];
        board[r][c] = '*';
        TrieNode prev = node;
        node = node.children[temp - 'a'];
        if (node.idx != -1) {
            res.Add(words[node.idx]);
            node.idx = -1;
            node.refs--;
            if (node.refs == 0) {
                node = null;
                prev.children[temp - 'a'] = null;
                board[r][c] = temp;
                return;
            }
        }

        Dfs(board, node, r + 1, c, words);
        Dfs(board, node, r - 1, c, words);
        Dfs(board, node, r, c + 1, words);
        Dfs(board, node, r, c - 1, words);

        board[r][c] = temp;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n * 4 * 3 ^ {t - 1} + s)$
* Space complexity: $O(s)$

> Where $m$ is the number of rows, $n$ is the number of columns, $t$ is the maximum length of any word in the array $words$ and $s$ is the sum of the lengths of all the words.
