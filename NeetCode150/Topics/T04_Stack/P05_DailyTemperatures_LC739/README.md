# ⭐ | Daily Temperatures

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


## Problem Description
You are given an array of integers `temperatures` where `temperatures[i]` represents the daily temperatures on the `ith` day.
    
Return an array `result` where `result[i]` is the number of days after the `ith` day before a warmer temperature appears on a future day. If there is no day in the future where a warmer temperature will appear for the `ith` day, set `result[i]` to `0` instead.

**Example 1:**

```java
Input: temperatures = [30,38,30,36,35,40,28]

Output: [1,4,1,2,1,0,0]
```

**Example 2:**

```java
Input: temperatures = [22,21,20]

Output: [0,0,0]
```

**Constraints:**
* `1 <= temperatures.length <= 1000`.
* `1 <= temperatures[i] <= 100`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution as good or better than <code>O(n)</code> time and <code>O(n)</code> space, where <code>n</code> is the size of the input array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would involve iterating through the array with index <code>i</code> and checking how far is the next greater element to the right of <code>i</code>. This would be an <code>O(n^2)</code> solution. Can you think of a better way?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    Can you consider a reverse approach? For example, in <code>[2, 1, 1, 3]</code>, the next greater element for the numbers <code>[2, 1, 1]</code> is <code>3</code>. Instead of checking for each element individually, can you think of a way where, by standing at the element <code>3</code>, you compute the result for the elements <code>[2, 1, 1]</code>?  Maybe there's a data structure that is useful here.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
   We can use a stack to maintain indices in a monotonically decreasing order, popping indices where the values are smaller than the current element. This helps us find the result by using the difference between indices while considering the values at those indices. Can you see how the stack is useful?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    In the array <code>[2, 1, 1, 3]</code>, we don't perform any pop operations while processing <code>[2, 1, 1]</code> because these elements are already in decreasing order. However, when we reach <code>3</code>, we pop elements from the stack until the top element of the stack is no longer less than the current element. For each popped element, we compute the difference between the indices and store it in the position corresponding to the popped element.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/cTBiBSnjO3c/0.jpg)](https://www.youtube.com/watch?v=cTBiBSnjO3c)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=cTBiBSnjO3c)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/daily-temperatures)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        int n = temperatures.Length;
        int[] res = new int[n];

        for (int i = 0; i < n; i++) {
            int count = 1;
            int j = i + 1;
            while (j < n) {
                if (temperatures[j] > temperatures[i]) {
                    break;
                }
                j++;
                count++;
            }
            count = (j == n) ? 0 : count;
            res[i] = count;
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(1)$

---

### 2. Stack






```csharp
public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        int[] res = new int[temperatures.Length];
        Stack<int[]> stack = new Stack<int[]>(); // pair: [temp, index]

        for (int i = 0; i < temperatures.Length; i++) {
            int t = temperatures[i];
            while (stack.Count > 0 && t > stack.Peek()[0]) {
                int[] pair = stack.Pop();
                res[pair[1]] = i - pair[1];
            }
            stack.Push(new int[] { t, i });
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 3. Dynamic Programming






```csharp
public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        int n = temperatures.Length;
        int[] res = new int[n];

        for (int i = n - 2; i >= 0; i--) {
            int j = i + 1;
            while (j < n && temperatures[j] <= temperatures[i]) {
                if (res[j] == 0) {
                    j = n;
                    break;
                }
                j += res[j];
            }

            if (j < n) {
                res[i] = j - i;
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$
