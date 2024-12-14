# Search a 2D Matrix

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
- [Search Array](https://neetcode.io/courses/dsa-for-beginners/14) [from NeetCode's Course(s)]


## Problem Description
You are given an `m x n` 2-D integer array `matrix` and an integer `target`.

* Each row in `matrix` is sorted in *non-decreasing* order.
* The first integer of every row is greater than the last integer of the previous row.

Return `true` if `target` exists within `matrix` or `false` otherwise.

Can you write a solution that runs in `O(log(m * n))` time?

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/7ca61f56-00d4-4fa0-26cf-56809028ac00/public)

```java
Input: matrix = [[1,2,4,8],[10,11,12,13],[14,20,30,40]], target = 10

Output: true
```

**Example 2:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/f25f2085-ce04-4447-9cee-f0a66c32a300/public)

```java
Input: matrix = [[1,2,4,8],[10,11,12,13],[14,20,30,40]], target = 15

Output: false
```

**Constraints:**
* `m == matrix.length`
* `n == matrix[i].length`
* `1 <= m, n <= 100`
* `-10000 <= matrix[i][j], target <= 10000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(log(m * n))</code> time and <code>O(1)</code> space, where <code>m</code> is the number of rows and <code>n</code> is the number of columns in the matrix.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would be to do a linear search on the matrix. This would be an <code>O(m * n)</code> solution. Can you think of a better way? Maybe an efficient searching algorithm, as the given matrix is sorted.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use binary search, which is particularly effective when we visualize a row as a range of numbers, <code>[x, y]</code> where <code>x</code> is the first cell and <code>y</code> is the last cell of a row. Using this representation, it becomes straightforward to check if the target value falls within the range. How can you use binary search to solve the problem?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We perform a binary search on the rows to identify the row in which the target value might fall. This operation takes <code>O(logm)</code> time, where <code>m</code> is the number of rows. Now, when we find the potential row, can you find the best way to search the target in that row? The sorted nature of each row is the hint.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    Once we identify the potential row where the target might exist, we can perform a binary search on that row which acts as a one dimensional array. It takes <code>O(logn)</code> time, where <code>n</code> is the number of columns in the row.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/Ber2pi2C0j0/0.jpg)](https://www.youtube.com/watch?v=Ber2pi2C0j0)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=Ber2pi2C0j0)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/search-2d-matrix)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        for (int r = 0; r < matrix.Length; r++) {
            for (int c = 0; c < matrix[r].Length; c++) {
                if (matrix[r][c] == target) {
                    return true;
                }
            }
        }
        return false;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n)$
* Space complexity: $O(1)$

> Where $m$ is the number of rows and $n$ is the number of columns of matrix.

---

### 2. Staircase Search






```csharp
public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int m = matrix.Length, n = matrix[0].Length;
        int r = 0, c = n - 1;

        while (r < m && c >= 0) {
            if (matrix[r][c] > target) {
                c--;
            } else if (matrix[r][c] < target) {
                r++;
            } else {
                return true;
            }
        }
        return false;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m + n)$
* Space complexity: $O(1)$

> Where $m$ is the number of rows and $n$ is the number of columns of matrix.

---

### 3. Binary Search






```csharp
public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int ROWS = matrix.Length;
        int COLS = matrix[0].Length;

        int top = 0, bot = ROWS - 1;
        int row = 0;
        while (top <= bot) {
            row = (top + bot) / 2;
            if (target > matrix[row][COLS - 1]) {
                top = row + 1;
            }
            else if (target < matrix[row][0]) {
                bot = row - 1;
            }
            else {
                break;
            }
        }

        if (!(top <= bot)) {
            return false;
        }

        int l = 0, r = COLS - 1;
        while (l <= r) {
            int m = (l + r) / 2;
            if (target > matrix[row][m]) {
                l = m + 1;
            }
            else if (target < matrix[row][m]) {
                r = m - 1;
            }
            else {
                return true;
            }
        }
        return false;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(\log m + \log n)$ (which reduces to $O(\log(m * n))$)
* Space complexity: $O(1)$

> Where $m$ is the number of rows and $n$ is the number of columns of matrix.

---

### 4. Binary Search (One Pass)






```csharp
public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int ROWS = matrix.Length, COLS = matrix[0].Length;

        int l = 0, r = ROWS * COLS - 1;
        while (l <= r) {
            int m = l + (r - l) / 2;
            int row = m / COLS, col = m % COLS;
            if (target > matrix[row][col]) {
                l = m + 1;
            } else if (target < matrix[row][col]) {
                r = m - 1;
            } else {
                return true;
            }
        }
        return false;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(\log(m * n))$
* Space complexity: $O(1)$

> Where $m$ is the number of rows and $n$ is the number of columns of matrix.
