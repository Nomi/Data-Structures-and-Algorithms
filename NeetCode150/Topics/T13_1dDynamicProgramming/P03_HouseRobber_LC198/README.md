# House Robber

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
- [Tree Maze](https://neetcode.io/courses/dsa-for-beginners/22) [from NeetCode's Course(s)]
- [1-Dimension DP](https://neetcode.io/courses/dsa-for-beginners/32) [from NeetCode's Course(s)]


## Problem Description
You are given an integer array `nums` where `nums[i]` represents the amount of money the `i`th house has. The houses are arranged in a straight line, i.e. the `i`th house is the neighbor of the `(i-1)`th and `(i+1)`th house.

You are planning to rob money from the houses, but you cannot rob **two adjacent houses** because the security system will automatically alert the police if two adjacent houses were *both* broken into.

Return the *maximum* amount of money you can rob **without** alerting the police.

**Example 1:**

```java
Input: nums = [1,1,3,3]

Output: 4
```

Explanation: `nums[0] + nums[2] = 1 + 3 = 4`.

**Example 2:**

```java
Input: nums = [2,9,8,3,6]

Output: 16
```

Explanation: `nums[0] + nums[2] + nums[4] = 2 + 8 + 6 = 16`.

**Constraints:**
* `1 <= nums.length <= 100`
* `0 <= nums[i] <= 100`


## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/73r3KWiEvyk/0.jpg)](https://www.youtube.com/watch?v=73r3KWiEvyk)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=73r3KWiEvyk)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/house-robber)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Recursion






```csharp
public class Solution {
    public int Rob(int[] nums) {
        return Dfs(nums, 0);
    }

    private int Dfs(int[] nums, int i) {
        if (i >= nums.Length) {
            return 0;
        }
        return Math.Max(Dfs(nums, i + 1),
               nums[i] + Dfs(nums, i + 2));
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(2 ^ n)$
* Space complexity: $O(n)$

---

### 2. Dynamic Programming (Top-Down)






```csharp
public class Solution {
    private int[] memo;

    public int Rob(int[] nums) {
        memo = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++) {
            memo[i] = -1;
        }
        return Dfs(nums, 0);
    }

    private int Dfs(int[] nums, int i) {
        if (i >= nums.Length) {
            return 0;
        }
        if (memo[i] != -1) {
            return memo[i];
        }
        memo[i] = Math.Max(Dfs(nums, i + 1),
                         nums[i] + Dfs(nums, i + 2));
        return memo[i];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 3. Dynamic Programming (Bottom-Up)






```csharp
public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];

        int[] dp = new int[nums.Length];
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++) {
            dp[i] = Math.Max(dp[i - 1], nums[i] + dp[i - 2]);
        }

        return dp[nums.Length - 1];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 4. Dynamic Programming (Space Optimized)






```csharp
public class Solution {
    public int Rob(int[] nums) {
        int rob1 = 0, rob2 = 0;

        foreach (int num in nums) {
            int temp = Math.Max(num + rob1, rob2);
            rob1 = rob2;
            rob2 = temp;
        }
        return rob2;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$
