# ⭐ | Task Scheduler

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
- [Heap Properties](https://neetcode.io/courses/dsa-for-beginners/23) [from NeetCode's Course(s)]
- [Push and Pop](https://neetcode.io/courses/dsa-for-beginners/24) [from NeetCode's Course(s)]
- [Heapify](https://neetcode.io/courses/dsa-for-beginners/25) [from NeetCode's Course(s)]


## Problem Description
You are given an array of CPU  tasks `tasks`, where `tasks[i]` is an uppercase english character from `A` to `Z`. You are also given an integer `n`. 
    
Each CPU cycle allows the completion of a single task, and tasks may be completed in any order.

The only constraint is that **identical** tasks must be separated by at least `n` CPU cycles, to cooldown the CPU.

Return the *minimum number* of CPU cycles required to complete all tasks.

**Example 1:**

```java
Input: tasks = ["X","X","Y","Y"], n = 2

Output: 5
```

Explanation: A possible sequence is: X -> Y -> idle -> X -> Y.

**Example 2:**

```java
Input: tasks = ["A","A","A","B","C"], n = 3

Output: 9
```

Explanation: A possible sequence is: A -> B -> C -> Idle -> A -> Idle -> Idle -> Idle -> A.

**Constraints:**
* `1 <= tasks.length <= 1000`
* `0 <= n <= 100`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(m)</code> time and <code>O(1)</code> space, where <code>m</code> is the size of the input array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    There are at most <code>26</code> different tasks, represented by <code>A</code> through <code>Z</code>. It is more efficient to count the frequency of each task and store it in a hash map or an array of size <code>26</code>. Can you think of a way to determine which task should be processed first?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We should always process the most frequent task first. After selecting the most frequent task, we must ensure that it is not processed again until after <code>n</code> seconds, due to the cooldown condition. Can you think of an efficient way to select the most frequent task and enforce the cooldown? Perhaps you could use a data structure that allows for <code>O(1)</code> time to retrieve the maximum element and another data structure to cooldown the processed tasks.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We can use a Max-Heap to efficiently retrieve the most frequent task at any given instance. However, to enforce the cooldown period, we must temporarily hold off from reinserting the processed task into the heap. This is where a queue data structure comes in handy. It helps maintain the order of processed tasks. Can you implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We start by calculating the frequency of each task and initialize a variable <code>time</code> to track the total processing time. The task frequencies are inserted into a Max-Heap. We also use a queue to store tasks along with the time they become available after the cooldown. At each step, if the Max-Heap is empty, we update <code>time</code> to match the next available task in the queue, covering idle time. Otherwise, we process the most frequent task from the heap, decrement its frequency, and if it's still valid, add it back to the queue with its next available time. If the task at the front of the queue becomes available, we pop it and reinsert it into the heap.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/s8p8ukTyA2I/0.jpg)](https://www.youtube.com/watch?v=s8p8ukTyA2I)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=s8p8ukTyA2I)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/task-scheduling)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        int[] count = new int[26];
        foreach (char task in tasks) {
            count[task - 'A']++;
        }
        
        List<int[]> arr = new List<int[]>();
        for (int i = 0; i < 26; i++) {
            if (count[i] > 0) {
                arr.Add(new int[] { count[i], i });
            }
        }

        int time = 0;
        List<int> processed = new List<int>();
        while (arr.Count > 0) {
            int maxi = -1;
            for (int i = 0; i < arr.Count; i++) {
                bool ok = true;
                for (int j = Math.Max(0, time - n); j < time; j++) {
                    if (j < processed.Count && processed[j] == arr[i][1]) {
                        ok = false;
                        break;
                    }
                }
                if (!ok) continue;
                if (maxi == -1 || arr[maxi][0] < arr[i][0]) {
                    maxi = i;
                }
            }
            
            time++;
            int cur = -1;
            if (maxi != -1) {
                cur = arr[maxi][1];
                arr[maxi][0]--;
                if (arr[maxi][0] == 0) {
                    arr.RemoveAt(maxi);
                }
            }
            processed.Add(cur);
        }
        return time;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(t * n)$
* Space complexity: $O(t)$

> Where $t$ is the time to process given tasks and $n$ is the cooldown time.

---

### 2. Max-Heap






```csharp
public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        int[] count = new int[26];
        foreach (var task in tasks) {
            count[task - 'A']++;
        }

        var maxHeap = new PriorityQueue<int, int>();
        for (int i = 0; i < 26; i++) {
            if (count[i] > 0) {
                maxHeap.Enqueue(count[i], -count[i]);
            }
        }

        int time = 0;
        Queue<int[]> queue = new Queue<int[]>();  
        while (maxHeap.Count > 0 || queue.Count > 0) {
            if (queue.Count > 0 && time >= queue.Peek()[1]) {
                int[] temp = queue.Dequeue();
                maxHeap.Enqueue(temp[0], -temp[0]);
            }
            if (maxHeap.Count > 0) {
                int cnt = maxHeap.Dequeue() - 1;
                if (cnt > 0) {
                    queue.Enqueue(new int[] { cnt, time + n + 1 });
                }
            }
            time++;
        }
        return time;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m)$
* Space complexity: $O(1)$ since we have at most $26$ different characters.

> Where $m$ is the number of tasks.

---

### 3. Greedy






```csharp
public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        int[] count = new int[26];
        foreach (char task in tasks) {
            count[task - 'A']++;
        }

        Array.Sort(count);
        int maxf = count[25];
        int idle = (maxf - 1) * n;

        for (int i = 24; i >= 0; i--) {
            idle -= Math.Min(maxf - 1, count[i]);
        }
        return Math.Max(0, idle) + tasks.Length;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m)$
* Space complexity: $O(1)$ since we have at most $26$ different characters.

> Where $m$ is the number of tasks.

---

### 4. Math






```csharp
public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        int[] count = new int[26];
        foreach (char task in tasks) {
            count[task - 'A']++;
        }

        int maxf = count.Max();
        int maxCount = 0;
        foreach (int i in count) {
            if (i == maxf) {
                maxCount++;
            }
        }

        int time = (maxf - 1) * (n + 1) + maxCount;
        return Math.Max(tasks.Length, time);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m)$
* Space complexity: $O(1)$ since we have at most $26$ different characters.

> Where $m$ is the number of tasks.
