# ⭐ | Subtree of Another Tree

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
Given the roots of two binary trees `root` and `subRoot`, return `true` if there is a subtree of `root` with the same structure and node values of `subRoot` and `false` otherwise.

A subtree of a binary tree `tree` is a tree that consists of a node in `tree` and all of this node's descendants. The tree `tree` could also be considered as a subtree of itself.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/2991a77a-9664-46ed-528d-019e392f7400/public)

```java
Input: root = [1,2,3,4,5], subRoot = [2,4,5]

Output: true
```

**Example 2:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/ae6114cb-23a0-457f-c441-0a82b7a58500/public)

```java
Input: root = [1,2,3,4,5,null,null,6], subRoot = [2,4,5]

Output: false
```

**Constraints:**
* `0 <= The number of nodes in both trees <= 100`.
* `-100 <= root.val, subRoot.val <= 100`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution as good or better than <code>O(m * n)</code> time and <code>O(m + n)</code> space, where <code>n</code> and <code>m</code> are the number of nodes in <code>root</code> and <code>subRoot</code>, respectively.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A subtree of a tree is a tree rooted at a specific node. We need to check whether the given <code>subRoot</code> is identical to any of the subtrees of <code>root</code>. Can you think of a recursive way to check this? Maybe you can leverage the idea of solving a problem where two trees are given, and you need to check whether they are identical in structure and values.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    When two trees are identical, it means that every node in both trees has the same value and structure. We can use the Depth First Search (DFS) algorithm to solve the problem. How do you implement this? 
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We traverse the given <code>root</code>, and at each node, we check if the subtree rooted at that node is identical to the given <code>subRoot</code>. We use a helper function, <code>sameTree(root1, root2)</code>, to determine whether the two trees passed to it are identical in both structure and values.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/E36O5SWp-LE/0.jpg)](https://www.youtube.com/watch?v=E36O5SWp-LE)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=E36O5SWp-LE)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/subtree-of-a-binary-tree)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Depth First Search (DFS)






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
    
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        if (subRoot == null) {
            return true;
        }
        if (root == null) {
            return false;
        }

        if (SameTree(root, subRoot)) {
            return true;
        }
        return IsSubtree(root.left, subRoot) || 
               IsSubtree(root.right, subRoot);
    }

    public bool SameTree(TreeNode root, TreeNode subRoot) {
        if (root == null && subRoot == null) {
            return true;
        }
        if (root != null && subRoot != null && root.val == subRoot.val) {
            return SameTree(root.left, subRoot.left) && 
                   SameTree(root.right, subRoot.right);
        }
        return false;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n)$
* Space complexity: $O(m + n)$

> Where $m$ is the number of nodes in $subRoot$ and $n$ is the number of nodes in $root$.

---

### 2. Serialization And Pattern Matching






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
    public string Serialize(TreeNode root) {
        if (root == null) {
            return "$#";
        }
        return "$" + root.val + 
                Serialize(root.left) + Serialize(root.right);
    }

    public int[] ZFunction(string s) {
        int[] z = new int[s.Length];
        int l = 0, r = 0, n = s.Length;
        for (int i = 1; i < n; i++) {
            if (i <= r) {
                z[i] = Math.Min(r - i + 1, z[i - l]);
            }
            while (i + z[i] < n && s[z[i]] == s[i + z[i]]) {
                z[i]++;
            }
            if (i + z[i] - 1 > r) {
                l = i;
                r = i + z[i] - 1;
            }
        }
        return z;
    }

    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        string serialized_root = Serialize(root);
        string serialized_subRoot = Serialize(subRoot);
        string combined = serialized_subRoot + "|" + serialized_root;
        
        int[] z_values = ZFunction(combined);
        int sub_len = serialized_subRoot.Length;
        
        for (int i = sub_len + 1; i < combined.Length; i++) {
            if (z_values[i] == sub_len) {
                return true;
            }
        }
        return false;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m + n)$
* Space complexity: $O(m + n)$

> Where $m$ is the number of nodes in $subRoot$ and $n$ is the number of nodes in $root$.
