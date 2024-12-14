# ⭐ | Diameter of Binary Tree

|   | Difficulty | Tricky |
|---|------------|--------|
| <big>⭐<big> | <big>**🟩 Easy**</big> | <big></big> |


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
The **diameter** of a binary tree is defined as the **length** of the longest path between *any two nodes within the tree*. The path does not necessarily have to pass through the root.
    
The **length** of a path between two nodes in a binary tree is the number of edges between the nodes.

Given the root of a binary tree `root`, return the **diameter** of the tree.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/90e1d7a0-4322-4c5d-c59b-dde2bf92bb00/public)

```java
Input: root = [1,null,2,3,4,5]

Output: 3
```

Explanation: 3 is the length of the path `[1,2,3,5]` or `[5,3,2,4]`.

**Example 2:**

```java
Input: root = [1,2,3]

Output: 2
```

**Constraints:**
* `1 <= number of nodes in the tree <= 100`
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
    The diameter of a binary tree is the maximum among the sums of the left height and right height of the nodes in the tree. Why?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    Because the diameter of a binary tree is defined as the longest path between any two nodes in the tree. The path may or may not pass through the root. For any given node, the longest path that passes through it is the sum of the height of its left subtree and the height of its right subtree.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    A brute force solution would be to go through every node in the tree and compute its left height and right height, returning the maximum diameter found. This would be an <code>O(n^2)</code> solution. Can you think of a better way? Maybe we can compute the diameter as we calculate the height of the tree? Think about what information you need from each subtree during a single traversal.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We can use the Depth First Search (DFS) algorithm to calculate the height of the tree. At each node, the subtrees return their respective heights (leftHeight and rightHeight). Then we calculate the diameter at that node as <code>d = leftHeight + rightHeight</code>. We use a global variable to update the maximum diameter as needed during the traversal.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/K81C31ytOZE/0.jpg)](https://www.youtube.com/watch?v=K81C31ytOZE)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=K81C31ytOZE)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/binary-tree-diameter)
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
    public int DiameterOfBinaryTree(TreeNode root) {
        if (root == null) {
            return 0;
        }

        int leftHeight = MaxHeight(root.left);
        int rightHeight = MaxHeight(root.right);
        int diameter = leftHeight + rightHeight;
        int sub = Math.Max(DiameterOfBinaryTree(root.left), 
                           DiameterOfBinaryTree(root.right));
        return Math.Max(diameter, sub);
    }

    public int MaxHeight(TreeNode root) {
        if (root == null) {
            return 0;
        }
        return 1 + Math.Max(MaxHeight(root.left), MaxHeight(root.right));
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
    
    public int DiameterOfBinaryTree(TreeNode root) {
        int res = 0;
        DFS(root, ref res);
        return res;
    }

    private int DFS(TreeNode root, ref int res) {
        if (root == null) {
            return 0;
        }
        int left = DFS(root.left, ref res);
        int right = DFS(root.right, ref res);
        res = Math.Max(res, left + right);
        return 1 + Math.Max(left, right);
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

### 3. Iterative DFS






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
    public int DiameterOfBinaryTree(TreeNode root) {
        if (root == null) {
            return 0;
        }

        Stack<TreeNode> stack = new Stack<TreeNode>();
        Dictionary<TreeNode, (int, int)> mp = new Dictionary<TreeNode, (int, int)>();
        stack.Push(root);

        while (stack.Count > 0) {
            TreeNode node = stack.Peek();

            if (node.left != null && !mp.ContainsKey(node.left)) {
                stack.Push(node.left);
            } else if (node.right != null && !mp.ContainsKey(node.right)) {
                stack.Push(node.right);
            } else {
                node = stack.Pop();

                int leftHeight = 0, leftDiameter = 0;
                if (node.left != null && mp.ContainsKey(node.left)) {
                    (leftHeight, leftDiameter) = mp[node.left];
                }

                int rightHeight = 0, rightDiameter = 0;
                if (node.right != null && mp.ContainsKey(node.right)) {
                    (rightHeight, rightDiameter) = mp[node.right];
                }

                int height = 1 + Math.Max(leftHeight, rightHeight);
                int diameter = Math.Max(leftHeight + rightHeight, 
                               Math.Max(leftDiameter, rightDiameter));

                mp[node] = (height, diameter);
            }
        }

        return mp[root].Item2;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
