# ⭐ | Design Add And Search Words Data Structure

|   | Difficulty | Tricky |
|---|------------|--------|
| <big>⭐<big> | <big>**🟨 Medium**</big> | <big></big> |


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
- [Trie](https://neetcode.io/courses/advanced-algorithms/6) [from NeetCode's Course(s)]


## Problem Description
Design a data structure that supports adding new words and searching for existing words.

Implement the `WordDictionary` class:

* `void addWord(word)` Adds `word` to the data structure.
* `bool search(word)` Returns `true` if there is any string in the data structure that matches `word` or `false` otherwise. `word` may contain dots `'.'` where dots can be matched with any letter.

**Example 1:**

```java
Input:
["WordDictionary", "addWord", "day", "addWord", "bay", "addWord", "may", "search", "say", "search", "day", "search", ".ay", "search", "b.."]

Output:
[null, null, null, null, false, true, true, true]

Explanation:
WordDictionary wordDictionary = new WordDictionary();
wordDictionary.addWord("day");
wordDictionary.addWord("bay");
wordDictionary.addWord("may");
wordDictionary.search("say"); // return false
wordDictionary.search("day"); // return true
wordDictionary.search(".ay"); // return true
wordDictionary.search("b.."); // return true
```

**Constraints:**
* `1 <= word.length <= 20`
* `word` in `addWord` consists of lowercase English letters.
* `word` in `search` consist of `'.'` or lowercase English letters.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time for each function call and <code>O(t + n)</code> space, where <code>n</code> is the length of the string and <code>t</code> is the total number of nodes created in the Trie.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would be to store each added word in a list and search linearly through the list for a word every time. This would be an <code>O(m * n)</code> solution, where <code>m</code> is the size of the list and <code>n</code> is the length of the string. Can you think of a better way? Maybe there is a tree-like data structure.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use a Trie to implement adding and searching for words efficiently. Adding a word follows the standard Trie insertion process. However, when searching for a word containing <code>'.'</code>, which can match any character, we need a different approach. Instead of directly matching, we consider all possible characters at the position of <code>'.'</code> and recursively check the rest of the word for each possibility. How would you implement it?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We traverse the word with index <code>i</code>, starting at the root of the Trie. For normal characters, we search as usual. When encountering a dot (<code>'.'</code>), we try all possible characters by recursively extending the search in each direction. If any path leads to a valid word, we return <code>true</code>; otherwise, we return <code>false</code>. Although we try all paths for a dot, the time complexity is still <code>O(n)</code> because there are at most two dots (<code>'.'</code>) in the word, making the complexity <code>O((26^2) * n)</code>.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/BTf05gs_8iU/0.jpg)](https://www.youtube.com/watch?v=BTf05gs_8iU)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=BTf05gs_8iU)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/design-word-search-data-structure)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class WordDictionary {

    private List<string> store;

    public WordDictionary() {
        store = new List<string>();
    }

    public void AddWord(string word) {
        store.Add(word);
    }

    public bool Search(string word) {
        foreach (string w in store) {
            if (w.Length != word.Length) continue;
            int i = 0;
            while (i < w.Length) {
                if (w[i] == word[i] || word[i] == '.') {
                    i++;
                } else {
                    break;
                }
            }
            if (i == w.Length) {
                return true;
            }
        }
        return false;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$ for $addWord()$, $O(m * n)$ for $search()$.
* Space complexity: $O(m * n)$

> Where $m$ is the number of words added and $n$ is the length of the string.

---

### 2. Depth First Search (Trie)






```csharp
public class TrieNode {
    public TrieNode[] children = new TrieNode[26];
    public bool word = false;
}

public class WordDictionary {
    
    private TrieNode root;

    public WordDictionary() {
        root = new TrieNode();
    }

    public void AddWord(string word) {
        TrieNode cur = root;
        foreach (char c in word) {
            if (cur.children[c - 'a'] == null) {
                cur.children[c - 'a'] = new TrieNode();
            }
            cur = cur.children[c - 'a'];
        }
        cur.word = true;
    }

    public bool Search(string word) {
        return Dfs(word, 0, root);
    }

    private bool Dfs(string word, int j, TrieNode root) {
        TrieNode cur = root;

        for (int i = j; i < word.Length; i++) {
            char c = word[i];
            if (c == '.') {
                foreach (TrieNode child in cur.children) {
                    if (child != null && Dfs(word, i + 1, child)) {
                        return true;
                    }
                }
                return false;
            } else {
                if (cur.children[c - 'a'] == null) {
                    return false;
                }
                cur = cur.children[c - 'a'];
            }
        }
        return cur.word;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$ for $addWord()$, $O(n)$ for $search()$.
* Space complexity: $O(t + n)$

> Where $n$ is the length of the string and $t$ is the total number of TrieNodes created in the Trie.
