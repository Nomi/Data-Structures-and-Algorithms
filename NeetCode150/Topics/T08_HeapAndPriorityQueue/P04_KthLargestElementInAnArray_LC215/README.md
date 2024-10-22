# Kth Largest Element In An Array

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



## Problem Description
Given an unsorted array of integers `nums` and an integer `k`, return the `kth` largest element in the array.

By `kth` largest element, we mean the `kth` largest element in the sorted order, not the `kth` distinct element.

Follow-up: Can you solve it without sorting?

**Example 1:**

```java
Input: nums = [2,3,1,5,4], k = 2

Output: 4
```

**Example 2:**

```java
Input: nums = [2,3,1,1,5,5,4], k = 3

Output: 4
```

**Constraints:**
* `1 <= k <= nums.length <= 10000`
* `-1000 <= nums[i] <= 1000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution as good or better than <code>O(nlogk)</code> time and <code>O(k)</code> space, where <code>n</code> is the size of the input array, and <code>k</code> represents the rank of the largest number to be returned (i.e., the <code>k-th</code> largest element).
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A naive solution would be to sort the array in descending order and return the <code>k-th</code> largest element. This would be an <code>O(nlogn)</code> solution. Can you think of a better way? Maybe you should think of a data structure which can maintain only the top <code>k</code> largest elements.
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
    We initialize an empty Min-Heap. We iterate through the array and add elements to the heap. When the size of the heap exceeds <code>k</code>, we pop from the heap and continue. After the iteration, the top element of the heap is the <code>k-th</code> largest element. 
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/XEmy13g1Qxc/0.jpg)](https://www.youtube.com/watch?v=XEmy13g1Qxc)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=XEmy13g1Qxc)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/kth-largest-element-in-an-array)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Sorting






```csharp
public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        Array.Sort(nums);
        return nums[nums.Length - k];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log n)$
* Space complexity: $O(1)$ or $O(n)$ depending on the sorting algorithm.

---

### 2. Min-Heap






```csharp
public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        foreach (int num in nums) {
            minHeap.Enqueue(num, num);
            if (minHeap.Count > k) {
                minHeap.Dequeue();
            }
        }
        return minHeap.Peek();
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log k)$
* Space complexity: $O(k)$

> Where $n$ is the length of the array $nums$.

---

### 3. Quick Select






```csharp
public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        k = nums.Length - k;
        return QuickSelect(nums, 0, nums.Length - 1, k);
    }

    private int QuickSelect(int[] nums, int left, int right, int k) {
        int pivot = nums[right];
        int p = left;

        for (int i = left; i < right; i++) {
            if (nums[i] <= pivot) {
                int temp = nums[p];
                nums[p] = nums[i];
                nums[i] = temp;
                p++;
            }
        }

        int tmp = nums[p];
        nums[p] = nums[right];
        nums[right] = tmp;

        if (p > k) {
            return QuickSelect(nums, left, p - 1, k);
        } else if (p < k) {
            return QuickSelect(nums, p + 1, right, k);
        } else {
            return nums[p];
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$ in average case, $O(n ^ 2)$ in worst case.
* Space complexity: $O(n)$

---

### 4. Quick Select (Optimal)






```csharp
public class Solution {
    private int Partition(int[] nums, int left, int right) {
        int mid = (left + right) >> 1;
        (nums[mid], nums[left + 1]) = (nums[left + 1], nums[mid]);
        
        if (nums[left] < nums[right])
            (nums[left], nums[right]) = (nums[right], nums[left]);
        if (nums[left + 1] < nums[right])
            (nums[left + 1], nums[right]) = (nums[right], nums[left + 1]);
        if (nums[left] < nums[left + 1])
            (nums[left], nums[left + 1]) = (nums[left + 1], nums[left]);
        
        int pivot = nums[left + 1];
        int i = left + 1;
        int j = right;
        
        while (true) {
            while (nums[++i] > pivot);
            while (nums[--j] < pivot);
            if (i > j) break;
            (nums[i], nums[j]) = (nums[j], nums[i]);
        }
        
        nums[left + 1] = nums[j];
        nums[j] = pivot;
        return j;
    }
    
    private int QuickSelect(int[] nums, int k) {
        int left = 0;
        int right = nums.Length - 1;
        
        while (true) {
            if (right <= left + 1) {
                if (right == left + 1 && nums[right] > nums[left])
                    (nums[left], nums[right]) = (nums[right], nums[left]);
                return nums[k];
            }
            
            int j = Partition(nums, left, right);
            
            if (j >= k) right = j - 1;
            if (j <= k) left = j + 1;
        }
    }
    
    public int FindKthLargest(int[] nums, int k) {
        return QuickSelect(nums, k - 1);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$ in average case, $O(n ^ 2)$ in worst case.
* Space complexity: $O(1)$
