# ⭐ | Alien Dictionary

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
- [Adjacency List](https://neetcode.io/courses/dsa-for-beginners/31) [from NeetCode's Course(s)]
- [Topological Sort](https://neetcode.io/courses/advanced-algorithms/17) [from NeetCode's Course(s)]


## Problem Description
There is a foreign language which uses the latin alphabet, but the order among letters is *not* "a", "b", "c" ... "z" as in English.

You receive a list of *non-empty* strings `words` from the dictionary, where the words are **sorted lexicographically** based on the rules of this new language. 

Derive the order of letters in this language. If the order is invalid, return an empty string. If there are multiple valid order of letters, return **any** of them.

A string `a` is lexicographically smaller than a string `b` if either of the following is true:
* The first letter where they differ is smaller in `a` than in `b`.
* There is no index `i` such that `a[i] != b[i]` *and* `a.length < b.length`.

**Example 1:**

```java
Input: ["z","o"]

Output: "zo"
```

Explanation:
From "z" and "o", we know 'z' < 'o', so return "zo".

**Example 2:**

```java
Input: ["hrn","hrf","er","enn","rfnn"]

Output: "hernf"
```

Explanation:
* from "hrn" and "hrf", we know 'n' < 'f'
* from "hrf" and "er", we know 'h' < 'e'
* from "er" and "enn", we know get 'r' < 'n'
* from "enn" and "rfnn" we know 'e'<'r'
* so one possibile solution is "hernf"

**Constraints:**
* The input `words` will contain characters only from lowercase `'a'` to `'z'`.
* `1 <= words.length <= 100`
* `1 <= words[i].length <= 100`


## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/6kTZYvNNyps/0.jpg)](https://www.youtube.com/watch?v=6kTZYvNNyps)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=6kTZYvNNyps)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/foreign-dictionary)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Depth First Search






```csharp
public class Solution {
    private Dictionary<char, HashSet<char>> adj;
    private Dictionary<char, bool> visited;
    private List<char> result;

    public string foreignDictionary(string[] words) {
        adj = new Dictionary<char, HashSet<char>>();
        foreach (var word in words) {
            foreach (var c in word) {
                if (!adj.ContainsKey(c)) {
                    adj[c] = new HashSet<char>();
                }
            }
        }

        for (int i = 0; i < words.Length - 1; i++) {
            var w1 = words[i];
            var w2 = words[i + 1];
            int minLen = Math.Min(w1.Length, w2.Length);
            if (w1.Length > w2.Length && w1.Substring(0, minLen) == w2.Substring(0, minLen)) {
                return "";
            }
            for (int j = 0; j < minLen; j++) {
                if (w1[j] != w2[j]) {
                    adj[w1[j]].Add(w2[j]);
                    break;
                }
            }
        }

        visited = new Dictionary<char, bool>();
        result = new List<char>();
        foreach (var c in adj.Keys) {
            if (dfs(c)) {
                return "";
            }
        }

        result.Reverse();
        var sb = new StringBuilder();
        foreach (var c in result) {
            sb.Append(c);
        }
        return sb.ToString();
    }

    private bool dfs(char ch) {
        if (visited.ContainsKey(ch)) {
            return visited[ch];
        }

        visited[ch] = true;
        foreach (var next in adj[ch]) {
            if (dfs(next)) {
                return true;
            }
        }
        visited[ch] = false;
        result.Add(ch);
        return false;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(N + V + E)$
* Space complexity: $O(V + E)$

> Where $V$ is the number of unique characters, $E$ is the number of edges and $N$ is the sum of lengths of all the strings.

---

### 2. Topological Sort (Kahn's Algorithm)






```csharp
public class Solution {
    public string foreignDictionary(string[] words) {
        var adj = new Dictionary<char, HashSet<char>>();
        var indegree = new Dictionary<char, int>();

        foreach (var word in words) {
            foreach (var c in word) {
                if (!adj.ContainsKey(c)) {
                    adj[c] = new HashSet<char>();
                }
                if (!indegree.ContainsKey(c)) {
                    indegree[c] = 0;
                }
            }
        }

        for (int i = 0; i < words.Length - 1; i++) {
            var w1 = words[i];
            var w2 = words[i + 1];
            int minLen = Math.Min(w1.Length, w2.Length);
            if (w1.Length > w2.Length && 
                w1.Substring(0, minLen) == w2.Substring(0, minLen)) {
                return "";
            }
            for (int j = 0; j < minLen; j++) {
                if (w1[j] != w2[j]) {
                    if (!adj[w1[j]].Contains(w2[j])) {
                        adj[w1[j]].Add(w2[j]);
                        indegree[w2[j]]++;
                    }
                    break;
                }
            }
        }

        var q = new Queue<char>();
        foreach (var c in indegree.Keys) {
            if (indegree[c] == 0) {
                q.Enqueue(c);
            }
        }

        var res = new StringBuilder();
        while (q.Count > 0) {
            var char_ = q.Dequeue();
            res.Append(char_);
            foreach (var neighbor in adj[char_]) {
                indegree[neighbor]--;
                if (indegree[neighbor] == 0) {
                    q.Enqueue(neighbor);
                }
            }
        }

        if (res.Length != indegree.Count) {
            return "";
        }

        return res.ToString();
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(N + V + E)$
* Space complexity: $O(V + E)$

> Where $V$ is the number of unique characters, $E$ is the number of edges and $N$ is the sum of lengths of all the strings.
