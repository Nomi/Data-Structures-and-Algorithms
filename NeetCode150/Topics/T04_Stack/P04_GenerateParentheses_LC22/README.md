# ⭐ | Generate Parentheses

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
- [Stacks](https://neetcode.io/courses/dsa-for-beginners/4) [from NeetCode's Course(s)]
- [Tree Maze](https://neetcode.io/courses/dsa-for-beginners/22) [from NeetCode's Course(s)]


## Problem Description
You are given an integer `n`. Return all well-formed parentheses strings that you can generate with `n` pairs of parentheses.

**Example 1:**

```java
Input: n = 1

Output: ["()"]
```

**Example 2:**

```java
Input: n = 3

Output: ["((()))","(()())","(())()","()(())","()()()"]
```

You may return the answer in **any order**.

**Constraints:**
* `1 <= n <= 7`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution as good or better than <code>O(4^n / sqrt(n))</code> time and <code>O(n)</code> space, where <code>n</code> is the number of parenthesis pairs in the string.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would be to generate all possible strings of size <code>2n</code> and add only the valid strings. This would be an <code>O(n * 2 ^ (2n))</code> solution. Can you think of a better way? Maybe you can use pruning to avoid generating invalid strings.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use backtracking with pruning. But what makes a string invalid? Can you think of a condition for this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    When the count of closing brackets exceeds the count of opening brackets, the string becomes invalid. Therefore, we can maintain two variables, <code>open</code> and <code>close</code>, to track the number of opening and closing brackets. We avoid exploring paths where <code>close > open</code>. Once the string length reaches <code>2n</code>, we add it to the result.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/s9fokUqJ76A/0.jpg)](https://www.youtube.com/watch?v=s9fokUqJ76A)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=s9fokUqJ76A)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/generate-parentheses)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public bool Valid(string s) {
        int open = 0;
        foreach (char c in s) {
            open += (c == '(') ? 1 : -1;
            if (open < 0) return false;
        }
        return open == 0;
    }

    public void Dfs(string s, List<string> res, int n) {
        if (s.Length == 2 * n) {
            if (Valid(s)) res.Add(s);
            return;
        }
        Dfs(s + '(', res, n);
        Dfs(s + ')', res, n);
    }

    public List<string> GenerateParenthesis(int n) {
        List<string> res = new List<string>();
        Dfs("", res, n);
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(2 ^ {2n} * n)$
* Space complexity: $O(2 ^ {2n} * n)$

---

### 2. Backtracking






```csharp
public class Solution {
    public void Backtrack(int openN, int closedN, int n, List<string> res, string stack) {
        if (openN == closedN && openN == n) {
            res.Add(stack);
            return;
        }

        if (openN < n) {
            Backtrack(openN + 1, closedN, n, res, stack + '(');
        }

        if (closedN < openN) {
            Backtrack(openN, closedN + 1, n, res, stack + ')');
        }
    }

    public List<string> GenerateParenthesis(int n) {
        List<string> res = new List<string>();
        string stack = ""; 
        Backtrack(0, 0, n, res, stack);
        return res;  
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(\frac{4^n}{\sqrt{n}})$
* Space complexity: $O(n)$

---

### 3. Dynamic Programming






```csharp
public class Solution {
    public List<string> GenerateParenthesis(int n) {
        List<List<string>> res = new List<List<string>>();
        for (int i = 0; i <= n; i++) {
            res.Add(new List<string>());
        }
        res[0].Add("");

        for (int k = 0; k <= n; k++) {
            for (int i = 0; i < k; i++) {
                foreach (string left in res[i]) {
                    foreach (string right in res[k - i - 1]) {
                        res[k].Add("(" + left + ")" + right);
                    }
                }
            }
        }

        return res[n];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(\frac{4^n}{\sqrt{n}})$
* Space complexity: $O(n)$
