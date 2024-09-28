# ⭐ | Find The Duplicate Number

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
- [Singly Linked Lists](https://neetcode.io/courses/dsa-for-beginners/5) [from NeetCode's Course(s)]
- [Fast and Slow Pointers](https://neetcode.io/courses/advanced-algorithms/5) [from NeetCode's Course(s)]


## Problem Description
You are given an array of integers `nums` containing `n + 1` integers. Each integer in `nums` is in the range `[1, n]` inclusive.

Every integer appears **exactly once**, except for one integer which appears **two or more times**. Return the integer that appears more than once.

**Example 1:**

```java
Input: nums = [1,2,3,2,2]

Output: 2
```

**Example 2:**

```java
Input: nums = [1,2,3,4,4]

Output: 4
```

Follow-up: Can you solve the problem **without** modifying the array `nums` and using $O(1)$ extra space?

**Constraints:**
* `1 <= n <= 10000`
* `nums.length == n + 1`
* `1 <= nums[i] <= n`

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
    A naive approach would be to use a hash set, which takes <code>O(1)</code> time to detect duplicates. Although this solution is acceptable, it requires <code>O(n)</code> extra space. Can you think of a better solution that avoids using extra space? Consider that the elements in the given array <code>nums</code> are within the range <code>1</code> to <code>len(nums)</code>.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use the given input array itself as a hash set without creating a new one. This can be achieved by marking the positions (<code>0</code>-indexed) corresponding to the elements that have already been encountered. Can you implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We iterate through the array using index <code>i</code>. For each element, we use its absolute value to find the corresponding index and mark that position as negative: <code>nums[abs(nums[i]) - 1] *= -1</code>. Taking absolute value ensures we work with the original value even if it’s already negated. How can you detect duplicates?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    For example, in the array <code>[2, 1, 2, 3]</code>, where <code>2</code> is repeated, we mark the index corresponding to each element as negative. If we encounter a number whose corresponding position is already negative, it means the number is a duplicate, and we return it.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/wjYnzkAhcNk/0.jpg)](https://www.youtube.com/watch?v=wjYnzkAhcNk)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=wjYnzkAhcNk)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/find-duplicate-integer)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Sorting






```csharp
public class Solution {
    public int FindDuplicate(int[] nums) {
        Array.Sort(nums);
        for (int i = 0; i < nums.Length - 1; i++) {
            if (nums[i] == nums[i + 1]) {
                return nums[i];
            }
        }
        return -1;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log n)$
* Space complexity: $O(1)$ or $O(n)$ depending on the sorting algorithm.

---

### 2. Hash Set






```csharp
public class Solution {
    public int FindDuplicate(int[] nums) {
        HashSet<int> seen = new HashSet<int>();
        foreach (int num in nums) {
            if (seen.Contains(num)) {
                return num;
            }
            seen.Add(num);
        }
        return -1;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 3. Array






```csharp
public class Solution {
    public int FindDuplicate(int[] nums) {
        int[] seen = new int[nums.Length];
        foreach (int num in nums) {
            if (seen[num - 1] == 1) {
                return num;
            }
            seen[num - 1] = 1;
        }
        return -1;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 4. Negative Marking






```csharp
public class Solution {
    public int FindDuplicate(int[] nums) {
        foreach (int num in nums) {
            int idx = Math.Abs(num) - 1;
            if (nums[idx] < 0) {
                return Math.Abs(num);
            }
            nums[idx] *= -1;
        }
        return -1;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$

---

### 5. Binary Search






```csharp
public class Solution {
    public int FindDuplicate(int[] nums) {
        int n = nums.Length;
        int low = 1, high = n - 1;

        while (low < high) {
            int mid = low + (high - low) / 2;
            int lessOrEqual = 0;

            for (int i = 0; i < n; i++) {
                if (nums[i] <= mid) {
                    lessOrEqual++;
                }
            }

            if (lessOrEqual <= mid) {
                low = mid + 1;
            } else {
                high = mid;
            }
        }

        return low;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log n)$
* Space complexity: $O(1)$

---

### 6. Bit Manipulation






```csharp
public class Solution {
    public int FindDuplicate(IList<int> nums) {
        int n = nums.Count;
        int res = 0;
        for (int b = 0; b < 32; b++) {
            int x = 0, y = 0;
            int mask = 1 << b;
            foreach (int num in nums) {
                if ((num & mask) != 0) {
                    x++;
                }
            }
            for (int num = 1; num < n; num++) {
                if ((num & mask) != 0) {
                    y++;
                }
            }
            if (x > y) {
                res |= mask;
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(32 * n)$
* Space complexity: $O(1)$

---

### 7. Fast And Slow Pointers






```csharp
public class Solution {
    public int FindDuplicate(int[] nums) {
        int slow = 0, fast = 0;
        while (true) {
            slow = nums[slow];
            fast = nums[nums[fast]];
            if (slow == fast) {
                break;
            }
        }

        int slow2 = 0;
        while (true) {
            slow = nums[slow];
            slow2 = nums[slow2];
            if (slow == slow2) {
                return slow;
            }
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$
