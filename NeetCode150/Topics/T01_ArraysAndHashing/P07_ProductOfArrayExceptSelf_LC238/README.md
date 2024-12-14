# ⭐ | Product of Array Except Self

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
- [Static Arrays](https://neetcode.io/courses/dsa-for-beginners/2) [from NeetCode's Course(s)]
- [Prefix Sums](https://neetcode.io/courses/advanced-algorithms/4) [from NeetCode's Course(s)]


## Problem Description
Given an integer array `nums`, return an array `output` where `output[i]` is the product of all the elements of `nums` except `nums[i]`.

Each product is **guaranteed** to fit in a **32-bit** integer.   

Follow-up: Could you solve it in $O(n)$ time without using the division operation?

**Example 1:**

```java
Input: nums = [1,2,4,6]

Output: [48,24,12,8]
```

**Example 2:**

```java
Input: nums = [-1,0,1,2,3]

Output: [0,-6,0,0,0]
```

**Constraints:**
* `2 <= nums.length <= 1000`
* `-20 <= nums[i] <= 20`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution as good or better than <code>O(n)</code> time and <code>O(n)</code> space, where <code>n</code> is the size of the input array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute-force solution would be to iterate through the array with index <code>i</code> and compute the product of the array except for that index element. This would be an <code>O(n^2)</code> solution. Can you think of a better way?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    Is there a way to avoid the repeated work? Maybe we can store the results of the repeated work in an array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We can use the prefix and suffix technique. First, we iterate from left to right and store the prefix products for each index in a prefix array, excluding the current index's number. Then, we iterate from right to left and store the suffix products for each index in a suffix array, also excluding the current index's number. Can you figure out the solution from here? 
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We can use the stored prefix and suffix products to compute the result array by iterating through the array and simply multiplying the prefix and suffix products at each index.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/bNvIQI2wAjk/0.jpg)](https://www.youtube.com/watch?v=bNvIQI2wAjk)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=bNvIQI2wAjk)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/products-of-array-discluding-self)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;
        int[] res = new int[n];

        for (int i = 0; i < n; i++) {
            int prod = 1;
            for (int j = 0; j < n; j++) {
                if (i != j) {
                    prod *= nums[j];
                }
            }
            res[i] = prod;
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(1)$ since the output array is excluded from space analysis.
---

### 2. Division






```csharp
public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int prod = 1, zeroCount = 0;
        foreach (int num in nums) {
            if (num != 0) {
                prod *= num;
            } else {
                zeroCount++;
            }
        }

        if (zeroCount > 1) {
            return new int[nums.Length]; 
        }

        int[] res = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++) {
            if (zeroCount > 0) {
                res[i] = (nums[i] == 0) ? prod : 0;
            } else {
                res[i] = prod / nums[i];
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$ since the output array is excluded from space analysis.

---

### 3. Prefix & Suffix 






```csharp
public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;
        int[] res = new int[n];
        int[] pref = new int[n];
        int[] suff = new int[n];

        pref[0] = 1;
        suff[n - 1] = 1;
        for (int i = 1; i < n; i++) {
            pref[i] = nums[i - 1] * pref[i - 1];
        }
        for (int i = n - 2; i >= 0; i--) {
            suff[i] = nums[i + 1] * suff[i + 1];
        }
        for (int i = 0; i < n; i++) {
            res[i] = pref[i] * suff[i];
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 4. Prefix & Suffix (Optimal) 






```csharp
public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;
        int[] res = new int[n];
        Array.Fill(res, 1);

        for (int i = 1; i < n; i++) {
            res[i] = res[i - 1] * nums[i - 1];
        }
        
        int postfix = 1;
        for (int i = n - 1; i >= 0; i--) {
            res[i] *= postfix;
            postfix *= nums[i];
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$ since the output array is excluded from space analysis.
