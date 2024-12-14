# ⭐ | Kth Smallest Element In a Bst

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
Given the `root` of a binary search tree, and an integer `k`, return the `kth` smallest value (**1-indexed**) in the tree.

A **binary search tree** satisfies the following constraints:    
* The left subtree of every node contains only nodes with keys **less than** the node's key.
* The right subtree of every node contains only nodes with keys **greater than** the node's key.
* Both the left and right subtrees are also binary search trees.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/02eca3db-f72f-4277-7134-faec4f02e500/public)

```java
Input: root = [2,1,3], k = 1

Output: 1
```

**Example 2:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/dca6c42d-2327-4036-f7f2-3e99d8203100/public)

```java
Input: root = [4,3,5,2,null], k = 4

Output: 5
```

**Constraints:**
* `1 <= k <= The number of nodes in the tree <= 1000`.
* `0 <= Node.val <= 1000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution as good or better than <code>O(n)</code> time and <code>O(n)</code> space, where <code>n</code> is the number of nodes in the given tree.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A naive solution would be to store the node values in an array, sort it, and then return the <code>k-th</code> value from the sorted array. This would be an <code>O(nlogn)</code> solution due to sorting. Can you think of a better way? Maybe you should try one of the traversal technique.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use the Depth First Search (DFS) algorithm to traverse the tree. Since the tree is a Binary Search Tree (BST), we can leverage its structure and perform an in-order traversal, where we first visit the left subtree, then the current node, and finally the right subtree. Why? Because we need the <code>k-th</code> smallest integer, and by visiting the left subtree first, we ensure that we encounter smaller nodes before the current node. How can you implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We keep a counter variable <code>cnt</code> to track the position of the current node in the ascending order of values. When <code>cnt == k</code>, we store the current node's value in a global variable and return. This allows us to identify and return the <code>k-th</code> smallest element during the in-order traversal.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/5LUXSvjmGCw/0.jpg)](https://www.youtube.com/watch?v=5LUXSvjmGCw)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=5LUXSvjmGCw)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/kth-smallest-integer-in-bst)
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
    public int KthSmallest(TreeNode root, int k) {
        List<int> arr = new List<int>();
        Dfs(root, arr);
        arr.Sort();
        return arr[k - 1];
    }

    private void Dfs(TreeNode node, List<int> arr) {
        if (node == null) return;
        arr.Add(node.val);
        Dfs(node.left, arr);
        Dfs(node.right, arr);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log n)$
* Space complexity: $O(n)$

---

### 2. Inorder Traversal






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
    public int KthSmallest(TreeNode root, int k) {
        List<int> arr = new List<int>();
        Dfs(root, arr);
        return arr[k - 1];
    }

    private void Dfs(TreeNode node, List<int> arr) {
        if (node == null) return;
        Dfs(node.left, arr);
        arr.Add(node.val);
        Dfs(node.right, arr);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 3. Recursive DFS (Optimal)






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
    public int KthSmallest(TreeNode root, int k) {
        int[] tmp = new int[2];
        tmp[0] = k;
        Dfs(root, tmp);
        return tmp[1];
    }

    private void Dfs(TreeNode node, int[] tmp) {
        if (node == null) return;
        Dfs(node.left, tmp);
        tmp[0]--;
        if (tmp[0] == 0) {
            tmp[1] = node.val;
            return;
        }
        Dfs(node.right, tmp);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 4. Iterative DFS (Optimal)






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
    public int KthSmallest(TreeNode root, int k) {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode curr = root;

        while (stack.Count > 0 || curr != null) {
            while (curr != null) {
                stack.Push(curr);
                curr = curr.left;
            }
            curr = stack.Pop();
            k--;
            if (k == 0) {
                return curr.val;
            }
            curr = curr.right;
        }

        return -1;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 5. Morris Traversal






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
    public int KthSmallest(TreeNode root, int k) {
        TreeNode curr = root;
        
        while (curr != null) {
            if (curr.left == null) {
                k--;
                if (k == 0) return curr.val;
                curr = curr.right;
            } else {
                TreeNode pred = curr.left;
                while (pred.right != null && pred.right != curr)
                    pred = pred.right;
                
                if (pred.right == null) {
                    pred.right = curr;
                    curr = curr.left;
                } else {
                    pred.right = null;
                    k--;
                    if (k == 0) return curr.val;
                    curr = curr.right;
                }
            }
        }
        return -1;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$
