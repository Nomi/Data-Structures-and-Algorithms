# ⭐ | Redundant Connection

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
- [Union-Find](https://neetcode.io/courses/advanced-algorithms/7) [from NeetCode's Course(s)]


## Problem Description
You are given a connected **undirected graph** with `n` nodes labeled from `1` to `n`. Initially, it contained no cycles and consisted of `n-1` edges.

We have now added one additional edge to the graph. The edge has two **different** vertices chosen from `1` to `n`, and was not an edge that previously existed in the graph.

The graph is represented as an array `edges` of length `n` where `edges[i] = [ai, bi]` represents an edge between nodes `ai` and `bi` in the graph.

Return an edge that can be removed so that the graph is still a connected non-cyclical graph. If there are multiple answers, return the edge that appears last in the input `edges`.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/1a966522-e4d9-4215-18a1-4df7d26c3700/public)

```java
Input: edges = [[1,2],[1,3],[3,4],[2,4]]

Output: [2,4]
```

**Example 2:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/5cf17b17-8758-4f0a-8829-99cea143b100/public)

```java
Input: edges = [[1,2],[1,3],[1,4],[3,4],[4,5]]

Output: [3,4]
```

**Constraints:**
* `n == edges.length`
* `3 <= n <= 100`
* `1 <= edges[i][0] < edges[i][1] <= edges.length`
* There are no repeated edges and no self-loops in the input.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution as good or better than <code>O(V + E)</code> time and <code>O(V + E)</code> space, where <code>V</code> is the number vertices and <code>E</code> is the number of edges in the graph.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    There will be only one edge that creates the cycle in the given problem. Why? Because the graph is initially acyclic, and a cycle is formed only after adding one extra edge that was not present in the graph initially. Can you think of an algorithm that helps determine whether the current connecting edge forms a cycle? Perhaps a component-oriented algorithm?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use the Union-Find (DSU) algorithm to create the graph from the given edges. While connecting the edges, if we fail to connect any edge, it means this is the redundant edge, and we return it. How would you implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We create an instance of the DSU object and traverse through the given edges. For each edge, we attempt to connect the nodes using the union function. If the union function returns <code>false</code>, indicating that the current edge forms a cycle, we immediately return that edge.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/FXWRE67PLL0/0.jpg)](https://www.youtube.com/watch?v=FXWRE67PLL0)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=FXWRE67PLL0)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/redundant-connection)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Cycle Detection (DFS)






```csharp
public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        int n = edges.Length;
        List<List<int>> adj = new List<List<int>>();
        for (int i = 0; i <= n; i++) {
            adj.Add(new List<int>());
        }

        foreach (var edge in edges) {
            int u = edge[0], v = edge[1];
            adj[u].Add(v);
            adj[v].Add(u);
            bool[] visit = new bool[n + 1];

            if (Dfs(u, -1, adj, visit)) {
                return new int[] { u, v };
            }
        }
        return new int[0];
    }

    private bool Dfs(int node, int parent, 
                     List<List<int>> adj, bool[] visit) {
        if (visit[node]) return true;
        visit[node] = true;
        foreach (int nei in adj[node]) {
            if (nei == parent) continue;
            if (Dfs(nei, node, adj, visit)) return true;
        }
        return false;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(E * (V + E))$
* Space complexity: $O(V + E)$

> Where $V$ is the number of vertices and $E$ is the number of edges in the graph.

---

### 2. Depth First Search (Optimal)






```csharp
public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        int n = edges.Length;
        List<int>[] adj = new List<int>[n + 1];
        for (int i = 0; i <= n; i++) adj[i] = new List<int>();

        foreach (var edge in edges) {
            int u = edge[0], v = edge[1];
            adj[u].Add(v);
            adj[v].Add(u);
        }

        bool[] visit = new bool[n + 1];
        HashSet<int> cycle = new HashSet<int>();
        int cycleStart = -1;

        bool Dfs(int node, int par) {
            if (visit[node]) {
                cycleStart = node;
                return true;
            }
            visit[node] = true;
            foreach (int nei in adj[node]) {
                if (nei == par) continue;
                if (Dfs(nei, node)) {
                    if (cycleStart != -1) cycle.Add(node);
                    if (node == cycleStart) {
                        cycleStart = -1;
                    }
                    return true;
                }
            }
            return false;
        }

        Dfs(1, -1);

        for (int i = edges.Length - 1; i >= 0; i--) {
            int u = edges[i][0], v = edges[i][1];
            if (cycle.Contains(u) && cycle.Contains(v)) {
                return new int[] { u, v };
            }
        }
        return new int[0];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(V + E)$
* Space complexity: $O(V + E)$

> Where $V$ is the number of vertices and $E$ is the number of edges in the graph.

---

### 3. Topological Sort (Kahn's Algorithm)






```csharp
public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        int n = edges.Length;
        int[] indegree = new int[n + 1];
        List<int>[] adj = new List<int>[n + 1];
        for (int i = 0; i <= n; i++) adj[i] = new List<int>();
        foreach (var edge in edges) {
            int u = edge[0], v = edge[1];
            adj[u].Add(v);
            adj[v].Add(u);
            indegree[u]++;
            indegree[v]++;
        }

        Queue<int> q = new Queue<int>();
        for (int i = 1; i <= n; i++) {
            if (indegree[i] == 1) q.Enqueue(i);
        }

        while (q.Count > 0) {
            int node = q.Dequeue();
            indegree[node]--;
            foreach (int nei in adj[node]) {
                indegree[nei]--;
                if (indegree[nei] == 1) q.Enqueue(nei);
            }
        }

        for (int i = edges.Length - 1; i >= 0; i--) {
            int u = edges[i][0], v = edges[i][1];
            if (indegree[u] == 2 && indegree[v] > 0) 
                return new int[] {u, v};
        }
        return new int[0];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(V + E)$
* Space complexity: $O(V + E)$

> Where $V$ is the number of vertices and $E$ is the number of edges in the graph.

---

### 4. Disjoint Set Union






```csharp
public class Solution {
    
    public int[] FindRedundantConnection(int[][] edges) {
        int[] par = new int[edges.Length + 1];
        int[] rank = new int[edges.Length + 1];
        for (int i = 0; i < par.Length; i++) {
            par[i] = i;
            rank[i] = 1;
        }

        foreach (var edge in edges) {
            if (!Union(par, rank, edge[0], edge[1]))
                return new int[]{ edge[0], edge[1] };
        }
        return new int[0];
    }

    private int Find(int[] par, int n) {
        int p = par[n];
        while (p != par[p]) {
            par[p] = par[par[p]];
            p = par[p];
        }
        return p;
    }

    private bool Union(int[] par, int[] rank, int n1, int n2) {
        int p1 = Find(par, n1);
        int p2 = Find(par, n2);

        if (p1 == p2)
            return false;
        if (rank[p1] > rank[p2]) {
            par[p2] = p1;
            rank[p1] += rank[p2];
        } else {
            par[p1] = p2;
            rank[p2] += rank[p1];
        }
        return true;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(V + (E * α(V)))$
* Space complexity: $O(V)$

> Where $V$ is the number of vertices and $E$ is the number of edges in the graph. $α()$ is used for amortized complexity.
