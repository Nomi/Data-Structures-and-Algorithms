# ⭐ | Container With Most Water

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


## Problem Description
You are given an integer array `heights` where `heights[i]` represents the height of the $i^{th}$ bar.

You may choose any two bars to form a container. Return the *maximum* amount of water a container can store.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/77f004c6-e773-4e63-7b99-a2309303c700/public)

```java
Input: height = [1,7,2,5,4,7,3,6]

Output: 36
```

**Example 2:**

```java
Input: height = [2,2,2]

Output: 4
```

**Constraints:**
* `2 <= height.length <= 1000`
* `0 <= height[i] <= 1000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time and <code>O(1)</code> space, where <code>n</code> is the size of the input array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would be to try all pairs of bars in the array, compute the water for each pair, and return the maximum water among all pairs. This would be an <code>O(n^2)</code> solution. Can you think of a better way?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    Can you think of an algorithm that runs in linear time and is commonly used in problems that deal with pairs of numbers? Find a formula to calculate the amount of water when we fix two heights.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We can use the two pointer algorithm. One pointer is at the start and the other at the end. At each step, we calculate the amount of water using the formula <code>(j - i) * min(heights[i], heights[j])</code>. Then, we move the pointer that has the smaller height value. Can you think why we only move the pointer at smaller height?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    In the formula, the amount of water depends only on the minimum height. Therefore, it is appropriate to replace the smaller height value.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/UuiTKBwPgAo/0.jpg)](https://www.youtube.com/watch?v=UuiTKBwPgAo)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=UuiTKBwPgAo)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/max-water-container)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public int MaxArea(int[] heights) {
        int res = 0;
        for (int i = 0; i < heights.Length; i++) {
            for (int j = i + 1; j < heights.Length; j++) {
                res = Math.Max(res, Math.Min(heights[i], heights[j]) * (j - i));
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(1)$

---

### 2. Two Pointers






```csharp
public class Solution {
    public int MaxArea(int[] heights) {
        int res = 0;
        int l = 0, r = heights.Length-1;
        
        while (l < r){
            int area = (Math.Min(heights[l], heights[r])) * (r - l);
            res = Math.Max(area, res);
            
            if (heights[l] <= heights[r]){
                l++;
            } else{
                r--;
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$
