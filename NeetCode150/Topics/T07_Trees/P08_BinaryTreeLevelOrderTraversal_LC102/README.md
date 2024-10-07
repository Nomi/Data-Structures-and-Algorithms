# Binary Tree Level Order Traversal

|   | Difficulty | Tricky |
|---|------------|--------|
| <big>☆<big> | <big>**🟨 Medium**</big> | <big></big> |


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
- [Breadth-First Search](https://neetcode.io/courses/dsa-for-beginners/20) [from NeetCode's Course(s)]


## Problem Description
Given a binary tree `root`, return the level order traversal of it as a nested list, where each sublist contains the values of nodes at a particular level in the tree, from left to right.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/a4639809-0754-4eda-221f-a4cd58bd9c00/public)

```java
Input: root = [1,2,3,4,5,6,7]

Output: [[1],[2,3],[4,5,6,7]]
```

**Example 2:**

```java
Input: root = [1]

Output: [[1]]
```

**Example 3:**

```java
Input: root = []

Output: []
```

**Constraints:**
* `0 <= The number of nodes in both trees <= 1000`.
* `-1000 <= Node.val <= 1000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time and <code>O(n)</code> space, where <code>n</code> is the number of nodes in the given tree.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    The level of a tree refers to the nodes that are at equal distance from the root node. Can you think of an algorithm that traverses the tree level by level, rather than going deeper into the tree?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use the Breadth First Search (BFS) algorithm to traverse the tree level by level. BFS uses a queue data structure to achieve this. At each step of BFS, we only iterate over the queue up to its size at that step. Then, we take the left and right child pointers and add them to the queue. This allows us to explore all paths simultaneously.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    The number of times we iterate the queue corresponds to the number of levels in the tree. At each step, we pop all nodes from the queue for the current level and add them collectively to the resultant array. This ensures that we capture all nodes at each level of the tree.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/6ZnyEApgFYg/0.jpg)](https://www.youtube.com/watch?v=6ZnyEApgFYg)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=6ZnyEApgFYg)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/level-order-traversal-of-binary-tree)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Depth First Search






```csharp
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
 
public class Solution {
    List<List<int>> res = new List<List<int>>();
    
    public List<List<int>> LevelOrder(TreeNode root) {
        dfs(root, 0);
        return res;
    }
    
    private void dfs(TreeNode node, int depth) {
        if (node == null) {
            return;
        }
        
        if (res.Count == depth) {
            res.Add(new List<int>());
        }
        
        res[depth].Add(node.val);
        dfs(node.left, depth + 1);
        dfs(node.right, depth + 1);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 2. Breadth First Search






```csharp
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
 
public class Solution {
    public List<List<int>> LevelOrder(TreeNode root) {
        List<List<int>> res = new List<List<int>>();
        if (root == null) return res;

        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0) {
            List<int> level = new List<int>();

            for (int i = q.Count; i > 0; i--) {
                TreeNode node = q.Dequeue();
                if (node != null) {
                    level.Add(node.val);
                    q.Enqueue(node.left);
                    q.Enqueue(node.right);
                }
            }
            if (level.Count > 0) {
                res.Add(level);
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
