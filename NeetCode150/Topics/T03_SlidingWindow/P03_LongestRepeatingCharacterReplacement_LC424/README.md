# ⭐ | Longest Repeating Character Replacement

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
You are given a string `s` consisting of only uppercase english characters and an integer `k`. You can choose up to `k` characters of the string and replace them with any other uppercase English character.

After performing at most `k` replacements, return the length of the longest substring which contains only one distinct character.

**Example 1:**

```java
Input: s = "XYYX", k = 2

Output: 4
```

Explanation: Either replace the 'X's with 'Y's, or replace the 'Y's with 'X's.

**Example 2:**

```java
Input: s = "AAABABB", k = 1

Output: 5
```

**Constraints:**
* `1 <= s.length <= 1000`
* `0 <= k <= s.length`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time and <code>O(m)</code> space, where <code>n</code> is the length of the given string and <code>m</code> is the number of unique characters in the string.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    Which characters would you replace in a string to make all its characters unique? Can you think with respect to the frequency of the characters?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    It is always optimal to replace characters with the most frequent character in the string. Why? Because using the most frequent character minimizes the number of replacements required to make all characters in the string identical. How can you find the number of replacements now?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    The number of replacements is equal to the difference between the length of the string and the frequency of the most frequent character in the string. A brute force solution would be to consider all substrings, use a hash map for frequency counting, and return the maximum length of the substring that has at most <code>k</code> replacements. This would be an <code>O(n^2)</code> solution. Can you think of a better way?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We can use the sliding window approach. The window size will be dynamic, and we will shrink the window when the number of replacements exceeds <code>k</code>. The result will be the maximum window size observed at each iteration.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/gqXU1UyA8pk/0.jpg)](https://www.youtube.com/watch?v=gqXU1UyA8pk)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=gqXU1UyA8pk)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/longest-repeating-substring-with-replacement)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public int CharacterReplacement(string s, int k) {
        int res = 0;
        for (int i = 0; i < s.Length; i++) {
            Dictionary<char, int> count = new Dictionary<char, int>();
            int maxf = 0;
            for (int j = i; j < s.Length; j++) {
                if (count.ContainsKey(s[j])) {
                    count[s[j]]++;
                } else {
                    count[s[j]] = 1;
                }
                maxf = Math.Max(maxf, count[s[j]]);
                if ((j - i + 1) - maxf <= k) {
                    res = Math.Max(res, j - i + 1);
                }
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(m)$

> Where $n$ is the length of the string and $m$ is the total number of unique characters in the string.

---

### 2. Sliding Window






```csharp
public class Solution {
    public int CharacterReplacement(string s, int k) {
        int res = 0;
        HashSet<char> charSet = new HashSet<char>(s);

        foreach (char c in charSet) {
            int count = 0, l = 0;
            for (int r = 0; r < s.Length; r++) {
                if (s[r] == c) {
                    count++;
                }

                while ((r - l + 1) - count > k) {
                    if (s[l] == c) {
                        count--;
                    }
                    l++;
                }

                res = Math.Max(res, r - l + 1);
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n)$
* Space complexity: $O(m)$

> Where $n$ is the length of the string and $m$ is the total number of unique characters in the string.

---

### 3. Sliding Window (Optimal)






```csharp
public class Solution {
    public int CharacterReplacement(string s, int k) {
        Dictionary<char, int> count = new Dictionary<char, int>();
        int res = 0;

        int l = 0, maxf = 0;
        for (int r = 0; r < s.Length; r++) {
            if (count.ContainsKey(s[r])) {
                count[s[r]]++;
            } else {
                count[s[r]] = 1;
            }
            maxf = Math.Max(maxf, count[s[r]]);

            while ((r - l + 1) - maxf > k) {
                count[s[l]]--;
                l++;
            }
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
