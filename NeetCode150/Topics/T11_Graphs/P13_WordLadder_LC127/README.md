# ⭐ | Word Ladder

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


## Problem Description
You are given two words, `beginWord` and `endWord`, and also a list of words `wordList`. All of the given words are of the same length, consisting of lowercase English letters, and are all distinct.

Your goal is to transform `beginWord` into `endWord` by following the rules:
    
* You may transform `beginWord` to any word within `wordList`, provided that at exactly one position the words have a different character, and the rest of the positions have the same characters.
* You may repeat the previous step with the new word that you obtain, and you may do this as many times as needed.

Return the **minimum number of words within the transformation sequence** needed to obtain the `endWord`, or `0` if no such sequence exists.

**Example 1:**

```java
Input: beginWord = "cat", endWord = "sag", wordList = ["bat","bag","sag","dag","dot"]

Output: 4
```

Explanation: The transformation sequence is `"cat" -> "bat" -> "bag" -> "sag"`.

**Example 2:**

```java
Input: beginWord = "cat", endWord = "sag", wordList = ["bat","bag","sat","dag","dot"]

Output: 0
```

Explanation: There is no possible transformation sequence from `"cat"` to `"sag"` since the word `"sag"` is not in the wordList.

**Constraints:**
* `1 <= beginWord.length <= 10`
* `1 <= wordList.length <= 100`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O((m ^ 2) * n)</code> time and <code>O((m ^ 2) * n)</code> space, where <code>n</code> is the number of words and <code>m</code> is the length of the word. 
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    Consider the given problem in terms of a graph, treating strings as nodes. Think of a way to build edges where two strings have an edge if they differ by a single character. A naive approach would be to consider each pair of strings and check whether an edge can be formed. Can you think of an efficient way? For example, consider a string <code>hot</code> and think about the strings that can be formed from it by changing a single letter.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    To efficiently build edges, consider transforming each word into intermediate states by replacing one character with a wildcard, like <code>*</code>. For example, the word <code>hot</code> can be transformed into <code>*ot</code>, <code>h*t</code>, and <code>ho*</code>. These intermediate states act as "parents" that connect words differing by one character. For instance, <code>*ot</code> can connect to words like <code>cot</code>. For each word in the list, generate all possible patterns by replacing each character with <code>*</code> and store the word as a child of these patterns. We can run a <code>BFS</code> starting from the <code>beginWord</code>, visiting other words while avoiding revisiting by using a hash set.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    When visiting a node during BFS, if the word matches the <code>endWord</code>, we immediately return <code>true</code>. Otherwise, we generate the pattern words that can be formed from the current word and attempt to visit the words connected to these pattern words. We add only unvisited words to the queue. If we exhaust all possibilities without finding the <code>endWord</code>, we return <code>false</code>.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/h9iTnkgv05E/0.jpg)](https://www.youtube.com/watch?v=h9iTnkgv05E)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=h9iTnkgv05E)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/word-ladder)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Breadth First Search - I






```csharp
public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        if (!wordList.Contains(endWord) || beginWord == endWord) {
            return 0;
        }
        
        int n = wordList.Count;
        int m = wordList[0].Length;
        List<List<int>> adj = new List<List<int>>(n);
        for (int i = 0; i < n; i++) {
            adj.Add(new List<int>());
        }
        
        Dictionary<string, int> mp = new Dictionary<string, int>();
        for (int i = 0; i < n; i++) {
            mp[wordList[i]] = i;
        }

        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                int cnt = 0;
                for (int k = 0; k < m; k++) {
                    if (wordList[i][k] != wordList[j][k]) {
                        cnt++;
                    }
                }
                if (cnt == 1) {
                    adj[i].Add(j);
                    adj[j].Add(i);
                }
            }
        }

        Queue<int> q = new Queue<int>();
        int res = 1;
        HashSet<int> visit = new HashSet<int>();
        
        for (int i = 0; i < m; i++) {
            for (char c = 'a'; c <= 'z'; c++) {
                if (c == beginWord[i]) {
                    continue;
                }
                string word = beginWord.Substring(0, i) + c + 
                              beginWord.Substring(i + 1);
                if (mp.ContainsKey(word) && !visit.Contains(mp[word])) {
                    q.Enqueue(mp[word]);
                    visit.Add(mp[word]);
                }
            }
        }

        while (q.Count > 0) {
            res++;
            int size = q.Count;
            for (int i = 0; i < size; i++) {
                int node = q.Dequeue();
                if (wordList[node] == endWord) {
                    return res;
                }
                foreach (int nei in adj[node]) {
                    if (!visit.Contains(nei)) {
                        visit.Add(nei);
                        q.Enqueue(nei);
                    }
                }
            }
        }
        
        return 0;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2 * m)$
* Space complexity: $O(n ^ 2)$

> Where $n$ is the number of words and $m$ is the length of the word.

---

### 2. Breadth First Search - II






```csharp
public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        var words = new HashSet<string>(wordList);
        if (!words.Contains(endWord) || beginWord == endWord) return 0;
        int res = 0;
        var q = new Queue<string>();
        q.Enqueue(beginWord);
        
        while (q.Count > 0) {
            res++;
            int len = q.Count;
            for (int i = 0; i < len; i++) {
                string node = q.Dequeue();
                if (node == endWord) return res;
                char[] arr = node.ToCharArray();
                for (int j = 0; j < arr.Length; j++) {
                    char original = arr[j];
                    for (char c = 'a'; c <= 'z'; c++) {
                        if (c == original) continue;
                        arr[j] = c;
                        string nei = new string(arr);
                        if (words.Contains(nei)) {
                            q.Enqueue(nei);
                            words.Remove(nei);
                        }
                    }
                    arr[j] = original;
                }
            }
        }
        return 0;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m ^ 2 * n)$
