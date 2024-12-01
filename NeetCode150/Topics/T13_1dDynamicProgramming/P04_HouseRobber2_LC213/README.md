# ⭐ | House Robber II

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
- [Tree Maze](https://neetcode.io/courses/dsa-for-beginners/22) [from NeetCode's Course(s)]
- [1-Dimension DP](https://neetcode.io/courses/dsa-for-beginners/32) [from NeetCode's Course(s)]


## Problem Description
You are given an integer array `nums` where `nums[i]` represents the amount of money the `i`th house has. The houses are arranged in a circle, i.e. the first house and the last house are neighbors.

You are planning to rob money from the houses, but you cannot rob **two adjacent houses** because the security system will automatically alert the police if two adjacent houses were *both* broken into.
    
Return the *maximum* amount of money you can rob **without** alerting the police.

**Example 1:**

```java
Input: nums = [3,4,3]

Output: 4
```

Explanation: You cannot rob `nums[0] + nums[2] = 6` because `nums[0]` and `nums[2]` are adjacent houses. The maximum you can rob is `nums[1] = 4`.

**Example 2:**

```java
Input: nums = [2,9,8,3,6]

Output: 15
```

Explanation: You cannot rob `nums[0] + nums[2] + nums[4] = 16` because `nums[0]` and `nums[4]` are adjacent houses. The maximum you can rob is `nums[1] + nums[4] = 15`.


**Constraints:**
* `1 <= nums.length <= 100`
* `0 <= nums[i] <= 100`


## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/rWAJCfYYOvM/0.jpg)](https://www.youtube.com/watch?v=rWAJCfYYOvM)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=rWAJCfYYOvM)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/house-robber-ii)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Recursion






```csharp
public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 1) return nums[0];
        return Math.Max(Dfs(0, true, nums), Dfs(1, false, nums));
    }
    
    private int Dfs(int i, bool flag, int[] nums) {
        if (i >= nums.Length || (flag && i == nums.Length - 1)) 
            return 0;

        return Math.Max(Dfs(i + 1, flag, nums), 
                        nums[i] + Dfs(i + 2, flag || i == 0, nums));
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
    private int[][] memo;

    public int Rob(int[] nums) {
        if (nums.Length == 1) return nums[0];
        
        memo = new int[nums.Length][];
        for (int i = 0; i < nums.Length; i++) {
            memo[i] = new int[] { -1, -1 };
        }
        
        return Math.Max(Dfs(0, 1, nums), Dfs(1, 0, nums));
    }

    private int Dfs(int i, int flag, int[] nums) {
        if (i >= nums.Length || (flag == 1 && i == nums.Length - 1)) 
            return 0;
        if (memo[i][flag] != -1) 
            return memo[i][flag];
        memo[i][flag] = Math.Max(Dfs(i + 1, flag, nums), 
                        nums[i] + Dfs(i + 2, flag | (i == 0 ? 1 : 0), nums));
        return memo[i][flag];
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

        return Math.Max(Helper(nums[1..]), Helper(nums[..^1]));
    }

    private int Helper(int[] nums) {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];

        int[] dp = new int[nums.Length];
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++) {
            dp[i] = Math.Max(dp[i - 1], nums[i] + dp[i - 2]);
        }

        return dp[^1];
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
        if (nums.Length == 1) 
            return nums[0];

        return Math.Max(Helper(nums[1..]), 
                        Helper(nums[..^1]));
    }

    private int Helper(int[] nums) {
        int rob1 = 0, rob2 = 0;
        foreach (int num in nums) {
            int newRob = Math.Max(rob1 + num, rob2);
            rob1 = rob2;
            rob2 = newRob;
        }
        return rob2;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$
