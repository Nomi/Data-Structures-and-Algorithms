# ⭐ | Pacific Atlantic Water Flow

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
- [Matrix DFS](https://neetcode.io/courses/dsa-for-beginners/29) [from NeetCode's Course(s)]


## Problem Description
You are given a rectangular island `heights` where `heights[r][c]` represents the **height above sea level** of the cell at coordinate `(r, c)`.
    
The islands borders the **Pacific Ocean** from the top and left sides, and borders the **Atlantic Ocean** from the bottom and right sides.

Water can flow in **four directions** (up, down, left, or right) from a cell to a neighboring cell with **height equal or lower**. Water can also flow into the ocean from cells adjacent to the ocean.

Find all cells where water can flow from that cell to **both** the Pacific and Atlantic oceans. Return it as a **2D list** where each element is a list `[r, c]` representing the row and column of the cell. You may return the answer in **any order**.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/3899fae1-ab18-4d6b-15b4-c7f7aa224700/public)

```java
Input: heights = [
  [4,2,7,3,4],
  [7,4,6,4,7],
  [6,3,5,3,6]
]

Output: [[0,2],[0,4],[1,0],[1,1],[1,2],[1,3],[1,4],[2,0]]
```

**Example 2:**

```java
Input: heights = [[1],[1]]

Output: [[0,0],[0,1]]
```

