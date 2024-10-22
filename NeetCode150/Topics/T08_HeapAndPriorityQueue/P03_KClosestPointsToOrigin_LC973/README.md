# K Closest Points to Origin

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
- [Heap Properties](https://neetcode.io/courses/dsa-for-beginners/23) [from NeetCode's Course(s)]
- [Push and Pop](https://neetcode.io/courses/dsa-for-beginners/24) [from NeetCode's Course(s)]
- [Heapify](https://neetcode.io/courses/dsa-for-beginners/25) [from NeetCode's Course(s)]


## Problem Description
You are given an 2-D array `points` where `points[i] = [xi, yi]` represents the coordinates of a point on an X-Y axis plane. You are also given an integer `k`.
    
Return the `k` closest points to the origin `(0, 0)`. 

The distance between two points is defined as the Euclidean distance (`sqrt((x1 - x2)^2 + (y1 - y2)^2))`.

You may return the answer in **any order**.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/ffe90895-5c8e-47f1-6719-d5c0f656d700/public)

```java
Input: points = [[0,2],[2,2]], k = 1

Output: [[0,2]]
```

Explanation : The distance between `(0, 2)` and the origin `(0, 0)` is `2`. The distance between `(2, 2)` and the origin is `sqrt(2^2 + 2^2) = 2.82842`. So the closest point to the origin is `(0, 2)`.

**Example 2:**

```java
Input: points = [[0,2],[2,0],[2,2]], k = 2

Output: [[0,2],[2,0]]
```

Explanation: The output `[2,0],[0,2]` would also be accepted.

**Constraints:**
* `1 <= k <= points.length <= 1000`
* `-100 <= points[i][0], points[i][1] <= 100`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution as good or better than <code>O(nlogk)</code> time and <code>O(k)</code> space, where <code>n</code> is the size of the input array, and <code>k</code> is the number of points to be returned.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A naive solution would be to sort the array in ascending order based on the distances of the points from the origin <code>(0, 0)</code> and return the first <code>k</code> points. This would take <code>O(nlogn)</code> time. Can you think of a better way? Perhaps you could use a data structure that maintains only <code>k</code> points and allows efficient insertion and removal. 
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use a Max-Heap that keeps the maximum element at its top and allows retrieval in <code>O(1)</code> time. This data structure is ideal because we need to return the <code>k</code> closest points to the origin. By maintaining only <code>k</code> points in the heap, we can efficiently remove the farthest point when the size exceeds <code>k</code>. How would you implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We initialize a Max-Heap that orders points based on their distances from the origin. Starting with an empty heap, we iterate through the array of points, inserting each point into the heap. If the size of the heap exceeds <code>k</code>, we remove the farthest point (the maximum element in the heap). After completing the iteration, the heap will contain the <code>k</code> closest points to the origin. Finally, we convert the heap into an array and return it. 
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/rI2EBUEMfTk/0.jpg)](https://www.youtube.com/watch?v=rI2EBUEMfTk)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=rI2EBUEMfTk)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/k-closest-points-to-origin)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Sorting






```csharp
public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        Array.Sort(points, (a, b) => 
        (a[0] * a[0] + a[1] * a[1]).CompareTo(b[0] * b[0] + b[1] * b[1]));
        return points[..k];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log n)$
* Space complexity: $O(1)$ or $O(n)$ depending on the sorting algorithm.

---

### 2. Min Heap






```csharp
public class Solution {
    public int[][] KClosest(int[][] points, int K) {
        PriorityQueue<int[], int> minHeap = new PriorityQueue<int[], int>();
        foreach (int[] point in points) {
            int dist = point[0] * point[0] + point[1] * point[1];
            minHeap.Enqueue(new int[] { dist, point[0], point[1] }, dist);
        }

        int[][] result = new int[K][];
        for (int i = 0; i < K; ++i) {
            int[] point = minHeap.Dequeue();
            result[i] = new int[] { point[1], point[2] };
        }
        return result;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(k * \log n)$
* Space complexity: $O(n)$

> Where $n$ is the length of the array $points$.

---

### 3. Max Heap






```csharp
public class Solution {
    public int[][] KClosest(int[][] points, int K) {
        PriorityQueue<int[], int> maxHeap = new();
        
        foreach (var point in points) {
            int dist = point[0] * point[0] + point[1] * point[1];
            maxHeap.Enqueue(point, -dist);
            if (maxHeap.Count > K) {
                maxHeap.Dequeue();
            }
        }

        var res = new List<int[]>();
        while (maxHeap.Count > 0) {
            res.Add(maxHeap.Dequeue());
        }
        
        return res.ToArray();
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * \log k)$
* Space complexity: $O(k)$

> Where $n$ is the length of the array $points$.

---

### 4. Quick Select






```csharp
class Solution {
    public int[][] KClosest(int[][] points, int k) {
        int L = 0, R = points.Length - 1;
        int pivot = points.Length;

        while (pivot != k) {
            pivot = Partition(points, L, R);
            if (pivot < k) {
                L = pivot + 1;
            } else {
                R = pivot - 1;
            }
        }
        int[][] res = new int[k][];
        Array.Copy(points, res, k);
        return res;
    }

    private int Partition(int[][] points, int l, int r) {
        int pivotIdx = r;
        int pivotDist = Euclidean(points[pivotIdx]);
        int i = l;
        for (int j = l; j < r; j++) {
            if (Euclidean(points[j]) <= pivotDist) {
                Swap(points, i, j);
                i++;
            }
        }
        Swap(points, i, r);
        return i;
    }

    private int Euclidean(int[] point) {
        return point[0] * point[0] + point[1] * point[1];
    }

    private void Swap(int[][] points, int i, int j) {
        int[] temp = points[i];
        points[i] = points[j];
        points[j] = temp;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$ in average case, $O(n ^ 2)$ in worst case.
* Space complexity: $O(1)$
