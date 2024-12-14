# ⭐ | Binary Tree Right Side View

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
- [Breadth-First Search](https://neetcode.io/courses/dsa-for-beginners/20) [from NeetCode's Course(s)]


## Problem Description
You are given the `root` of a binary tree. Return only the values of the nodes that are visible from the right side of the tree, ordered from top to bottom.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/d348893a-8917-456c-9599-c405cfc4e000/public)

```java
Input: root = [1,2,3]

Output: [1,3]
```

**Example 2:**

```java
Input: root = [1,2,3,4,5,6,7]

Output: [1,3,7]
```

**Constraints:**
* `0 <= number of nodes in the tree <= 100`
* `-100 <= Node.val <= 100`

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
    In the right-side view of a tree, can you identify the nodes that are visible? Maybe you could traverse the tree level by level and determine which nodes are visible from the right side.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    The nodes visible in the right-side view are the last nodes at each level of the tree. Can you think of an algorithm to identify these nodes? Maybe an algorithm that can traverse the tree level by level.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We can use the Breadth First Search (BFS) algorithm to traverse the tree level by level. Once we completely visit a level, we take the last node of that level and add it to the result array. After processing all levels, we return the result.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/d4zLyf32e3I/0.jpg)](https://www.youtube.com/watch?v=d4zLyf32e3I)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=d4zLyf32e3I)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/binary-tree-right-side-view)
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
    List<int> res = new List<int>();
    
    public List<int> RightSideView(TreeNode root) {
        dfs(root, 0);
        return res;
    }
    
    private void dfs(TreeNode node, int depth) {
        if (node == null) {
            return;
        }
        
        if (res.Count == depth) {
            res.Add(node.val);
        }
        
        dfs(node.right, depth + 1);
        dfs(node.left, depth + 1);
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
    public List<int> RightSideView(TreeNode root) {
        List<int> res = new List<int>();
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0) {
            TreeNode rightSide = null;
            int qLen = q.Count;

            for (int i = 0; i < qLen; i++) {
                TreeNode node = q.Dequeue();
                if (node != null) {
                    rightSide = node;
                    q.Enqueue(node.left);
                    q.Enqueue(node.right);
                }
            }
            if (rightSide != null) {
                res.Add(rightSide.val);
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
