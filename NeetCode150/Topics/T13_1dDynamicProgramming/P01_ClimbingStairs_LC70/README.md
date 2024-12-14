# ⭐ | Climbing Stairs

|   | Difficulty | Tricky |
|---|------------|--------|
| <big>⭐<big> | <big>**🟩 Easy**</big> | <big></big> |


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
You are given an integer `n` representing the number of steps to reach the top of a staircase. You can climb with either `1` or `2` steps at a time.
    
Return the number of distinct ways to climb to the top of the staircase.   

**Example 1:**

```java
Input: n = 2

Output: 2
```

Explanation:
1. `1 + 1 = 2`
2. `2 = 2`

**Example 2:**

```java
Input: n = 3

Output: 3
```

Explanation:
1. `1 + 1 + 1 = 3`
2. `1 + 2 = 3`
3. `2 + 1 = 3`

**Constraints:**
* `1 <= n <= 30`


## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/Y0lT9Fck7qI/0.jpg)](https://www.youtube.com/watch?v=Y0lT9Fck7qI)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=Y0lT9Fck7qI)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/climbing-stairs)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Recursion






```csharp
public class Solution {
    public int ClimbStairs(int n) {     
        return Dfs(n, 0);
    }

    public int Dfs(int n, int i) {
        if (i >= n) return i == n ? 1 : 0;
        return Dfs(n, i + 1) + Dfs(n, i + 2);
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
    int[] cache;
    public int ClimbStairs(int n) { 
        cache = new int[n];
        for (int i = 0; i < n; i++) {
            cache[i] = -1;
        }    
        return Dfs(n, 0);
    }

    public int Dfs(int n, int i) {
        if (i >= n) return i == n ? 1 : 0;
        if (cache[i] != -1) return cache[i];
        return cache[i] = Dfs(n, i + 1) + Dfs(n, i + 2);
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
    public int ClimbStairs(int n) {
        if (n <= 2) {
            return n;
        }
        int[] dp = new int[n + 1];
        dp[1] = 1;
        dp[2] = 2;
        for (int i = 3; i <= n; i++) {
            dp[i] = dp[i - 1] + dp[i - 2];
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
    public int ClimbStairs(int n) {
        int one = 1, two = 1;
        
        for (int i = 0; i < n - 1; i++) {
            int temp = one;
            one = one + two;
            two = temp;
        }
        
        return one;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$

---

### 5. Matrix Exponentiation






```csharp
public class Solution {
    public int ClimbStairs(int n) {
        if (n == 1) return 1;

        int[,] M = new int[,] {{1, 1}, {1, 0}};
        int[,] result = MatrixPow(M, n);

        return result[0, 0];
    }

    private int[,] MatrixMult(int[,] A, int[,] B) {
        return new int[,] {
            {A[0, 0] * B[0, 0] + A[0, 1] * B[1, 0],
             A[0, 0] * B[0, 1] + A[0, 1] * B[1, 1]},
            {A[1, 0] * B[0, 0] + A[1, 1] * B[1, 0],
             A[1, 0] * B[0, 1] + A[1, 1] * B[1, 1]}
        };
    }

    private int[,] MatrixPow(int[,] M, int p) {
        int[,] result = new int[,] {{1, 0}, {0, 1}};  
        int[,] baseM = M;

        while (p > 0) {
            if (p % 2 == 1) {
                result = MatrixMult(result, baseM);
            }
            baseM = MatrixMult(baseM, baseM);
            p /= 2;
        }

        return result;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(\log n)$
* Space complexity: $O(1)$

---

### 6. Math






```csharp
public class Solution {
    public int ClimbStairs(int n) {     
        double sqrt5 = Math.Sqrt(5);
        double phi = (1 + sqrt5) / 2;
        double psi = (1 - sqrt5) / 2;
        n++;
        return (int) Math.Round((Math.Pow(phi, n) -
                     Math.Pow(psi, n)) / sqrt5);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(\log n)$
* Space complexity: $O(1)$
