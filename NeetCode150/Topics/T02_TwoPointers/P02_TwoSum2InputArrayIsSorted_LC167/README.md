# ⭐ | Two Sum II Input Array Is Sorted

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
- [Two Pointers](https://neetcode.io/courses/advanced-algorithms/3) [from NeetCode's Course(s)]


## Problem Description
Given an array of integers `numbers` that is sorted in **non-decreasing order**.

Return the indices (**1-indexed**) of two numbers, `[index1, index2]`, such that they add up to a given target number `target` and `index1 < index2`. Note that `index1` and `index2` cannot be equal, therefore you may not use the same element twice.

There will always be **exactly one valid solution**.

Your solution must use $O(1)$ additional space.

**Example 1:**

```java
Input: numbers = [1,2,3,4], target = 3

Output: [1,2]
```

Explanation:
The sum of 1 and 2 is 3. Since we are assuming a 1-indexed array, `index1` = 1, `index2` = 2. We return `[1, 2]`.

**Constraints:**
* `2 <= numbers.length <= 1000`
* `-1000 <= numbers[i] <= 1000`
* `-1000 <= target <= 1000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time and <code>O(1)</code> space, where <code>n</code> is the size of the input array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would be to check every pair of numbers in the array. This would be an <code>O(n^2)</code> solution. Can you think of a better way?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    Can you think of an algorithm by taking the advantage of array being sorted?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
     We can use the two-pointer algorithm. If <code>nums[0] + nums[n-1] > target</code>, then we know <code>nums[n - 1]</code> can not possibly be included in any pairs. Why? Because <code>nums[n - 1]</code> is the largest element in the array. Even by adding it with <code>nums[0]</code>, which is the smallest element, we still exceed the target. You can think of the case when <code>nums[0] + nums[n - 1] < target</code>.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We keep two pointers, one at the start and the other at the end of the array. If the sum of the numbers at the two pointers is greater than the <code>target</code>, decrement the right pointer, else increment the left pointer. Repeat this process until you find a valid pair.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/cQ1Oz4ckceM/0.jpg)](https://www.youtube.com/watch?v=cQ1Oz4ckceM)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=cQ1Oz4ckceM)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/two-integer-sum-ii)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        for (int i = 0; i < numbers.Length; i++) {
            for (int j = i + 1; j < numbers.Length; j++) {
                if (numbers[i] + numbers[j] == target) {
                    return new int[] { i + 1, j + 1 };
                }
            }
        }
        return new int[0];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(1)$

---

### 2. Binary Search






```csharp
public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        for (int i = 0; i < numbers.Length; i++) {
            int l = i + 1, r = numbers.Length - 1;
            int tmp = target - numbers[i];
            while (l <= r) {
                int mid = l + (r - l) / 2;
                if (numbers[mid] == tmp) {
                    return new int[] { i + 1, mid + 1 };
                } else if (numbers[mid] < tmp) {
                    l = mid + 1;
                } else {
                    r = mid - 1;
                }
            }
        }
        return new int[0];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log n)$
* Space complexity: $O(1)$

---

### 3. Hash Map






```csharp
public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        Dictionary<int, int> mp = new Dictionary<int, int>();
        for (int i = 0; i < numbers.Length; i++) {
            int tmp = target - numbers[i];
            if (mp.ContainsKey(tmp)) {
                return new int[] { mp[tmp], i + 1 };
            }
            mp[numbers[i]] = i + 1;
        }
        return new int[0];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 4. Two Pointers






```csharp
public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int l = 0, r = numbers.Length - 1;

        while (l < r) {
            int curSum = numbers[l] + numbers[r];

            if (curSum > target) {
                r--;
            } else if (curSum < target) {
                l++;
            } else {
                return new int[] { l + 1, r + 1 };
            }
        }
        return new int[0];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$
