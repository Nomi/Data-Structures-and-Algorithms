# Count Good Nodes In Binary Tree

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
- [Binary Tree](https://neetcode.io/courses/dsa-for-beginners/16) [from NeetCode's Course(s)]
- [Depth-First Search](https://neetcode.io/courses/dsa-for-beginners/19) [from NeetCode's Course(s)]


## Problem Description
Within a binary tree, a node `x` is considered **good** if the path from the root of the tree to the node `x` contains no nodes with a value greater than the value of node `x`

Given the root of a binary tree `root`, return the number of **good** nodes within the tree.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/9bf374f1-71fe-469e-2840-5d223d9d1b00/public)

```java
Input: root = [2,1,1,3,null,1,5]

Output: 3
```

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/8df65da7-abac-4948-9a92-0bc7a8dda100/public)

**Example 2:**

```java
Input: root = [1,2,-1,3,4]

Output: 4
```


**Constraints:**
* `1 <= number of nodes in the tree <= 100`
* `-100 <= Node.val <= 100`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time and<code>O(n)</code> space, where <code>n</code> is the number of nodes in the given tree.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would involve considering every node and checking if the path from the root to that node is valid, resulting in an <code>O(n^2)</code> time complexity. Can you think of a better approach?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use the Depth First Search (DFS) algorithm to traverse the tree. But can you think of a way to determine if the current node is a good node in a single traversal? Maybe we need to track a value while traversing the tree.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    While traversing the tree, we should track the maximum value along the current path. This allows us to determine whether the nodes we encounter are good. We can use a global variable to count the number of good nodes.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/7cp5imvDzl4/0.jpg)](https://www.youtube.com/watch?v=7cp5imvDzl4)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=7cp5imvDzl4)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/count-good-nodes-in-binary-tree)
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
    
    public int GoodNodes(TreeNode root) {
        return Dfs(root, root.val);
    }

    private int Dfs(TreeNode node, int maxVal) {
        if (node == null) {
            return 0;
        }

        int res = (node.val >= maxVal) ? 1 : 0;
        maxVal = Math.Max(maxVal, node.val);
        res += Dfs(node.left, maxVal);
        res += Dfs(node.right, maxVal);
        return res;
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
    public int GoodNodes(TreeNode root) {
        int res = 0;
        Queue<(TreeNode, int)> q = new Queue<(TreeNode, int)>();
        q.Enqueue((root, int.MinValue));

        while (q.Count > 0) {
            var (node, maxval) = q.Dequeue();
            if (node.val >= maxval) {
                res++;
            }
            if (node.left != null) {
                q.Enqueue((node.left, Math.Max(maxval, node.val)));
            }
            if (node.right != null) {
                q.Enqueue((node.right, Math.Max(maxval, node.val)));
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
