# ⭐ | Validate Binary Search Tree

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
- [Binary Tree](https://neetcode.io/courses/dsa-for-beginners/16) [from NeetCode's Course(s)]
- [Binary Search Tree](https://neetcode.io/courses/dsa-for-beginners/17) [from NeetCode's Course(s)]
- [Depth-First Search](https://neetcode.io/courses/dsa-for-beginners/19) [from NeetCode's Course(s)]


## Problem Description
Given the `root` of a binary tree, return `true` if it is a **valid binary search tree**, otherwise return `false`.

A **valid binary search tree** satisfies the following constraints:    
* The left subtree of every node contains only nodes with keys **less than** the node's key.
* The right subtree of every node contains only nodes with keys **greater than** the node's key.
* Both the left and right subtrees are also binary search trees.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/18f9a316-8dc2-4e11-d304-51204454ac00/public)

```java
Input: root = [2,1,3]

Output: true
```

**Example 2:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/6f14cb8d-efad-4221-2beb-fba2b19c8a00/public)

```java
Input: root = [1,2,3]

Output: false
```

Explanation: The root node's value is 1 but its left child's value is 2 which is greater than 1.

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
    A brute force solution would involve traversing the tree and, for every node, checking its entire left subtree to ensure all nodes are less than the current node, and its entire right subtree to ensure all nodes are greater. This results in an <code>O(n^2)</code> solution. Can you think of a better way? Maybe tracking values during the traversal would help.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use the Depth First Search (DFS) algorithm to traverse the tree. At each node, we need to ensure that the tree rooted at that node is a valid Binary Search Tree (BST). One way to do this is by tracking an interval that defines the lower and upper limits for the node's value in that subtree. This interval will be updated as we move down the tree, ensuring each node adheres to the BST property.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We start with the interval <code>[-infinity, infinity]</code> for the root node. As we traverse the tree, when checking the left subtree, we update the maximum value limit because all values in the left subtree must be less than the current node's value. Conversely, when checking the right subtree, we update the minimum value limit because all values in the right subtree must be greater than the current node's value.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/s6ATEkipzow/0.jpg)](https://www.youtube.com/watch?v=s6ATEkipzow)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=s6ATEkipzow)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/valid-binary-search-tree)
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
    static bool LeftCheck(int val, int limit) {
        return val < limit; 
    }

    static bool RightCheck(int val, int limit) {
        return val > limit; 
    }

    public bool IsValidBST(TreeNode root) {
        if (root == null) {
            return true;
        }

        if (!IsValid(root.left, root.val, LeftCheck) || 
            !IsValid(root.right, root.val, RightCheck)) {
            return false;
        }

        return IsValidBST(root.left) && IsValidBST(root.right);
    }

    public bool IsValid(TreeNode root, int limit, Func<int, int, bool> check) {
        if (root == null) {
            return true;
        }
        if (!check(root.val, limit)) {
            return false;
        }
        return IsValid(root.left, limit, check) && 
               IsValid(root.right, limit, check);
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
    public bool IsValidBST(TreeNode root) {
        return valid(root, long.MinValue, long.MaxValue);
    }

    public bool valid(TreeNode node, long left, long right) {
        if (node == null) {
            return true;
        }
        if (!(left < node.val && node.val < right)) {
            return false;
        }
        return valid(node.left, left, node.val) &&
               valid(node.right, node.val, right);
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
    public bool IsValidBST(TreeNode root) {
        if (root == null) {
            return true;
        }

        Queue<(TreeNode node, long left, long right)> queue = new Queue<(TreeNode, long, long)>();
        queue.Enqueue((root, long.MinValue, long.MaxValue));

        while (queue.Count > 0) {
            var (node, left, right) = queue.Dequeue();

            if (!(left < node.val && node.val < right)) {
                return false;
            }
            if (node.left != null) {
                queue.Enqueue((node.left, left, node.val));
            }
            if (node.right != null) {
                queue.Enqueue((node.right, node.val, right));
            }
        }

        return true;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