**Constraints:**
* `1 <= heights.length, heights[r].length <= 100`
* `0 <= heights[r][c] <= 1000`

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
    A brute force solution would be to traverse each cell in the grid and run a BFS from each cell to check if it can reach both oceans. This would result in an <code>O((m * n)^2)</code> solution. Can you think of a better way? Maybe you should consider a reverse way of traversing.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use the Depth First Search (DFS) algorithm starting from the border cells of the grid. However, we reverse the condition such that the next visiting cell should have a height greater than or equal to the current cell. For the top and left borders connected to the Pacific Ocean, we use a hash set called <code>pacific</code> and run a DFS from each of these cells, visiting nodes recursively. Similarly, for the bottom and right borders connected to the Atlantic Ocean, we use a hash set called <code>atlantic</code> and run a DFS. The required coordinates are the cells that exist in both the <code>pacific</code> and <code>atlantic</code> sets. How do you implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We perform DFS from the border cells, using their respective hash sets. During the DFS, we recursively visit the neighbouring cells that are unvisited and have height greater than or equal to the current cell's height and add the current cell's coordinates to the corresponding hash set. Once the DFS completes, we traverse the grid and check if a cell exists in both the hash sets. If so, we add that cell to the result list.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/s-VkcjHqkGI/0.jpg)](https://www.youtube.com/watch?v=s-VkcjHqkGI)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=s-VkcjHqkGI)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/pacific-atlantic-water-flow)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force (Backtracking)






```csharp
public class Solution {
    int ROWS, COLS;
    bool pacific, atlantic;
    int[][] directions = new int[][] {
        new int[] {1, 0}, new int[] {-1, 0}, new int[] {0, 1}, new int[] {0, -1}
    };

    public List<List<int>> PacificAtlantic(int[][] heights) {
        ROWS = heights.Length;
        COLS = heights[0].Length;
        List<List<int>> res = new List<List<int>>();

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                pacific = false;
                atlantic = false;
                Dfs(heights, r, c, int.MaxValue);
                if (pacific && atlantic) {
                    res.Add(new List<int>{r, c});
                }
            }
        }
        return res;
    }

    private void Dfs(int[][] heights, int r, int c, int prevVal) {
        if (r < 0 || c < 0) {
            pacific = true;
            return;
        }
        if (r >= ROWS || c >= COLS) {
            atlantic = true;
            return;
        }
        if (heights[r][c] > prevVal) {
            return;
        }

        int tmp = heights[r][c];
        heights[r][c] = int.MaxValue;
        foreach (var dir in directions) {
            Dfs(heights, r + dir[0], c + dir[1], tmp);
            if (pacific && atlantic) {
                break;
            }
        }
        heights[r][c] = tmp;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n * 4 ^ {m * n})$
* Space complexity: $O(m * n)$

> Where $m$ is the number of rows and $n$ is the number of columns.

---

### 2. Depth First Search






```csharp
public class Solution {
    private int[][] directions = new int[][] { 
        new int[] { 1, 0 }, new int[] { -1, 0 }, 
        new int[] { 0, 1 }, new int[] { 0, -1 } 
    };
    public List<List<int>> PacificAtlantic(int[][] heights) {
        int ROWS = heights.Length, COLS = heights[0].Length;
        bool[,] pac = new bool[ROWS, COLS];
        bool[,] atl = new bool[ROWS, COLS];

        for (int c = 0; c < COLS; c++) {
            Dfs(0, c, pac, heights);
            Dfs(ROWS - 1, c, atl, heights);
        }
        for (int r = 0; r < ROWS; r++) {
            Dfs(r, 0, pac, heights);
            Dfs(r, COLS - 1, atl, heights);
        }

        List<List<int>> res = new List<List<int>>();
        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (pac[r, c] && atl[r, c]) {
                    res.Add(new List<int> { r, c });
                }
            }
        }
        return res;
    }

    private void Dfs(int r, int c, bool[,] ocean, int[][] heights) {
        ocean[r, c] = true;
        foreach (var dir in directions) {
            int nr = r + dir[0], nc = c + dir[1];
            if (nr >= 0 && nr < heights.Length && nc >= 0 && 
                nc < heights[0].Length && !ocean[nr, nc] && 
                heights[nr][nc] >= heights[r][c]) {
                Dfs(nr, nc, ocean, heights);
            }
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n)$
* Space complexity: $O(m * n)$

> Where $m$ is the number of rows and $n$ is the number of columns.

---

### 3. Breadth First Search






```csharp
public class Solution {
    private int[][] directions = new int[][] { 
        new int[] { 1, 0 }, new int[] { -1, 0 }, 
        new int[] { 0, 1 }, new int[] { 0, -1 } 
    };
    public List<List<int>> PacificAtlantic(int[][] heights) {
        int ROWS = heights.Length, COLS = heights[0].Length;
        bool[,] pac = new bool[ROWS, COLS];
        bool[,] atl = new bool[ROWS, COLS];

        Queue<int[]> pacQueue = new Queue<int[]>();
        Queue<int[]> atlQueue = new Queue<int[]>();

        for (int c = 0; c < COLS; c++) {
            pacQueue.Enqueue(new int[] { 0, c });
            atlQueue.Enqueue(new int[] { ROWS - 1, c });
        }
        for (int r = 0; r < ROWS; r++) {
            pacQueue.Enqueue(new int[] { r, 0 });
            atlQueue.Enqueue(new int[] { r, COLS - 1 });
        }

        Bfs(pacQueue, pac, heights);
        Bfs(atlQueue, atl, heights);

        List<List<int>> res = new List<List<int>>();
        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (pac[r, c] && atl[r, c]) {
                    res.Add(new List<int> { r, c });
                }
            }
        }
        return res;
    }

    private void Bfs(Queue<int[]> q, bool[,] ocean, int[][] heights) {
        while (q.Count > 0) {
            int[] cur = q.Dequeue();
            int r = cur[0], c = cur[1];
            ocean[r, c] = true;
            foreach (var dir in directions) {
                int nr = r + dir[0], nc = c + dir[1];
                if (nr >= 0 && nr < heights.Length && nc >= 0 && 
                    nc < heights[0].Length && !ocean[nr, nc] && 
                    heights[nr][nc] >= heights[r][c]) {
                    q.Enqueue(new int[] { nr, nc });
                }
            }
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n)$
* Space complexity: $O(m * n)$

> Where $m$ is the number of rows and $n$ is the number of columns.
