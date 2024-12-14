# ⭐ | Largest Rectangle In Histogram

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
- [Stacks](https://neetcode.io/courses/dsa-for-beginners/4) [from NeetCode's Course(s)]


## Problem Description
You are given an array of integers `heights` where `heights[i]` represents the height of a bar. The width of each bar is `1`.
    
Return the area of the largest rectangle that can be formed among the bars.

Note: This chart is known as a [histogram](https://en.wikipedia.org/wiki/Histogram).

**Example 1:**

```java
Input: heights = [7,1,7,2,2,4]

Output: 8
```

**Example 2:**

```java
Input: heights = [1,3,7]

Output: 7
```

**Constraints:**
* `1 <= heights.length <= 1000`.
* `0 <= heights[i] <= 1000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time and <code>O(n)</code> space, where <code>n</code> is the size of the input array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A rectangle has a height and a width. Can you visualize how rectangles are formed in the given input? Considering one bar at a time might help. We can try to form rectangles by going through every bar and current bar's height will be the height of the rectangle. How can you determine the width of the rectangle for the current bar being the height of the rectangle? Extending the current bar to the left and right might help determine the rectangle's width.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    For a bar with height <code>h</code>, try extending it to the left and right. We can see that we can't extend further when we encounter a bar with a smaller height than <code>h</code>. The width will be the number of bars within this extended range. A brute force solution would be to go through every bar and find the area of the rectangle it can form by extending towards the left and right. This would be an <code>O(n^2)</code> solution. Can you think of a better way? Maybe precomputing the left and right boundaries might be helpful.
    </p>
</details>

<br>
<details class="hint-accordion">
    <summary>Hint 3</summary>
    <p>
    The left and right boundaries are the positions up to which we can extend the bar at index <code>i</code>. The area of the rectangle will be <code>height[i] * (right - left + 1)</code>, which is the general formula for <code>height * width</code>. These boundaries are determined by the first smaller bars encountered to the left and right of the current bar. How can we find the left and right boundaries now? Maybe a data structure is helpful.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We can use a stack with a monotonically strictly increasing nature, but instead of storing values, we store indices in the stack and perform operations based on the values at those indices. The top of the stack will represent the smaller bar that we encounter while extending the current bar. To find the left and right boundaries, we perform this algorithm from left to right and vice versa, storing the boundaries. Then, we iterate through the array to find the area for each bar and return the maximum area we get.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/zx5Sw9130L0/0.jpg)](https://www.youtube.com/watch?v=zx5Sw9130L0)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=zx5Sw9130L0)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/largest-rectangle-in-histogram)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int n = heights.Length;
        int maxArea = 0;

        for (int i = 0; i < n; i++) {
            int height = heights[i];

            int rightMost = i + 1;
            while (rightMost < n && heights[rightMost] >= height) {
                rightMost++;
            }

            int leftMost = i;
            while (leftMost >= 0 && heights[leftMost] >= height) {
                leftMost--;
            }

            rightMost--;
            leftMost++;
            maxArea = Math.Max(maxArea, height * (rightMost - leftMost + 1));
        }
        return maxArea;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(1)$

---

### 2. Divide And Conquer (Segment Tree)






```csharp
public class MinIdx_Segtree {
    private int n;
    private readonly int INF = (int)1e9;
    private int[] A, tree;

    public MinIdx_Segtree(int N, int[] heights) {
        this.n = N;
        this.A = new int[heights.Length];
        heights.CopyTo(this.A, 0);
        while ((n & (n - 1)) != 0) {
            Array.Resize(ref A, n + 1);
            A[n] = INF;
            n++;
        }
        tree = new int[2 * n];
        Build();
    }

    private void Build() {
        for (int i = 0; i < n; i++) {
            tree[n + i] = i;
        }
        for (int j = n - 1; j >= 1; j--) {
            int a = tree[j << 1];
            int b = tree[(j << 1) + 1];
            tree[j] = A[a] <= A[b] ? a : b;
        }
    }

    public int Query(int ql, int qh) {
        return Query(1, 0, n - 1, ql, qh);
    }

    private int Query(int node, int l, int h, int ql, int qh) {
        if (ql > h || qh < l) return INF;
        if (l >= ql && h <= qh) return tree[node];
        int a = Query(node << 1, l, (l + h) >> 1, ql, qh);
        int b = Query((node << 1) + 1, ((l + h) >> 1) + 1, h, ql, qh);
        if (a == INF) return b;
        if (b == INF) return a;
        return A[a] <= A[b] ? a : b;
    }
}

public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int n = heights.Length;
        MinIdx_Segtree st = new MinIdx_Segtree(n, heights);
        return GetMaxArea(heights, 0, n - 1, st);
    }

    private int GetMaxArea(int[] heights, int l, int r, MinIdx_Segtree st) {
        if (l > r) return 0;
        if (l == r) return heights[l];

        int minIdx = st.Query(l, r);
        return Math.Max(
            Math.Max(GetMaxArea(heights, l, minIdx - 1, st), 
                    GetMaxArea(heights, minIdx + 1, r, st)),
                    (r - l + 1) * heights[minIdx]);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log n)$
* Space complexity: $O(n)$

---

### 3. Stack






```csharp
public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int n = heights.Length;
        int[] leftMost = new int[n];
        int[] rightMost = new int[n];
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < n; i++) {
            leftMost[i] = -1;
            while (stack.Count > 0 && heights[stack.Peek()] >= heights[i]) {
                stack.Pop();
            }
            if (stack.Count > 0) {
                leftMost[i] = stack.Peek();
            }
            stack.Push(i);
        }

        stack.Clear();
        for (int i = n - 1; i >= 0; i--) {
            rightMost[i] = n;
            while (stack.Count > 0 && heights[stack.Peek()] >= heights[i]) {
                stack.Pop();
            }
            if (stack.Count > 0) {
                rightMost[i] = stack.Peek();
            }
            stack.Push(i);
        }

        int maxArea = 0;
        for (int i = 0; i < n; i++) {
            leftMost[i] += 1;
            rightMost[i] -= 1;
            maxArea = Math.Max(maxArea, heights[i] * (rightMost[i] - leftMost[i] + 1));
        }

        return maxArea;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 4. Stack (Optimal)






```csharp
public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int maxArea = 0;
        Stack<int[]> stack = new Stack<int[]>(); // pair: (index, height)

        for (int i = 0; i < heights.Length; i++) {
            int start = i;
            while (stack.Count > 0 && stack.Peek()[1] > heights[i]) {
                int[] top = stack.Pop();
                int index = top[0];
                int height = top[1];
                maxArea = Math.Max(maxArea, height * (i - index));
                start = index;
            }
            stack.Push(new int[] { start, heights[i] });
        }

        foreach (int[] pair in stack) {
            int index = pair[0];
            int height = pair[1];
            maxArea = Math.Max(maxArea, height * (heights.Length - index));
        }
        return maxArea;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 5. Stack (One Pass)






```csharp
public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int n = heights.Length;
        int maxArea = 0;
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i <= n; i++) {
            while (stack.Count > 0 &&
                 (i == n || heights[stack.Peek()] >= heights[i])) {
                int height = heights[stack.Pop()];
                int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, height * width);
            }
            stack.Push(i);
        }
        return maxArea;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
