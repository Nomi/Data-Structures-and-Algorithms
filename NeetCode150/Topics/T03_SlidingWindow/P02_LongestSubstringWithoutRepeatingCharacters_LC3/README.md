# ⭐ | Longest Substring Without Repeating Characters

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
- [Sliding Window Fixed Size](https://neetcode.io/courses/advanced-algorithms/1) [from NeetCode's Course(s)]
- [Sliding Window Variable Size](https://neetcode.io/courses/advanced-algorithms/2) [from NeetCode's Course(s)]


## Problem Description
Given a string `s`, find the *length of the longest substring* without duplicate characters.

A **substring** is a contiguous sequence of characters within a string.

**Example 1:**

```java
Input: s = "zxyzxyz"

Output: 3
```

Explanation: The string "xyz" is the longest without duplicate characters.

**Example 2:**

```java
Input: s = "xxxx"

Output: 1
```

**Constraints:**
* `0 <= s.length <= 1000`
* `s` may consist of printable ASCII characters.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time and <code>O(m)</code> space, where <code>n</code> is the length of the string and <code>m</code> is the number of unique characters in the string.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would be to try the substring starting at index <code>i</code> and try to find the maximum length we can form without duplicates by starting at that index. we can use a hash set to detect duplicates in <code>O(1)</code> time. Can you think of a better way?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use the sliding window algorithm. Since we only care about substrings without duplicate characters, the sliding window can help us maintain valid substring with its dynamic nature.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We can iterate through the given string with index <code>r</code> as the right boundary and <code>l</code> as the left boundary of the window. We use a hash set to check if the character is present in the window or not. When we encounter a character at index <code>r</code> that is already present in the window, we shrink the window by incrementing the <code>l</code> pointer until the window no longer contains any duplicates. Also, we remove characters from the hash set that are excluded from the window as the <code>l</code> pointer moves. At each iteration, we update the result with the length of the current window, <code>r - l + 1</code>, if this length is greater than the current result.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/wiGpQwVHdE0/0.jpg)](https://www.youtube.com/watch?v=wiGpQwVHdE0)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=wiGpQwVHdE0)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/longest-substring-without-duplicates)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int res = 0;
        for (int i = 0; i < s.Length; i++) {
            HashSet<char> charSet = new HashSet<char>();
            for (int j = i; j < s.Length; j++) {
                if (charSet.Contains(s[j])) {
                    break;
                }
                charSet.Add(s[j]);
            }
            res = Math.Max(res, charSet.Count);
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * m)$
* Space complexity: $O(m)$

> Where $n$ is the length of the string and $m$ is the total number of unique characters in the string.

---

### 2. Sliding Window






```csharp
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        HashSet<char> charSet = new HashSet<char>();
        int l = 0;
        int res = 0;

        for (int r = 0; r < s.Length; r++) {
            while (charSet.Contains(s[r])) {
                charSet.Remove(s[l]);
                l++;
            }
            charSet.Add(s[r]);
            res = Math.Max(res, r - l + 1);
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(m)$

> Where $n$ is the length of the string and $m$ is the total number of unique characters in the string.

---

### 3. Sliding Window (Optimal)






```csharp
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        Dictionary<char, int> mp = new Dictionary<char, int>();
        int l = 0, res = 0;
        
        for (int r = 0; r < s.Length; r++) {
            if (mp.ContainsKey(s[r])) {
                l = Math.Max(mp[s[r]] + 1, l);
            }
            mp[s[r]] = r;
            res = Math.Max(res, r - l + 1);
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(m)$

> Where $n$ is the length of the string and $m$ is the total number of unique characters in the string.
