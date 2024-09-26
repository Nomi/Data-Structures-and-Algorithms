# Copy List With Random Pointer

|   | Difficulty | Tricky |
|---|------------|--------|
| <big>☆<big> | <big>**🟨 Medium**</big> | <big></big> |


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
- [Singly Linked Lists](https://neetcode.io/courses/dsa-for-beginners/5) [from NeetCode's Course(s)]
- [Doubly Linked Lists](https://neetcode.io/courses/dsa-for-beginners/6) [from NeetCode's Course(s)]
- [Hash Usage](https://neetcode.io/courses/dsa-for-beginners/26) [from NeetCode's Course(s)]


## Problem Description
You are given the head of a linked list of length `n`. Unlike a singly linked list, each node contains an additional pointer `random`, which may point to any node in the list, or `null`.

Create a **deep copy** of the list. 

The deep copy should consist of exactly `n` **new** nodes, each including:
* The original value `val` of the copied node
* A `next` pointer to the new node corresponding to the `next` pointer of the original node
* A `random` pointer to the new node corresponding to the `random` pointer of the original node

Note: None of the pointers in the new list should point to nodes in the original list.

*Return the head of the copied linked list.*

In the examples, the linked list is represented as a list of `n` nodes. Each node is represented as a pair of `[val, random_index]` where `random_index` is the index of the node (0-indexed) that the `random` pointer points to, or `null` if it does not point to any node.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/5a5c2bdd-51e2-4795-4544-096af4b6cc00/public)

```java
Input: head = [[3,null],[7,3],[4,0],[5,1]]

Output: [[3,null],[7,3],[4,0],[5,1]]
```

**Example 2:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/6e56fa98-cf1e-4ca6-18d4-716dac4ba900/public)

```java
Input: head = [[1,null],[2,2],[3,2]]

Output: [[1,null],[2,2],[3,2]]
```

**Constraints:**
* `0 <= n <= 100`
* `-100 <= Node.val <= 100`
* `random` is `null` or is pointing to some node in the linked list.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution as good or better than <code>O(n)</code> time and <code>O(n)</code> space, where <code>n</code> is the length of the given list.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    There is an extra random pointer for each node, and unlike the next pointer, which points to the next node, the random pointer can point to any random node in the list. A deep copy is meant to create completely separate nodes occupying different memory. Why can't we build a new list while iterating through the original list?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    Because, while iterating through the list, when we encounter a node and create a copy of it, we can't immediately assign the random pointer's address. This is because the random pointer might point to a node that has not yet been created. To solve this, we can first create copies of all the nodes in one iteration. However, we still can't directly assign the random pointers since we don't have the addresses of the copies of those random pointers. Can you think of a data structure to store this information? Maybe a hash data structure could help.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We can use a hash data structure, such as a hash map, which takes <code>O(1)</code> time to retrieve data. This can help by mapping the original nodes to their corresponding copies. This way, we can easily retrieve the copy of any node and assign the random pointers in a subsequent pass after creating copies of all nodes in the first pass.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/5Y2EiZST97Y/0.jpg)](https://www.youtube.com/watch?v=5Y2EiZST97Y)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=5Y2EiZST97Y)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/copy-linked-list-with-random-pointer)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Hash Map (Recursion)






```csharp
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    private Dictionary<Node, Node> map = new Dictionary<Node, Node>();

    public Node copyRandomList(Node head) {
        if (head == null) return null;
        if (map.ContainsKey(head)) return map[head];

        Node copy = new Node(head.val);
        map[head] = copy;
        copy.next = copyRandomList(head.next);
        
        if (head.random != null) {
            copy.random = copyRandomList(head.random);
        } else {
            copy.random = null;
        }

        return copy;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 2. Hash Map (Two Pass)






```csharp
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        Dictionary<Node, Node> oldToCopy = new Dictionary<Node, Node>();

        Node cur = head;
        while (cur != null) {
            Node copy = new Node(cur.val);
            oldToCopy[cur] = copy;
            cur = cur.next;
        }

        cur = head;
        while (cur != null) {
            Node copy = oldToCopy[cur];
            copy.next = cur.next != null ? oldToCopy[cur.next] : null;
            copy.random = cur.random != null ? oldToCopy[cur.random] : null;
            cur = cur.next;
        }

        return head != null ? oldToCopy[head] : null;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 3. Hash Map (One Pass)






```csharp
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        if (head == null) return null;
        Dictionary<Node, Node> oldToCopy = new Dictionary<Node, Node>();

        Node cur = head;
        while (cur != null) {
            if (!oldToCopy.ContainsKey(cur)) {
                oldToCopy[cur] = new Node(cur.val);
            } else {
                oldToCopy[cur].val = cur.val;
            }

            if (cur.next != null) {
                if (!oldToCopy.ContainsKey(cur.next)) {
                    oldToCopy[cur.next] = new Node(0);
                }
                oldToCopy[cur].next = oldToCopy[cur.next];
            } else {
                oldToCopy[cur].next = null;
            }

            if (cur.random != null) {
                if (!oldToCopy.ContainsKey(cur.random)) {
                    oldToCopy[cur.random] = new Node(0);
                }
                oldToCopy[cur].random = oldToCopy[cur.random];
            } else {
                oldToCopy[cur].random = null;
            }
            cur = cur.next;
        }
        return oldToCopy[head];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 4. Space Optimized - I






```csharp
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        if (head == null) {
            return null;
        }
        
        Node l1 = head;
        while (l1 != null) {
            Node l2 = new Node(l1.val);
            l2.next = l1.next;
            l1.next = l2;
            l1 = l2.next;
        }

        Node newHead = head.next;

        l1 = head;
        while (l1 != null) {
            if (l1.random != null) {
                l1.next.random = l1.random.next;
            }
            l1 = l1.next.next;
        }

        l1 = head;
        while (l1 != null) {
            Node l2 = l1.next;
            l1.next = l2.next;
            if (l2.next != null) {
                l2.next = l2.next.next;
            }
            l1 = l1.next;
        }

        return newHead;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$

---

### 5. Space Optimized - II






```csharp
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        if (head == null) {
            return null;
        }

        Node l1 = head;
        while (l1 != null) {
            Node l2 = new Node(l1.val);
            l2.next = l1.random;
            l1.random = l2;
            l1 = l1.next;
        }

        Node newHead = head.random;

        l1 = head;
        while (l1 != null) {
            Node l2 = l1.random;
            l2.random = (l2.next != null) ? l2.next.random : null;
            l1 = l1.next;
        }

        l1 = head;
        while (l1 != null) {
            Node l2 = l1.random;
            l1.random = l2.next;
            l2.next = (l1.next != null) ? l1.next.random : null;
            l1 = l1.next;
        }

        return newHead;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$
