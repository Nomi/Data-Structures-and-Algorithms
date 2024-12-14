# ⭐ | Rotting Oranges

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
- [Matrix BFS](https://neetcode.io/courses/dsa-for-beginners/30) [from NeetCode's Course(s)]


## Problem Description
You are given a 2-D matrix `grid`. Each cell can have one of three possible values:
* `0` representing an empty cell
* `1` representing a fresh fruit
* `2` representing a rotten fruit

Every minute, if a fresh fruit is horizontally or vertically adjacent to a rotten fruit, then the fresh fruit also becomes rotten.

Return the minimum number of minutes that must elapse until there are zero fresh fruits remaining. If this state is impossible within the grid, return `-1`.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/5daa219c-ae90-4027-41c3-6ea4d9158300/public)

```java
Input: grid = [[1,1,0],[0,1,1],[0,1,2]]

Output: 4
```

**Example 2:**

```java
Input: grid = [[1,0,1],[0,2,0],[1,0,1]]

Output: -1
```

**Constraints:**
* `1 <= grid.length, grid[i].length <= 10`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(m * n)</code> time and <code>O(m * n)</code> space, where <code>m</code> is the number of rows and <code>n</code> is the number of columns in the given grid.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    The DFS algorithm is not suitable for this problem because it explores nodes deeply rather than level by level. In this scenario, we need to determine which oranges rot at each second, which naturally fits a level-by-level traversal. Can you think of an algorithm designed for such a traversal?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use the Breadth First Search (BFS) algorithm. At each second, we rot the oranges that are adjacent to the rotten ones. So, we store the rotten oranges in a queue and process them in one go. The time at which a fresh orange gets rotten is the level at which it is visited. How would you implement it?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We traverse the grid and store the rotten oranges in a queue. We then run a BFS, processing the current level of rotten oranges and visiting the adjacent cells of each rotten orange. We only insert the adjacent cell into the queue if it contains a fresh orange. This process continues until the queue is empty. The level at which the BFS stops is the answer. However, we also need to check whether all oranges have rotted by traversing the grid. If any fresh orange is found, we return <code>-1</code>; otherwise, we return the level.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/y704fEOx0s0/0.jpg)](https://www.youtube.com/watch?v=y704fEOx0s0)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=y704fEOx0s0)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/rotting-fruit)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Breadth First Search






```csharp
public class Solution {
    public int OrangesRotting(int[][] grid) {
        Queue<int[]> q = new Queue<int[]>();
        int fresh = 0;
        int time = 0;

        for (int r = 0; r < grid.Length; r++) {
            for (int c = 0; c < grid[0].Length; c++) {
                if (grid[r][c] == 1) {
                    fresh++;
                }
                if (grid[r][c] == 2) {
                    q.Enqueue(new int[] { r, c });
                }
            }
        }

        int[][] directions = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
        while (fresh > 0 && q.Count > 0) {
            int length = q.Count;
            for (int i = 0; i < length; i++) {
                int[] curr = q.Dequeue();
                int r = curr[0];
                int c = curr[1];

                foreach (int[] dir in directions) {
                    int row = r + dir[0];
                    int col = c + dir[1];
                    if (row >= 0 && row < grid.Length && 
                        col >= 0 && col < grid[0].Length &&
                        grid[row][col] == 1) {
                        grid[row][col] = 2;
                        q.Enqueue(new int[] { row, col });
                        fresh--;
                    }
                }
            }
            time++;
        }
        return fresh == 0 ? time : -1;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n)$
* Space complexity: $O(m * n)$

> Where $m$ is the number of rows and $n$ is the number of columns in the $grid$.

---

### 2. Breadth First Search (No Queue) 






```csharp
public class Solution {
    public int OrangesRotting(int[][] grid) {
        int ROWS = grid.Length, COLS = grid[0].Length;
        int fresh = 0, time = 0;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (grid[r][c] == 1) fresh++;
            }
        }

        int[][] directions = new int[][] {
            new int[] {0, 1}, new int[] {0, -1}, 
            new int[] {1, 0}, new int[] {-1, 0}
        };

        while (fresh > 0) {
            bool flag = false;
            for (int r = 0; r < ROWS; r++) {
                for (int c = 0; c < COLS; c++) {
                    if (grid[r][c] == 2) {
                        foreach (var d in directions) {
                            int row = r + d[0], col = c + d[1];
                            if (row >= 0 && col >= 0 && 
                                row < ROWS && col < COLS && 
                                grid[row][col] == 1) {
                                grid[row][col] = 3;
                                fresh--;
                                flag = true;
                            }
                        }
                    }
                }
            }

            if (!flag) return -1;

            for (int r = 0; r < ROWS; r++) {
                for (int c = 0; c < COLS; c++) {
                    if (grid[r][c] == 3) grid[r][c] = 2;
                }
            }

            time++;
        }

        return time;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O((m * n) ^ 2)$
* Space complexity: $O(1)$

> Where $m$ is the number of rows and $n$ is the number of columns in the $grid$.
