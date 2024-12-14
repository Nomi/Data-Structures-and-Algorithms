# Last Stone Weight

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
You are given an array of integers `stones` where `stones[i]` represents the weight of the `ith` stone.

We want to run a simulation on the stones as follows:

* At each step we choose the **two heaviest stones**, with weight `x` and `y` and smash them togethers
* If `x == y`, both stones are destroyed
* If `x < y`, the stone of weight `x` is destroyed, and the stone of weight `y` has new weight `y - x`.

Continue the simulation until there is no more than one stone remaining.

Return the weight of the last remaining stone or return `0` if none remain.

**Example 1:**

```java
Input: stones = [2,3,6,2,4]

Output: 1
```
Explanation: 
We smash 6 and 4 and are left with a 2, so the array becomes [2,3,2,2].
We smash 3 and 2 and are left with a 1, so the array becomes [1,2,2].
We smash 2 and 2, so the array becomes [1].

**Example 2:**

```java
Input: stones = [1,2]

Output: 1
```

**Constraints:**
* `1 <= stones.length <= 20`
* `1 <= stones[i] <= 100`

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
    A naive solution would involve simulating the process by sorting the array at each step and processing the top <code>2</code> heaviest stones, resulting in an <code>O(n * nlogn)</code> time complexity. Can you think of a better way? Consider using a data structure that efficiently supports insertion and removal of elements and maintain the sorted order. 
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use a Max-Heap, which allows us to retrieve the maximum element in <code>O(1)</code> time. We initially insert all the weights into the Max-Heap, which takes <code>O(logn)</code> time per insertion. We then simulate the process until only one or no element remains in the Max-Heap. At each step, we pop two elements from the Max-Heap which takes <code>O(logn)</code> time. If they are equal, we do not insert anything back into the heap and continue. Otherwise, we insert the difference of the two elements back into the heap.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/B-QCq79-Vfw/0.jpg)](https://www.youtube.com/watch?v=B-QCq79-Vfw)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=B-QCq79-Vfw)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/last-stone-weight)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Sorting






```csharp
public class Solution {
    public int LastStoneWeight(int[] stones) {
        List<int> stoneList = new List<int>(stones);
        while (stoneList.Count > 1) {
            stoneList.Sort();
            int cur = stoneList[stoneList.Count - 1] - stoneList[stoneList.Count - 2];
            stoneList.RemoveAt(stoneList.Count - 1); 
            stoneList.RemoveAt(stoneList.Count - 1); 
            if (cur != 0) {
                stoneList.Add(cur); 
            }
        }

        return stoneList.Count == 0 ? 0 : stoneList[0];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2 \log n)$
* Space complexity: $O(1)$ or $O(n)$ depending on the sorting algorithm.

---

### 2. Binary Search






```csharp
public class Solution {
    public int LastStoneWeight(int[] stones) {
        Array.Sort(stones);
        int n = stones.Length;

        while (n > 1) {
            int cur = stones[n - 1] - stones[n - 2];
            n -= 2;
            if (cur > 0) {
                int l = 0, r = n;
                while (l < r) {
                    int mid = (l + r) / 2;
                    if (stones[mid] < cur) {
                        l = mid + 1;
                    } else {
                        r = mid;
                    }
                }
                int pos = l;
                Array.Resize(ref stones, n + 1);
                for (int i = n; i > pos; i--) {
                    stones[i] = stones[i - 1];
                }
                stones[pos] = cur;
                n++;
            }
        }
        return n > 0 ? stones[0] : 0;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(1)$ or $O(n)$ depending on the sorting algorithm.

---

### 3. Heap






```csharp
public class Solution {
    public int LastStoneWeight(int[] stones) {
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        foreach (int s in stones) {
            minHeap.Enqueue(-s, -s);
        }

        while (minHeap.Count > 1) {
            int first = minHeap.Dequeue();
            int second = minHeap.Dequeue();
            if (second > first) {
                minHeap.Enqueue(first - second, first - second);
            }
        }

        minHeap.Enqueue(0, 0);
        return Math.Abs(minHeap.Peek());
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log n)$
* Space complexity: $O(n)$

---

### 4. Bucket Sort






```csharp
public class Solution {
    public int LastStoneWeight(int[] stones) {
        int maxStone = 0;
        foreach (int stone in stones) {
            maxStone = Math.Max(maxStone, stone);
        }

        int[] bucket = new int[maxStone + 1];
        foreach (int stone in stones) {
            bucket[stone]++;
        }

        int first = maxStone, second = maxStone;
        while (first > 0) {
            if (bucket[first] % 2 == 0) {
                first--;
                continue;
            }

            int j = Math.Min(first - 1, second);
            while (j > 0 && bucket[j] == 0) {
                j--;
            }

            if (j == 0) {
                return first;
            }

            second = j;
            bucket[first]--;
            bucket[second]--;
            bucket[first - second]++;
            first = Math.Max(first - second, second);
        }

        return first;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n + w)$
* Space complexity: $O(w)$

> Where $n$ is the length of the $stones$ array and $w$ is the maximum value in the $stones$ array.
