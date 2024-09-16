# Evaluate Reverse Polish Notation

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
You are given an array of strings `tokens` that represents a **valid** arithmetic expression in [Reverse Polish Notation](https://en.wikipedia.org/wiki/Reverse_Polish_notation).

Return the integer that represents the evaluation of the expression.

* The operands may be integers or the results of other operations.
* The operators include `'+'`, `'-'`, `'*'`, and `'/'`.
* Assume that division between integers always truncates toward zero.

**Example 1:**

```java
Input: tokens = ["1","2","+","3","*","4","-"]

Output: 5

Explanation: ((1 + 2) * 3) - 4 = 5
```

**Constraints:**
* `1 <= tokens.length <= 1000`.
* tokens[i] is `"+"`, `"-"`, `"*"`, or `"/"`, or a string representing an integer in the range `[-100, 100]`.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time and <code>O(n)</code> space, where <code>n</code> is the size of the input array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would involve repeatedly finding an operator <code>+ - * /</code> in the array and modifying the array by computing the result for that operator and two operands to its left. This would be an <code>O(n^2)</code> solution. Can you think of a better way? Maybe we can use a data structure to handle operations efficiently.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use a stack. We iterate through the array, and if we encounter a number, we push it onto the stack. If we encounter an operator, we pop two elements from the stack, treat them as operands, and solve the equation using the current operator. Then, we push the result back onto the stack. Why does this work?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    As the array has postfix expression, stack helps us to maintain the correct order of operations by ensuring that we always use the most recent operands (those closest to the operator) when performing the operation. After the iteration, the final result is left in the stack.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/iu0082c4HDE/0.jpg)](https://www.youtube.com/watch?v=iu0082c4HDE)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=iu0082c4HDE)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/evaluate-reverse-polish-notation)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public int EvalRPN(string[] tokens) {
        List<string> tokenList = new List<string>(tokens);
        
        while (tokenList.Count > 1) {
            for (int i = 0; i < tokenList.Count; i++) {
                if ("+-*/".Contains(tokenList[i])) {
                    int a = int.Parse(tokenList[i - 2]);
                    int b = int.Parse(tokenList[i - 1]);
                    int result = 0;
                    switch (tokenList[i]) {
                        case "+":
                            result = a + b;
                            break;
                        case "-":
                            result = a - b;
                            break;
                        case "*":
                            result = a * b;
                            break;
                        case "/":
                            result = a / b;
                            break;
                    }
                    tokenList.RemoveRange(i - 2, 3);
                    tokenList.Insert(i - 2, result.ToString());
                    break;
                }
            }
        }
        return int.Parse(tokenList[0]);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(n)$

---

### 2. Doubly Linked List






```csharp
public class DoublyLinkedList {
    public string val;
    public DoublyLinkedList next;
    public DoublyLinkedList prev;

    public DoublyLinkedList(string val, DoublyLinkedList next = null, 
                            DoublyLinkedList prev = null) {
        this.val = val;
        this.next = next;
        this.prev = prev;
    }
}

public class Solution {
    public int EvalRPN(string[] tokens) {
        DoublyLinkedList head = new DoublyLinkedList(tokens[0]);
        DoublyLinkedList curr = head;

        for (int i = 1; i < tokens.Length; i++) {
            curr.next = new DoublyLinkedList(tokens[i], null, curr);
            curr = curr.next;
        }

        int ans = 0;
        while (head != null) {
            if ("+-*/".Contains(head.val)) {
                int l = int.Parse(head.prev.prev.val);
                int r = int.Parse(head.prev.val);
                int res = 0;
                if (head.val == "+") {
                    res = l + r;
                } else if (head.val == "-") {
                    res = l - r;
                } else if (head.val == "*") {
                    res = l * r;
                } else {
                    res = l / r;
                }

                head.val = res.ToString();
                head.prev = head.prev.prev.prev;
                if (head.prev != null) {
                    head.prev.next = head;
                }
            }

            ans = int.Parse(head.val);
            head = head.next;
        }

        return ans;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 3. Recursion






```csharp
public class Solution {
    public int EvalRPN(string[] tokens) {
        List<string> tokenList = new List<string>(tokens);
        return DFS(tokenList);
    }

    public int DFS(List<string> tokens) {
        string token = tokens[tokens.Count - 1];
        tokens.RemoveAt(tokens.Count - 1);

        if (token != "+" && token != "-" &&
         token != "*" && token != "/") {
            return int.Parse(token);
        }

        int right = DFS(tokens);
        int left = DFS(tokens);

        if (token == "+") {
            return left + right;
        } else if (token == "-") {
            return left - right;
        } else if (token == "*") {
            return left * right;
        } else {
            return left / right;
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 4. Stack






```csharp
public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int> stack = new Stack<int>();
        foreach (string c in tokens) {
            if (c == "+") {
                stack.Push(stack.Pop() + stack.Pop());
            } else if (c == "-") {
                int a = stack.Pop();
                int b = stack.Pop();
                stack.Push(b - a);
            } else if (c == "*") {
                stack.Push(stack.Pop() * stack.Pop());
            } else if (c == "/") {
                int a = stack.Pop();
                int b = stack.Pop();
                stack.Push((int) ((double) b / a));
            } else {
                stack.Push(int.Parse(c));
            }
        }
        return stack.Pop();
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
