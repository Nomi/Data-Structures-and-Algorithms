# ⭐ | Course Schedule II

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
You are given an array `prerequisites` where `prerequisites[i] = [a, b]` indicates that you **must** take course `b` first if you want to take course `a`.

* For example, the pair `[0, 1]`, indicates that to take course `0` you have to first take course `1`.

There are a total of `numCourses` courses you are required to take, labeled from `0` to `numCourses - 1`. 

Return a valid ordering of courses you can take to finish all courses. If there are many valid answers, return **any** of them. If it's not possible to finish all courses, return an **empty array**.

**Example 1:**

```java
Input: numCourses = 3, prerequisites = [[1,0]]

Output: [0,1,2]
```

Explanation: We must ensure that course 0 is taken before course 1.

**Example 2:**

```java
Input: numCourses = 3, prerequisites = [[0,1],[1,2],[2,0]]

Output: []
```

Explanation: It's impossible to finish all courses.

**Constraints:**
* `1 <= numCourses <= 1000`
* `0 <= prerequisites.length <= 1000`
* All `prerequisite` pairs are **unique**.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(V + E)</code> time and <code>O(V + E)</code> space, where <code>V</code> is the number of courses (nodes) and <code>E</code> is the number of prerequisites (edges).
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    Consider the problem as a graph where courses represent the nodes, and <code>prerequisite[i] = [a, b]</code> represents a directed edge from <code>a</code> to <code>b</code>. We need to determine whether the graph contains a cycle. Why? Because if there is a cycle, it is impossible to complete the courses involved in the cycle. Can you think of an algorithm to detect a cycle in a graph and also find the valid ordering if a cycle doesn't exist?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use DFS to detect a cycle in a graph. However, we also need to find the valid ordering of the courses, which can also be achieved using DFS. Alternatively, we can use the Topological Sort algorithm to find the valid ordering in this directed graph, where the graph must be acyclic to complete all the courses, and the prerequisite of a course acts as the parent node of that course. How would you implement this? 
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We compute the indegrees of all the nodes. Then, we perform a BFS starting from the nodes that have no parents (<code>indegree[node] == 0</code>). At each level, we traverse these nodes, decrement the indegree of their child nodes, and append those child nodes to the queue if their indegree becomes <code>0</code>. We only append nodes whose indegree is <code>0</code> or becomes <code>0</code> during the BFS to our result array. If the length of the result array is not equal to the number of courses, we return an empty array.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/Akt3glAwyfY/0.jpg)](https://www.youtube.com/watch?v=Akt3glAwyfY)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=Akt3glAwyfY)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/course-schedule-ii)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Cycle Detection (DFS)






```csharp
public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        Dictionary<int, List<int>> prereq = new Dictionary<int, List<int>>();
        foreach (var pair in prerequisites) {
            if (!prereq.ContainsKey(pair[0])) {
                prereq[pair[0]] = new List<int>();
            }
            prereq[pair[0]].Add(pair[1]);
        }

        List<int> output = new List<int>();
        HashSet<int> visit = new HashSet<int>();
        HashSet<int> cycle = new HashSet<int>();

        for (int course = 0; course < numCourses; course++) {
            if (!Dfs(course, prereq, visit, cycle, output)) {
                return new int[0];
            }
        }

        return output.ToArray();
    }

    private bool Dfs(int course, Dictionary<int, List<int>> prereq,
                     HashSet<int> visit, HashSet<int> cycle, 
                     List<int> output) {
                        
        if (cycle.Contains(course)) {
            return false;
        }
        if (visit.Contains(course)) {
            return true;
        }

        cycle.Add(course);
        if (prereq.ContainsKey(course)) {
            foreach (int pre in prereq[course]) {
                if (!Dfs(pre, prereq, visit, cycle, output)) {
                    return false;
                }
            }
        }
        cycle.Remove(course);
        visit.Add(course);
        output.Add(course);
        return true;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(V + E)$
* Space complexity: $O(V + E)$

> Where $V$ is the number of courses and $E$ is the number of prerequisites.

---

### 2. Topological Sort (Kahn's Algorithm)






```csharp
public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        int[] indegree = new int[numCourses];
        List<List<int>> adj = new List<List<int>>();
        for (int i = 0; i < numCourses; i++) {
            adj.Add(new List<int>());
        }
        foreach (var pre in prerequisites) {
            indegree[pre[1]]++;
            adj[pre[0]].Add(pre[1]);
        }

        Queue<int> q = new Queue<int>();
        for (int i = 0; i < numCourses; i++) {
            if (indegree[i] == 0) {
                q.Enqueue(i);
            }
        }

        int finish = 0;
        int[] output = new int[numCourses];
        while (q.Count > 0) {
            int node = q.Dequeue();
            output[numCourses - finish - 1] = node;
            finish++;
            foreach (var nei in adj[node]) {
                indegree[nei]--;
                if (indegree[nei] == 0) {
                    q.Enqueue(nei);
                }
            }
        }

        if (finish != numCourses) {
            return new int[0];
        }
        return output;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(V + E)$
* Space complexity: $O(V + E)$

> Where $V$ is the number of courses and $E$ is the number of prerequisites.

---

### 3. Topological Sort (DFS)






```csharp
public class Solution {
    private List<int> output = new List<int>();
    private int[] indegree;
    private List<List<int>> adj;

    private void Dfs(int node) {
        output.Add(node);
        indegree[node]--;
        foreach (var nei in adj[node]) {
            indegree[nei]--;
            if (indegree[nei] == 0) {
                Dfs(nei);
            }
        }
    }

    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        adj = new List<List<int>>();
        for (int i = 0; i < numCourses; i++) {
            adj.Add(new List<int>());
        }
        indegree = new int[numCourses];
        foreach (var pre in prerequisites) {
            indegree[pre[0]]++;
            adj[pre[1]].Add(pre[0]);
        }

        for (int i = 0; i < numCourses; i++) {
            if (indegree[i] == 0) {
                Dfs(i);
            }
        }

        if (output.Count != numCourses) return new int[0];
        return output.ToArray();
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(V + E)$
* Space complexity: $O(V + E)$

> Where $V$ is the number of courses and $E$ is the number of prerequisites.
