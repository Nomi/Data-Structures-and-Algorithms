# ⭐ | Clone Graph

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
Given a node in a connected undirected graph, return a deep copy of the graph.

Each node in the graph contains an integer value and a list of its neighbors.

```java
class Node {
    public int val;
    public List<Node> neighbors;
}
```

The graph is shown in the test cases as an adjacency list. **An adjacency list** is a mapping of nodes to lists, used to represent a finite graph. Each list describes the set of neighbors of a node in the graph.

For simplicity, nodes values are numbered from 1 to `n`, where `n` is the total number of nodes in the graph. The index of each node within the adjacency list is the same as the node's value (1-indexed).

The input node will always be the first node in the graph and have `1` as the value.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/ca68c09d-4d0e-4d80-9c20-078c666cf900/public)

```java
Input: adjList = [[2],[1,3],[2]]

Output: [[2],[1,3],[2]]
```

Explanation: There are 3 nodes in the graph.
Node 1: val = 1 and neighbors = [2].
Node 2: val = 2 and neighbors = [1, 3].
Node 3: val = 3 and neighbors = [2].

**Example 2:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/96c7fb34-26e8-42e0-5f5d-61b8b8c96800/public)

```java
Input: adjList = [[]]

Output: [[]]
```

Explanation: The graph has one node with no neighbors.

**Example 3:**

```java
Input: adjList = []

Output: []
```

Explanation: The graph is empty.

**Constraints:**
* `0 <= The number of nodes in the graph <= 100`.
* `1 <= Node.val <= 100`
* There are no duplicate edges and no self-loops in the graph.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(V + E)</code> time and <code>O(E)</code> space, where <code>V</code> is the number of vertices and <code>E</code> is the number of edges in the given graph.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    We are given only the reference to the node in the graph. Cloning the entire graph means we need to clone all the nodes as well as their child nodes. We can't just clone the node and its neighbor and return the node. We also need to clone the entire graph. Can you think of a recursive way to do this, as we are cloning nodes in a nested manner? Also, can you think of a data structure that can store the nodes with their cloned references?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use the Depth First Search (DFS) algorithm. We use a hash map to map the nodes to their cloned nodes. We start from the given node. At each step of the DFS, we create a node with the current node's value. We then recursively go to the current node's neighbors and try to clone them first. After that, we add their cloned node references to the current node's neighbors list. Can you think of a base condition to stop this recursive path?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We stop this recursive path when we encounter a node that has already been cloned or visited. This DFS approach creates an exact clone of the given graph, and we return the clone of the given node.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/mQeF6bN8hMk/0.jpg)](https://www.youtube.com/watch?v=mQeF6bN8hMk)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=mQeF6bN8hMk)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/clone-graph)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Depth First Seacrh






```csharp
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        Dictionary<Node, Node> oldToNew = new Dictionary<Node, Node>();
        return Dfs(node, oldToNew);
    }

    private Node Dfs(Node node, Dictionary<Node, Node> oldToNew) {
        if (node == null)
            return null;

        if (oldToNew.ContainsKey(node))
            return oldToNew[node];

        Node copy = new Node(node.val);
        oldToNew[node] = copy;

        foreach (Node nei in node.neighbors)
            copy.neighbors.Add(Dfs(nei, oldToNew));

        return copy;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(V + E)$
* Space complexity: $O(V)$

> Where $V$ is the number of vertices and $E$ is the number of edges.

---

### 2. Breadth First Search






```csharp
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if (node == null) return null;
        var oldToNew = new Dictionary<Node, Node>();
        var q = new Queue<Node>();
        oldToNew[node] = new Node(node.val);
        q.Enqueue(node);

        while (q.Count > 0) {
            var cur = q.Dequeue();
            foreach (var nei in cur.neighbors) {
                if (!oldToNew.ContainsKey(nei)) {
                    oldToNew[nei] = new Node(nei.val);
                    q.Enqueue(nei);
                }
                oldToNew[cur].neighbors.Add(oldToNew[nei]);
            }
        }
        return oldToNew[node];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(V + E)$
* Space complexity: $O(V)$

> Where $V$ is the number of vertices and $E$ is the number of edges.
