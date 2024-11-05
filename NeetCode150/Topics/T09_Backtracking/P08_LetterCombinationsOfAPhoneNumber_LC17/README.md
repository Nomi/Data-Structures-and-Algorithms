# Letter Combinations of a Phone Number

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
- [Tree Maze](https://neetcode.io/courses/dsa-for-beginners/22) [from NeetCode's Course(s)]


## Problem Description
You are given a string `digits` made up of digits from `2` through `9` inclusive.

Each digit (not including 1) is mapped to a set of characters as shown below:

A digit could represent any one of the characters it maps to.

Return all possible letter combinations that `digits` could represent. You may return the answer in **any order**.

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/796a0dc1-2fcd-4ebb-0686-28f9007ec800/public)

**Example 1:**

```java
Input: digits = "34"

Output: ["dg","dh","di","eg","eh","ei","fg","fh","fi"]
```

**Example 2:**

```java
Input: digits = ""

Output: []
```

**Constraints:**
* `0 <= digits.length <= 4`
* `2 <= digits[i] <= 9`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n * (4^n))</code> time and <code>O(n)</code> space, where <code>n</code> is the length of the input string.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    We can use a hash map to pair all the digits with their corresponding letters. Think of this as a decision tree, where at each step, we have a digit, and we select one of multiple characters to proceed to the next digit in the given string <code>digits</code>. Can you think of an algorithm to generate all combinations of strings? 
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use backtracking where we select a character and process it, then backtrack to process another character. We recursively iterate on the given string with index <code>i</code>. At each step, we consider the letters from the hash map that correspond to the digit at the <code>i-th</code> index. Can you think of the base condition to stop this recursive path?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We initialize an empty string that represents the choices of the characters throughout the current recursive path. When the index <code>i</code> reaches the end of the string, we add the current string to the result list and return.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/0snEunUacZY/0.jpg)](https://www.youtube.com/watch?v=0snEunUacZY)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=0snEunUacZY)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/combinations-of-a-phone-number)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Bactracking






```csharp
public class Solution {
    
    private List<string> res = new List<string>();
    private Dictionary<char, string> digitToChar = new Dictionary<char, string> {
        {'2', "abc"}, {'3', "def"}, {'4', "ghi"}, {'5', "jkl"},
        {'6', "mno"}, {'7', "qprs"}, {'8', "tuv"}, {'9', "wxyz"}
    };

    public List<string> LetterCombinations(string digits) {
        if (digits.Length == 0) return res;
        Backtrack(0, "", digits);
        return res;
    }

    private void Backtrack(int i, string curStr, string digits) {
        if (curStr.Length == digits.Length) {
            res.Add(curStr);
            return;
        }
        foreach (char c in digitToChar[digits[i]]) {
            Backtrack(i + 1, curStr + c, digits);
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * 4 ^ n)$
* Space complexity: $O(n)$

---

### 2. Iteration






```csharp
public class Solution {

    public List<string> LetterCombinations(string digits) {
        if (digits.Length == 0) return new List<string>();
        
        List<string> res = new List<string> { "" };
        Dictionary<char, string> digitToChar = new Dictionary<char, string> {
            { '2', "abc" }, { '3', "def" }, { '4', "ghi" }, { '5', "jkl" },
            { '6', "mno" }, { '7', "qprs" }, { '8', "tuv" }, { '9', "wxyz" }
        };

        foreach (char digit in digits) {
            List<string> tmp = new List<string>();
            foreach (string curStr in res) {
                foreach (char c in digitToChar[digit]) {
                    tmp.Add(curStr + c);
                }
            }
            res = tmp;
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * 4 ^ n)$
* Space complexity: $O(n)$
