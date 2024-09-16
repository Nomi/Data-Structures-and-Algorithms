# ⭐ | Sliding Window Maximum

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
- [Queues](https://neetcode.io/courses/dsa-for-beginners/7) [from NeetCode's Course(s)]
- [Sliding Window Fixed Size](https://neetcode.io/courses/advanced-algorithms/1) [from NeetCode's Course(s)]
- [Sliding Window Variable Size](https://neetcode.io/courses/advanced-algorithms/2) [from NeetCode's Course(s)]


## Problem Description
You are given an array of integers `nums` and an integer `k`. There is a sliding window of size `k` that starts at the left edge of the array. The window slides one position to the right until it reaches the right edge of the array.

Return a list that contains the maximum element in the window at each step.

**Example 1:**

```java
Input: nums = [1,2,1,0,4,2,6], k = 3

Output: [2,2,4,4,6]

Explanation: 
Window position            Max
---------------           -----
[1  2  1] 0  4  2  6        2
 1 [2  1  0] 4  2  6        2
 1  2 [1  0  4] 2  6        4
 1  2  1 [0  4  2] 6        4
 1  2  1  0 [4  2  6]       6
```

**Constraints:**
* `1 <= nums.length <= 1000`
* `-1000 <= nums[i] <= 1000`
* `1 <= k <= nums.length`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution as good or better than <code>O(nlogn)</code> time and <code>O(n)</code> space, where <code>n</code> is the size of the input array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would involve iterating through each window of size <code>k</code> and finding the maximum element within the window by iterating through it. This would be an <code>O(n * k)</code> solution. Can you think of a better way? Maybe think of a data structure that tells the current maximum element of the window in <code>O(1)</code> time.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    A heap is the best data structure to use when dealing with maximum or minimum values and it takes <code>O(1)</code> time to get the max or min value. Here, we use a max-heap. But what should we do if the current maximum element is no longer part of the window? Can you think of a different way of adding values to the max-heap?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We process each window by adding elements to the heap along with their indices to track whether the maximum value is still within the current window. As we move from one window to the next, an element may go out of the window but still remain in the max-heap. Is there a way to handle this situation efficiently?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We can ignore those elements that are no longer part of the current window, except when the maximum value is outside the window. In that case, we remove elements from the max-heap until the maximum value belongs to the current window. Why? Because those elements will be eventually removed when the maximum element goes out of the window. 
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/DfljaUwZsOk/0.jpg)](https://www.youtube.com/watch?v=DfljaUwZsOk)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=DfljaUwZsOk)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/sliding-window-maximum)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        int n = nums.Length;
        int[] output = new int[n - k + 1];

        for (int i = 0; i <= n - k; i++) {
            int maxi = nums[i];
            for (int j = i; j < i + k; j++) {
                maxi = Math.Max(maxi, nums[j]);
            }
            output[i] = maxi;
        }

        return output;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * k)$
* Space complexity: $O(1)$

> Where $n$ is the length of the array and $k$ is the size of the window.

---

### 2. Segment Tree






```csharp
public class SegmentTree {
    public int n;
    public int[] A;
    public int[] tree;
    public const int NEG_INF = int.MinValue;

    public SegmentTree(int N, int[] a) {
        this.n = N;
        while (System.Numerics.BitOperations.PopCount((uint)n) != 1) {
            n++;
        }
        A = new int[n];
        for (int i = 0; i < N; i++) {
            A[i] = a[i];
        }
        for (int i = N; i < n; i++) {
            A[i] = NEG_INF;
        }
        tree = new int[2 * n];
        Build();
    }

    public void Build() {
        for (int i = 0; i < n; i++) {
            tree[n + i] = A[i];
        }
        for (int i = n - 1; i > 0; --i) {
            tree[i] = Math.Max(tree[i << 1], tree[i << 1 | 1]);
        }
    }

    public void Update(int i, int val) {
        tree[n + i] = val;
        for (int j = (n + i) >> 1; j >= 1; j >>= 1) {
            tree[j] = Math.Max(tree[j << 1], tree[j << 1 | 1]);
        }
    }

    public int Query(int l, int r) {
        int res = NEG_INF;
        l += n;
        r += n + 1;
        while (l < r) {
            if ((l & 1) == 1) res = Math.Max(res, tree[l++]);
            if ((r & 1) == 1) res = Math.Max(res, tree[--r]);
            l >>= 1;
            r >>= 1;
        }
        return res;
    }
}

public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        int n = nums.Length;
        SegmentTree segTree = new SegmentTree(n, nums);
        int[] output = new int[n - k + 1];
        for (int i = 0; i <= n - k; i++) {
            output[i] = segTree.Query(i, i + k - 1);
        }
        return output;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log n)$
* Space complexity: $O(n)$

---

### 3. Heap






```csharp
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        PriorityQueue<(int val, int idx), int> pq = new PriorityQueue<(int val, int idx), int>
        (Comparer<int>.Create((a, b) => b.CompareTo(a)));
        
        int[] output = new int[nums.Length - k + 1];
        int idx = 0;

        for (int i = 0; i < nums.Length; i++) {
            pq.Enqueue((nums[i], i), nums[i]);

            if (i >= k - 1) {
                while (pq.Peek().idx <= i - k) {
                    pq.Dequeue();
                }
                output[idx++] = pq.Peek().val;
            }
        }

        return output;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log n)$
* Space complexity: $O(n)$

---

### 4. Dynamic Programming






```csharp
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        int n = nums.Length;
        int[] leftMax = new int[n];
        int[] rightMax = new int[n];

        leftMax[0] = nums[0];
        rightMax[n - 1] = nums[n - 1];

        for (int i = 1; i < n; i++) {
            if (i % k == 0) {
                leftMax[i] = nums[i];
            } else {
                leftMax[i] = Math.Max(leftMax[i - 1], nums[i]);
            }

            if ((n - 1 - i) % k == 0) {
                rightMax[n - 1 - i] = nums[n - 1 - i];
            } else {
                rightMax[n - 1 - i] = Math.Max(rightMax[n - i], nums[n - 1 - i]);
            }
        }

        int[] output = new int[n - k + 1];

        for (int i = 0; i < n - k + 1; i++) {
            output[i] = Math.Max(leftMax[i + k - 1], rightMax[i]);
        }

        return output;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 5. Deque






```csharp
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        int n = nums.Length;
        int[] output = new int[n - k + 1];
        var q = new LinkedList<int>();
        int l = 0, r = 0;

        while (r < n) {
            while (q.Count > 0 && nums[q.Last.Value] < nums[r]) {
                q.RemoveLast();
            }
            q.AddLast(r);

            if (l > q.First.Value) {
                q.RemoveFirst();
            }

            if ((r + 1) >= k) {
                output[l] = nums[q.First.Value];
                l++;
            }
            r++;
        }

        return output;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
