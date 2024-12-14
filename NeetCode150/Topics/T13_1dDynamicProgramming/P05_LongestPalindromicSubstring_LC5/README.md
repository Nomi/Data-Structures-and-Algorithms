# ⭐ | Longest Palindromic Substring

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
- [Two Pointers](https://neetcode.io/courses/advanced-algorithms/3) [from NeetCode's Course(s)]
- [Palindromes](https://neetcode.io/courses/advanced-algorithms/21) [from NeetCode's Course(s)]


## Problem Description
Given a string `s`, return the longest substring of `s` that is a *palindrome*.

A **palindrome** is a string that reads the same forward and backward.

If there are multiple palindromic substrings that have the same length, return any one of them.

**Example 1:**

```java
Input: s = "ababd"

Output: "bab"
```

Explanation: Both "aba" and "bab" are valid answers.

**Example 2:**

```java
Input: s = "abbc"

Output: "bb"
```

**Constraints:**
* `1 <= s.length <= 1000`
* `s` contains only digits and English letters.


## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/XYQecbcd6_c/0.jpg)](https://www.youtube.com/watch?v=XYQecbcd6_c)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=XYQecbcd6_c)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/longest-palindromic-substring)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public string LongestPalindrome(string s) {
        string res = "";
        int resLen = 0;

        for (int i = 0; i < s.Length; i++) {
            for (int j = i; j < s.Length; j++) {
                int l = i, r = j;
                while (l < r && s[l] == s[r]) {
                    l++;
                    r--;
                }

                if (l >= r && resLen < (j - i + 1)) {
                    res = s.Substring(i, j - i + 1);
                    resLen = j - i + 1;
                }
            }
        }

        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 3)$
* Space complexity: $O(1)$

---

### 2. Dynamic Programming






```csharp
public class Solution {
    public string LongestPalindrome(string s) {
        int resIdx = 0, resLen = 0;
        int n = s.Length;

        bool[,] dp = new bool[n, n];

        for (int i = n - 1; i >= 0; i--) {
            for (int j = i; j < n; j++) {
                if (s[i] == s[j] && 
                   (j - i <= 2 || dp[i + 1, j - 1])) {
                    
                    dp[i, j] = true;
                    if (resLen < (j - i + 1)) {
                        resIdx = i;
                        resLen = j - i + 1;
                    }
                }
            }
        }

        return s.Substring(resIdx, resLen);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(n ^ 2)$

---

### 3. Two Pointers






```csharp
public class Solution {
    public string LongestPalindrome(string s) {
        int resLen = 0, resIdx = 0;

        for (int i = 0; i < s.Length; i++) {
            // odd length
            int l = i, r = i;
            while (l >= 0 && r < s.Length &&
                   s[l] == s[r]) {
                if (r - l + 1 > resLen) {
                    resIdx = l;
                    resLen = r - l + 1;
                }
                l--;
                r++;
            }

            // even length
            l = i;
            r = i + 1;
            while (l >= 0 && r < s.Length &&
                   s[l] == s[r]) {
                if (r - l + 1 > resLen) {
                    resIdx = l;
                    resLen = r - l + 1;
                }
                l--;
                r++;
            }
        }

        return s.Substring(resIdx, resLen);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(1)$

---

### 4. Manacher's Algorithm






```csharp
public class Solution {
    public int[] Manacher(string s) {
        string t = "#" + string.Join("#", s.ToCharArray()) + "#";
        int n = t.Length;
        int[] p = new int[n];
        int l = 0, r = 0;
        for (int i = 0; i < n; i++) {
            p[i] = (i < r) ? Math.Min(r - i, p[l + (r - i)]) : 0;
            while (i + p[i] + 1 < n && i - p[i] - 1 >= 0 &&
                   t[i + p[i] + 1] == t[i - p[i] - 1]) {
                p[i]++;
            }
            if (i + p[i] > r) {
                l = i - p[i];
                r = i + p[i];
            }
        }
        return p;
    }

    public string LongestPalindrome(string s) {
        int[] p = Manacher(s);
        int resLen = 0, center_idx = 0;
        for (int i = 0; i < p.Length; i++) {
            if (p[i] > resLen) {
                resLen = p[i];
                center_idx = i;
            }
        }
        int resIdx = (center_idx - resLen) / 2;
        return s.Substring(resIdx, resLen);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
