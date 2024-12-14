# ⭐ | Walls And Gates

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
You are given a $m \times n$ 2D `grid` initialized with these three possible values:

1. `-1` - A water cell that *can not* be traversed.
2. `0` - A treasure chest.
3. `INF` - A land cell that *can* be traversed. We use the integer `2^31 - 1 = 2147483647` to represent `INF`.

Fill each land cell with the distance to its nearest treasure chest. If a land cell cannot reach a treasure chest than the value should remain `INF`.

Assume the grid can only be traversed up, down, left, or right.

**Example 1:**

```java
Input: [
  [2147483647,-1,0,2147483647],
  [2147483647,2147483647,2147483647,-1],
  [2147483647,-1,2147483647,-1],
  [0,-1,2147483647,2147483647]
]

Output: [
  [3,-1,0,1],
  [2,2,1,-1],
  [1,-1,2,-1],
  [0,-1,3,4]
]
```

**Example 2:**

```java
Input: [
  [0,-1],
  [2147483647,2147483647]
]

Output: [
  [0,-1],
  [1,2]
]
```

**Constraints:**
* `m == grid.length`
* `n == grid[i].length`
* `1 <= m, n <= 100`
* `grid[i][j]` is one of `{-1, 0, 2147483647}`

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
    A brute force solution would be to iterate on each land cell and run a BFS from that cells to find the nearest treasure chest. This would be an <code>O((m * n)^2)</code> solution. Can you think of a better way? Sometimes it is not optimal to go from source to destination.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can see that instead of going from every cell to find the nearest treasure chest, we can do it in reverse. We can just do a BFS from all the treasure chests in grid and just explore all possible paths from those chests. Why? Because in this approach, the treasure chests self mark the cells level by level and the level number will be the distance from that cell to a treasure chest. We don't revisit a cell. This approach is called <code>Multi-Source BFS</code>. How would you implement it?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We insert all the cells <code>(row, col)</code> that represent the treasure chests into the queue. Then, we process the cells level by level, handling all the current cells in the queue at once. For each cell, we mark it as visited and store the current level value as the distance at that cell. We then try to add the neighboring cells (adjacent cells) to the queue, but only if they have not been visited and are land cells.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/e69C6xhiSQE/0.jpg)](https://www.youtube.com/watch?v=e69C6xhiSQE)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=e69C6xhiSQE)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/islands-and-treasure)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force (Backtracking)






```csharp
public class Solution {
    private int[][] directions = new int[][] {
        new int[] {1, 0}, new int[] {-1, 0}, 
        new int[] {0, 1}, new int[] {0, -1}
    };
    private int INF = 2147483647;
    private bool[,] visit;
    private int ROWS, COLS;

    private int Dfs(int[][] grid, int r, int c) {
        if (r < 0 || c < 0 || r >= ROWS || 
            c >= COLS || grid[r][c] == -1 || visit[r, c]) {
            return INF;
        }
        if (grid[r][c] == 0) {
            return 0;
        }
        visit[r, c] = true;
        int res = INF;
        foreach (var dir in directions) {
            int cur = Dfs(grid, r + dir[0], c + dir[1]);
            if (cur != INF) {
                res = Math.Min(res, 1 + cur);
            }
        }
        visit[r, c] = false;
        return res;
    }

    public void islandsAndTreasure(int[][] grid) {
        ROWS = grid.Length;
        COLS = grid[0].Length;
        visit = new bool[ROWS, COLS];

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (grid[r][c] == INF) {
                    grid[r][c] = Dfs(grid, r, c);
                }
            }
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n * 4 ^ {m * n})$
* Space complexity: $O(m * n)$

> Where $m$ is the number of rows and $n$ is the number of columns in the $grid$.

---

### 2. Breadth First Search






```csharp
public class Solution {
    private int[][] directions = new int[][] {
        new int[] { 1, 0 }, new int[] { -1, 0 },
        new int[] { 0, 1 }, new int[] { 0, -1 }
    };
    private int INF = int.MaxValue;
    private int ROWS, COLS;

    private int Bfs(int[][] grid, int r, int c) {
        var q = new Queue<int[]>();
        q.Enqueue(new int[] { r, c });
        bool[][] visit = new bool[ROWS][];
        for (int i = 0; i < ROWS; i++) visit[i] = new bool[COLS];
        visit[r][c] = true;
        int steps = 0;

        while (q.Count > 0) {
            int size = q.Count;
            for (int i = 0; i < size; i++) {
                var curr = q.Dequeue();
                int row = curr[0], col = curr[1];
                if (grid[row][col] == 0) return steps;
                foreach (var dir in directions) {
                    int nr = row + dir[0], nc = col + dir[1];
                    if (nr >= 0 && nr < ROWS && nc >= 0 && nc < COLS && 
                        !visit[nr][nc] && grid[nr][nc] != -1) {
                        visit[nr][nc] = true;
                        q.Enqueue(new int[] { nr, nc });
                    }
                }
            }
            steps++;
        }
        return INF;
    }

    public void islandsAndTreasure(int[][] grid) {
        ROWS = grid.Length;
        COLS = grid[0].Length;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (grid[r][c] == INF) {
                    grid[r][c] = Bfs(grid, r, c);
                }
            }
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O((m * n) ^ 2)$
* Space complexity: $O(m * n)$

> Where $m$ is the number of rows and $n$ is the number of columns in the $grid$.

---

### 3. Multi Source BFS






```csharp
public class Solution {
    public void islandsAndTreasure(int[][] grid) {
        Queue<int[]> q = new Queue<int[]>();
        int m = grid.Length;
        int n = grid[0].Length;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 0) q.Enqueue(new int[] { i, j });
            }
        }

        if (q.Count == 0) return;
        
        int[][] dirs = { 
            new int[] { -1, 0 }, new int[] { 0, -1 }, 
            new int[] { 1, 0 }, new int[] { 0, 1 } 
        };
        while (q.Count > 0) {
            int[] cur = q.Dequeue();
            int row = cur[0];
            int col = cur[1];
            foreach (int[] dir in dirs) {
                int r = row + dir[0];
                int c = col + dir[1];
                if (r >= m || c >= n || r < 0 ||
                    c < 0 || grid[r][c] != int.MaxValue) {
                    continue;   
                }
                q.Enqueue(new int[] { r, c });

                grid[r][c] = grid[row][col] + 1;
            }
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n)$
* Space complexity: $O(m * n)$

> Where $m$ is the number of rows and $n$ is the number of columns in the $grid$.
