# Two Sum

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
- [Hash Usage](https://neetcode.io/courses/dsa-for-beginners/26) [from NeetCode's Course(s)]


## Problem Description
Given an array of integers `nums` and an integer `target`, return the indices `i` and `j` such that `nums[i] + nums[j] == target` and `i != j`.
    
You may assume that *every* input has exactly one pair of indices `i` and `j` that satisfy the condition.

Return the answer with the smaller index first. 

**Example 1:**

```java
Input: 
nums = [3,4,5,6], target = 7

Output: [0,1]
```

Explanation: `nums[0] + nums[1] == 7`, so we return `[0, 1]`.

**Example 2:**

```java
Input: nums = [4,5,6], target = 10

Output: [0,2]
```

**Example 3:**

```java
Input: nums = [5,5], target = 10

Output: [0,1]
```

**Constraints:**
* `2 <= nums.length <= 1000`
* `-10,000,000 <= nums[i] <= 10,000,000`
* `-10,000,000 <= target <= 10,000,000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time and <code>O(n)</code> space, where n is the size of the input array.
    </p>
</details>

<br>
<details class="hint-accordion">
    <summary>Hint 1</summary>
    <p>
    A brute force solution would be to check every pair of numbers in the array. This would be an <code>O(n^2)</code> solution. Can you think of a better way? Maybe in terms of mathematical equation?
    </p>
</details>

<br>
<details class="hint-accordion">
    <summary>Hint 2</summary>
    <p>
    Given, We need to find indices <code>i</code> and <code>j</code> such that <code>i != j</code> and <code>nums[i] + nums[j] == target</code>. Can you rearrange the equation and try to fix any index to iterate on? 
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
     we can iterate through nums with index <code>i</code>. Let <code>difference = target - nums[i]</code> and check if <code>difference</code> exists in the hash map as we iterate through the array, else store the current element in the hashmap with its index and continue. We use a hashmap for <code>O(1)</code> lookups.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/KLlXCFG5TnA/0.jpg)](https://www.youtube.com/watch?v=KLlXCFG5TnA)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=KLlXCFG5TnA)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/two-integer-sum)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        for (int i = 0; i < nums.Length; i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                if (nums[i] + nums[j] == target) {
                    return new int[]{i, j}; 
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

### 2. Sorting






```csharp
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        List<int[]> A = new List<int[]>();
        for (int idx = 0; idx < nums.Length; idx++) {
            A.Add(new int[]{nums[idx], idx});
        }

        A.Sort((a, b) => a[0].CompareTo(b[0]));

        int i = 0, j = nums.Length - 1;
        while (i < j) {
            int cur = A[i][0] + A[j][0];
            if (cur == target) {
                return new int[]{
                    Math.Min(A[i][1], A[j][1]), 
                    Math.Max(A[i][1], A[j][1])
                };
            } else if (cur < target) {
                i++;
            } else {
                j--;
            }
        }
        return new int[0];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log n)$
* Space complexity: $O(n)$

---

### 3. Hash Map (Two Pass)






```csharp
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // val -> index
        Dictionary<int, int> indices = new Dictionary<int, int>();  

        for (int i = 0; i < nums.Length; i++) {
            indices[nums[i]] = i;
        }

        for (int i = 0; i < nums.Length; i++) {
            int diff = target - nums[i];
            if (indices.ContainsKey(diff) && indices[diff] != i) {
                return new int[]{i, indices[diff]};
            }
        }

        return new int[0];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 4. Hash Map (One Pass)






```csharp
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> prevMap = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++) {
            var diff = target - nums[i];
            if (prevMap.ContainsKey(diff)) {
                return new int[] {prevMap[diff], i};
            }
            prevMap[nums[i]] = i;
        }
        return null;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
