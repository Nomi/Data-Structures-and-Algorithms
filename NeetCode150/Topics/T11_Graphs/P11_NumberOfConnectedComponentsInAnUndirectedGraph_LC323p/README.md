# ⭐ | Number of Connected Components In An Undirected Graph

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
There is an undirected graph with `n` nodes. There is also an `edges` array, where `edges[i] = [a, b]` means that there is an edge between node `a` and node `b` in the graph.

The nodes are numbered from `0` to `n - 1`.

Return the total number of connected components in that graph.

**Example 1:**

```java
Input:
n=3
edges=[[0,1], [0,2]]

Output:
1
```

**Example 2:**

```java
Input:
n=6
edges=[[0,1], [1,2], [2,3], [4,5]]

Output:
2
```

**Constraints:**
* `1 <= n <= 100`
* `0 <= edges.length <= n * (n - 1) / 2`

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
    Assume there are no edges initially, so we have <code>n</code> components, as there are that many nodes given. Now, we should add the given edges between the nodes. Can you think of an algorithm to add the edges between the nodes? Also, after adding an edge, how do you determine the number of components left?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use the Union-Find (DSU) algorithm to add the given edges. For simplicity, we use Union-Find by size, where we merge the smaller component into the larger one. The Union-Find algorithm inserts the edge only between two nodes from different components. It does not add the edge if the nodes are from the same component. How do you find the number of components after adding the edges? For example, consider that nodes <code>0</code> and <code>1</code> are not connected, so there are initially two components. After adding an edge between these nodes, they become part of the same component, leaving us with one component.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We create an object of the DSU and initialize the result variable <code>res = n</code>, which indicates that there are <code>n</code> components initially. We then iterate through the given edges. For each edge, we attempt to connect the nodes using the union function of the DSU. If the union is successful, we decrement <code>res</code>; otherwise, we continue. Finally, we return <code>res</code> as the number of components.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/8f1XPm4WOUc/0.jpg)](https://www.youtube.com/watch?v=8f1XPm4WOUc)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=8f1XPm4WOUc)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/count-connected-components)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Depth First Search






```csharp
public class Solution {
    public int CountComponents(int n, int[][] edges) {
        List<List<int>> adj = new List<List<int>>();
        bool[] visit = new bool[n];
        for (int i = 0; i < n; i++) {
            adj.Add(new List<int>());
        }
        foreach (var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        int res = 0;
        for (int node = 0; node < n; node++) {
            if (!visit[node]) {
                Dfs(adj, visit, node);
                res++;
            }
        }
        return res;
    }

    private void Dfs(List<List<int>> adj, bool[] visit, int node) {
        visit[node] = true;
        foreach (var nei in adj[node]) {
            if (!visit[nei]) {
                Dfs(adj, visit, nei);
            }
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(V + E)$
* Space complexity: $O(V + E)$

> Where $V$ is the number of vertices and $E$ is the number of edges in the graph.

---

### 2. Breadth First Search






```csharp
public class Solution {
    public int CountComponents(int n, int[][] edges) {
        List<List<int>> adj = new List<List<int>>();
        bool[] visit = new bool[n];
        for (int i = 0; i < n; i++) {
            adj.Add(new List<int>());
        }
        foreach (var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        int res = 0;
        for (int node = 0; node < n; node++) {
            if (!visit[node]) {
                Bfs(adj, visit, node);
                res++;
            }
        }
        return res;
    }

    private void Bfs(List<List<int>> adj, bool[] visit, int node) {
        Queue<int> q = new Queue<int>();
        q.Enqueue(node);
        visit[node] = true;
        while (q.Count > 0) {
            int cur = q.Dequeue();
            foreach (var nei in adj[cur]) {
                if (!visit[nei]) {
                    visit[nei] = true;
                    q.Enqueue(nei);
                }
            }
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(V + E)$
* Space complexity: $O(V + E)$

> Where $V$ is the number of vertices and $E$ is the number of edges in the graph.

---

### 3. Disjoint Set Union (Rank | Size)






```csharp
public class DSU {
    private int[] parent;
    private int[] rank;

    public DSU(int n) {
        parent = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i;
            rank[i] = 1;
        }
    }

    public int Find(int node) {
        int cur = node;
        while (cur != parent[cur]) {
            parent[cur] = parent[parent[cur]];
            cur = parent[cur];
        }
        return cur;
    }

    public bool Union(int u, int v) {
        int pu = Find(u);
        int pv = Find(v);
        if (pu == pv) {
            return false;
        }
        if (rank[pv] > rank[pu]) {
            int temp = pu;
            pu = pv;
            pv = temp;
        }
        parent[pv] = pu;
        rank[pu] += rank[pv];
        return true;
    }
}

public class Solution {
    public int CountComponents(int n, int[][] edges) {
        DSU dsu = new DSU(n);
        int res = n;
        foreach (var edge in edges) {
            if (dsu.Union(edge[0], edge[1])) {
                res--;
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(V + (E * α(V)))$
* Space complexity: $O(V)$

> Where $V$ is the number of vertices and $E$ is the number of edges in the graph. $α()$ is used for amortized complexity.
