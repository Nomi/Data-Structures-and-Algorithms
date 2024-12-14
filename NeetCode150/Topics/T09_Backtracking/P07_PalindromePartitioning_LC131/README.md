# ⭐ | Palindrome Partitioning

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
- [Tree Maze](https://neetcode.io/courses/dsa-for-beginners/22) [from NeetCode's Course(s)]


## Problem Description
Given a string `s`, split `s` into substrings where every substring is a palindrome. Return all possible lists of palindromic substrings.

You may return the solution in **any order**.

**Example 1:**

```java
Input: s = "aab"

Output: [["a","a","b"],["aa","b"]]
```

**Example 2:**

```java
Input: s = "a"

Output: [["a"]]
```

**Constraints:**
* `1 <= s.length <= 20`
* `s` contains only lowercase English letters.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n * (2^n))</code> time and <code>O(n)</code> space, where <code>n</code> is the length of the input string.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    For a given string there are <code>2^n</code> possible partitions because at each index we have two decisions: we can either partition and start a new string, or continue without partitioning. Can you think of an algorithm to recursively traverse all combinations?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use backtracking to recursively traverse the string with indices <code>j</code> (start of the current substring) and <code>i</code> (current iterating index). At each step, we either skip partitioning at the current index or, if the substring from <code>j</code> to <code>i</code> is a palindrome, make a partition, update <code>j = i + 1</code>, and start a new substring. The base condition to stop the recursion is when <code>j</code> reaches the end of the string. How do you implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We start with <code>j = 0</code>, <code>i = 0</code> and a temporary list which stores the substrings from the partitions. Then we recursively iterate the string with the index <code>i</code>. At each step we apply the <code>2</code> decisions accordingly. At the base condition of the recursive path, we make a copy of the current partition list and add it to the result.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/3jvWodd7ht0/0.jpg)](https://www.youtube.com/watch?v=3jvWodd7ht0)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=3jvWodd7ht0)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/palindrome-partitioning)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Backtracking (Pick / Not Pick)






```csharp
public class Solution {
    private List<List<string>> res = new List<List<string>>();
    private List<string> part = new List<string>();

    public List<List<string>> Partition(string s) {
        dfs(0, 0, s);
        return res;
    }

    private void dfs(int j, int i, string s) {
        if (i >= s.Length) {
            if (i == j) {
                res.Add(new List<string>(part));
            }
            return;
        }

        if (isPali(s, j, i)) {
            part.Add(s.Substring(j, i - j + 1));
            dfs(i + 1, i + 1, s);
            part.RemoveAt(part.Count - 1);
        }

        dfs(j, i + 1, s);
    }

    private bool isPali(string s, int l, int r) {
        while (l < r) {
            if (s[l] != s[r]) {
                return false;
            }
            l++;
            r--;
        }
        return true;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * 2 ^ n)$
* Space complexity: $O(n)$

---

### 2. Backtracking






```csharp
public class Solution {
    
    public List<List<string>> Partition(string s) {
        List<List<string>> res = new List<List<string>>();
        List<string> part = new List<string>();
        Dfs(0, s, part, res);
        return res;
    }

    private void Dfs(int i, string s, List<string> part, List<List<string>> res) {
        if (i >= s.Length) {
            res.Add(new List<string>(part));
            return;
        }
        for (int j = i; j < s.Length; j++) {
            if (IsPali(s, i, j)) {
                part.Add(s.Substring(i, j - i + 1));
                Dfs(j + 1, s, part, res);
                part.RemoveAt(part.Count - 1);
            }
        }
    }

    private bool IsPali(string s, int l, int r) {
        while (l < r) {
            if (s[l] != s[r]) {
                return false;
            }
            l++;
            r--;
        }
        return true;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * 2 ^ n)$
* Space complexity: $O(n)$

---

### 3. Backtracking (DP)






```csharp
public class Solution {
    
    public List<List<string>> Partition(string s) {
        int n = s.Length;
        bool[,] dp = new bool[n, n];
        for (int l = 1; l <= n; l++) {
            for (int i = 0; i <= n - l; i++) {
                dp[i, i + l - 1] = (s[i] == s[i + l - 1] && 
                                    (i + 1 > (i + l - 2) || 
                                    dp[i + 1, i + l - 2]));
            }
        }
        
        List<List<string>> res = new List<List<string>>();
        List<string> part = new List<string>();
        Dfs(0, s, part, res, dp);
        return res;
    }

    private void Dfs(int i, string s, List<string> part, List<List<string>> res, bool[,] dp) {
        if (i >= s.Length) {
            res.Add(new List<string>(part));
            return;
        }
        for (int j = i; j < s.Length; j++) {
            if (dp[i, j]) {
                part.Add(s.Substring(i, j - i + 1));
                Dfs(j + 1, s, part, res, dp);
                part.RemoveAt(part.Count - 1);
            }
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * 2 ^ n)$
* Space complexity: $O(n ^ 2)$

---

### 4. Recursion






```csharp
public class Solution {
    
    public List<List<string>> Partition(string s) {
        int n = s.Length;
        bool[,] dp = new bool[n, n];
        for (int l = 1; l <= n; l++) {
            for (int i = 0; i <= n - l; i++) {
                dp[i, i + l - 1] = (s[i] == s[i + l - 1] && 
                                    (i + 1 > (i + l - 2) || 
                                    dp[i + 1, i + l - 2]));
            }
        }
        
        return Dfs(s, dp, 0);
    }

    private List<List<string>> Dfs(string s, bool[,] dp, int i) {
        if (i >= s.Length) {
            return new List<List<string>> { new List<string>() };
        }

        var ret = new List<List<string>>();
        for (int j = i; j < s.Length; j++) {
            if (dp[i, j]) {
                var nxt = Dfs(s, dp, j + 1);
                foreach (var part in nxt) {
                    var cur = new List<string> { s.Substring(i, j - i + 1) };
                    cur.AddRange(part);
                    ret.Add(cur);
                }
            }
        }
        return ret;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * 2 ^ n)$
* Space complexity: $O(n ^ 2)$
