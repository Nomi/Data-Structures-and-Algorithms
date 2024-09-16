# ⭐ | Minimum Window Substring

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
- [Hash Usage](https://neetcode.io/courses/dsa-for-beginners/26) [from NeetCode's Course(s)]
- [Sliding Window Fixed Size](https://neetcode.io/courses/advanced-algorithms/1) [from NeetCode's Course(s)]
- [Sliding Window Variable Size](https://neetcode.io/courses/advanced-algorithms/2) [from NeetCode's Course(s)]


## Problem Description
Given two strings `s` and `t`, return the shortest **substring** of `s` such that every character in `t`, including duplicates, is present in the substring. If such a substring does not exist, return an empty string `""`.

You may assume that the correct output is always unique.

**Example 1:**

```java
Input: s = "OUZODYXAZV", t = "XYZ"

Output: "YXAZ"
```

Explanation: `"YXAZ"` is the shortest substring that includes `"X"`, `"Y"`, and `"Z"` from string `t`.

**Example 2:**

```java
Input: s = "xyz", t = "xyz"

Output: "xyz"
```

**Example 3:**

```java
Input: s = "x", t = "xy"

Output: ""
```

**Constraints:**
* `1 <= s.length <= 1000`
* `1 <= t.length <= 1000`
* `s` and `t` consist of uppercase and lowercase English letters.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time and <code>O(m)</code> space, where <code>n</code> is the length of the string <code>s</code> and <code>m</code> is the number of unique characters in <code>s</code> and <code>t</code>.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would involve checking every substring of <code>s</code> against <code>t</code> and returning the minimum length valid substring. This would be an <code>O(n^2)</code> solution. Can you think of a better way? Maybe you should think in terms of frequency of characters.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We need to find substrings in <code>s</code> that should have atleast the characters of <code>t</code>. We can use hash maps to maintain the frequencies of characters. It will be <code>O(1)</code> for lookups. Can you think of an algorithm now?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We can use a dynamically sized sliding window approach on <code>s</code>. We iterate through <code>s</code> while maintaining a window. If the current window contains at least the frequency of characters from <code>t</code>, we update the result and shrink the window until it is valid. 
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We should ensure that we maintain the result substring and only update it if we find a shorter valid substring. Additionally, we need to keep track of the result substring's length so that we can return an empty string if no valid substring is found.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/jSto0O4AJbM/0.jpg)](https://www.youtube.com/watch?v=jSto0O4AJbM)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=jSto0O4AJbM)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/minimum-window-with-characters)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public string MinWindow(string s, string t) {
        if (t == "") return "";

        Dictionary<char, int> countT = new Dictionary<char, int>();
        foreach (char c in t) {
            if (countT.ContainsKey(c)) {
                countT[c]++;
            } else {
                countT[c] = 1;
            }
        }

        int[] res = { -1, -1 };
        int resLen = int.MaxValue;

        for (int i = 0; i < s.Length; i++) {
            Dictionary<char, int> countS = new Dictionary<char, int>();
            for (int j = i; j < s.Length; j++) {
                if (countS.ContainsKey(s[j])) {
                    countS[s[j]]++;
                } else {
                    countS[s[j]] = 1;
                }

                bool flag = true;
                foreach (var c in countT.Keys) {
                    if (!countS.ContainsKey(c) || countS[c] < countT[c]) {
                        flag = false;
                        break;
                    }
                }

                if (flag && (j - i + 1) < resLen) {
                    resLen = j - i + 1;
                    res[0] = i;
                    res[1] = j;
                }
            }
        }

        return resLen == int.MaxValue ? "" : s.Substring(res[0], resLen);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(m)$

> Where $n$ is the length of the string $s$ and $m$ is the total number of unique characters in the strings $t$ and $s$.

---

### 2. Sliding Window






```csharp
public class Solution {
    public string MinWindow(string s, string t) {
        if (t == "") return "";

        Dictionary<char, int> countT = new Dictionary<char, int>();
        Dictionary<char, int> window = new Dictionary<char, int>();

        foreach (char c in t) {
            if (countT.ContainsKey(c)) {
                countT[c]++;
            } else {
                countT[c] = 1;
            }
        }

        int have = 0, need = countT.Count;
        int[] res = { -1, -1 };
        int resLen = int.MaxValue;
        int l = 0;

        for (int r = 0; r < s.Length; r++) {
            char c = s[r];
            if (window.ContainsKey(c)) {
                window[c]++;
            } else {
                window[c] = 1;
            }

            if (countT.ContainsKey(c) && window[c] == countT[c]) {
                have++;
            }

            while (have == need) {
                if ((r - l + 1) < resLen) {
                    resLen = r - l + 1;
                    res[0] = l;
                    res[1] = r;
                }

                char leftChar = s[l];
                window[leftChar]--;
                if (countT.ContainsKey(leftChar) && window[leftChar] < countT[leftChar]) {
                    have--;
                }
                l++;
            }
        }

        return resLen == int.MaxValue ? "" : s.Substring(res[0], resLen);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(m)$

> Where $n$ is the length of the string $s$ and $m$ is the total number of unique characters in the strings $t$ and $s$.
