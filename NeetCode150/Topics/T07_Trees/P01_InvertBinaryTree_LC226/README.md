# Invert Binary Tree

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
You are given the root of a binary tree `root`. Invert the binary tree and return its root.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/ac124ee6-207f-41f6-3aaa-dfb35815f200/public)

```java
Input: root = [1,2,3,4,5,6,7]

Output: [1,3,2,7,6,5,4]
```

**Example 2:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/e39e8d4f-9946-4f99-ee3d-0d4df08d4d00/public)

```java
Input: root = [3,2,1]

Output: [3,1,2]
```

**Example 3:**

```java
Input: root = []

Output: []
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
    From the diagram, you can see that the left and right children of every node in the tree are swapped. Can you think of a way to achieve this recursively? Maybe an algorithm that is helpful to traverse the tree.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use the Depth First Search (DFS) algorithm. At each node, we swap its left and right children by swapping their pointers. This inverts the current node, but every node in the tree also needs to be inverted. To achieve this, we recursively visit the left and right children and perform the same operation. If the current node is <code>null</code>, we simply return.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/OnSn2XEQ4MY/0.jpg)](https://www.youtube.com/watch?v=OnSn2XEQ4MY)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=OnSn2XEQ4MY)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/invert-a-binary-tree)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Breadth First Search






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
    public TreeNode InvertTree(TreeNode root) {
        if (root == null) return null;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            TreeNode node = queue.Dequeue();
            TreeNode temp = node.left;
            node.left = node.right;
            node.right = temp;
            if (node.left != null) queue.Enqueue(node.left);
            if (node.right != null) queue.Enqueue(node.right);
        }
        return root;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
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
    public TreeNode InvertTree(TreeNode root) {
        if (root == null) return null;

        TreeNode node = new TreeNode(root.val);
        
        node.right = InvertTree(root.left);
        node.left = InvertTree(root.right);

        return node;
    }
}
```


#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

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
    public TreeNode InvertTree(TreeNode root) {
        if (root == null) return null;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0) {
            TreeNode node = stack.Pop();
            TreeNode temp = node.left;
            node.left = node.right;
            node.right = temp;
            if (node.left != null) stack.Push(node.left);
            if (node.right != null) stack.Push(node.right);
        }
        return root;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
