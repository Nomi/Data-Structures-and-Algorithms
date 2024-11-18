# ⭐ | Implement Trie Prefix Tree

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
A **prefix tree** (also known as a trie) is a tree data structure used to efficiently store and retrieve keys in a set of strings. Some applications of this data structure include auto-complete and spell checker systems.

Implement the PrefixTree class:
* `PrefixTree()` Initializes the prefix tree object.
* `void insert(String word)` Inserts the string `word` into the prefix tree.
* `boolean search(String word)` Returns `true` if the string `word` is in the prefix tree (i.e., was inserted before), and `false` otherwise.
* `boolean startsWith(String prefix)` Returns `true` if there is a previously inserted string `word` that has the prefix `prefix`, and `false` otherwise.

**Example 1:**

```java
Input: 
["Trie", "insert", "dog", "search", "dog", "search", "do", "startsWith", "do", "insert", "do", "search", "do"]

Output:
[null, null, true, false, true, null, true]

Explanation:
PrefixTree prefixTree = new PrefixTree();
prefixTree.insert("dog");
prefixTree.search("dog");    // return true
prefixTree.search("do");     // return false
prefixTree.startsWith("do"); // return true
prefixTree.insert("do");
prefixTree.search("do");     // return true
```

**Constraints:**
* `1 <= word.length, prefix.length <= 1000`
* `word` and `prefix` are made up of lowercase English letters.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time for each function call and <code>O(t)</code> space, where <code>n</code> is the length of the given string and <code>t</code> is the total number of nodes created in the Trie.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A Trie is structured as a tree-like data structure where each node contains a hash map (or an array for fixed character sets) to store references to its child nodes, which represent characters. Each node also includes a boolean flag to indicate whether the current node marks the end of a valid word. The Trie starts with a root node that does not hold any character and serves as the entry point for all operations. The child nodes of the root and subsequent nodes represent unique characters from the words stored in the Trie, forming a hierarchical structure based on the prefixes of the words.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    To insert a word, we iterate through the characters of the word with index <code>i</code>, starting at the root of the Trie as the current node. If the current node already contains <code>word[i]</code>, we continue to the next character and move to the node that <code>word[i]</code> points to. If <code>word[i]</code> is not present, we create a new node for <code>word[i]</code> and continue the process until we reach the end of the word. We mark the boolean variable as true as it is the end of the inserted word.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    Searching for a word is similar to inserting, but instead of creating new nodes, we return <code>false</code> if we don't find a character in the path while iterating or if the end-of-word marker is not set to <code>true</code> when we reach the end of the word.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/oobqoCJlHA0/0.jpg)](https://www.youtube.com/watch?v=oobqoCJlHA0)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=oobqoCJlHA0)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/implement-prefix-tree)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Prefix Tree (Array)






```csharp
public class TrieNode {
    public TrieNode[] children = new TrieNode[26];
    public bool endOfWord = false;
}

public class PrefixTree {
    private TrieNode root;

    public PrefixTree() {
        root = new TrieNode();
    }

    public void Insert(string word) {
        TrieNode cur = root;
        foreach (char c in word) {
            int i = c - 'a';
            if (cur.children[i] == null) {
                cur.children[i] = new TrieNode();
            }
            cur = cur.children[i];
        }
        cur.endOfWord = true;
    }

    public bool Search(string word) {
        TrieNode cur = root;
        foreach (char c in word) {
            int i = c - 'a';
            if (cur.children[i] == null) {
                return false;
            }
            cur = cur.children[i];
        }
        return cur.endOfWord;
    }

    public bool StartsWith(string prefix) {
        TrieNode cur = root;
        foreach (char c in prefix) {
            int i = c - 'a';
            if (cur.children[i] == null) {
                return false;
            }
            cur = cur.children[i];
        }
        return true;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$ for each function call.
* Space complexity: $O(t)$

> Where $n$ is the length of the string and $t$ is the total number of TrieNodes created in the Trie.

---

### 2. Prefix Tree (Hash Map)






```csharp
public class TrieNode {
    public Dictionary<char, TrieNode> children = 
                            new Dictionary<char, TrieNode>();
    public bool endOfWord = false;
}

public class PrefixTree {
    private TrieNode root;

    public PrefixTree() {
        root = new TrieNode();
    }

    public void Insert(string word) {
        TrieNode cur = root;
        foreach (char c in word) {
            if (!cur.children.ContainsKey(c)) {
                cur.children[c] = new TrieNode();
            }
            cur = cur.children[c];
        }
        cur.endOfWord = true;
    }

    public bool Search(string word) {
        TrieNode cur = root;
        foreach (char c in word) {
            if (!cur.children.ContainsKey(c)) {
                return false;
            }
            cur = cur.children[c];
        }
        return cur.endOfWord;
    }

    public bool StartsWith(string prefix) {
        TrieNode cur = root;
        foreach (char c in prefix) {
            if (!cur.children.ContainsKey(c)) {
                return false;
            }
            cur = cur.children[c];
        }
        return true;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$ for each function call.
* Space complexity: $O(t)$

> Where $n$ is the length of the string and $t$ is the total number of TrieNodes created in the Trie.
