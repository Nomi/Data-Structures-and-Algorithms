# ⭐ | Median of Two Sorted Arrays

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
- [Search Array](https://neetcode.io/courses/dsa-for-beginners/14) [from NeetCode's Course(s)]


## Problem Description
You are given two integer arrays `nums1` and `nums2` of size `m` and `n` respectively, where each is sorted in ascending order. Return the [median](https://en.wikipedia.org/wiki/Median) value among all elements of the two arrays.

Your solution must run in $O(log (m+n))$ time.

**Example 1:**

```java
Input: nums1 = [1,2], nums2 = [3]

Output: 2.0
```

Explanation: Among `[1, 2, 3]` the median is 2.

**Example 2:**

```java
Input: nums1 = [1,3], nums2 = [2,4]

Output: 2.5
```

Explanation: Among `[1, 2, 3, 4]` the median is (2 + 3) / 2 = 2.5.

**Constraints:**
* `nums1.length == m`
* `nums2.length == n`
* `0 <= m <= 1000`
* `0 <= n <= 1000`
* `-10^6 <= nums1[i], nums2[i] <= 10^6`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(log(min(n, m)))</code> time and <code>O(1)</code> space, where <code>n</code> is the size of <code>nums1</code> and <code>m</code> is the size of <code>nums2</code>.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would be to create a new array by merging elements from both arrays, then sorting it and returning the median. This would be an <code>O(n + m)</code> solution. Can you think of a better way? Maybe you can use the criteria of both the arrays being sorted in ascending order.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    Suppose we merged both arrays. Then, we would have <code>half = (m + n) / 2</code> elements to the left of the median. So, without merging, is there any way to use this information to find the median? You can leverage the fact that the arrays are sorted. Consider the smaller array between the two and use binary search to find the correct partition between the two arrays, which will allow you to directly find the median without fully merging the arrays. How will you implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We will always try to keep array <code>A</code> smaller and interchange it with array <code>B</code> if <code>len(A) > len(B)</code>. Now, we perform binary search on the number of elements we will choose from array <code>A</code>. It is straightforward that when we choose <code>x</code> elements from array <code>A</code>, we have to choose <code>half - x</code> elements from array <code>B</code>. But we should also ensure that this partition is valid. How can we do this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p> 
    When we do a partition for both arrays, we should ensure that the maximum elements from the left partitions of both arrays are smaller than or equal to the minimum elements of the right partitions of both the arrays. This will ensure that the partition is valid, and we can then find the median. We can find the min or max of these partitions in <code>O(1)</code> as these partitions are sorted in ascending order. Why does this work?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 5</summary>
    <p>
    For example, consider the arrays <code>A = [1, 2, 3, 4, 5]</code> and <code>B = [1, 2, 3, 4, 5, 6, 7, 8]</code>. When we select <code>x = 2</code>, we take <code>4</code> elements from array <code>B</code>. However, this partition is not valid because value <code>4</code> from the left partition of array <code>B</code> is greater than the value <code>3</code> from the right partition of array <code>A</code>. So, we should try to take more elements from array <code>A</code> to make the partition valid. Binary search will eventually help us find a valid partition.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/q6IEA26hvXc/0.jpg)](https://www.youtube.com/watch?v=q6IEA26hvXc)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=q6IEA26hvXc)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/median-of-two-sorted-arrays)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int len1 = nums1.Length;
        int len2 = nums2.Length;
        int[] merged = new int[len1 + len2];
        Array.Copy(nums1, merged, len1);
        Array.Copy(nums2, 0, merged, len1, len2);
        Array.Sort(merged);
        
        int totalLen = merged.Length;
        if (totalLen % 2 == 0) {
            return (merged[totalLen / 2 - 1] + merged[totalLen / 2]) / 2.0;
        } else {
            return merged[totalLen / 2];
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O((n + m)\log (n + m))$
* Space complexity: $O(n + m)$

> Where $n$ is the length of $nums1$ and $m$ is the length of $nums2$.

---

### 2. Two Pointers






```csharp
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int len1 = nums1.Length, len2 = nums2.Length;
        int i = 0, j = 0;
        int median1 = 0, median2 = 0;

        for (int count = 0; count < (len1 + len2) / 2 + 1; count++) {
            median2 = median1;
            if (i < len1 && j < len2) {
                if (nums1[i] > nums2[j]) {
                    median1 = nums2[j];
                    j++;
                } else {
                    median1 = nums1[i];
                    i++;
                }
            } else if (i < len1) {
                median1 = nums1[i];
                i++;
            } else {
                median1 = nums2[j];
                j++;
            }
        }

        if ((len1 + len2) % 2 == 1) {
            return (double) median1;
        } else {
            return (median1 + median2) / 2.0;
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n + m)$
* Space complexity: $O(1)$

> Where $n$ is the length of $nums1$ and $m$ is the length of $nums2$.

---

### 3. Binary Search






```csharp
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int m = nums1.Length;
        int n = nums2.Length;
        int left = (m + n + 1) / 2;
        int right = (m + n + 2) / 2;

        return (GetKth(nums1, m, nums2, n, left, 0, 0) +
                GetKth(nums1, m, nums2, n, right, 0, 0)) / 2.0;
    }

    public int GetKth(int[] a, int m, int[] b, int n, int k, int aStart, int bStart) {
        if (m > n) {
            return GetKth(b, n, a, m, k, bStart, aStart);
        }
        if (m == 0) {
            return b[bStart + k - 1];
        }
        if (k == 1) {
            return Math.Min(a[aStart], b[bStart]);
        }

        int i = Math.Min(m, k / 2);
        int j = Math.Min(n, k / 2);

        if (a[aStart + i - 1] > b[bStart + j - 1]) {
            return GetKth(a, m, b, n - j, k - j, aStart, bStart + j);
        }
        else {
            return GetKth(a, m - i, b, n, k - i, aStart + i, bStart);
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(\log (m + n))$
* Space complexity: $O(\log (m + n))$

> Where $n$ is the length of $nums1$ and $m$ is the length of $nums2$.

---

### 4. Binary Search (Optimal)






```csharp
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int[] A = nums1;
        int[] B = nums2;
        int total = A.Length + B.Length;
        int half = (total + 1) / 2;

        if (B.Length < A.Length) {
            int[] temp = A;
            A = B;
            B = temp;
        }

        int l = 0;
        int r = A.Length;
        while (l <= r) {
            int i = (l + r) / 2;
            int j = half - i;

            int Aleft = i > 0 ? A[i - 1] : int.MinValue;
            int Aright = i < A.Length ? A[i] : int.MaxValue;
            int Bleft = j > 0 ? B[j - 1] : int.MinValue;
            int Bright = j < B.Length ? B[j] : int.MaxValue;

            if (Aleft <= Bright && Bleft <= Aright) {
                if (total % 2 != 0) {
                    return Math.Max(Aleft, Bleft);
                }
                return (Math.Max(Aleft, Bleft) + Math.Min(Aright, Bright)) / 2.0;
            }
            else if (Aleft > Bright) {
                r = i - 1;
            }
            else {
                l = i + 1;
            }
        }
        return -1;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(\log (min(n, m)))$
* Space complexity: $O(1)$

> Where $n$ is the length of $nums1$ and $m$ is the length of $nums2$.
