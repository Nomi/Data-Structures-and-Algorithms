# Reverse Linked List

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
- [Singly Linked Lists](https://neetcode.io/courses/dsa-for-beginners/5) [from NeetCode's Course(s)]


## Problem Description
Given the beginning of a singly linked list `head`, reverse the list, and return the new beginning of the list.

**Example 1:**

```java
Input: head = [0,1,2,3]

Output: [3,2,1,0]
```

**Example 2:**

```java
Input: head = []

Output: []
```

**Constraints:**
* `0 <= The length of the list <= 1000`.
* `-1000 <= Node.val <= 1000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time and <code>O(1)</code> space, where <code>n</code> is the length of the given list.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would be to store the node values of the linked list into an array, then reverse the array, convert it back into a linked list, and return the new linked list's head. This would be an <code>O(n)</code> time solution but uses extra space. Can you think of a better way? Maybe there is an approach to reverse a linked list in place.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    As you can see, the head of the linked list becomes the tail after we reverse it. Can you think of an approach to change the references of the node pointers? Perhaps reversing a simple two-node list might help clarify the process.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    For example, consider a list <code>[2, 3]</code>, where <code>2</code> is the head of the list and <code>3</code> is the tail. When we reverse it, <code>3</code> becomes the new head, and its next pointer will point to <code>2</code>. Then, <code>2</code>'s next pointer will point to <code>null</code>. Can you figure out how to apply this approach to reverse a linked list of length <code>n</code> by iterating through it?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We can reverse the linked list in place by reversing the pointers between two nodes while keeping track of the next node's address. Before changing the next pointer of the current node, we must store the next node to ensure we don't lose the rest of the list during the reversal. This way, we can safely update the links between the previous and current nodes.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/G0_I-ZF0S38/0.jpg)](https://www.youtube.com/watch?v=G0_I-ZF0S38)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=G0_I-ZF0S38)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/reverse-a-linked-list)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Recursion






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
    public ListNode ReverseList(ListNode head) {
        if (head == null) {
            return null;
        }

        ListNode newHead = head;
        if (head.next != null) {
            newHead = ReverseList(head.next);
            head.next.next = head;
        }
        head.next = null;

        return newHead;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 2. Iteration






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
    public ListNode ReverseList(ListNode head) {
        ListNode prev = null;
        ListNode curr = head;

        while (curr != null) {
            ListNode temp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = temp;
        }
        return prev;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$
