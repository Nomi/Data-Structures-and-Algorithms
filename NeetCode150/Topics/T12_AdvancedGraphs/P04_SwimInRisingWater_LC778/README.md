# ⭐ | Swim In Rising Water

|   | Difficulty | Tricky |
|---|------------|--------|
| <big>⭐<big> | <big>**🟥 Hard**</big> | <big></big> |


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
- [Adjacency List](https://neetcode.io/courses/dsa-for-beginners/31) [from NeetCode's Course(s)]
- [Dijkstra's](https://neetcode.io/courses/advanced-algorithms/14) [from NeetCode's Course(s)]


## Problem Description
You are given a square 2-D matrix of distinct integers `grid` where each integer `grid[i][j]` represents the elevation at position `(i, j)`.

Rain starts to fall at time = `0`, which causes the water level to rise. At time `t`, the water level across the entire grid is `t`.

You may swim either horizontally or vertically in the grid between two adjacent squares if the original elevation of both squares is less than or equal to the water level at time `t`.

Starting from the top left square `(0, 0)`, return the minimum amount of time it will take until it is possible to reach the bottom right square `(n - 1, n - 1)`.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/11a45dd8-625f-4be6-9fbb-a3b6ffcc1100/public)

```java
Input: grid = [[0,1],[2,3]]

Output: 3
```

Explanation: For a path to exist to the bottom right square `grid[1][1]` the water elevation must be at least `3`. At time `t = 3`, the water level is `3`.

**Example 2:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/e585e59c-a1f9-4d10-538d-9e52bcdb6200/public)

```java
Input: grid = [
  [0,1,2,10],
  [9,14,4,13],
  [12,3,8,15],
  [11,5,7,6]]
]

Output: 8
```

Explanation: The water level must be at least `8` to reach the bottom right square. The path is `[0, 1, 2, 4, 8, 7, 6]`.

