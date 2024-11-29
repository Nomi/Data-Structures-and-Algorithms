# ⭐ | Network Delay Time

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
- [Dijkstra's](https://neetcode.io/courses/advanced-algorithms/14) [from NeetCode's Course(s)]


## Problem Description
You are given a network of `n` directed nodes, labeled from `1` to `n`. You are also given `times`, a list of directed edges where `times[i] = (ui, vi, ti)`. 
    
* `ui` is the source node (an integer from `1` to `n`)
* `vi` is the target node (an integer from `1` to `n`)
* `ti` is the time it takes for a signal to travel from the source to the target node (an integer greater than or equal to `0`).

You are also given an integer `k`, representing the node that we will send a signal from.

Return the **minimum** time it takes for all of the `n` nodes to receive the signal. If it is impossible for all the nodes to receive the signal, return `-1` instead.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/ba9b9be8-b888-45d6-627a-e719d1ac4e00/public)

```java
Input: times = [[1,2,1],[2,3,1],[1,4,4],[3,4,1]], n = 4, k = 1

Output: 3
```

**Example 2:**

```java
Input: times = [[1,2,1],[2,3,1]], n = 3, k = 2

Output: -1
```

**Constraints:**
* `1 <= k <= n <= 100`
* `1 <= times.length <= 1000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution as good or better than <code>O(ElogV)</code> time and <code>O(V + E)</code> space, where <code>E</code> is the number of edges and <code>V</code> is the number of vertices (nodes).
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    As we are given the source node and we need to find the minimum time to reach all nodes, this represents the shortest path from the source node to all nodes. Can you think of a standard algorithm to find the shortest path from a source to a destination? Maybe a heap-based algorithm is helpful.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use Dijkstra's algorithm to find the shortest path from a source to destination. We end up finding the shortest paths from the source to the nodes that we encounter in finding the destination. So, to find shortest path for all nodes from the source, we need to perform Dijkstra's algorithm until the heap in this algorithm becomes empty. How would you implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We use a Min-Heap as we need to find the minimum time. We create an adjacency list for the given times (weighted edges). We also initialize an array <code>dist[]</code> of size <code>n</code> (number of nodes) which represents the distance from the source to all nodes, initialized with infinity. We put <code>dist[source] = 0</code>. Then we continue the algorithm. After the heap becomes empty, if we don't visit any node, we return <code>-1</code>; otherwise, we return the time.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/EaphyqKU4PQ/0.jpg)](https://www.youtube.com/watch?v=EaphyqKU4PQ)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=EaphyqKU4PQ)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/network-delay-time)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Depth First Search






```csharp
public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        var adj = new Dictionary<int, List<int[]>>();
        foreach (var time in times) {
            if (!adj.ContainsKey(time[0])) {
                adj[time[0]] = new List<int[]>();
            }
            adj[time[0]].Add(new int[] { time[1], time[2] });
        }

        var dist = new Dictionary<int, int>();
        for (int i = 1; i <= n; i++) dist[i] = int.MaxValue;

        Dfs(k, 0, adj, dist);
        int res = dist.Values.Max();
        return res == int.MaxValue ? -1 : res;
    }

    private void Dfs(int node, int time, 
                     Dictionary<int, List<int[]>> adj, 
                     Dictionary<int, int> dist) {
        if (time >= dist[node]) return;
        dist[node] = time;
        if (!adj.ContainsKey(node)) return;
        foreach (var edge in adj[node]) {
            Dfs(edge[0], time + edge[1], adj, dist);
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(V * E)$
* Space complexity: $O(V + E)$

> Where $V$ is the number of vertices and $E$ is the number of edges.

---

### 2. Floyd Warshall Algorithm






```csharp
public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        int inf = int.MaxValue / 2;
        int[,] dist = new int[n, n];
        
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                dist[i, j] = i == j ? 0 : inf;
            }
        }
        
        foreach (var time in times) {
            int u = time[0] - 1, v = time[1] - 1, w = time[2];
            dist[u, v] = w;
        }
        
        for (int mid = 0; mid < n; mid++)
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    dist[i, j] = Math.Min(dist[i, j], 
                                          dist[i, mid] + dist[mid, j]);
        
        int res = Enumerable.Range(0, n).Select(i => dist[k-1, i]).Max();
        return res == inf ? -1 : res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(V ^ 3)$
* Space complexity: $O(V ^ 2)$

> Where $V$ is the number of vertices.

---

### 3. Bellman Ford Algorithm






```csharp
public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        int[] dist = Enumerable.Repeat(int.MaxValue, n).ToArray();
        dist[k - 1] = 0;

        for (int i = 0; i < n - 1; i++) {
            foreach (var time in times) {
                int u = time[0] - 1, v = time[1] - 1, w = time[2];
                if (dist[u] != int.MaxValue && dist[u] + w < dist[v]) {
                    dist[v] = dist[u] + w;
                }
            }
        }

        int maxDist = dist.Max();
        return maxDist == int.MaxValue ? -1 : maxDist;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(V * E)$
* Space complexity: $O(V)$

> Where $V$ is the number of vertices and $E$ is the number of edges.

---

### 4. Shortest Path Faster Algorithm






```csharp
public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        var adj = new Dictionary<int, List<int[]>>();
        for (int i = 1; i <= n; i++) adj[i] = new List<int[]>();
        foreach (var time in times) {
            adj[time[0]].Add(new int[] {time[1], time[2]});
        }
        
        var dist = new Dictionary<int, int>();
        for (int i = 1; i <= n; i++) dist[i] = int.MaxValue;
        dist[k] = 0;

        var q = new Queue<int[]>();
        q.Enqueue(new int[] {k, 0});

        while (q.Count > 0) {
            var curr = q.Dequeue();
            int node = curr[0], time = curr[1];
            if (dist[node] < time) continue;
            foreach (var nei in adj[node]) {
                int nextNode = nei[0], weight = nei[1];
                if (time + weight < dist[nextNode]) {
                    dist[nextNode] = time + weight;
                    q.Enqueue(new int[] {nextNode, time + weight});
                }
            }
        }

        int res = 0;
        foreach (var time in dist.Values) { 
            res = Math.Max(res, time);
        }
        return res == int.MaxValue ? -1 : res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(V + E)$ in average case, $O(V * E)$ in worst case.
* Space complexity: $O(V + E)$

> Where $V$ is the number of vertices and $E$ is the number of edges.

---

### 5. Dijkstra's Algorithm






```csharp
public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        var edges = new Dictionary<int, List<int[]>>();
        foreach (var time in times) {
            if (!edges.ContainsKey(time[0])) {
                edges[time[0]] = new List<int[]>();
            }
            edges[time[0]].Add(new int[] { time[1], time[2] });
        }

        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(k, 0);

        var dist = new Dictionary<int, int>();
        for (int i = 1; i <= n; i++) {
            dist[i] = int.MaxValue;
        }
        dist[k] = 0;

        while (pq.Count > 0) {
            // Correctly using TryDequeue to get node and its distance
            if (pq.TryDequeue(out int node, out int minDist)) {
                if (minDist > dist[node]) {
                    continue;
                }

                if (edges.ContainsKey(node)) {
                    foreach (var edge in edges[node]) {
                        var next = edge[0];
                        var weight = edge[1];
                        var newDist = minDist + weight;
                        if (newDist < dist[next]) {
                            dist[next] = newDist;
                            pq.Enqueue(next, newDist);
                        }
                    }
                }
            }
        }

        int result = 0;
        for (int i = 1; i <= n; i++) {
            if (dist[i] == int.MaxValue) return -1;
            result = Math.Max(result, dist[i]);
        }

        return result;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(E \log V)$
* Space complexity: $O(V + E)$

> Where $V$ is the number of vertices and $E$ is the number of edges.
