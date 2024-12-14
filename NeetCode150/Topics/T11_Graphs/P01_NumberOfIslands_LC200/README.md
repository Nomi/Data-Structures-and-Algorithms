# Number of Islands

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
- [Matrix DFS](https://neetcode.io/courses/dsa-for-beginners/29) [from NeetCode's Course(s)]
- [Matrix BFS](https://neetcode.io/courses/dsa-for-beginners/30) [from NeetCode's Course(s)]


## Problem Description
Given a 2D grid `grid` where `'1'` represents land and `'0'` represents water, count and return the number of islands.

An **island** is formed by connecting adjacent lands horizontally or vertically and is surrounded by water. You may assume water is surrounding the grid (i.e., all the edges are water).   

**Example 1:**

```java
Input: grid = [
    ["0","1","1","1","0"],
    ["0","1","0","1","0"],
    ["1","1","0","0","0"],
    ["0","0","0","0","0"]
  ]
Output: 1
```

**Example 2:**

```java
Input: grid = [
    ["1","1","0","0","1"],
    ["1","1","0","0","1"],
    ["0","0","1","0","0"],
    ["0","0","0","1","1"]
  ]
Output: 4
```


**Constraints:**
* `1 <= grid.length, grid[i].length <= 100`
* `grid[i][j]` is `'0'` or `'1'`.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(m * n)</code> time and <code>O(m * n)</code> space, where <code>m</code> is the number of rows and <code>n</code> is the number of columns in the grid.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    An island is a group of <code>1</code>'s in which every <code>1</code> is reachable from any other <code>1</code> in that group. Can you think of an algorithm that can find the number of groups by visiting a group only once? Maybe there is a recursive way of doing it.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use the Depth First Search (DFS) algorithm to traverse each group independently. We iterate through each cell of the grid. When we encounter a <code>1</code>, we perform a DFS starting at that cell and recursively visit every other <code>1</code> that is reachable. During this process, we mark the visited <code>1</code>'s as <code>0</code> to ensure we don't revisit them, as they belong to the same group. The number of groups corresponds to the number of islands.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/pV2kpPD66nE/0.jpg)](https://www.youtube.com/watch?v=pV2kpPD66nE)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=pV2kpPD66nE)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/count-number-of-islands)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Depth First Search






```csharp
public class Solution {
    private static readonly int[][] directions = new int[][] {
        new int[] {1, 0}, new int[] {-1, 0}, 
        new int[] {0, 1}, new int[] {0, -1}
    };
    
    public int NumIslands(char[][] grid) {
        int ROWS = grid.Length, COLS = grid[0].Length;
        int islands = 0;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (grid[r][c] == '1') {
                    Dfs(grid, r, c);
                    islands++;
                }
            }
        }

        return islands;
    }

    private void Dfs(char[][] grid, int r, int c) {
        if (r < 0 || c < 0 || r >= grid.Length || 
            c >= grid[0].Length || grid[r][c] == '0') {
            return;
        }

        grid[r][c] = '0';
        foreach (var dir in directions) {
            Dfs(grid, r + dir[0], c + dir[1]);
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n)$
* Space complexity: $O(m * n)$

> Where $m$ is the number of rows and $n$ is the number of columns in the $grid$.

---

### 2. Breadth First Search






```csharp
public class Solution {
    private static readonly int[][] directions = new int[][] {
        new int[] {1, 0}, new int[] {-1, 0}, 
        new int[] {0, 1}, new int[] {0, -1}
    };

    public int NumIslands(char[][] grid) {
        int ROWS = grid.Length, COLS = grid[0].Length;
        int islands = 0;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (grid[r][c] == '1') {
                    Bfs(grid, r, c);
                    islands++;
                }
            }
        }

        return islands;
    }

    private void Bfs(char[][] grid, int r, int c) {
        Queue<int[]> q = new Queue<int[]>();
        grid[r][c] = '0';
        q.Enqueue(new int[] { r, c });

        while (q.Count > 0) {
            var node = q.Dequeue();
            int row = node[0], col = node[1];

            foreach (var dir in directions) {
                int nr = row + dir[0], nc = col + dir[1];
                if (nr >= 0 && nc >= 0 && nr < grid.Length && 
                    nc < grid[0].Length && grid[nr][nc] == '1') {
                    q.Enqueue(new int[] { nr, nc });
                    grid[nr][nc] = '0';
                }
            }
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n)$
* Space complexity: $O(m * n)$

> Where $m$ is the number of rows and $n$ is the number of columns in the $grid$.

---

### 3. Disjoint Set Union






```csharp
public class DSU {
    private int[] Parent, Size;

    public DSU(int n) {
        Parent = new int[n + 1];
        Size = new int[n + 1];
        for (int i = 0; i <= n; i++) {
            Parent[i] = i;
            Size[i] = 1;
        }
    }

    public int Find(int node) {
        if (node != Parent[node]) {
            Parent[node] = Find(Parent[node]);
        }
        return Parent[node];
    }

    public bool Union(int u, int v) {
        int pu = Find(u);
        int pv = Find(v);
        if (pu == pv) return false;
        if (Size[pu] >= Size[pv]) {
            Size[pu] += Size[pv];
            Parent[pv] = pu;
        } else {
            Size[pv] += Size[pu];
            Parent[pu] = pv;
        }
        return true;
    }
}

public class Solution {
    public int NumIslands(char[][] grid) {
        int ROWS = grid.Length;
        int COLS = grid[0].Length;
        DSU dsu = new DSU(ROWS * COLS);

        int[][] directions = new int[][] {
            new int[] { 1, 0 }, new int[] { -1, 0 }, 
            new int[] { 0, 1 }, new int[] { 0, -1 }
        };
        int islands = 0;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (grid[r][c] == '1') {
                    islands++;
                    foreach (var d in directions) {
                        int nr = r + d[0];
                        int nc = c + d[1];
                        if (nr >= 0 && nc >= 0 && nr < ROWS && 
                            nc < COLS && grid[nr][nc] == '1') {
                            if (dsu.Union(r * COLS + c, nr * COLS + nc)) {
                                islands--;
                            }
                        }
                    }
                }
            }
        }

        return islands;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n)$
* Space complexity: $O(m * n)$

> Where $m$ is the number of rows and $n$ is the number of columns in the $grid$.
