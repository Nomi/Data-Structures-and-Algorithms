# ⭐ | Serialize And Deserialize Binary Tree

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
Implement an algorithm to serialize and deserialize a binary tree.

Serialization is the process of converting an in-memory structure into a sequence of bits so that it can be stored or sent across a network to be reconstructed later in another computer environment.

You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure. There is no additional restriction on how your serialization/deserialization algorithm should work.

**Note:** The input/output format in the examples is the same as how NeetCode serializes a binary tree. You do not necessarily need to follow this format.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/a9dfb17f-70e9-42a3-ba97-33cfd82f6100/public)

```java
Input: root = [1,2,3,null,null,4,5]

Output: [1,2,3,null,null,4,5]
```

**Example 2:**

```java
Input: root = []

Output: []
```

**Constraints:**
* `0 <= The number of nodes in the tree <= 1000`.
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
    A straightforward way to serialize a tree is by traversing it and adding nodes to a string separated by a delimiter (example: ","), but this does not handle <code>null</code> nodes effectively. During deserialization, it becomes unclear where to stop or how to handle missing children. Can you think of a way to indicate <code>null</code> nodes explicitly?  
    </p>  
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    Including a placeholder for <code>null</code> nodes (example: "N") during serialization ensures that the exact structure of the tree is preserved. This placeholder allows us to identify missing children and reconstruct the tree accurately during deserialization.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We can use the Depth First Search (DFS) algorithm for both serialization and deserialization. During serialization, we traverse the tree and add node values to the result string separated by a delimiter, inserting <code>N</code> whenever we encounter a <code>null</code> node. During deserialization, we process the serialized string using an index <code>i</code>, create nodes for valid values, and return from the current path whenever we encounter <code>N</code>, reconstructing the tree accurately.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/u4JAi2JJhI8/0.jpg)](https://www.youtube.com/watch?v=u4JAi2JJhI8)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=u4JAi2JJhI8)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/serialize-and-deserialize-binary-tree)
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

public class Codec {
    
    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {
        List<string> res = new List<string>();
        dfsSerialize(root, res);
        return String.Join(",", res);
    }

    private void dfsSerialize(TreeNode node, List<string> res) {
        if (node == null) {
            res.Add("N");
            return;
        }
        res.Add(node.val.ToString());
        dfsSerialize(node.left, res);
        dfsSerialize(node.right, res);
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        string[] vals = data.Split(',');
        int i = 0;
        return dfsDeserialize(vals, ref i);
    }

    private TreeNode dfsDeserialize(string[] vals, ref int i) {
        if (vals[i] == "N") {
            i++;
            return null;
        }
        TreeNode node = new TreeNode(Int32.Parse(vals[i]));
        i++;
        node.left = dfsDeserialize(vals, ref i);
        node.right = dfsDeserialize(vals, ref i);
        return node;
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

public class Codec {

    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {
        if (root == null) return "N";
        var res = new List<string>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0) {
            var node = queue.Dequeue();
            if (node == null) {
                res.Add("N");
            } else {
                res.Add(node.val.ToString());
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
        }
        return string.Join(",", res);
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        var vals = data.Split(',');
        if (vals[0] == "N") return null;
        var root = new TreeNode(int.Parse(vals[0]));
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int index = 1;

        while (queue.Count > 0) {
            var node = queue.Dequeue();
            if (vals[index] != "N") {
                node.left = new TreeNode(int.Parse(vals[index]));
                queue.Enqueue(node.left);
            }
            index++;
            if (vals[index] != "N") {
                node.right = new TreeNode(int.Parse(vals[index]));
                queue.Enqueue(node.right);
            }
            index++;
        }
        return root;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
