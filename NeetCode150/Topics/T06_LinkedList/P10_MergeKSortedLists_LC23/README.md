# ⭐ | Merge K Sorted Lists

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
- [Merge Sort](https://neetcode.io/courses/dsa-for-beginners/11) [from NeetCode's Course(s)]
- [Heap Properties](https://neetcode.io/courses/dsa-for-beginners/23) [from NeetCode's Course(s)]
- [Push and Pop](https://neetcode.io/courses/dsa-for-beginners/24) [from NeetCode's Course(s)]


## Problem Description
You are given an array of `k` linked lists `lists`, where each list is sorted in ascending order.

Return the **sorted** linked list that is the result of merging all of the individual linked lists.

**Example 1:**

```java
Input: lists = [[1,2,4],[1,3,5],[3,6]]

Output: [1,1,2,3,3,4,5,6]
```

**Example 2:**

```java
Input: lists = []

Output: []
```

**Example 3:**

```java
Input: lists = [[]]

Output: []
```

**Constraints:**
* `0 <= lists.length <= 1000`
* `0 <= lists[i].length <= 100`
* `-1000 <= lists[i][j] <= 1000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution as good or better than <code>O(n * k)</code> time and <code>O(1)</code> space, where <code>k</code> is the total number of lists and <code>n</code> is the total number of nodes across all lists.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute-force solution would involve storing all <code>n</code> nodes in an array, sorting them, and converting the array back into a linked list, resulting in an <code>O(nlogn)</code> time complexity. Can you think of a better way? Perhaps consider leveraging the idea behind merging two sorted linked lists. 
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can merge two sorted linked lists without using any extra space. To handle <code>k</code> sorted linked lists, we can iteratively merge each linked list with a resultant merged list. How can you implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We iterate through the list array with index <code>i</code>, starting at <code>i = 1</code>. We merge the linked lists using <code>mergeTwoLists(lists[i], lists[i - 1])</code>, which returns the head of the merged list. This head is stored in <code>lists[i]</code>, and the process continues. Finally, the merged list is obtained at the last index, and we return its head.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/q5a5OiGbT6Q/0.jpg)](https://www.youtube.com/watch?v=q5a5OiGbT6Q)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=q5a5OiGbT6Q)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/merge-k-sorted-linked-lists)
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
    public ListNode MergeKLists(ListNode[] lists) {
        List<int> nodes = new List<int>();
        foreach (ListNode lst in lists) {
            ListNode curr = lst;
            while (curr != null) {
                nodes.Add(curr.val);
                curr = curr.next;
            }
        }
        nodes.Sort();

        ListNode res = new ListNode(0);
        ListNode cur = res;
        foreach (int node in nodes) {
            cur.next = new ListNode(node);
            cur = cur.next;
        }
        return res.next;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log n)$
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
    public ListNode MergeKLists(ListNode[] lists) {
        ListNode res = new ListNode(0);
        ListNode cur = res;

        while (true) {
            int minNode = -1;
            for (int i = 0; i < lists.Length; i++) {
                if (lists[i] == null) continue;
                if (minNode == -1 || lists[minNode].val > lists[i].val) {
                    minNode = i;
                }
            }

            if (minNode == -1) break;
            cur.next = lists[minNode];
            lists[minNode] = lists[minNode].next;
            cur = cur.next;
        }
        return res.next;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * k)$
* Space complexity: $O(1)$

> Where $k$ is the total number of lists and $n$ is the total number of nodes across $k$ lists.

---

### 3. Merge Lists One By One






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
    public ListNode MergeKLists(ListNode[] lists) {
        if (lists.Length == 0) return null;

        for (int i = 1; i < lists.Length; i++) {
            lists[i] = Merge(lists[i], lists[i - 1]);
        }
        return lists[lists.Length - 1];
    }

    private ListNode Merge(ListNode l1, ListNode l2) {
        ListNode dummy = new ListNode(0);
        ListNode curr = dummy;

        while (l1 != null && l2 != null) {
            if (l1.val <= l2.val) {
                curr.next = l1;
                l1 = l1.next;
            } else {
                curr.next = l2;
                l2 = l2.next;
            }
            curr = curr.next;
        }

        if (l1 != null) {
            curr.next = l1;
        } else {
            curr.next = l2;
        }

        return dummy.next;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * k)$
* Space complexity: $O(1)$

> Where $k$ is the total number of lists and $n$ is the total number of nodes across $k$ lists.

---

### 4. Heap






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
    public ListNode MergeKLists(ListNode[] lists) {
        if (lists.Length == 0) return null;

        var minHeap = new PriorityQueue<ListNode, int>();
        foreach (var list in lists) {
            if (list != null) {
                minHeap.Enqueue(list, list.val);
            }
        }

        var res = new ListNode(0);
        var cur = res;
        while (minHeap.Count > 0) {
            var node = minHeap.Dequeue();
            cur.next = node;
            cur = cur.next;

            node = node.next;
            if (node != null) {
                minHeap.Enqueue(node, node.val);
            }
        }
        return res.next;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log k)$
* Space complexity: $O(k)$

> Where $k$ is the total number of lists and $n$ is the total number of nodes across $k$ lists.

---

### 5. Divide And Conquer (Recursion)






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
    public ListNode MergeKLists(ListNode[] lists) {
        if (lists == null || lists.Length == 0) {
            return null;
        }
        return Divide(lists, 0, lists.Length - 1);
    }

    private ListNode Divide(ListNode[] lists, int l, int r) {
        if (l > r) {
            return null;
        }
        if (l == r) {
            return lists[l];
        }
        int mid = l + (r - l) / 2;
        ListNode left = Divide(lists, l, mid);
        ListNode right = Divide(lists, mid + 1, r);
        return Conquer(left, right);
    }

    private ListNode Conquer(ListNode l1, ListNode l2) {
        ListNode dummy = new ListNode(0);
        ListNode curr = dummy;

        while (l1 != null && l2 != null) {
            if (l1.val <= l2.val) {
                curr.next = l1;
                l1 = l1.next;
            } else {
                curr.next = l2;
                l2 = l2.next;
            }
            curr = curr.next;
        }

        if (l1 != null) {
            curr.next = l1;
        } else {
            curr.next = l2;
        }

        return dummy.next;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log k)$
* Space complexity: $O(\log k)$

> Where $k$ is the total number of lists and $n$ is the total number of nodes across $k$ lists.

---

### 6. Divide And Conquer (Iteration)






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
    public ListNode MergeKLists(ListNode[] lists) {
        if (lists == null || lists.Length == 0) {
            return null;
        }

        while (lists.Length > 1) {
            List<ListNode> mergedLists = new List<ListNode>();
            for (int i = 0; i < lists.Length; i += 2) {
                ListNode l1 = lists[i];
                ListNode l2 = (i + 1) < lists.Length ? lists[i + 1] : null;
                mergedLists.Add(MergeList(l1, l2));
            }
            lists = mergedLists.ToArray();
        }
        return lists[0];
    }

    private ListNode MergeList(ListNode l1, ListNode l2) {
        ListNode dummy = new ListNode();
        ListNode tail = dummy;

        while (l1 != null && l2 != null) {
            if (l1.val < l2.val) {
                tail.next = l1;
                l1 = l1.next;
            } else {
                tail.next = l2;
                l2 = l2.next;
            }
            tail = tail.next;
        }
        if (l1 != null) {
            tail.next = l1;
        }
        if (l2 != null) {
            tail.next = l2;
        }
        return dummy.next;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log k)$
* Space complexity: $O(k)$

> Where $k$ is the total number of lists and $n$ is the total number of nodes across $k$ lists.