**Constraints:**
* `grid.length == grid[i].length`
* `1 <= grid.length <= 50`
* `0 <= grid[i][j] < n^2`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O((n^2)logn)</code> time and <code>O(n^2)</code> space, where <code>n</code> is the number of rows or columns of the square matrix.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    Think of this problem as a graph where each cell represents a node. You can move from one cell to its adjacent cell if the time is greater than or equal to the adjacent cell's elevation. Note that swimming does not cost time, but you may need to wait at a cell for the time to reach the required elevation. What do you notice about the path from <code>(0, 0)</code> to <code>(n - 1, n - 1)</code>? Perhaps a greedy approach would be useful here.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can observe that the maximum elevation value along the path determines the time taken for that path. Therefore, we need to find the path where the maximum elevation is minimized. Can you think of an algorithm to find such a path from the source <code>(0, 0)</code> to the destination <code>(n - 1, n - 1)</code>? Perhaps a shortest path algorithm could be useful here.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We can use Dijkstra's algorithm. We initialize a Min-heap and a matrix with infinity. We run the algorithm starting from the source <code>(0, 0)</code>, and we track the maximum elevation encountered along the paths. This maximum elevation is used as the key for comparison in Dijkstra's algorithm. If we encounter the destination <code>(n - 1, n - 1)</code>, we return the maximum elevation of the path that reached the destination.  
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/amvrKlMLuGY/0.jpg)](https://www.youtube.com/watch?v=amvrKlMLuGY)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=amvrKlMLuGY)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/swim-in-rising-water)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public int SwimInWater(int[][] grid) {
        int n = grid.Length;
        bool[][] visit = new bool[n][];
        for (int i = 0; i < n; i++) {
            visit[i] = new bool[n];
        }
        return Dfs(grid, visit, 0, 0, 0);
    }

    private int Dfs(int[][] grid, bool[][] visit, 
                    int r, int c, int t) {
        int n = grid.Length;
        if (r < 0 || c < 0 || r >= n || 
            c >= n || visit[r][c]) {
            return 1000000;
        }
        if (r == n - 1 && c == n - 1) {
            return Math.Max(t, grid[r][c]);
        }
        visit[r][c] = true;
        t = Math.Max(t, grid[r][c]);
        int res = Math.Min(Math.Min(Dfs(grid, visit, r + 1, c, t),
                                     Dfs(grid, visit, r - 1, c, t)),
                           Math.Min(Dfs(grid, visit, r, c + 1, t),
                                    Dfs(grid, visit, r, c - 1, t)));
        visit[r][c] = false;
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(4 ^ {n ^ 2})$
* Space complexity: $O(n ^ 2)$

---

### 2. Depth First Search






```csharp
public class Solution {
    public int SwimInWater(int[][] grid) {
        int n = grid.Length;
        bool[][] visit = new bool[n][];
        for (int i = 0; i < n; i++) {
            visit[i] = new bool[n];
        }
        int minH = grid[0][0], maxH = grid[0][0];
        for (int row = 0; row < n; row++) {
            for (int col = 0; col < n; col++) {
                maxH = Math.Max(maxH, grid[row][col]);
                minH = Math.Min(minH, grid[row][col]);
            }
        }

        for (int t = minH; t < maxH; t++) {
            if (dfs(grid, visit, 0, 0, t)) {
                return t;
            }
            for (int r = 0; r < n; r++) {
                Array.Fill(visit[r], false);
            }
        }
        return maxH;
    }

    private bool dfs(int[][] grid, bool[][] visit, int r, int c, int t) {
        if (r < 0 || c < 0 || r >= grid.Length || 
            c >= grid.Length || visit[r][c] || grid[r][c] > t) {
            return false;
        }
        if (r == grid.Length - 1 && c == grid.Length - 1) {
            return true;
        }
        visit[r][c] = true;
        return dfs(grid, visit, r + 1, c, t) || 
               dfs(grid, visit, r - 1, c, t) || 
               dfs(grid, visit, r, c + 1, t) || 
               dfs(grid, visit, r, c - 1, t);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 4)$
* Space complexity: $O(n ^ 2)$

---

### 3. Binary Search + DFS






```csharp
public class Solution {
    public int SwimInWater(int[][] grid) {
        int n = grid.Length;
        bool[][] visit = new bool[n][];
        for (int i = 0; i < n; i++) {
            visit[i] = new bool[n];
        }
        int minH = grid[0][0], maxH = grid[0][0];
        for (int row = 0; row < n; row++) {
            for (int col = 0; col < n; col++) {
                maxH = Math.Max(maxH, grid[row][col]);
                minH = Math.Min(minH, grid[row][col]);
            }
        }

        int l = minH, r = maxH;
        while (l < r) {
            int m = (l + r) >> 1;
            if (dfs(grid, visit, 0, 0, m)) {
                r = m;
            } else {
                l = m + 1;
            }
            for (int row = 0; row < n; row++) {
                Array.Fill(visit[row], false);
            }
        }
        return r;
    }

    private bool dfs(int[][] grid, bool[][] visit, int r, int c, int t) {
        if (r < 0 || c < 0 || r >= grid.Length || 
            c >= grid.Length || visit[r][c] || grid[r][c] > t) {
            return false;
        }
        if (r == grid.Length - 1 && c == grid.Length - 1) {
            return true;
        }
        visit[r][c] = true;
        return dfs(grid, visit, r + 1, c, t) || 
               dfs(grid, visit, r - 1, c, t) || 
               dfs(grid, visit, r, c + 1, t) || 
               dfs(grid, visit, r, c - 1, t);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2 \log n)$
* Space complexity: $O(n ^ 2)$

---

### 4. Dijkstra's Algorithm






```csharp
public class Solution {
    public int SwimInWater(int[][] grid) {
        int N = grid.Length;
        var visit = new HashSet<(int, int)>();
        var minHeap = new PriorityQueue<(int t, int r, int c), int>();
        int[][] directions = { 
            new int[]{0, 1}, new int[]{0, -1}, 
            new int[]{1, 0}, new int[]{-1, 0} 
        };

        minHeap.Enqueue((grid[0][0], 0, 0), grid[0][0]);
        visit.Add((0, 0));

        while (minHeap.Count > 0) {
            var curr = minHeap.Dequeue();
            int t = curr.t, r = curr.r, c = curr.c;
            if (r == N - 1 && c == N - 1) {
                return t;
            }
            foreach (var dir in directions) {
                int neiR = r + dir[0], neiC = c + dir[1];
                if (neiR < 0 || neiC < 0 || neiR >= N || 
                    neiC >= N || visit.Contains((neiR, neiC))) {
                    continue;
                }
                visit.Add((neiR, neiC));
                minHeap.Enqueue(
                    (Math.Max(t, grid[neiR][neiC]), neiR, neiC), 
                    Math.Max(t, grid[neiR][neiC]));
            }
        }

        return N * N;  
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2 \log n)$
* Space complexity: $O(n ^ 2)$

---

### 5. Kruskal's Algorithm






```csharp
public class DSU {
    private int[] Parent, Size;

    public DSU(int n) {
        Parent = new int[n + 1];
        Size = new int[n + 1];
        for (int i = 0; i <= n; i++) Parent[i] = i;
        Array.Fill(Size, 1);
    }

    public int Find(int node) {
        if (Parent[node] != node)
            Parent[node] = Find(Parent[node]);
        return Parent[node];
    }

    public bool Union(int u, int v) {
        int pu = Find(u), pv = Find(v);
        if (pu == pv) return false;
        if (Size[pu] < Size[pv]) {
            int temp = pu;
            pu = pv;
            pv = temp;
        }
        Size[pu] += Size[pv];
        Parent[pv] = pu;
        return true;
    }

    public bool Connected(int u, int v) {
        return Find(u) == Find(v);
    }
}

public class Solution {
    public int SwimInWater(int[][] grid) {
        int N = grid.Length;
        DSU dsu = new DSU(N * N);
        List<int[]> positions = new List<int[]>();
        for (int r = 0; r < N; r++)
            for (int c = 0; c < N; c++)
                positions.Add(new int[] {grid[r][c], r, c});
        positions.Sort((a, b) => a[0] - b[0]);
        int[][] directions = new int[][] { 
            new int[] {0, 1}, new int[] {1, 0}, 
            new int[] {0, -1}, new int[] {-1, 0} 
        };

        foreach (var pos in positions) {
            int t = pos[0], r = pos[1], c = pos[2];
            foreach (var dir in directions) {
                int nr = r + dir[0], nc = c + dir[1];
                if (nr >= 0 && nr < N && nc >= 0 && 
                    nc < N && grid[nr][nc] <= t) {
                    dsu.Union(r * N + c, nr * N + nc);
                }
            }
            if (dsu.Connected(0, N * N - 1)) return t;
        }
        return N * N;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2 \log n)$
* Space complexity: $O(n ^ 2)$
