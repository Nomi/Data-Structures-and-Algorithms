# ⭐ | Surrounded Regions

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
You are given a 2-D matrix `board` containing `'X'` and `'O'` characters.

If a continous, four-directionally connected group of `'O'`s is surrounded by `'X'`s, it is considered to be **surrounded**. 

Change all **surrounded** regions of `'O'`s to `'X'`s and do so **in-place** by modifying the input board.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/9e6916bf-0e25-4e15-9619-cbc42d2d8f00/public)

```java
Input: board = [
  ["X","X","X","X"],
  ["X","O","O","X"],
  ["X","O","O","X"],
  ["X","X","X","O"]
]

Output: [
  ["X","X","X","X"],
  ["X","X","X","X"],
  ["X","X","X","X"],
  ["X","X","X","O"]
]
```

Explanation: Note that regions that are on the border are not considered surrounded regions.

**Constraints:**
* `1 <= board.length, board[i].length <= 200`
* `board[i][j]` is `'X'` or `'O'`.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(m * n)</code> time and <code>O(m * n)</code> space, where <code>m</code> is the number of rows and <code>n</code> is the number of columns in the matrix.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    We observe that we need to capture the regions that are not connected to the <code>O</code>'s on the border of the matrix. This means there should be no path connecting the <code>O</code>'s on the border to any <code>O</code>'s in the region. Can you think of a way to check the region connected to these border <code>O</code>'s?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use the Depth First Search (<code>DFS</code>) algorithm. Instead of checking the region connected to the border <code>O</code>'s, we can reverse the approach and mark the regions that are reachable from the border <code>O</code>'s. How would you implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We run the DFS from every <code>'O'</code> on the border of the matrix, visiting the neighboring cells that are equal to <code>'O'</code> recursively and marking them as <code>'#'</code> to avoid revisiting. After completing all the DFS calls, we traverse the matrix again and capture the cells where <code>matrix[i][j] == 'O'</code>, and unmark the cells back to <code>'O'</code> where <code>matrix[i][j] == '#'</code>.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/9z2BunfoZ5Y/0.jpg)](https://www.youtube.com/watch?v=9z2BunfoZ5Y)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=9z2BunfoZ5Y)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/surrounded-regions)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Depth First Search






```csharp
public class Solution {
    private int ROWS, COLS;

    public void Solve(char[][] board) {
        ROWS = board.Length;
        COLS = board[0].Length;

        for (int r = 0; r < ROWS; r++) {
            if (board[r][0] == 'O') {
                Capture(board, r, 0);
            }
            if (board[r][COLS - 1] == 'O') {
                Capture(board, r, COLS - 1);
            }
        }

        for (int c = 0; c < COLS; c++) {
            if (board[0][c] == 'O') {
                Capture(board, 0, c);
            }
            if (board[ROWS - 1][c] == 'O') {
                Capture(board, ROWS - 1, c);
            }
        }

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (board[r][c] == 'O') {
                    board[r][c] = 'X';
                } else if (board[r][c] == 'T') {
                    board[r][c] = 'O';
                }
            }
        }
    }

    private void Capture(char[][] board, int r, int c) {
        if (r < 0 || c < 0 || r == ROWS || 
            c == COLS || board[r][c] != 'O') {
            return;
        }
        board[r][c] = 'T';
        Capture(board, r + 1, c);
        Capture(board, r - 1, c);
        Capture(board, r, c + 1);
        Capture(board, r, c - 1);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n)$
* Space complexity: $O(m * n)$

> Where $m$ is the number of rows and $n$ is the number of columns of the $board$.

---

### 2. Breadth First Search






```csharp
public class Solution {
    private int ROWS, COLS;
    private int[][] directions = new int[][] { 
        new int[] { 1, 0 }, new int[] { -1, 0 }, 
        new int[] { 0, 1 }, new int[] { 0, -1 } 
    };

    public void Solve(char[][] board) {
        ROWS = board.Length;
        COLS = board[0].Length;

        Capture(board);

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (board[r][c] == 'O') {
                    board[r][c] = 'X';
                } else if (board[r][c] == 'T') {
                    board[r][c] = 'O';
                }
            }
        }
    }

    private void Capture(char[][] board) {
        Queue<int[]> q = new Queue<int[]>();
        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (r == 0 || r == ROWS - 1 || 
                    c == 0 || c == COLS - 1 && 
                    board[r][c] == 'O') {
                    q.Enqueue(new int[] { r, c });
                }
            }
        }
        while (q.Count > 0) {
            int[] cell = q.Dequeue();
            int r = cell[0], c = cell[1];
            if (board[r][c] == 'O') {
                board[r][c] = 'T';
                foreach (var direction in directions) {
                    int nr = r + direction[0];
                    int nc = c + direction[1];
                    if (nr >= 0 && nr < ROWS && 
                        nc >= 0 && nc < COLS) {
                        q.Enqueue(new int[] { nr, nc });
                    }
                }
            }
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n)$
* Space complexity: $O(m * n)$

> Where $m$ is the number of rows and $n$ is the number of columns of the $board$.

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
        if (Parent[node] != node) {
            Parent[node] = Find(Parent[node]);
        }
        return Parent[node];
    }

    public bool Union(int u, int v) {
        int pu = Find(u), pv = Find(v);
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

    public bool Connected(int u, int v) {
        return Find(u) == Find(v);
    }
}

public class Solution {
    public void Solve(char[][] board) {
        int ROWS = board.Length, COLS = board[0].Length;
        DSU dsu = new DSU(ROWS * COLS + 1);
        int[][] directions = new int[][] { 
            new int[] { 1, 0 }, new int[] { -1, 0 }, 
            new int[] { 0, 1 }, new int[] { 0, -1 } 
        };

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (board[r][c] != 'O') continue;
                if (r == 0 || c == 0 || 
                    r == ROWS - 1 || c == COLS - 1) {
                    dsu.Union(ROWS * COLS, r * COLS + c);
                } else {
                    foreach (var dir in directions) {
                        int nr = r + dir[0], nc = c + dir[1];
                        if (board[nr][nc] == 'O') {
                            dsu.Union(r * COLS + c, nr * COLS + nc);
                        }
                    }
                }
            }
        }

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (!dsu.Connected(ROWS * COLS, r * COLS + c)) {
                    board[r][c] = 'X';
                }
            }
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n)$
* Space complexity: $O(m * n)$

> Where $m$ is the number of rows and $n$ is the number of columns of the $board$.
