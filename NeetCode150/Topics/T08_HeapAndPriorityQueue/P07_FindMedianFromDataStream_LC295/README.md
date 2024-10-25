# ⭐ | Find Median From Data Stream

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
- [Heap Properties](https://neetcode.io/courses/dsa-for-beginners/23) [from NeetCode's Course(s)]
- [Push and Pop](https://neetcode.io/courses/dsa-for-beginners/24) [from NeetCode's Course(s)]
- [Two Heaps](https://neetcode.io/courses/advanced-algorithms/10) [from NeetCode's Course(s)]


## Problem Description
The **[median](https://en.wikipedia.org/wiki/Median)** is the middle value in a sorted list of integers. For lists of *even* length, there is no middle value, so the median is the [mean](https://en.wikipedia.org/wiki/Mean) of the two middle values.

For example:
* For `arr = [1,2,3]`, the median is `2`.
* For `arr = [1,2]`, the median is `(1 + 2) / 2 = 1.5`

Implement the MedianFinder class:

* `MedianFinder()` initializes the `MedianFinder` object.
* `void addNum(int num)` adds the integer `num` from the data stream to the data structure.
* `double findMedian()` returns the median of all elements so far.

**Example 1:**

```java
Input:
["MedianFinder", "addNum", "1", "findMedian", "addNum", "3" "findMedian", "addNum", "2", "findMedian"]

Output:
[null, null, 1.0, null, 2.0, null, 2.0]

Explanation:
MedianFinder medianFinder = new MedianFinder();
medianFinder.addNum(1);    // arr = [1]
medianFinder.findMedian(); // return 1.0
medianFinder.addNum(3);    // arr = [1, 3]
medianFinder.findMedian(); // return 2.0
medianFinder.addNum(2);    // arr[1, 2, 3]
medianFinder.findMedian(); // return 2.0
```

**Constraints:**
* `-100,000 <= num <= 100,000`
* `findMedian` will only be called after adding at least one integer to the data structure.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(logn)</code> time for <code>addNum()</code>, <code>O(1)</code> time for <code>findMedian()</code>, and <code>O(n)</code> space, where <code>n</code> is the current number of elements.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A naive solution would be to store the data stream in an array and sort it each time to find the median, resulting in <code>O(nlogn)</code> time for each <code>findMedian()</code> call. Can you think of a better way? Perhaps using a data structure that allows efficient insertion and retrieval of the median can make the solution more efficient.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    If we divide the array into two parts, we can find the median in <code>O(1)</code> if the left half can efficiently return the maximum and the right half can efficiently return the minimum. These values determine the median. However, the process changes slightly if the total number of elements is odd — in that case, the median is the element from the half with the larger size. Can you think of a data structure which is suitable to implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We can use a Heap (Max-Heap for the left half and Min-Heap for the right half). Instead of dividing the array, we store the elements in these heaps as they arrive in the data stream. But how can you maintain equal halves of elements in these two heaps? How do you implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We initialize a Max-Heap and a Min-Heap. When adding an element, if the element is greater than the minimum element of the Min-Heap, we push it into the Min-Heap; otherwise, we push it into the Max-Heap. If the size difference between the two heaps becomes greater than one, we rebalance them by popping an element from the larger heap and pushing it into the smaller heap. This process ensures that the elements are evenly distributed between the two heaps, allowing us to retrieve the middle element or elements in <code>O(1)</code> time.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/itmhHWaHupI/0.jpg)](https://www.youtube.com/watch?v=itmhHWaHupI)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=itmhHWaHupI)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/find-median-in-a-data-stream)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Sorting






```csharp
class MedianFinder {
    private List<int> data;

    public MedianFinder() {
        data = new List<int>();
    }

    public void AddNum(int num) {
        data.Add(num);
    }

    public double FindMedian() {
        data.Sort();
        int n = data.Count;
        if ((n & 1) == 1) {
            return data[n / 2];
        } else {
            return (data[n / 2] + data[n / 2 - 1]) / 2.0;
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m)$ for $addNum()$, $O(m * n \log n)$ for $findMedian()$.
* Space complexity: $O(n)$

> Where $m$ is the number of function calls and $n$ is the length of the array.

---

### 2. Heap






```csharp
public class MedianFinder {

    private PriorityQueue<int, int> small; // Max heap for the smaller half
    private PriorityQueue<int, int> large; // Min heap for the larger half

    public MedianFinder() {
        small = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        large = new PriorityQueue<int, int>();
    }
    
    public void AddNum(int num) {
        if (large.Count != 0 && num > large.Peek()) {
            large.Enqueue(num, num);
        } else {
            small.Enqueue(num, num);
        }

        if (small.Count > large.Count + 1) {
            int val = small.Dequeue();
            large.Enqueue(val, val);
        } else if (large.Count > small.Count + 1) {
            int val = large.Dequeue();
            small.Enqueue(val, val);
        }
    }
    
    public double FindMedian() {
        if (small.Count > large.Count) {
            return small.Peek();
        } else if (large.Count > small.Count) {
            return large.Peek();
        }
        
        int smallTop = small.Peek();
        return (smallTop + large.Peek()) / 2.0;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * \log n)$ for $addNum()$, $O(m)$ for $findMedian()$.
* Space complexity: $O(n)$

> Where $m$ is the number of function calls and $n$ is the length of the array.
