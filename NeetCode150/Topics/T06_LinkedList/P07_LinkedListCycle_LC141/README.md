# ⭐ | Linked List Cycle

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
- [Fast and Slow Pointers](https://neetcode.io/courses/advanced-algorithms/5) [from NeetCode's Course(s)]


## Problem Description
Given the beginning of a linked list `head`, return `true` if there is a cycle in the linked list. Otherwise, return `false`.

There is a cycle in a linked list if at least one node in the list that can be visited again by following the `next` pointer.

Internally, `index` determines the index of the beginning of the cycle, if it exists. The tail node of the list will set it's `next` pointer to the `index-th` node. If `index = -1`, then the tail node points to `null` and no cycle exists.

**Note:** `index` is **not** given to you as a parameter.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/3ecdbcfc-70fc-429a-4654-cf4f6a7dbe00/public)

```java
Input: head = [1,2,3,4], index = 1

Output: true
```

Explanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).

**Example 2:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/89e6716c-9f65-46da-d7b2-f04a93269700/public)

```java
Input: head = [1,2], index = -1

Output: false
```

**Constraints:**
* `1 <= Length of the list <= 1000`.
* `-1000 <= Node.val <= 1000`
* `index` is `-1` or a valid index in the linked list.

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
    A naive approach would be to use a hash set, which takes <code>O(1)</code> time to detect duplicates. Although this solution is acceptable, it requires <code>O(n)</code> extra space. Can you think of a better solution that avoids using extra space? Maybe there is an efficient algorithm which uses two pointers.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use the fast and slow pointers technique, which is primarily used to detect cycles in a linked list. We iterate through the list using two pointers. The slow pointer moves one step at a time, while the fast pointer moves two steps at a time. If the list has a cycle, these two pointers will eventually meet. Why does this work?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    When there is no cycle in the list, the loop ends when the fast pointer becomes <code>null</code>. If a cycle exists, the fast pointer moves faster and continuously loops through the cycle. With each step, it reduces the gap between itself and the slow pointer by one node. For example, if the gap is <code>10</code>, the slow pointer moves by <code>1</code>, increasing the gap to <code>11</code>, while the fast pointer moves by <code>2</code>, reducing the gap to <code>9</code>. This process continues until the fast pointer catches up to the slow pointer, confirming a cycle.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/gBTe7lFR3vc/0.jpg)](https://www.youtube.com/watch?v=gBTe7lFR3vc)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=gBTe7lFR3vc)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/linked-list-cycle-detection)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Hash Set






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
    public bool HasCycle(ListNode head) {
        HashSet<ListNode> seen = new HashSet<ListNode>();
        ListNode cur = head;
        while (cur != null) {
            if (seen.Contains(cur)) {
                return true;
            }
            seen.Add(cur);
            cur = cur.next;
        }
        return false;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 2. Fast And Slow Pointers






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
    public bool HasCycle(ListNode head) {
        ListNode slow = head, fast = head;

        while (fast != null && fast.next != null) {
            fast = fast.next.next;
            slow = slow.next;
            if (slow.Equals(fast)) return true;
        }
        return false;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$
