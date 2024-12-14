# Balanced Binary Tree

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


## Problem Description
Given a binary tree, return `true` if it is **height-balanced** and `false` otherwise.

A **height-balanced** binary tree is defined as a binary tree in which the left and right subtrees of every node differ in height by no more than 1.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/c19c3727-ea28-416c-3873-79ee75f2b400/public)

```java
Input: root = [1,2,3,null,null,4]

Output: true
```

**Example 2:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/24fcc2da-e012-4f9e-856e-040f200f3c00/public)

```java
Input: root = [1,2,3,null,null,4,null,5]

Output: false
```

**Example 3:**

```java
Input: root = []

Output: true
```

**Constraints:**
* The number of nodes in the tree is in the range `[0, 1000]`.
* `-1000 <= Node.val <= 1000`

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
    A brute force solution would involve traversing every node and checking whether the tree rooted at each node is balanced by computing the heights of its left and right subtrees. This approach would result in an <code>O(n^2)</code> solution. Can you think of a more efficient way? Perhaps you could avoid repeatedly computing the heights for every node by determining balance and height in a single traversal.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use the Depth First Search (DFS) algorithm to compute the heights at each node. While calculating the heights of the left and right subtrees, we also check if the tree rooted at the current node is balanced. If <code>leftHeight - rightHeight > 1</code>, we update a global variable, such as <code>isBalanced = False</code>. After traversing all the nodes, the value of <code>isBalanced</code> indicates whether the entire tree is balanced or not.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/QfJsau0ItOY/0.jpg)](https://www.youtube.com/watch?v=QfJsau0ItOY)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=QfJsau0ItOY)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/balanced-binary-tree)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






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
    public bool IsBalanced(TreeNode root) {
        if (root == null) return true;

        int left = Height(root.left);
        int right = Height(root.right);
        if (Math.Abs(left - right) > 1) return false;
        return IsBalanced(root.left) && IsBalanced(root.right);
    }

    public int Height(TreeNode root) {
        if (root == null) {
            return 0;
        }

        return 1 + Math.Max(Height(root.left), Height(root.right));
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(n)$

---

### 2. Depth First Search






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
    
    public bool IsBalanced(TreeNode root) {
        return Dfs(root)[0] == 1;
    }

    private int[] Dfs(TreeNode root) {
        if (root == null) {
            return new int[]{1, 0};
        }

        int[] left = Dfs(root.left);
        int[] right = Dfs(root.right);

        bool balanced = (left[0] == 1 && right[0] == 1) &&
                        (Math.Abs(left[1] - right[1]) <= 1);
        int height = 1 + Math.Max(left[1], right[1]);

        return new int[]{balanced ? 1 : 0, height};
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

### 3. Depth First Search (Stack)






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
    public bool IsBalanced(TreeNode root) {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode node = root, last = null;
        Dictionary<TreeNode, int> depths = new Dictionary<TreeNode, int>();

        while (stack.Count > 0 || node != null) {
            if (node != null) {
                stack.Push(node);
                node = node.left;
            } else {
                node = stack.Peek();
                if (node.right == null || last == node.right) {
                    stack.Pop();
                    
                    int left = (node.left != null && depths.ContainsKey(node.left)) 
                                ? depths[node.left] : 0;
                    int right = (node.right != null && depths.ContainsKey(node.right)) 
                                ? depths[node.right] : 0;

                    if (Math.Abs(left - right) > 1) return false;

                    depths[node] = 1 + Math.Max(left, right);
                    last = node;
                    node = null;
                } else {
                    node = node.right;
                }
            }
        }
        return true;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
