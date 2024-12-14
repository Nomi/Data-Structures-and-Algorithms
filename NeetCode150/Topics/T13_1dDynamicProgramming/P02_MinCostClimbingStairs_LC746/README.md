# Min Cost Climbing Stairs

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
- [Fibonacci Sequence](https://neetcode.io/courses/dsa-for-beginners/9) [from NeetCode's Course(s)]
- [Tree Maze](https://neetcode.io/courses/dsa-for-beginners/22) [from NeetCode's Course(s)]
- [1-Dimension DP](https://neetcode.io/courses/dsa-for-beginners/32) [from NeetCode's Course(s)]


## Problem Description
You are given an array of integers `cost` where `cost[i]` is the cost of taking a step from the `ith` floor of a staircase. After paying the cost, you can step to either the `(i + 1)th` floor or the `(i + 2)th` floor.

You may choose to start at the index `0` or the index `1` floor.

Return the minimum cost to reach the top of the staircase, i.e. just past the last index in `cost`.

**Example 1:**

```java
Input: cost = [1,2,3]

Output: 2
```

Explanation: We can start at index = `1` and pay the cost of `cost[1] = 2` and take two steps to reach the top. The total cost is `2`.

**Example 2:**

```java
Input: cost = [1,2,1,2,1,1,1]

Output: 4
```

Explanation: Start at index = `0`.
* Pay the cost of `cost[0] = 1` and take two steps to reach index = `2`.
* Pay the cost of `cost[2] = 1` and take two steps to reach index = `4`.
* Pay the cost of `cost[4] = 1` and take two steps to reach index = `6`.
* Pay the cost of `cost[6] = 1` and take one step to reach the top.
* The total cost is `4`.

**Constraints:**
* `2 <= cost.length <= 100`
* `0 <= cost[i] <= 100`


## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/ktmzAZWkEZ0/0.jpg)](https://www.youtube.com/watch?v=ktmzAZWkEZ0)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=ktmzAZWkEZ0)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/min-cost-climbing-stairs)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Recursion






```csharp
public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        return Math.Min(Dfs(cost, 0), Dfs(cost, 1));
    }
    
    private int Dfs(int[] cost, int i) {
        if (i >= cost.Length) {
            return 0;
        }
        return cost[i] + Math.Min(Dfs(cost, i + 1),
                                  Dfs(cost, i + 2));
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
    int[] memo;
    
    public int MinCostClimbingStairs(int[] cost) {
        memo = new int[cost.Length];
        Array.Fill(memo, -1);
        return Math.Min(Dfs(cost, 0), Dfs(cost, 1));
    }
    
    private int Dfs(int[] cost, int i) {
        if (i >= cost.Length) {
            return 0;
        }
        if (memo[i] != -1) {
            return memo[i];
        }
        memo[i] = cost[i] + Math.Min(Dfs(cost, i + 1),
                                     Dfs(cost, i + 2));
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
    public int MinCostClimbingStairs(int[] cost) {
        int n = cost.Length;
        int[] dp = new int[n + 1];
        
        for (int i = 2; i <= n; i++) {
            dp[i] = Math.Min(dp[i - 1] + cost[i - 1],
                             dp[i - 2] + cost[i - 2]);
        }
        
        return dp[n];
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
    public int MinCostClimbingStairs(int[] cost) {
        for (int i = cost.Length - 3; i >= 0; i--) {
            cost[i] += Math.Min(cost[i + 1], cost[i + 2]);
        }
        return Math.Min(cost[0], cost[1]);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$
