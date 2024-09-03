# Valid Anagram

|   | Difficulty | Tricky |
|---|------------|--------|
| <big>☆<big> | <big>**🟩 Easy**</big> | <big></big> |


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
Given two strings `s` and `t`, return `true` if the two strings are anagrams of each other, otherwise return `false`.

An **anagram** is a string that contains the exact same characters as another string, but the order of the characters can be different.

**Example 1:**

```java
Input: s = "racecar", t = "carrace"

Output: true
```

**Example 2:**

```java
Input: s = "jar", t = "jam"

Output: false
```

**Constraints:**
* `s` and `t` consist of lowercase English letters.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n + m)</code> time and <code>O(1)</code> space, where <code>n</code> is the length of the string <code>s</code> and <code>m</code> is the length of the string <code>t</code>.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would be to sort the given strings and check for their equality. This would be an <code>O(nlogn + mlogm)</code> solution. Though this solution is acceptable, can you think of a better way without sorting the given strings?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    By the definition of the anagram, we can rearrange the characters. Does the order of characters matter in both the strings? Then what matters?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We can just consider maintaining the frequency of each character. We can do this by having two separate hash tables for the two strings. Then, we can check whether the frequency of each character in string <code>s</code> is equal to that in string <code>t</code> and vice versa.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/9UtInBqnCgA/0.jpg)](https://www.youtube.com/watch?v=9UtInBqnCgA)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=9UtInBqnCgA)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/is-anagram)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Sorting






```csharp
public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }

        char[] sSort = s.ToCharArray();
        char[] tSort = t.ToCharArray();
        Array.Sort(sSort);
        Array.Sort(tSort);
        return sSort.SequenceEqual(tSort);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log n + m \log m)$
* Space complexity: $O(1)$ or $O(n + m)$ depending on the sorting algorithm.

> Where $n$ is the length of string $s$ and $m$ is the length of string $t$. 

---

### 2. Hash Table






```csharp
public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }

        Dictionary<char, int> countS = new Dictionary<char, int>();
        Dictionary<char, int> countT = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++) {
            countS[s[i]] = countS.GetValueOrDefault(s[i], 0) + 1;
            countT[t[i]] = countT.GetValueOrDefault(t[i], 0) + 1;
        }
        return countS.Count == countT.Count && !countS.Except(countT).Any();
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n + m)$
* Space complexity: $O(1)$ since we have at most $26$ different characters.

> Where $n$ is the length of string $s$ and $m$ is the length of string $t$. 

---

### 3. Hash Table (Optimal)






```csharp
public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }

        int[] count = new int[26];
        for (int i = 0; i < s.Length; i++) {
            count[s[i] - 'a']++;
            count[t[i] - 'a']--;
        }

        foreach (int val in count) {
            if (val != 0) {
                return false;
            }
        }
        return true;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n + m)$
* Space complexity: $O(1)$ since we have at most $26$ different characters.

> Where $n$ is the length of string $s$ and $m$ is the length of string $t$.
