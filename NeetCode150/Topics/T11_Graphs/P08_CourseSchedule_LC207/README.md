# ⭐ | Course Schedule

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

The pair `[0, 1]`, indicates that must take course `1` before taking course `0`.

There are a total of `numCourses` courses you are required to take, labeled from `0` to `numCourses - 1`. 

Return `true` if it is possible to finish all courses, otherwise return `false`.

**Example 1:**

```java
Input: numCourses = 2, prerequisites = [[0,1]]

Output: true
```
Explanation: First take course 1 (no prerequisites) and then take course 0.

**Example 2:**

```java
Input: numCourses = 2, prerequisites = [[0,1],[1,0]]

Output: false
```

Explanation: In order to take course 1 you must take course 0, and to take course 0 you must take course 1. So it is impossible.

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
    Consider the problem as a graph where courses represent the nodes, and <code>prerequisite[i] = [a, b]</code> represents a directed edge from <code>a</code> to <code>b</code>. We need to determine whether the graph contains a cycle. Why? Because if there is a cycle, it is impossible to complete the courses involved in the cycle. Can you think of an algorithm to detect cycle in a graph?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use the Depth First Search (DFS) algorithm to detect a cycle in a graph. We iterate over each course, run a DFS from that course, and first try to finish its prerequisite courses by recursively traversing through them. To detect a cycle, we initialize a hash set called <code>path</code>, which contains the nodes visited in the current DFS call. If we encounter a course that is already in the <code>path</code>, we can conclude that a cycle is detected. How would you implement it?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
     We run a DFS starting from each course by initializing a hash set, <code>path</code>, to track the nodes in the current DFS call. At each step of the DFS, we return <code>false</code> if the current node is already in the <code>path</code>, indicating a cycle. We recursively traverse the neighbors of the current node, and if any of the neighbor DFS calls detect a cycle, we immediately return <code>false</code>. Additionally, we clear the neighbors list of a node when no cycle is found from that node to avoid revisiting those paths again.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/EgI5nU9etnU/0.jpg)](https://www.youtube.com/watch?v=EgI5nU9etnU)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=EgI5nU9etnU)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/course-schedule)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Cycle Detection (DFS)






```csharp
public class Solution {
    // Map each course to its prerequisites
    private Dictionary<int, List<int>> preMap = new Dictionary<int, List<int>>();
    // Store all courses along the current DFS path
    private HashSet<int> visiting = new HashSet<int>();

    public bool CanFinish(int numCourses, int[][] prerequisites) {
        for (int i = 0; i < numCourses; i++) {
            preMap[i] = new List<int>();
        }
        foreach (var prereq in prerequisites) {
            preMap[prereq[0]].Add(prereq[1]);
        }

        for (int c = 0; c < numCourses; c++) {
            if (!Dfs(c)) {
                return false;
            }
        }
        return true;
    }

    private bool Dfs(int crs) {
        if (visiting.Contains(crs)) {
            // Cycle detected
            return false;
        }
        if (preMap[crs].Count == 0) {
            return true;
        }

        visiting.Add(crs);
        foreach (int pre in preMap[crs]) {
            if (!Dfs(pre)) {
                return false;
            }
        }
        visiting.Remove(crs);
        preMap[crs].Clear();
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
    public bool CanFinish(int numCourses, int[][] prerequisites) {
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
        while (q.Count > 0) {
            int node = q.Dequeue();
            finish++;
            foreach (var nei in adj[node]) {
                indegree[nei]--;
                if (indegree[nei] == 0) {
                    q.Enqueue(nei);
                }
            }
        }

        return finish == numCourses;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(V + E)$
* Space complexity: $O(V + E)$

> Where $V$ is the number of courses and $E$ is the number of prerequisites.
