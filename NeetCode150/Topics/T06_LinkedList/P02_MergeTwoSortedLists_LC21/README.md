# ⭐ | Merge Two Sorted Lists

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
- [Singly Linked Lists](https://neetcode.io/courses/dsa-for-beginners/5) [from NeetCode's Course(s)]


## Problem Description
You are given the heads of two sorted linked lists `list1` and `list2`.

Merge the two lists into one **sorted** linked list and return the head of the new sorted linked list.

The new list should be made up of nodes from `list1` and `list2`.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/51adfea9-493a-4abb-ece7-fbb359d1c800/public)

```java
Input: list1 = [1,2,4], list2 = [1,3,5]

Output: [1,1,2,3,4,5]
```

**Example 2:**

```java
Input: list1 = [], list2 = [1,2]

Output: [1,2]
```

**Example 3:**

```java
Input: list1 = [], list2 = []

Output: []
```

**Constraints:**
* `0 <= The length of the each list <= 100`.
* `-100 <= Node.val <= 100`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n + m)</code> time and <code>O(1)</code> space, where <code>n</code> is the length of <code>list1</code> and <code>m</code> is the length of <code>list2</code>.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would involve storing the values of both linked lists in an array, sorting the array, and then converting it back into a linked list. This approach would use <code>O(n)</code> extra space and is trivial. Can you think of a better way? Perhaps the sorted nature of the lists can be leveraged.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We create a dummy node to keep track of the head of the resulting linked list while iterating through the lists. Using <code>l1</code> and <code>l2</code> as iterators for <code>list1</code> and <code>list2</code>, respectively, we traverse both lists node by node to build a final linked list that is also sorted. How do you implement this?
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    For example, consider <code>list1 = [1, 2, 3]</code> and <code>list2 = [2, 3, 4]</code>. While iterating through the lists, we move the pointers by comparing the node values from both lists. We link the next pointer of the iterator to the node with the smaller value. For instance, when <code>l1 = 1</code> and <code>l2 = 2</code>, since <code>l1 < l2</code>, we point the iterator's next pointer to <code>l1</code> and proceed.
    </p>
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/XIdigk956u0/0.jpg)](https://www.youtube.com/watch?v=XIdigk956u0)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=XIdigk956u0)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/merge-two-sorted-linked-lists)
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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if (list1 == null) {
            return list2;
        }
        if (list2 == null) {
            return list1;
        }
        if (list1.val <= list2.val) {
            list1.next = MergeTwoLists(list1.next, list2);
            return list1;
        } else {
            list2.next = MergeTwoLists(list1, list2.next);
            return list2;
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n + m)$
* Space complexity: $O(n + m)$

> Where $n$ is the length of $list1$ and $m$ is the length of $list2$.

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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode dummy = new ListNode(0);
        ListNode node = dummy;

        while (list1 != null && list2 != null) {
            if (list1.val < list2.val) {
                node.next = list1;
                list1 = list1.next;
            } else {
                node.next = list2;
                list2 = list2.next;
            }
            node = node.next;
        }

        if (list1 != null) {
            node.next = list1;
        } else {
            node.next = list2;
        }

        return dummy.next;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n + m)$
* Space complexity: $O(1)$

> Where $n$ is the length of $list1$ and $m$ is the length of $list2$.
