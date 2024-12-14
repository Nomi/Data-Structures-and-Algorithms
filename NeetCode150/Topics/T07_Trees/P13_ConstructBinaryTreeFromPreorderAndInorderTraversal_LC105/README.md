# ⭐ | Construct Binary Tree From Preorder And Inorder Traversal

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
- [Depth-First Search](https://neetcode.io/courses/dsa-for-beginners/19) [from NeetCode's Course(s)]


## Problem Description
You are given two integer arrays `preorder` and `inorder`.
        
* `preorder` is the preorder traversal of a binary tree
* `inorder` is the inorder traversal of the same tree
* Both arrays are of the same size and consist of unique values.

Rebuild the binary tree from the preorder and inorder traversals and return its root.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/938c14d3-6669-47ab-924b-a1a08640f200/public)

```java
Input: preorder = [1,2,3,4], inorder = [2,1,3,4]

Output: [1,2,3,null,null,null,4]
```

**Example 2:**

```java
Input: preorder = [1], inorder = [1]

Output: [1]
```

**Constraints:**
* `1 <= inorder.length <= 1000`.
* `inorder.length == preorder.length`
* `-1000 <= preorder[i], inorder[i] <= 1000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time and <code>O(n)</code> space, where <code>n</code> is the number of nodes.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
   You can observe that the in-order traversal helps divide the array into two halves based on the root node: the left part corresponds to the left subtree, and the right part corresponds to the right subtree. Can you think of how we can get the index of the root node in the in-order array? Maybe you should look into the pre-order traversal array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    From the pre-order traversal, we know that the first node is the root node. Using this information, can you now construct the binary tree?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    After getting the root node from pre-order traversal, we then look for the index of that node in the in-order array. We can linearly search for the index but this would be an <code>O(n^2)</code> solution. Can you think of a better way? Maybe we can use a data structure to get the index of a node in <code>O(1)</code>?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We can use a hash map to get the index of any node in the in-order array in <code>O(1)</code> time. How can we implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 5</summary>
    <p>
    We use Depth First Search (DFS) to construct the tree. A global variable tracks the current index in the pre-order array. Indices <code>l</code> and <code>r</code> represent the segment in the in-order array for the current subtree. For each node in the pre-order array, we create a node, find its index in the in-order array using the hash map, and recursively build the left and right subtrees by splitting the range <code>[l, r]</code> into two parts for the left and right subtrees.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/ihj4IQGZ2zc/0.jpg)](https://www.youtube.com/watch?v=ihj4IQGZ2zc)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=ihj4IQGZ2zc)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/binary-tree-from-preorder-and-inorder-traversal)
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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        if (preorder.Length == 0 || inorder.Length == 0) {
            return null;
        }

        TreeNode root = new TreeNode(preorder[0]);
        int mid = Array.IndexOf(inorder, preorder[0]);
        root.left = BuildTree(preorder.Skip(1).Take(mid).ToArray(), inorder.Take(mid).ToArray());
        root.right = BuildTree(preorder.Skip(mid + 1).ToArray(), inorder.Skip(mid + 1).ToArray());
        return root;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(n ^ 2)$

---

### 2. Hash Map






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
    int pre_idx = 0;
    Dictionary<int, int> indices = new Dictionary<int, int>();

    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        for (int i = 0; i < inorder.Length; i++) {
            indices[inorder[i]] = i;
        }
        return Dfs(preorder, 0, inorder.Length - 1);
    }

    private TreeNode Dfs(int[] preorder, int l, int r) {
        if (l > r) return null;
        int root_val = preorder[pre_idx++];
        TreeNode root = new TreeNode(root_val);
        int mid = indices[root_val];
        root.left = Dfs(preorder, l, mid - 1);
        root.right = Dfs(preorder, mid + 1, r);
        return root;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 3. Depth First Search (Optimal)






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
    int preIdx = 0;
    int inIdx = 0;

    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        return Dfs(preorder, inorder, int.MaxValue);
    }

    private TreeNode Dfs(int[] preorder, int[] inorder, int limit) {
        if (preIdx >= preorder.Length) return null;
        if (inorder[inIdx] == limit) {
            inIdx++;
            return null;
        }

        TreeNode root = new TreeNode(preorder[preIdx++]);
        root.left = Dfs(preorder, inorder, root.val);
        root.right = Dfs(preorder, inorder, limit);
        return root;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
