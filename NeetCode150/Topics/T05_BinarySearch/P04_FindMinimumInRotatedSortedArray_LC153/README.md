# ⭐ | Find Minimum In Rotated Sorted Array

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
- [Search Array](https://neetcode.io/courses/dsa-for-beginners/14) [from NeetCode's Course(s)]


## Problem Description
You are given an array of length `n` which was originally sorted in ascending order. It has now been **rotated** between `1` and `n` times. For example, the array `nums = [1,2,3,4,5,6]` might become:

* `[3,4,5,6,1,2]` if it was rotated `4` times.
* `[1,2,3,4,5,6]` if it was rotated `6` times.

Notice that rotating the array `4` times moves the last four elements of the array to the beginning. Rotating the array `6` times produces the original array.

Assuming all elements in the rotated sorted array `nums` are **unique**, return the minimum element of this array.

A solution that runs in `O(n)` time is trivial, can you write an algorithm that runs in `O(log n) time`?

**Example 1:**

```java
Input: nums = [3,4,5,6,1,2]

Output: 1
```

**Example 2:**

```java
Input: nums = [4,5,0,1,2,3]

Output: 0
```

**Example 3:**

```java
Input: nums = [4,5,6,7]

Output: 4
```

**Constraints:**
* `1 <= nums.length <= 1000`
* `-1000 <= nums[i] <= 1000`

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
    A brute force solution would be to do a linear search on the array to find the minimum element. This would be an <code>O(n)</code> solution. Can you think of a better way? Maybe an efficient searching algorithm is helpful.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    Given that the array is rotated after sorting, elements from the right end are moved to the left end one by one. This creates two parts of a sorted array, separated by a deflection point caused by the rotation. For example, consider the array <code>[3, 4, 1, 2]</code>. Here, the array is rotated twice, resulting in two sorted segments: <code>[3, 4]</code> and <code>[1, 2]</code>. And the minimum element will be the first element of the right segment. Can you do a binary search to find this cut?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We perform a binary search on the array with pointers <code>l</code> and <code>r</code>, which belong to two different sorted segments. For example, in <code>[3, 4, 5, 6, 1, 2, 3]</code>, <code>l = 0</code>, <code>r = 6</code>, and <code>mid = 3</code>. At least two of <code>l</code>, <code>mid</code>, and <code>r</code> will always be in the same sorted segment. Can you find conditions to eliminate one half and continue the binary search? Perhaps analyzing all possible conditions for <code>l</code>, <code>mid</code>, and <code>r</code> would help. 
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    There will be two conditions where <code>l</code> and <code>mid</code> will be in left sorted segment or <code>mid</code> and <code>r</code> will be in right sorted segement.
    If <code>l</code> and <code>mid</code> in sorted segement, then <code>nums[l] < nums[mid]</code> and the minimum element will be in the right part. If <code>mid</code> and <code>r</code> in sorted segment, then <code>nums[m] < nums[r]</code> and the minimum element will be in the left part. After the binary search we end up finding the minimum element.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/nIVW4P8b1VA/0.jpg)](https://www.youtube.com/watch?v=nIVW4P8b1VA)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=nIVW4P8b1VA)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/find-minimum-in-rotated-sorted-array)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public int FindMin(int[] nums) {
        return nums.Min();
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$

---

### 2. Binary Search






```csharp
public class Solution {
    public int FindMin(int[] nums) {
        int l = 0, r = nums.Length - 1;
        int res = nums[0];

        while (l <= r) {
            if (nums[l] < nums[r]) {
                res = Math.Min(res, nums[l]);
                break;
            }

            int m = l + (r - l) / 2;
            res = Math.Min(res, nums[m]);
            if (nums[m] >= nums[l]) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(\log n)$
* Space complexity: $O(1)$

---

### 3. Binary Search (Lower Bound)






```csharp
public class Solution {
    public int FindMin(int[] nums) {
        int l = 0;
        int r = nums.Length - 1;
        while (l < r) {
            int m = l + (r - l) / 2;
            if (nums[m] < nums[r]) {
                r = m;
            } else {
                l = m + 1;
            }
        }
        return nums[l];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(\log n)$
* Space complexity: $O(1)$
