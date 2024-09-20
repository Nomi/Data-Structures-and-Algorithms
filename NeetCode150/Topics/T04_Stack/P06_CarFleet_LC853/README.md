# ⭐ | Car Fleet

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
- [Stacks](https://neetcode.io/courses/dsa-for-beginners/4) [from NeetCode's Course(s)]


## Problem Description
There are `n` cars traveling to the same destination on a one-lane highway.

You are given two arrays of integers `position` and `speed`, both of length `n`. 
* `position[i]` is the position of the `ith car` (in miles)
* `speed[i]` is the speed of the `ith` car (in miles per hour)

The **destination** is at position `target` miles.

A car can **not** pass another car ahead of it. It can only catch up to another car and then drive at the same speed as the car ahead of it.

A **car fleet** is a non-empty set of cars driving at the same position and same speed. A single car is also considered a car fleet.

If a car catches up to a car fleet the moment the fleet reaches the destination, then the car is considered to be part of the fleet.

Return the number of **different car fleets** that will arrive at the destination.

**Example 1:**

```java
Input: target = 10, position = [1,4], speed = [3,2]

Output: 1
```

Explanation: The cars starting at 1 (speed 3) and 4 (speed 2) become a fleet, meeting each other at 10, the destination.

**Example 2:**

```java
Input: target = 10, position = [4,1,0,7], speed = [2,2,1,1]

Output: 3
```

Explanation: The cars starting at 4 and 7 become a fleet at position 10. The cars starting at 1 and 0 never catch up to the car ahead of them. Thus, there are 3 car fleets that will arrive at the destination.

**Constraints:**
* `n == position.length == speed.length`.
* `1 <= n <= 1000`
* `0 < target <= 1000`
* `0 < speed[i] <= 100`
* `0 <= position[i] < target`
* All the values of `position` are **unique**.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(nlogn)</code> time and <code>O(n)</code> space, where <code>n</code> is the size of the input array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    First draw a picture of all the points which represents the positions and respective speeds of the cars. It is appropriate to represent the position and speed of each car as an array, where each cell corresponds to a car. It is also logical to sort this array based on the positions in descending order. Why?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
     Because a car can only form a fleet with another car that is ahead of it, sorting the array in descending order ensures clarity about the final speed of each car. Sorting in ascending order would create ambiguity, as the next car might form a fleet with another car while reaching the target, making it difficult to determine its final speed.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    Calculating the time for a car to reach the target is straightforward and can be done using the formula: <code>time = (target - position) / speed</code>. Now, it becomes easy to identify that two cars will form a fleet if and only if the car ahead has a time that is greater than or equal to the time of the car behind it. How can we maintain the total number of fleets happened while going through the array? Maybe a data structure is helpful.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We can use a stack to maintain the times of the fleets. As we iterate through the array (sorted in descending order of positions), we compute the time for each car to reach the target and check if it can form a fleet with the car ahead. If the current car's time is less than or equal to the top of the stack, it joins the same fleet. Otherwise, it forms a new fleet, and we push its time onto the stack. The length of the stack at the end represents the total number of fleets formed.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/Pr6T-3yB9RM/0.jpg)](https://www.youtube.com/watch?v=Pr6T-3yB9RM)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=Pr6T-3yB9RM)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/car-fleet)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Stack






```csharp
public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        int[][] pair = new int[position.Length][];
        for (int i = 0; i < position.Length; i++) {
            pair[i] = new int[] { position[i], speed[i] };
        }
        Array.Sort(pair, (a, b) => b[0].CompareTo(a[0]));
        Stack<double> stack = new Stack<double>();
        foreach (var p in pair) {
            stack.Push((double)(target - p[0]) / p[1]);
            if (stack.Count >= 2 && stack.Peek() <= stack.ElementAt(1)) {
                stack.Pop();
            }
        }
        return stack.Count;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log n)$
* Space complexity: $O(n)$

---

### 2. Iteration






```csharp
public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        int n = position.Length;
        int[][] pair = new int[n][];
        for (int i = 0; i < n; i++) {
            pair[i] = new int[] { position[i], speed[i] };
        }
        Array.Sort(pair, (a, b) => b[0].CompareTo(a[0]));
        
        int fleets = 1;
        double prevTime = (double)(target - pair[0][0]) / pair[0][1];
        for (int i = 1; i < n; i++) {
            double currTime = (double)(target - pair[i][0]) / pair[i][1];
            if (currTime > prevTime) {
                fleets++;
                prevTime = currTime;
            }
        }
        return fleets;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log n)$
* Space complexity: $O(n)$
