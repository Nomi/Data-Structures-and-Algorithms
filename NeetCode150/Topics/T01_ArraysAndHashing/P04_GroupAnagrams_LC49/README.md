# ⭐ | Group Anagrams

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
- [Hash Usage](https://neetcode.io/courses/dsa-for-beginners/26) [from NeetCode's Course(s)]


## Problem Description
Given an array of strings `strs`, group all *anagrams* together into sublists. You may return the output in **any order**.

An **anagram** is a string that contains the exact same characters as another string, but the order of the characters can be different.

**Example 1:**

```java
Input: strs = ["act","pots","tops","cat","stop","hat"]

Output: [["hat"],["act", "cat"],["stop", "pots", "tops"]]
```

**Example 2:**

```java
Input: strs = ["x"]

Output: [["x"]]
```

**Example 3:**

```java
Input: strs = [""]

Output: [[""]]
```

**Constraints:**
* `1 <= strs.length <= 1000`.
* `0 <= strs[i].length <= 100`
* `strs[i]` is made up of lowercase English letters.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(m * n)</code> time and <code>O(m)</code> space, where <code>m</code> is the number of strings and <code>n</code> is the length of the longest string.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A naive solution would be to sort each string and group them using a hash map. This would be an <code>O(m * nlogn)</code> solution. Though this solution is acceptable, can you think of a better way without sorting the strings?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    By the definition of an anagram, we only care about the frequency of each character in a string. How is this helpful in solving the problem?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We can simply use an array of size <code>O(26)</code>, since the character set is <code>a</code> through <code>z</code> (<code>26</code> continuous characters), to count the frequency of each character in a string. Then, we can use this array as the key in the hash map to group the strings.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/vzdNOK2oB2E/0.jpg)](https://www.youtube.com/watch?v=vzdNOK2oB2E)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=vzdNOK2oB2E)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/anagram-groups)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Sorting






```csharp
public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        var res = new Dictionary<string, List<string>>();
        foreach (var s in strs) {
            char[] charArray = s.ToCharArray();
            Array.Sort(charArray);
            string sortedS = new string(charArray);
            if (!res.ContainsKey(sortedS)) {
                res[sortedS] = new List<string>();
            }
            res[sortedS].Add(s);
        }
        return res.Values.ToList<List<string>>();       
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n \log n)$
* Space complexity: $O(m * n)$

> Where $m$ is the number of strings and $n$ is the length of the longest string.

---

### 2. Hash Table






```csharp
public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        var res = new Dictionary<string, List<string>>();
        foreach (var s in strs) {
            int[] count = new int[26];
            foreach (char c in s) {
                count[c - 'a']++;
            }
            string key = string.Join(",", count);
            if (!res.ContainsKey(key)) {
                res[key] = new List<string>();
            }
            res[key].Add(s);
        }
        return res.Values.ToList<List<string>>();       
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n)$
* Space complexity: $O(m)$

> Where $m$ is the number of strings and $n$ is the length of the longest string.
