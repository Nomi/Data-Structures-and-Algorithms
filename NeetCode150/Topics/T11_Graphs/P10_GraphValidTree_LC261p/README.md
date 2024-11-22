# ⭐ | Graph Valid Tree

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


## Problem Description
Given `n` nodes labeled from `0` to `n - 1` and a list of **undirected** edges (each edge is a pair of nodes), write a function to check whether these edges make up a valid tree.

**Example 1:**

```java
Input:
n = 5
edges = [[0, 1], [0, 2], [0, 3], [1, 4]]

Output:
true
```

**Example 2:**

```java
Input:
n = 5
edges = [[0, 1], [1, 2], [2, 3], [1, 3], [1, 4]]

Output:
false
```

**Note:**
* You can assume that no duplicate edges will appear in edges. Since all edges are `undirected`, `[0, 1]` is the same as `[1, 0]` and thus will not appear together in edges.

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
    According to the definition of a tree, a tree is an undirected graph with no cycles, all the nodes are connected as one component, and any two nodes have exactly one path. Can you think of a recursive algorithm to detect a cycle in the given graph and ensure it is a tree?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use the Depth First Search (DFS) algorithm to detect a cycle in the graph. Since a tree has only one component, we can start the DFS from any node, say node <code>0</code>. During the traversal, we recursively visit its neighbors (children). If we encounter any already visited node that is not the parent of the current node, we return false as it indicates a cycle. How would you implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We start DFS from node <code>0</code>, assuming <code>-1</code> as its parent. We initialize a hash set <code>visit</code> to track the visited nodes in the graph. During the DFS, we first check if the current node is already in <code>visit</code>. If it is, we return false, detecting a cycle. Otherwise, we mark the node as visited and perform DFS on its neighbors, skipping the parent node to avoid revisiting it. After all DFS calls, if we have visited all nodes, we return true, as the graph is connected. Otherwise, we return false because a tree must contain all nodes.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/bXsUuownnoQ/0.jpg)](https://www.youtube.com/watch?v=bXsUuownnoQ)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=bXsUuownnoQ)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/valid-tree)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Cycle Detection (DFS)






```csharp
public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        if (edges.Length > n - 1) {
            return false;
        }

        List<List<int>> adj = new List<List<int>>();
        for (int i = 0; i < n; i++) {
            adj.Add(new List<int>());
        }

        foreach (var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        HashSet<int> visit = new HashSet<int>();
        if (!Dfs(0, -1, visit, adj)) {
            return false;
        }

        return visit.Count == n;
    }

    private bool Dfs(int node, int parent, HashSet<int> visit, 
                     List<List<int>> adj) {
        if (visit.Contains(node)) {
            return false;
        }

        visit.Add(node);
        foreach (var nei in adj[node]) {
            if (nei == parent) {
                continue;
            }
            if (!Dfs(nei, node, visit, adj)) {
                return false;
            }
        }
        return true;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(V + E)$
* Space complexity: $O(V + E)$

> Where $V$ is the number vertices and $E$ is the number of edges in the graph.

---

### 2. Breadth First Search






```csharp
public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        if (edges.Length > n - 1) {
            return false;
        }

        List<List<int>> adj = new List<List<int>>();
        for (int i = 0; i < n; i++) {
            adj.Add(new List<int>());
        }

        foreach (var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        HashSet<int> visit = new HashSet<int>();
        Queue<(int, int)> q = new Queue<(int, int)>();
        q.Enqueue((0, -1));  // (current node, parent node)
        visit.Add(0);

        while (q.Count > 0) {
            var (node, parent) = q.Dequeue();
            foreach (var nei in adj[node]) {
                if (nei == parent) {
                    continue;
                }
                if (visit.Contains(nei)) {
                    return false;
                }
                visit.Add(nei);
                q.Enqueue((nei, node));
            }
        }

        return visit.Count == n;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(V + E)$
* Space complexity: $O(V + E)$

> Where $V$ is the number vertices and $E$ is the number of edges in the graph.

---

### 3. Disjoint Set Union






```csharp
public class DSU {
    private int[] Parent, Size;
    private int comps;

    public DSU(int n) {
        comps = n;
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
        if (Size[pu] < Size[pv]) {
            int temp = pu;
            pu = pv;
            pv = temp;
        }
        comps--;
        Size[pu] += Size[pv];
        Parent[pv] = pu;
        return true;
    }

    public int Components() {
        return comps;
    }
}

public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        if (edges.Length > n - 1) {
            return false;
        }

        DSU dsu = new DSU(n);
        foreach (var edge in edges) {
            if (!dsu.Union(edge[0], edge[1])) {
                return false;
            }
        }
        return dsu.Components() == 1;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(V + (E * α(V)))$
* Space complexity: $O(V)$

> Where $V$ is the number of vertices and $E$ is the number of edges in the graph. $α()$ is used for amortized complexity.
