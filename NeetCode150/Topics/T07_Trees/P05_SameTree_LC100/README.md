# Same Tree

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
Given the roots of two binary trees `p` and `q`, return `true` if the trees are **equivalent**, otherwise return `false`.

Two binary trees are considered **equivalent** if they share the exact same structure and the nodes have the same values.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/e78fc10c-4692-471f-5261-61e9be4f3a00/public)

```java
Input: p = [1,2,3], q = [1,2,3]

Output: true
```

**Example 2:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/0b0ee764-c643-46ff-cb3f-86ce8b58ab00/public)

```java
Input: p = [4,7], q = [4,null,7]

Output: false
```

**Example 3:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/4d811f95-0488-490b-1f4f-fc5489df0f00/public)

```java
Input: p = [1,2,3], q = [1,3,2]

Output: false
```

**Constraints:**
* `0 <= The number of nodes in both trees <= 100`.
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
    Can you think of an algorithm that is used to traverse the tree? Maybe in terms of recursion.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use the Depth First Search (DFS) algorithm to traverse the tree. Can you think of a way to simultaneously traverse both the trees?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We traverse both trees starting from their root nodes. At each step in the recursion, we check if the current nodes in both trees are either <code>null</code> or have the same value. If one node is <code>null</code> while the other is not, or if their values differ, we return <code>false</code>. If the values match, we recursively check their <code>left</code> and <code>right</code> subtrees. If any recursive call returns <code>false</code>, the result for the current recursive call is <code>false</code>.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/vRbbcKXCxOw/0.jpg)](https://www.youtube.com/watch?v=vRbbcKXCxOw)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=vRbbcKXCxOw)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/same-binary-tree)
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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        if (p == null && q == null) {
            return true;
        }
        if (p != null && q != null && p.val == q.val) {
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        } else {
            return false;
        }
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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        var q1 = new Queue<TreeNode>(new[] { p });
        var q2 = new Queue<TreeNode>(new[] { q });

        while (q1.Count > 0 && q2.Count > 0) {
            var nodeP = q1.Dequeue();
            var nodeQ = q2.Dequeue();

            if (nodeP == null && nodeQ == null) continue;
            if (nodeP == null || nodeQ == null || nodeP.val != nodeQ.val)
                 return false;

            q1.Enqueue(nodeP.left);
            q1.Enqueue(nodeP.right);
            q2.Enqueue(nodeQ.left);
            q2.Enqueue(nodeQ.right);
        }

        return true;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
