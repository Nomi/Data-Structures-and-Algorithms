# Permutation In String

|   | Difficulty | Tricky |
|---|------------|--------|
| <big>☆<big> | <big>**🟨 Medium**</big> | <big></big> |


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
You are given two strings `s1` and `s2`.
    
Return `true` if `s2` contains a permutation of `s1`, or `false` otherwise. That means if a permutation of `s1` exists as a substring of `s2`, then return `true`.

Both strings only contain lowercase letters.

**Example 1:**

```java
Input: s1 = "abc", s2 = "lecabee"

Output: true
```

Explanation: The substring `"cab"` is a permutation of `"abc"` and is present in `"lecabee"`.

**Example 2:**

```java
Input: s1 = "abc", s2 = "lecaabee"

Output: false
```

**Constraints:**
* `1 <= s1.length, s2.length <= 1000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time and <code>O(1)</code> space, where <code>n</code> is the maximum of the lengths of the two strings.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would be to check every substring of <code>s2</code> with <code>s1</code> by sorting <code>s1</code> as well as the substring of <code>s2</code>. This would be an <code>O(n^2)</code> solution. Can you think of a better way? Maybe we can use the freqency of the characters of both the strings as we did in checking anagrams.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We return false if the length of <code>s1</code> is greater than the length of <code>s2</code>. To count the frequency of each character in a string, we can simply use an array of size <code>O(26)</code>, since the character set consists of <code>a</code> through <code>z</code> (<code>26</code> continuous characters). Which algorithm can we use now?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We use a sliding window approach on <code>s2</code> with a fixed window size equal to the length of <code>s1</code>. To track the current window, we maintain a running frequency count of characters in <code>s2</code>. This frequency count represents the characters in the current window. At each step, if the frequency count matches that of <code>s1</code>, we return <code>true</code>.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/UbyhOgBN834/0.jpg)](https://www.youtube.com/watch?v=UbyhOgBN834)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=UbyhOgBN834)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/permutation-string)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        char[] s1Arr = s1.ToCharArray();
        Array.Sort(s1Arr);
        string sortedS1 = new string(s1Arr);

        for (int i = 0; i < s2.Length; i++) {
            for (int j = i; j < s2.Length; j++) {
                char[] subStrArr = s2.Substring(i, j - i + 1).ToCharArray();
                Array.Sort(subStrArr);
                string sortedSubStr = new string(subStrArr);

                if (sortedSubStr == sortedS1) {
                    return true;
                }
            }
        }
        return false;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 3 \log n)$
* Space complexity: $O(n)$

---

### 2. Hash Table






```csharp
public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        Dictionary<char, int> count1 = new Dictionary<char, int>();
        foreach (char c in s1) {
            if (count1.ContainsKey(c)) {
                count1[c]++;
            } else {
                count1[c] = 1;
            }
        }

        int need = count1.Count;
        for (int i = 0; i < s2.Length; i++) {
            Dictionary<char, int> count2 = new Dictionary<char, int>();
            int cur = 0;
            for (int j = i; j < s2.Length; j++) {
                char c = s2[j];
                if (count2.ContainsKey(c)) {
                    count2[c]++;
                } else {
                    count2[c] = 1;
                }

                if (!count1.ContainsKey(c) || count1[c] < count2[c]) {
                    break;
                }

                if (count1[c] == count2[c]) {
                    cur++;
                }

                if (cur == need) {
                    return true;
                }
            }
        }
        return false;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * m)$
* Space complexity: $O(1)$

> Where $n$ is the length of the string1 and $m$ is the length of string2.

---

### 3. Sliding Window






```csharp
public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if (s1.Length > s2.Length) {
            return false;
        }

        int[] s1Count = new int[26];
        int[] s2Count = new int[26];
        for (int i = 0; i < s1.Length; i++) {
            s1Count[s1[i] - 'a']++;
            s2Count[s2[i] - 'a']++;
        }

        int matches = 0;
        for (int i = 0; i < 26; i++) {
            if (s1Count[i] == s2Count[i]) {
                matches++;
            }
        }

        int l = 0;
        for (int r = s1.Length; r < s2.Length; r++) {
            if (matches == 26) {
                return true;
            }

            int index = s2[r] - 'a';
            s2Count[index]++;
            if (s1Count[index] == s2Count[index]) {
                matches++;
            } else if (s1Count[index] + 1 == s2Count[index]) {
                matches--;
            }

            index = s2[l] - 'a';
            s2Count[index]--;
            if (s1Count[index] == s2Count[index]) {
                matches++;
            } else if (s1Count[index] - 1 == s2Count[index]) {
                matches--;
            }
            l++;
        }

        return matches == 26;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$
