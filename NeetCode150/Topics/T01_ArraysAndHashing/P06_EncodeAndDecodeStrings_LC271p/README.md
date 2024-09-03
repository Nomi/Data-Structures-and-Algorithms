# ⭐ | Encode and Decode Strings

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



## Problem Description
Design an algorithm to encode a list of strings to a single string. The encoded string is then decoded back to the original list of strings.

Please implement `encode` and `decode`

**Example 1:**

```java
Input: ["neet","code","love","you"]

Output:["neet","code","love","you"]
```

**Example 2:**
```java
Input: ["we","say",":","yes"]

Output: ["we","say",":","yes"]
```

**Constraints:**
* `0 <= strs.length < 100`
* `0 <= strs[i].length < 200`
* `strs[i]` contains only UTF-8 characters.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(m)</code> time and <code>O(1)</code> space for each <code>encode()</code> and <code>decode()</code> call, where <code>m</code>  is the sum of lengths of all the strings.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A naive solution would be to use a non-ascii character as a delimiter. Can you think of a better way?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    Try to encode and decode the strings using a smart approach based on the lengths of each string. How can you differentiate between the lengths and any numbers that might be present in the strings?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We can use an encoding approach where we start with a number representing the length of the string, followed by a separator character (let's use <code>#</code> for simplicity), and then the string itself. To decode, we read the number until we reach a <code>#</code>, then use that number to read the specified number of characters as the string.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/B1k_sxOSgv8/0.jpg)](https://www.youtube.com/watch?v=B1k_sxOSgv8)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=B1k_sxOSgv8)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/string-encode-and-decode)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Encoding & Decoding






```csharp
public class Solution {

    public string Encode(IList<string> strs) {
        if (strs.Count == 0) return "";
        List<int> sizes = new List<int>();
        string res = "";
        foreach (string s in strs) {
            sizes.Add(s.Length);
        }
        foreach (int sz in sizes) {
            res += sz.ToString() + ',';
        }
        res += '#';
        foreach (string s in strs) {
            res += s;
        }
        return res;
    }

    public List<string> Decode(string s) {
        if (s.Length == 0) {
            return new List<string>();
        }
        List<int> sizes = new List<int>();
        List<string> res = new List<string>();
        int i = 0;
        while (s[i] != '#') {
            string cur = "";
            while (s[i] != ',') {
                cur += s[i];
                i++;
            }
            sizes.Add(int.Parse(cur));
            i++;
        }
        i++;
        foreach (int sz in sizes) {
            res.Add(s.Substring(i, sz));
            i += sz;
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m)$ for $encode()$ and $decode()$.
* Space complexity: $O(n)$ for $encode()$ and $decode()$.

> Where $m$ is the sum of lengths of all the strings and $n$ is the number of strings.

---

### 2. Encoding & Decoding (Optimal)






```csharp
public class Solution {
    public string Encode(IList<string> strs) {
        string res = "";
        foreach (string s in strs) {
            res += s.Length + "#" + s;
        }
        return res;
    }

    public List<string> Decode(string s) {
        List<string> res = new List<string>();
        int i = 0;
        while (i < s.Length) {
            int j = i;
            while (s[j] != '#') {
                j++;
            }
            int length = int.Parse(s.Substring(i, j - i));
            i = j + 1;
            j = i + length;
            res.Add(s.Substring(i, length));
            i = j;
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m)$ for $encode()$ and $decode()$.
* Space complexity: $O(1)$ for $encode()$ and $decode()$.

> Where $m$ is the sum of lengths of all the strings and $n$ is the number of strings.
