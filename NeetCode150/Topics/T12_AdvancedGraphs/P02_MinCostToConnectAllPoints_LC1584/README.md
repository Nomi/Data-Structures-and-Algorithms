# ⭐ | Min Cost to Connect All Points

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
- [Adjacency List](https://neetcode.io/courses/dsa-for-beginners/31) [from NeetCode's Course(s)]
- [Prim's](https://neetcode.io/courses/advanced-algorithms/15) [from NeetCode's Course(s)]
- [Kruskal's](https://neetcode.io/courses/advanced-algorithms/16) [from NeetCode's Course(s)]


## Problem Description
You are given a 2-D integer array `points`, where `points[i] = [xi, yi]`. Each `points[i]` represents a distinct point on a 2-D plane.

The cost of connecting two points `[xi, yi]` and `[xj, yj]` is the **manhattan distance** between the two points, i.e. `|xi - xj| + |yi - yj|`.

Return the minimum cost to connect all points together, such that there exists exactly one path between each pair of points.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/e0cd5270-73b5-42d4-3c3f-5451f795ca00/public)

```java
Input: points = [[0,0],[2,2],[3,3],[2,4],[4,2]]

Output: 10
```

**Constraints:**
* `1 <= points.length <= 1000`
* `-1000 <= xi, yi <= 1000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution as good or better than <code>O((n^2)logn)</code> time and <code>O(n^2)</code> space, where <code>n</code> is the number of points.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    Think of this problem as a graph, where the given points represent nodes. We need to connect these nodes into a single component by creating edges. Can you think of an advanced graph algorithm that can be used to connect all points into one component?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We use Kruskal's algorithm along with Union-Find (DSU) to connect nodes into components. The final component forms the minimum spanning tree (MST), where the edges between nodes are weighted by the Manhattan distance, and the total weight of the tree is minimized. How would you implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We create the possible edges by iterating through every pair of points and calculating the weights as the Manhattan distance between them. Next, we sort the edges in ascending order based on their weights, as we aim to minimize the cost. Then, we traverse through these edges, connecting the nodes and adding the weight of the edge to the total cost if the edge is successfully added. The final result will be the minimum cost.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/f7JOBJIC-NA/0.jpg)](https://www.youtube.com/watch?v=f7JOBJIC-NA)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=f7JOBJIC-NA)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/min-cost-to-connect-points)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Kruskal's Algorithm






```csharp
public class DSU {
    public int[] Parent, Size;
    
    public DSU(int n) {
        Parent = new int[n + 1];
        Size = new int[n + 1];
        for (int i = 0; i <= n; i++) Parent[i] = i;
        Array.Fill(Size, 1);
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
        if (Size[pu] < Size[pv]) {
            int temp = pu;
            pu = pv;
            pv = temp;
        }
        Size[pu] += Size[pv];
        Parent[pv] = pu;
        return true;
    }
}

public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        int n = points.Length;
        DSU dsu = new DSU(n);
        List<(int, int, int)> edges = new List<(int, int, int)>();

        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                int dist = Math.Abs(points[i][0] - points[j][0]) + 
                           Math.Abs(points[i][1] - points[j][1]);
                edges.Add((dist, i, j));
            }
        }

        edges.Sort((a, b) => a.Item1.CompareTo(b.Item1));
        int res = 0;

        foreach (var edge in edges) {
            if (dsu.Union(edge.Item2, edge.Item3)) {
                res += edge.Item1;
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2 \log n)$
* Space complexity: $O(n ^ 2)$

---

### 2. Prim's Algorithm






```csharp
public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        int N = points.Length;
        var adj = new Dictionary<int, List<int[]>>();
        for (int i = 0; i < N; i++) {
            int x1 = points[i][0];
            int y1 = points[i][1];
            for (int j = i + 1; j < N; j++) {
                int x2 = points[j][0];
                int y2 = points[j][1];
                int dist = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
                if (!adj.ContainsKey(i))
                    adj[i] = new List<int[]>();
                adj[i].Add(new int[] { j, dist });

                if (!adj.ContainsKey(j))
                    adj[j] = new List<int[]>();
                adj[j].Add(new int[] { i, dist });
            }
        }

        int res = 0;
        var visit = new HashSet<int>();
        var pq = new PriorityQueue<int, int>(); 
        pq.Enqueue(0, 0); 

        while (visit.Count < N && pq.Count > 0) {
            if (pq.TryPeek(out int i, out int cost)) {
                pq.Dequeue();

                if (visit.Contains(i)) {
                    continue;
                }

                res += cost;
                visit.Add(i);

                if (adj.ContainsKey(i)) {
                    foreach (var edge in adj[i]) {
                        var nei = edge[0];
                        var neiCost = edge[1];
                        if (!visit.Contains(nei)) {
                            pq.Enqueue(nei, neiCost);
                        }
                    }
                }
            }
        }
        return visit.Count == N ? res : -1;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2 \log n)$
* Space complexity: $O(n ^ 2)$

---

### 3. Prim's Algorithm (Optimal)






```csharp
public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        int n = points.Length, node = 0;
        int[] dist = new int[n];
        bool[] visit = new bool[n];
        Array.Fill(dist, 100000000);
        int edges = 0, res = 0;

        while (edges < n - 1) {
            visit[node] = true;
            int nextNode = -1;
            for (int i = 0; i < n; i++) {
                if (visit[i]) continue;
                int curDist = Math.Abs(points[i][0] - points[node][0]) + 
                               Math.Abs(points[i][1] - points[node][1]);
                dist[i] = Math.Min(dist[i], curDist);
                if (nextNode == -1 || dist[i] < dist[nextNode]) {
                    nextNode = i;
                }
            }
            res += dist[nextNode];
            node = nextNode;
            edges++;
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(n)$
