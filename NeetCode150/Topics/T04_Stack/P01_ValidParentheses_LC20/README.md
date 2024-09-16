# ⭐ | Valid Parentheses

|   | Difficulty | Tricky |
|---|------------|--------|
| <big>⭐<big> | <big>**🟩 Easy**</big> | <big></big> |


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


## Problem Description
You are given a string `s` consisting of the following characters: `'('`, `')'`, `'{'`, `'}'`, `'['` and `']'`.

The input string `s` is valid if and only if:

1. Every open bracket is closed by the same type of close bracket.
2. Open brackets are closed in the correct order.
3. Every close bracket has a corresponding open bracket of the same type.

Return `true` if `s` is a valid string, and `false` otherwise.

**Example 1:**

```java
Input: s = "[]"

Output: true
```

**Example 2:**

```java
Input: s = "([{}])"

Output: true
```

**Example 3:**

```java
Input: s = "[(])"

Output: false
```

Explanation: The brackets are not closed in the correct order.

**Constraints:**
* `1 <= s.length <= 1000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time and <code>O(n)</code> space, where <code>n</code> is the length of the given string. 
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would be to continuously remove valid brackets until no more can be removed. If the remaining string is empty, return true; otherwise, return false. This would result in an <code>O(n^2)</code> solution. Can we think of a better approach? Perhaps a data structure could help.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use a stack to store characters. Iterate through the string by index. For an opening bracket, push it onto the stack. If the bracket is a closing type, check for the corresponding opening bracket at the top of the stack. If we don't find the corresponding opening bracket, immediately return false. Why does this work?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    In a valid parenthesis expression, every opening bracket must have a corresponding closing bracket. The stack is used to process the valid string, and it should be empty after the entire process. This ensures that there is a valid substring between each opening and closing bracket.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/WTzjTskDFMg/0.jpg)](https://www.youtube.com/watch?v=WTzjTskDFMg)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=WTzjTskDFMg)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/validate-parentheses)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public bool IsValid(string s) {
        while (s.Contains("()") || s.Contains("{}") || s.Contains("[]")) {
            s = s.Replace("()", "");
            s = s.Replace("{}", "");
            s = s.Replace("[]", "");
        }
        return s == "";
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(n)$

---

### 2. Stack






```csharp
public class Solution {
    public bool IsValid(string s) {
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> closeToOpen = new Dictionary<char, char> {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

        foreach (char c in s) {
            if (closeToOpen.ContainsKey(c)) {
                if (stack.Count > 0 && stack.Peek() == closeToOpen[c]) {
                    stack.Pop();
                } else {
                    return false;
                }
            } else {
                stack.Push(c);
            }
        }
        return stack.Count == 0;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
