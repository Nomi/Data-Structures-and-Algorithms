# Maximum Depth of Binary Tree

|   | Difficulty | Tricky |
|---|------------|--------|
| <big>☆<big> | <big>**🟩 Easy**</big> | <big></big> |


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
- [Breadth-First Search](https://neetcode.io/courses/dsa-for-beginners/20) [from NeetCode's Course(s)]


## Problem Description
Given the `root` of a binary tree, return its **depth**.

The **depth** of a binary tree is defined as the number of nodes along the longest path from the root node down to the farthest leaf node.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/5ea6da77-7e43-43e0-dd9d-e879ca0b1600/public)

```java
Input: root = [1,2,3,null,null,4]

Output: 3
```

**Example 2:**

```java
Input: root = []

Output: 0
```

**Constraints:**
* `0 <= The number of nodes in the tree <= 100`.
* `-100 <= Node.val <= 100`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time and <code>O(n)</code> space, where <code>n</code> is the number of nodes in the tree.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    From the definition of binary tree's maximum depth, Can you think of a way to achieve this recursively? Maybe you should consider the max depth of the subtrees first before computing the maxdepth at the root.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We use the Depth First Search (DFS) algorithm to find the maximum depth of a binary tree, starting from the <code>root</code>. For the subtrees rooted at the <code>left</code> and <code>right</code> children of the <code>root</code> node, we calculate their maximum depths recursively going through <code>left</code> and <code>right</code> subtrees. We return <code>1 + max(leftDepth, rightDepth)</code>. Why?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    The <code>+1</code> accounts for the current node, as it contributes to the current depth in the recursion call. We pass the maximum depth from the current node's left and right subtrees to its parent because the current maximum depth determines the longest path from the parent to a leaf node through this subtree.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/hTM3phVI6YQ/0.jpg)](https://www.youtube.com/watch?v=hTM3phVI6YQ)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=hTM3phVI6YQ)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/depth-of-binary-tree)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Recursive DFS






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
    public int MaxDepth(TreeNode root) {
        if (root == null) {
            return 0;
        }

        return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(h)$  
  * Best Case ([balanced tree](https://www.geeksforgeeks.org/balanced-binary-tree/)): $O(log(n))$
  * Worst Case ([degenerate tree](https://www.geeksforgeeks.org/introduction-to-degenerate-binary-tree/)): $O(n)$

> Where $n$ is the number of nodes in the tree and $h$ is the height of the tree.

---

### 2. Iterative DFS (Stack)






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
    public int MaxDepth(TreeNode root) {
        Stack<Tuple<TreeNode, int>> stack = new Stack<Tuple<TreeNode, int>>();
        stack.Push(new Tuple<TreeNode, int>(root, 1));
        int res = 0;

        while (stack.Count > 0) {
            Tuple<TreeNode, int> current = stack.Pop();
            TreeNode node = current.Item1;
            int depth = current.Item2;

            if (node != null) {
                res = Math.Max(res, depth);
                stack.Push(new Tuple<TreeNode, int>(node.left, depth + 1));
                stack.Push(new Tuple<TreeNode, int>(node.right, depth + 1));
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 3. Breadth First Search 






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
    public int MaxDepth(TreeNode root) {
        Queue<TreeNode> q = new Queue<TreeNode>();
        if (root != null) {
            q.Enqueue(root);
        }

        int level = 0;
        while (q.Count > 0) {
            int size = q.Count;
            for (int i = 0; i < size; i++) {
                TreeNode node = q.Dequeue();
                if (node.left != null) {
                    q.Enqueue(node.left);
                }
                if (node.right != null) {
                    q.Enqueue(node.right);
                }
            }
            level++;
        }
        return level;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
