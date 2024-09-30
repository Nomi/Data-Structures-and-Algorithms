# ⭐ | Reverse Nodes In K Group

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
- [Singly Linked Lists](https://neetcode.io/courses/dsa-for-beginners/5) [from NeetCode's Course(s)]


## Problem Description
You are given the head of a singly linked list `head` and a positive integer `k`.

You must reverse the first `k` nodes in the linked list, and then reverse the next `k` nodes, and so on. If there are fewer than `k` nodes left, leave the nodes as they are.

Return the modified list after reversing the nodes in each group of `k`.

You are only allowed to modify the nodes' `next` pointers, not the values of the nodes.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/67cf2fff-f20a-4558-6091-c3e857f56e00/public)

```java
Input: head = [1,2,3,4,5,6], k = 3

Output: [3,2,1,6,5,4]
```

**Example 2:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/af843e59-df12-4c55-652b-6ddab0a92900/public)

```java
Input: head = [1,2,3,4,5], k = 3

Output: [3,2,1,4,5]
```

**Constraints:**
* The length of the linked list is `n`.
* `1 <= k <= n <= 100`
* `0 <= Node.val <= 100`

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
    A brute-force solution would involve storing the linked list node values in an array, reversing the <code>k</code> groups one by one, and then converting the array back into a linked list, requiring extra space of <code>O(n)</code>. Can you think of a better way? Perhaps you could apply the idea of reversing a linked list in-place without using extra space.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can avoid extra space by reversing each group in-place while keeping track of the head of the next group. For example, consider the list <code>[1, 2, 3, 4, 5]</code> with <code>k = 2</code>. First, we reverse the group <code>[1, 2]</code> to <code>[2, 1]</code>. Then, we reverse <code>[3, 4]</code>, resulting in <code>[2, 1, 4, 3, 5]</code>. While reversing <code>[3, 4]</code>, we need to link <code>1</code> to <code>4</code> and also link <code>3</code> to <code>5</code>. How can we efficiently manage these pointers?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We create a dummy node to handle modifications to the head of the linked list, pointing its <code>next</code> pointer to the current head. We then iterate <code>k</code> nodes, storing the address of the next group's head and tracking the tail of the previous group. After reversing the current group, we reconnect it by linking the previous group's tail to the new head and the current group's tail to the next group's head. This process is repeated for all groups, and we return the new head of the linked list.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/1UOPsfP85V4/0.jpg)](https://www.youtube.com/watch?v=1UOPsfP85V4)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=1UOPsfP85V4)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/reverse-nodes-in-k-group)
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
    public ListNode ReverseKGroup(ListNode head, int k) {
        ListNode cur = head;
        int group = 0;
        while (cur != null && group < k) {
            cur = cur.next;
            group++;
        }

        if (group == k) {
            cur = ReverseKGroup(cur, k);
            while (group-- > 0) {
                ListNode tmp = head.next;
                head.next = cur;
                cur = head;
                head = tmp;
            }
            head = cur;
        }
        return head;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(\frac{n}{k})$

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
    public ListNode ReverseKGroup(ListNode head, int k) {
        ListNode dummy = new ListNode(0, head);
        ListNode groupPrev = dummy;

        while (true) {
            ListNode kth = GetKth(groupPrev, k);
            if (kth == null) {
                break;
            }
            ListNode groupNext = kth.next;

            ListNode prev = kth.next;
            ListNode curr = groupPrev.next;
            while (curr != groupNext) {
                ListNode tmp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = tmp;
            }

            ListNode tmpNode = groupPrev.next;
            groupPrev.next = kth;
            groupPrev = tmpNode;
        }
        return dummy.next;
    }

    private ListNode GetKth(ListNode curr, int k) {
        while (curr != null && k > 0) {
            curr = curr.next;
            k--;
        }
        return curr;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$
