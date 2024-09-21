# Binary Search

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
- [Search Array](https://neetcode.io/courses/dsa-for-beginners/14) [from NeetCode's Course(s)]


## Problem Description
You are given an array of **distinct** integers `nums`, sorted in ascending order, and an integer `target`.
    
Implement a function to search for `target` within `nums`. If it exists, then return its index, otherwise, return `-1`.

Your solution must run in $O(log n)$ time.

**Example 1:**

```java
Input: nums = [-1,0,2,4,6,8], target = 4

Output: 3
```

**Example 2:**

```java
Input: nums = [-1,0,2,4,6,8], target = 3

Output: -1
```

**Constraints:**
* `1 <= nums.length <= 10000`.
* `-10000 < nums[i], target < 10000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(logn)</code> time and <code>O(1)</code> space, where <code>n</code> is the size of the input array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    Can you find an algorithm that is useful when the array is sorted? Maybe other than linear seacrh.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    The problem name is the name of the algorithm that we can use. We need to find a target value and if it does not exist in the array return <code>-1</code>. We have <code>l</code> and <code>r</code> as the boundaries of the segment of the array in which we are searching. Try building conditions to eliminate half of the search segment at each step. Maybe sorted nature of the array can be helpful.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We compare the target value with the <code>mid</code> of the segment. For example, consider the array <code>[1, 2, 3, 4, 5]</code> and <code>target = 4</code>. The <code>mid</code> value is <code>3</code>, thus, on the next iteration we search to the right of <code>mid</code>. The remaining segment is <code>[4,5]</code>. Why?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    Because the array is sorted, all elements to the left of <code>mid</code> (including <code>3</code>) are guaranteed to be smaller than the target. Therefore, we can safely eliminate that half of the array from consideration, narrowing the search to the right half and repeat this search until we find the target.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/s4DPM8ct1pI/0.jpg)](https://www.youtube.com/watch?v=s4DPM8ct1pI)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=s4DPM8ct1pI)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/binary-search)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Recursive Binary Search






```csharp
public class Solution {
    public int BinarySearch(int l, int r, int[] nums, int target) {
        if (l > r) return -1;
        int m = l + (r - l) / 2;
        
        if (nums[m] == target) return m;
        return (nums[m] < target) ? 
            BinarySearch(m + 1, r, nums, target) : 
            BinarySearch(l, m - 1, nums, target);
    }

    public int Search(int[] nums, int target) {
        return BinarySearch(0, nums.Length - 1, nums, target);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(\log n)$
* Space complexity: $O(\log n)$

---

### 2. Iterative Binary Search






```csharp
public class Solution {
    public int Search(int[] nums, int target) {
        int l = 0, r = nums.Length - 1;

        while (l <= r) {
            int m = l + ((r - l) / 2);
            if (nums[m] > target) {
                r = m - 1;
            } else if (nums[m] < target) {
                l = m + 1;
            } else {
                return m;
            }
        }
        return -1;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(\log n)$
* Space complexity: $O(1)$

---

### 3. Upper Bound






```csharp
public class Solution {
    public int Search(int[] nums, int target) {
        int l = 0, r = nums.Length;

        while (l < r) {
            int m = l + (r - l) / 2;
            if (nums[m] > target) {
                r = m;
            } else {
                l = m + 1;
            }
        }
        return (l > 0 && nums[l - 1] == target) ? l - 1 : -1;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(\log n)$
* Space complexity: $O(1)$

---

### 4. Lower Bound






```csharp
public class Solution {
    public int Search(int[] nums, int target) {
        int l = 0, r = nums.Length;

        while (l < r) {
            int m = l + (r - l) / 2;
            if (nums[m] >= target) {
                r = m;
            } else {
                l = m + 1;
            }
        }
        return (l < nums.Length && nums[l] == target) ? l : -1;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(\log n)$
* Space complexity: $O(1)$

---

### 5. Built-In Tool






```csharp
public class Solution {
    public int Search(int[] nums, int target) {
        int index = Array.BinarySearch(nums, target);
        return index >= 0 ? index : -1;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(\log n)$
* Space complexity: $O(1)$