* Space complexity: $O(m ^ 2 * n)$

> Where $n$ is the number of words and $m$ is the length of the word.

---

### 3. Breadth First Search - III






```csharp
public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        if (!wordList.Contains(endWord)) {
            return 0;
        }

        Dictionary<string, List<string>> nei = new Dictionary<string, List<string>>();
        wordList.Add(beginWord);
        foreach (string word in wordList) {
            for (int j = 0; j < word.Length; j++) {
                string pattern = word.Substring(0, j) + 
                                 "*" + word.Substring(j + 1);
                if (!nei.ContainsKey(pattern)) {
                    nei[pattern] = new List<string>();
                }
                nei[pattern].Add(word);
            }
        }

        HashSet<string> visit = new HashSet<string>();
        Queue<string> q = new Queue<string>();
        q.Enqueue(beginWord);
        int res = 1;
        while (q.Count > 0) {
            int size = q.Count;
            for (int i = 0; i < size; i++) {
                string word = q.Dequeue();
                if (word == endWord) {
                    return res;
                }
                for (int j = 0; j < word.Length; j++) {
                    string pattern = word.Substring(0, j) + 
                                     "*" + word.Substring(j + 1);
                    if (nei.ContainsKey(pattern)) {
                        foreach (string neiWord in nei[pattern]) {
                            if (!visit.Contains(neiWord)) {
                                visit.Add(neiWord);
                                q.Enqueue(neiWord);
                            }
                        }
                    }
                }
            }
            res++;
        }
        return 0;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m ^ 2 * n)$
* Space complexity: $O(m ^ 2 * n)$

> Where $n$ is the number of words and $m$ is the length of the word.

---

### 4. Meet In The Middle (BFS)






```csharp
public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        if (!wordList.Contains(endWord) || beginWord == endWord)
            return 0;
        int m = wordList[0].Length;
        HashSet<string> wordSet = new HashSet<string>(wordList);
        Queue<string> qb = new Queue<string>(), qe = new Queue<string>();
        Dictionary<string, int> fromBegin = new Dictionary<string, int>(), 
                                fromEnd = new Dictionary<string, int>();
        qb.Enqueue(beginWord);
        qe.Enqueue(endWord);
        fromBegin[beginWord] = 1;
        fromEnd[endWord] = 1;
        
        while (qb.Count > 0 && qe.Count > 0) {
            if (qb.Count > qe.Count) {
                var tempQ = qb;
                qb = qe;
                qe = tempQ;
                var tempMap = fromBegin;
                fromBegin = fromEnd;
                fromEnd = tempMap;
            }
            int size = qb.Count;
            for (int k = 0; k < size; k++) {
                string word = qb.Dequeue();
                int steps = fromBegin[word];
                for (int i = 0; i < m; i++) {
                    for (char c = 'a'; c <= 'z'; c++) {
                        if (c == word[i])
                            continue;
                        string nei = word.Substring(0, i) + 
                                     c + word.Substring(i + 1);
                        if (!wordSet.Contains(nei))
                            continue;
                        if (fromEnd.ContainsKey(nei))
                            return steps + fromEnd[nei];
                        if (!fromBegin.ContainsKey(nei)) {
                            fromBegin[nei] = steps + 1;
                            qb.Enqueue(nei);
                        }
                    }
                }
            }
        }
        return 0;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m ^ 2 * n)$
* Space complexity: $O(m ^ 2 * n)$

> Where $n$ is the number of words and $m$ is the length of the word.
