# ⭐ | Binary Tree Maximum Path Sum

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
- [Binary Tree](https://neetcode.io/courses/dsa-for-beginners/16) [from NeetCode's Course(s)]
- [Depth-First Search](https://neetcode.io/courses/dsa-for-beginners/19) [from NeetCode's Course(s)]


## Problem Description
Given the `root` of a *non-empty* binary tree, return the maximum **path sum** of any *non-empty* path.

A **path** in a binary tree is a sequence of nodes where each pair of adjacent nodes has an edge connecting them. A node can *not* appear in the sequence more than once. The path does *not* necessarily need to include the root.

The **path sum** of a path is the sum of the node's values in the path.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/9896b041-9021-44c2-ab3e-5cff76adf100/public)

```java
Input: root = [1,2,3]

Output: 6
```

Explanation: The path is 2 -> 1 -> 3 with a sum of 2 + 1 + 3 = 6.

**Example 2:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/19ce1187-387e-4323-f2c9-1a317ab36200/public)

```java
Input: root = [-15,10,20,null,null,15,5,-5]

Output: 40
```

Explanation: The path is 15 -> 20 -> 5 with a sum of 15 + 20 + 5 = 40.

**Constraints:**
* `1 <= The number of nodes in the tree <= 1000`.
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
    A brute force solution would involve checking the path sum between every pair of nodes in the tree, leading to an <code>O(n^2)</code> time complexity. Can you think of a more efficient approach? Consider what information you would need at each node to calculate the path sum if it passes through the current node.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    At a node, there are three scenarios to compute the maximum path sum that includes the current node. One includes both the left and right subtrees, with the current node as the connecting node. Another path sum includes only one of the subtrees (either left or right), but not both. Another considers the path sum extending from the current node to the parent. However, the parent’s contribution is computed during the traversal at the parent node. Can you implement this? 
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We can use the Depth First Search (DFS) algorithm to traverse the tree. We maintain a global variable to track the maximum path sum. At each node, we first calculate the maximum path sum from the left and right subtrees by traversing them. After that, we compute the maximum path sum at the current node. This approach follows a post-order traversal, where we visit the subtrees before processing the current node.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We return the maximum path sum from the current node to its parent, considering only one of the subtrees (either left or right) to extend the path. While calculating the left and right subtree path sums, we also ensure that we take the maximum with <code>0</code> to avoid negative sums, indicating that we should not include the subtree path in the calculation of the maximum path at the current node.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/Hr5cWUld4vU/0.jpg)](https://www.youtube.com/watch?v=Hr5cWUld4vU)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=Hr5cWUld4vU)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/binary-tree-maximum-path-sum)
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
    int res = int.MinValue;

    public int MaxPathSum(TreeNode root) {
        dfs(root);
        return res;
    }

    private int GetMax(TreeNode root) {
        if (root == null) return 0;
        int left = GetMax(root.left);
        int right = GetMax(root.right);
        int path = root.val + Math.Max(left, right);
        return Math.Max(0, path);
    }

    private void dfs(TreeNode root) {
        if (root == null) return;
        int left = GetMax(root.left);
        int right = GetMax(root.right);
        res = Math.Max(res, root.val + left + right);
        dfs(root.left);
        dfs(root.right);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(n)$

---

### 2. Depth First Search (Optimal)






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

    public int MaxPathSum(TreeNode root) {
        int res = root.val;
        Dfs(root, ref res);
        return res;
    }

    private int Dfs(TreeNode root, ref int res) {
        if (root == null) {
            return 0;
        }

        int leftMax = Math.Max(Dfs(root.left, ref res), 0);
        int rightMax = Math.Max(Dfs(root.right, ref res), 0);

        res = Math.Max(res, root.val + leftMax + rightMax);
        return root.val + Math.Max(leftMax, rightMax);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
