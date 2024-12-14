# ⭐ | Remove Nth Node From End of List

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
- [Singly Linked Lists](https://neetcode.io/courses/dsa-for-beginners/5) [from NeetCode's Course(s)]


## Problem Description
You are given the beginning of a linked list `head`, and an integer `n`.
    
Remove the `nth` node from the end of the list and return the beginning of the list.

**Example 1:**

```java
Input: head = [1,2,3,4], n = 2

Output: [1,2,4]
```

**Example 2:**

```java
Input: head = [5], n = 1

Output: []
```

**Example 3:**

```java
Input: head = [1,2], n = 2

Output: [2]
```

**Constraints:**
* The number of nodes in the list is `sz`.
* `1 <= sz <= 30`
* `0 <= Node.val <= 100`
* `1 <= n <= sz`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(N)</code> time and <code>O(1)</code> space, where <code>N</code> is the length of the given list.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would involve storing the nodes of the list into an array, removing the <code>nth</code> node from the array, and then converting the array back into a linked list to return the new head. However, this requires <code>O(N)</code> extra space. Can you think of a better approach to avoid using extra space? Maybe you should first solve with a two pass approach.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use a two-pass approach by first finding the length of the list, <code>N</code>. Since removing the <code>nth</code> node from the end is equivalent to removing the <code>(N - n)th</code> node from the front, as they both mean the same. How can you remove the node in a linked list? 
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    For example, consider a three-node list <code>[1, 2, 3]</code>. If we want to remove <code>2</code>, we update the <code>next</code> pointer of <code>1</code> (initially pointing to <code>2</code>) to point to the node after <code>2</code>, which is <code>3</code>. After this operation, the list becomes <code>[1, 3]</code>, and we return the head. But, can we think of a more better approach? Maybe a greedy calculation can help.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We can solve this in one pass using a greedy approach. Move the <code>first</code> pointer <code>n</code> steps ahead. Then, start another pointer <code>second</code> at the head and iterate both pointers simultaneously until <code>first</code> reaches <code>null</code>. At this point, the <code>second</code> pointer is just before the node to be removed. We then remove the node that is next to the <code>second</code> pointer. Why does this work?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 5</summary>
    <p>
    This greedy approach works because the <code>second</code> pointer is <code>n</code> nodes behind the <code>first</code> pointer. When the <code>first</code> pointer reaches the end, the <code>second</code> pointer is exactly <code>n</code> nodes from the end. This positioning allows us to remove the <code>nth</code> node from the end efficiently.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/XVuQxVej6y8/0.jpg)](https://www.youtube.com/watch?v=XVuQxVej6y8)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=XVuQxVej6y8)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/remove-node-from-end-of-linked-list)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        var nodes = new List<ListNode>();
        var cur = head;
        while (cur != null) {
            nodes.Add(cur);
            cur = cur.next;
        }

        int removeIndex = nodes.Count - n;
        if (removeIndex == 0) {
            return head.next;
        }

        nodes[removeIndex - 1].next = nodes[removeIndex].next;
        return head;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(N)$
* Space complexity: $O(N)$

---

### 2. Iteration (Two Pass)






```csharp
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        int N = 0;
        ListNode cur = head;
        while (cur != null) {
            N++;
            cur = cur.next;
        }

        int removeIndex = N - n;
        if (removeIndex == 0) {
            return head.next;
        }

        cur = head;
        for (int i = 0; i < N - 1; i++) {
            if (i + 1 == removeIndex) {
                cur.next = cur.next.next;
                break;
            }
            cur = cur.next;
        }
        return head;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(N)$
* Space complexity: $O(1)$

---

### 3. Recursion






```csharp
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public ListNode rec(ListNode head, ref int n) {
        if (head == null) {
            return null;
        }

        head.next = rec(head.next, ref n);
        n--;
        if (n == 0) {
            return head.next;
        }
        return head;
    }

    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        return rec(head, ref n);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(N)$
* Space complexity: $O(N)$

---

### 4. Two Pointers






```csharp
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode dummy = new ListNode(0, head);
        ListNode left = dummy;
        ListNode right = head;

        while (n > 0) {
            right = right.next;
            n--;
        }

        while (right != null) {
            left = left.next;
            right = right.next;
        }

        left.next = left.next.next;
        return dummy.next;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(N)$
* Space complexity: $O(1)$
