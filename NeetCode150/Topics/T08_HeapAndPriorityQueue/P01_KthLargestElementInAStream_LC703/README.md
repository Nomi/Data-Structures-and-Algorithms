# Kth Largest Element In a Stream

|   | Difficulty | Tricky |
|---|------------|--------|
| <big>☆<big> | <big>**🟩 Easy**</big> | <big></big> |


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
Design a class to find the `kth` largest integer in a stream of values, including duplicates. E.g. the `2nd` largest from [1, 2, 3, 3] is `3`. The stream is not necessarily sorted.

Implement the following methods:
* `constructor(int k, int[] nums)` Initializes the object given an integer `k` and the stream of integers `nums`.
* `int add(int val)` Adds the integer `val` to the stream and returns the `kth` largest integer in the stream.

**Example 1:**

```java
Input:
["KthLargest", [3, [1, 2, 3, 3]], "add", [3], "add", [5], "add", [6], "add", [7], "add", [8]]

Output:
[null, 3, 3, 3, 5, 6]

Explanation:
KthLargest kthLargest = new KthLargest(3, [1, 2, 3, 3]);
kthLargest.add(3);   // return 3
kthLargest.add(5);   // return 3
kthLargest.add(6);   // return 3
kthLargest.add(7);   // return 5
kthLargest.add(8);   // return 6
```

**Constraints:**
* `1 <= k <= 1000`
* `0 <= nums.length <= 1000`
* `-1000 <= nums[i] <= 1000`
* `-1000 <= val <= 1000`
* There will always be at least `k` integers in the stream when you search for the `kth` integer.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(mlogk)</code> time and <code>O(k)</code> space, where <code>m</code> is the number of times <code>add()</code> is called, and <code>k</code> represents the rank of the largest number to be tracked (i.e., the <code>k-th</code> largest element).
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would involve sorting the array in every time a number is added using <code>add()</code>, and then returning the <code>k-th</code> largest element. This would take <code>O(m * nlogn)</code> time, where <code>m</code> is the number of calls to <code>add()</code> and <code>n</code> is the total number of elements added. However, do we really need to track all the elements added, given that we only need the <code>k-th</code> largest element? Maybe you should think of a data structure which can maintain only the top <code>k</code> largest elements.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use a Min-Heap, which stores elements and keeps the smallest element at its top. When we add an element to the Min-Heap, it takes <code>O(logk)</code> time since we are storing <code>k</code> elements in it. Retrieving the top element (the smallest in the heap) takes <code>O(1)</code> time. How can this be useful for finding the <code>k-th</code> largest element?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    The <code>k-th</code> largest element is the smallest element among the top <code>k</code> largest elements. This means we only need to maintain <code>k</code> elements in our Min-Heap to efficiently determine the <code>k-th</code> largest element. Whenever the size of the Min-Heap exceeds <code>k</code>, we remove the smallest element by popping from the heap. How do you implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We initialize a Min-Heap with the elements of the input array. When the <code>add()</code> function is called, we insert the new element into the heap. If the heap size exceeds <code>k</code>, we remove the smallest element (the root of the heap). Finally, the top element of the heap represents the <code>k-th</code> largest element and is returned.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/hOjcdrqMoQ8/0.jpg)](https://www.youtube.com/watch?v=hOjcdrqMoQ8)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=hOjcdrqMoQ8)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/kth-largest-integer-in-a-stream)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Sorting






```csharp
public class KthLargest {
    private List<int> arr;
    private int K;

    public KthLargest(int k, int[] nums) {
        arr = new List<int>(nums);
        K = k;
    }

    public int Add(int val) {
        arr.Add(val);
        arr.Sort();
        return arr[arr.Count - K];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n\log n)$
* Space complexity: $O(1)$ or $O(n)$ depending on the sorting algorithm.

> Where $m$ is the number of calls made to $add()$ and $n$ is the current size of the array.

---

### 2. Min-Heap






```csharp
public class KthLargest {
    
    private PriorityQueue<int, int> minHeap;
    private int k;

    public KthLargest(int k, int[] nums) {
        this.k = k;
        this.minHeap = new PriorityQueue<int, int>();
        foreach (int num in nums) {
            minHeap.Enqueue(num, num);
            if (minHeap.Count > k) {
                minHeap.Dequeue();
            }
        }
    }

    public int Add(int val) {
        minHeap.Enqueue(val, val);
        if (minHeap.Count > k) {
            minHeap.Dequeue();
        }
        return minHeap.Peek();
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * \log k)$
* Space complexity: $O(k)$

> Where $m$ is the number of calls made to $add()$.
