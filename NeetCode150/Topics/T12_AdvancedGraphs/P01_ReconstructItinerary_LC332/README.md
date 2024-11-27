# ⭐ | Reconstruct Itinerary

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


## Problem Description
You are given a list of flight tickets `tickets` where `tickets[i] = [from_i, to_i]` represent the source airport and the destination airport. 

Each `from_i` and `to_i` consists of three uppercase English letters.

Reconstruct the itinerary in order and return it.

All of the tickets belong to someone who originally departed from `"JFK"`. Your objective is to reconstruct the flight path that this person took, assuming each ticket was used exactly once.

If there are multiple valid flight paths, return the lexicographically smallest one.
* For example, the itinerary `["JFK", "SEA"]` has a smaller lexical order than `["JFK", "SFO"]`.

You may assume all the tickets form at least one valid flight path.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/e5ea2ea5-da22-4c22-a5c1-5840dab7fb00/public)

```java
Input: tickets = [["BUF","HOU"],["HOU","SEA"],["JFK","BUF"]]

Output: ["JFK","BUF","HOU","SEA"]
```

**Example 2:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/9bfece1f-1fec-4618-4f95-31b2abcd3100/public)

```java
Input: tickets = [["HOU","JFK"],["SEA","JFK"],["JFK","SEA"],["JFK","HOU"]]

Output: ["JFK","HOU","JFK","SEA","JFK"]
```

Explanation: Another possible reconstruction is `["JFK","SEA","JFK","HOU","JFK"]` but it is lexicographically larger.

**Constraints:**
* `1 <= tickets.length <= 300`
* `from_i != to_i`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(ElogE)</code> time and <code>O(E)</code> space, where <code>E</code> is the number of tickets (edges).
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    Consider this problem as a graph where airports are the nodes and tickets are the edges. Since we need to utilize all the tickets exactly once, can you think of an algorithm that visits every edge exactly once? Additionally, how do you ensure the smallest lexical order is maintained?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We build an adjacency list from the given tickets, which represent directed edges. We perform a DFS to construct the result, but we first sort the neighbors' list of each node to ensure the smallest lexical order. Why? Sorting guarantees that during DFS, we visit the node with the smallest lexical order first.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    DFS would be a naive solution, as it takes <code>O(E * V)</code> time, where <code>E</code> is the number of tickets (edges) and <code>V</code> is the number of airports (nodes). In this approach, we traverse from the given source airport <code>JFK</code>, perform DFS by removing the neighbor, traversing it, and then reinserting it back. Can you think of a better way? Perhaps an advanced algorithm that incorporates DFS might be helpful?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We can use Hierholzer's algorithm, a modified DFS approach. Instead of appending the node to the result list immediately, we first visit all its neighbors. This results in a post-order traversal. After completing all the DFS calls, we reverse the path to obtain the final path, which is also called Euler's path.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/ZyB_gQ8vqGA/0.jpg)](https://www.youtube.com/watch?v=ZyB_gQ8vqGA)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=ZyB_gQ8vqGA)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/reconstruct-flight-path)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Depth First Search






```csharp
public class Solution {
    public List<string> FindItinerary(List<List<string>> tickets) {
        var adj = new Dictionary<string, List<string>>();
        foreach (var ticket in tickets) {
            if (!adj.ContainsKey(ticket[0])) {
                adj[ticket[0]] = new List<string>();
            }
        }

        tickets.Sort((a, b) => string.Compare(a[1], b[1]));
        foreach (var ticket in tickets) {
            adj[ticket[0]].Add(ticket[1]);
        }

        var res = new List<string> { "JFK" };
        Dfs("JFK", res, adj, tickets.Count + 1);
        return res;
    }

    private bool Dfs(string src, List<string> res, 
                     Dictionary<string, List<string>> adj, int targetLen) {
        if (res.Count == targetLen) return true;
        if (!adj.ContainsKey(src)) return false;

        var temp = new List<string>(adj[src]);
        for (int i = 0; i < temp.Count; i++) {
            var v = temp[i];
            adj[src].RemoveAt(i);
            res.Add(v);
            if (Dfs(v, res, adj, targetLen)) return true;
            res.RemoveAt(res.Count - 1);
            adj[src].Insert(i, v);
        }
        return false;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(E * V)$
* Space complexity: $O(E * V)$

> Where $E$ is the number of tickets (edges) and $V$ is the number of airports (vertices).

---

### 2. Hierholzer's Algorithm (Recursion)






```csharp
public class Solution {
    private Dictionary<string, List<string>> adj;
    private List<string> res = new List<string>();
    
    public List<string> FindItinerary(List<List<string>> tickets) {
        adj = new Dictionary<string, List<string>>();
        var sortedTickets = tickets.OrderByDescending(t => t[1]).ToList();
        foreach (var ticket in sortedTickets) {
            if (!adj.ContainsKey(ticket[0])) {
                adj[ticket[0]] = new List<string>();
            }
            adj[ticket[0]].Add(ticket[1]);
        }
        
        Dfs("JFK");
        res.Reverse();
        return res;
    }
    
    private void Dfs(string src) {
        while (adj.ContainsKey(src) && adj[src].Count > 0) {
            var dst = adj[src][adj[src].Count - 1];
            adj[src].RemoveAt(adj[src].Count - 1);
            Dfs(dst);
        }
        res.Add(src);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(E\log E)$
* Space complexity: $O(E)$

> Where $E$ is the number of tickets (edges) and $V$ is the number of airports (vertices).

---

### 3. Hierholzer's Algorithm (Iteration)






```csharp
public class Solution {
    public List<string> FindItinerary(List<List<string>> tickets) {
        var adj = new Dictionary<string, List<string>>();
        foreach (var ticket in tickets.OrderByDescending(t => t[1])) {
            if (!adj.ContainsKey(ticket[0])) {
                adj[ticket[0]] = new List<string>();
            }
            adj[ticket[0]].Add(ticket[1]);
        }
        
        var res = new List<string>();
        var stack = new Stack<string>();
        stack.Push("JFK");
        
        while (stack.Count > 0) {
            var curr = stack.Peek();
            if (!adj.ContainsKey(curr) || adj[curr].Count == 0) {
                res.Insert(0, stack.Pop());
            } else {
                var next = adj[curr][adj[curr].Count - 1];
                adj[curr].RemoveAt(adj[curr].Count - 1);
                stack.Push(next);
            }
        }
        
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(E\log E)$
* Space complexity: $O(E)$

> Where $E$ is the number of tickets (edges) and $V$ is the number of airports (vertices).
