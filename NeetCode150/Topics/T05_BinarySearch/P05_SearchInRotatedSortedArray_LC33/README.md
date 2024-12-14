# ⭐ | Search In Rotated Sorted Array

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

Given the rotated sorted array `nums` and an integer `target`, return the index of `target` within `nums`, or `-1` if it is not present.

You may assume all elements in the sorted rotated array `nums` are **unique**,

A solution that runs in `O(n)` time is trivial, can you write an algorithm that runs in `O(log n) time`?

**Example 1:**

```java
Input: nums = [3,4,5,6,1,2], target = 1

Output: 4
```

**Example 2:**

```java
Input: nums = [3,5,6,0,1,2], target = 4

Output: -1
```

**Constraints:**
* `1 <= nums.length <= 1000`
* `-1000 <= nums[i] <= 1000`
* `-1000 <= target <= 1000`

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
    A brute force solution would be to do a linear search on the array to find the target element. This would be an <code>O(n)</code> solution. Can you think of a better way? Maybe an efficient searching algorithm is helpful.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    Given that the array is rotated after sorting, elements from the right end are moved to the left end one by one, creating two sorted segments separated by a deflection point due to the rotation. For example, consider the array <code>[3, 4, 1, 2]</code>, which is rotated twice, resulting in two sorted segments: <code>[3, 4]</code> and <code>[1, 2]</code>. In a fully sorted array, it's easy to find the target. So, if you can identify the deflection point (cut), you can perform a binary search on both segments to find the target element. Can you use binary search to find this cut?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We perform a binary search on the array with pointers <code>l</code> and <code>r</code>, which belong to two different sorted segments. For example, in <code>[3, 4, 5, 6, 1, 2, 3]</code>, <code>l = 0</code>, <code>r = 6</code>, and <code>mid = 3</code>. At least two of <code>l</code>, <code>mid</code>, and <code>r</code> will always be in the same sorted segment. Can you find conditions to eliminate one half and continue the binary search? Perhaps analyzing all possible conditions for <code>l</code>, <code>mid</code>, and <code>r</code> may help.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    There are two cases: <code>l</code> and <code>mid</code> belong to the left sorted segment, or <code>mid</code> and <code>r</code> belong to the right sorted segment.
    If <code>l</code> and <code>mid</code> are in the same segment, <code>nums[l] < nums[mid]</code>, so the pivot index must lie in the right part. If <code>mid</code> and <code>r</code> are in the same segment, <code>nums[mid] < nums[r]</code>, so the pivot index must lie in the left part. After the binary search, we eventually find the pivot index. Once the pivot is found, it's straightforward to select the segment where the target lies and perform a binary search on that segement to find its position. If we don't find the target, we return <code>-1</code>.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/U8XENwh8Oy8/0.jpg)](https://www.youtube.com/watch?v=U8XENwh8Oy8)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=U8XENwh8Oy8)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/find-target-in-rotated-sorted-array)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public int Search(int[] nums, int target) {
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == target) {
                return i;
            }
        }
        return -1;
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
    public int Search(int[] nums, int target) {
        int l = 0, r = nums.Length - 1;

        while (l < r) {
            int m = (l + r) / 2;
            if (nums[m] > nums[r]) {
                l = m + 1;
            } else {
                r = m;
            }
        }

        int pivot = l;

        int result = BinarySearch(nums, target, 0, pivot - 1);
        if (result != -1) {
            return result;
        }

        return BinarySearch(nums, target, pivot, nums.Length - 1);
    }

    public int BinarySearch(int[] nums, int target, int left, int right) {
        while (left <= right) {
            int mid = (left + right) / 2;
            if (nums[mid] == target) {
                return mid;
            } else if (nums[mid] < target) {
                left = mid + 1;
            } else {
                right = mid - 1;
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

### 3. Binary Search (Two Pass)






```csharp
public class Solution {
    public int Search(int[] nums, int target) {
        int l = 0, r = nums.Length - 1;

        while (l < r) {
            int m = (l + r) / 2;
            if (nums[m] > nums[r]) {
                l = m + 1;
            } else {
                r = m;
            }
        }

        int pivot = l;
        l = 0;
        r = nums.Length - 1;

        if (target >= nums[pivot] && target <= nums[r]) {
            l = pivot;
        } else {
            r = pivot - 1;
        }

        while (l <= r) {
            int m = (l + r) / 2;
            if (nums[m] == target) {
                return m;
            } else if (nums[m] < target) {
                l = m + 1;
            } else {
                r = m - 1;
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

### 4. Binary Search (One Pass)






```csharp
public class Solution {
    public int Search(int[] nums, int target) {
        int l = 0, r = nums.Length - 1;

        while (l <= r) {
            int mid = (l + r) / 2;
            if (target == nums[mid]) {
                return mid;
            }

            if (nums[l] <= nums[mid]) {
                if (target > nums[mid] || target < nums[l]) {
                    l = mid + 1;
                } else {
                    r = mid - 1;
                }
            } else {
                if (target < nums[mid] || target > nums[r]) {
                    r = mid - 1;
                } else {
                    l = mid + 1;
                }
            }
        }
        return -1;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(\log n)$
* Space complexity: $O(1)$
