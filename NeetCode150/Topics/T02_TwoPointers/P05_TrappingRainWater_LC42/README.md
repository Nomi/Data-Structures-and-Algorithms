# ⭐ | Trapping Rain Water

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
- [Two Pointers](https://neetcode.io/courses/advanced-algorithms/3) [from NeetCode's Course(s)]


## Problem Description
You are given an array non-negative integers `height` which represent an elevation map. Each value `height[i]` represents the height of a bar, which has a width of `1`.

Return the maximum area of water that can be trapped between the bars.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/0c25cb81-1095-4382-fff2-6ef77c1fd100/public)

```java
Input: height = [0,2,0,3,1,0,1,3,2,1]

Output: 9
```

**Constraints:**
* `1 <= height.length <= 1000`
* `0 <= height[i] <= 1000`

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
    How can we determine the amount of water that can be trapped at a specific position in the array? Perhaps looking at the image might help clarify.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    From the image, we can see that to calculate the amount of water trapped at a position, the greater element to the left <code>l</code> and the greater element to the right <code>r</code> of the current position are crucial. The formula for the trapped water at index <code>i</code> is given by: <code>min(height[l], height[r]) - height[i]</code>.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    A brute force solution would involve iterating through the array with index <code>i</code>, finding the greater elements to the left (<code>l</code>) and right (<code>r</code>) for each index, and then calculating the trapped water for that position. The total amount of trapped water would be the sum of the water trapped at each index. Finding <code>l</code> and <code>r</code> for each index involves repeated work, resulting in an <code>O(n^2)</code> solution. Can you think of a more efficient approach? Maybe there is something that we can precompute and store in arrays.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We can store the prefix maximum in an array by iterating from left to right and the suffix maximum in another array by iterating from right to left. For example, in <code>[1, 5, 2, 3, 4]</code>, for the element <code>3</code>, the prefix maximum is <code>5</code>, and the suffix maximum is <code>4</code>. Once these arrays are built, we can iterate through the array with index <code>i</code> and calculate the total water trapped at each position using the formula: <code>min(prefix[i], suffix[i]) - height[i]</code>. 
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/ZI2z5pq0TqA/0.jpg)](https://www.youtube.com/watch?v=ZI2z5pq0TqA)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=ZI2z5pq0TqA)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/trapping-rain-water)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public int Trap(int[] height) {
        if (height == null || height.Length == 0) {
            return 0;
        }
        int n = height.Length;
        int res = 0;

        for (int i = 0; i < n; i++) {
            int leftMax = height[i];
            int rightMax = height[i];

            for (int j = 0; j < i; j++) {
                leftMax = Math.Max(leftMax, height[j]);
            }
            for (int j = i + 1; j < n; j++) {
                rightMax = Math.Max(rightMax, height[j]);
            }

            res += Math.Min(leftMax, rightMax) - height[i];
        }

        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(1)$

---

### 2. Prefix & Suffix Arrays






```csharp
public class Solution {
    public int Trap(int[] height) {
        int n = height.Length;
        if (n == 0) {
            return 0;
        }

        int[] leftMax = new int[n];
        int[] rightMax = new int[n];

        leftMax[0] = height[0];
        for (int i = 1; i < n; i++) {
            leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
        }

        rightMax[n - 1] = height[n - 1];
        for (int i = n - 2; i >= 0; i--) {
            rightMax[i] = Math.Max(rightMax[i + 1], height[i]);
        }

        int res = 0;
        for (int i = 0; i < n; i++) {
            res += Math.Min(leftMax[i], rightMax[i]) - height[i];
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 3. Stack






```csharp
public class Solution {
    public int Trap(int[] height) {
        if (height.Length == 0) {
            return 0;
        }

        Stack<int> stack = new Stack<int>();
        int res = 0;

        for (int i = 0; i < height.Length; i++) {
            while (stack.Count > 0 && height[i] >= height[stack.Peek()]) {
                int mid = height[stack.Pop()];
                if (stack.Count > 0) {
                    int right = height[i];
                    int left = height[stack.Peek()];
                    int h = Math.Min(right, left) - mid;
                    int w = i - stack.Peek() - 1;
                    res += h * w;
                }
            }
            stack.Push(i);
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 4. Two Pointers






```csharp
public class Solution {
    public int Trap(int[] height) {
        if (height == null || height.Length == 0) {
            return 0;
        }

        int l = 0, r = height.Length - 1;
        int leftMax = height[l], rightMax = height[r];
        int res = 0;
        while (l < r) {
            if (leftMax < rightMax) {
                l++;
                leftMax = Math.Max(leftMax, height[l]);
                res += leftMax - height[l];
            } else {
                r--;
                rightMax = Math.Max(rightMax, height[r]);
                res += rightMax - height[r];
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$
