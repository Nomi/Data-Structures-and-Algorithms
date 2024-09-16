# Min Stack

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
- [Stacks](https://neetcode.io/courses/dsa-for-beginners/4) [from NeetCode's Course(s)]


## Problem Description
Design a stack class that supports the `push`, `pop`, `top`, and `getMin` operations.

* `MinStack()` initializes the stack object.
* `void push(int val)` pushes the element `val` onto the stack.
* `void pop()` removes the element on the top of the stack.
* `int top()` gets the top element of the stack.
* `int getMin()` retrieves the minimum element in the stack.

Each function should run in $O(1)$ time.

**Example 1:**

```java
Input: ["MinStack", "push", 1, "push", 2, "push", 0, "getMin", "pop", "top", "getMin"]

Output: [null,null,null,null,0,null,2,1]

Explanation:
MinStack minStack = new MinStack();
minStack.push(1);
minStack.push(2);
minStack.push(0);
minStack.getMin(); // return 0
minStack.pop();
minStack.top();    // return 2
minStack.getMin(); // return 1
```

**Constraints:**
* `-2^31 <= val <= 2^31 - 1`.
* `pop`, `top` and `getMin` will always be called on **non-empty** stacks.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(1)</code> time for each function call and <code>O(n)</code> space, where <code>n</code> is the maximum number of elements present in the stack.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would be to always check for the minimum element in the stack for the <code>getMin()</code> function call. This would be an <code>O(n)</code> appraoch. Can you think of a better way? Maybe <code>O(n)</code> extra space to store some information. 
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use a stack to maintain the elements. But how can we find the minimum element at any given time? Perhaps we should consider a prefix approach.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We use an additional stack to maintain the prefix minimum element. When popping elements from the main stack, we should also pop from this extra stack. However, when pushing onto the extra stack, we should push the minimum of the top element of the extra stack and the current element onto this extra stack.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/qkLl7nAwDPo/0.jpg)](https://www.youtube.com/watch?v=qkLl7nAwDPo)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=qkLl7nAwDPo)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/minimum-stack)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class MinStack {
    private Stack<int> stack;

    public MinStack() {
        stack = new Stack<int>();
    }
    
    public void Push(int val) {
        stack.Push(val);
    }
    
    public void Pop() {
        stack.Pop();
    }
    
    public int Top() {
        return stack.Peek();
    }
    
    public int GetMin() {
        Stack<int> tmp = new Stack<int>();
        int mini = stack.Peek();

        while (stack.Count > 0) {
            mini = System.Math.Min(mini, stack.Peek());
            tmp.Push(stack.Pop());
        }
        
        while (tmp.Count > 0) {
            stack.Push(tmp.Pop());
        }
        
        return mini;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$ for $getMin()$ and $O(1)$ for other operations.
* Space complexity: $O(n)$ for $getMin()$ and $O(1)$ for other operations.

---

### 2. Two Stacks






```csharp
public class MinStack {
    
    private Stack<int> stack;
    private Stack<int> minStack;

    public MinStack() {
        stack = new Stack<int>();
        minStack = new Stack<int>();
    }

    public void Push(int val) {
        stack.Push(val);
        val = Math.Min(val, minStack.Count == 0 ? val : minStack.Peek());
        minStack.Push(val);
    }

    public void Pop() {
        stack.Pop();
        minStack.Pop();
    }

    public int Top() {
        return stack.Peek();
    }

    public int GetMin() {
        return minStack.Peek();
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(1)$ for all operations.
* Space complexity: $O(n)$

---

### 3. One Stack






```csharp
public class MinStack {
    private long min;
    private Stack<long> stack;

    public MinStack() {
        stack = new Stack<long>();
    }

    public void Push(int val) {
        if (stack.Count == 0) {
            stack.Push(0L);
            min = val;
        } else {
            stack.Push(val - min);
            if (val < min) min = val;
        }
    }

    public void Pop() {
        if (stack.Count == 0) return;

        long pop = stack.Pop();

        if (pop < 0) min -= pop;
    }

    public int Top() {
        long top = stack.Peek();
        return top > 0 ? (int)(top + min) : (int)(min);
    }

    public int GetMin() {
        return (int)min;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(1)$ for all operations.
* Space complexity: $O(n)$
