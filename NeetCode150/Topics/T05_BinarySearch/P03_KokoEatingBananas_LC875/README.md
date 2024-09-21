# Koko Eating Bananas

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
- [Search Array](https://neetcode.io/courses/dsa-for-beginners/14) [from NeetCode's Course(s)]
- [Search Range](https://neetcode.io/courses/dsa-for-beginners/15) [from NeetCode's Course(s)]


## Problem Description
You are given an integer array `piles` where `piles[i]` is the number of bananas in the `ith` pile. You are also given an integer `h`, which represents the number of hours you have to eat all the bananas.

You may decide your bananas-per-hour eating rate of `k`. Each hour, you may choose a pile of bananas and eats `k` bananas from that pile. If the pile has less than `k` bananas, you may finish eating the pile but you can not eat from another pile in the same hour.

Return the minimum integer `k` such that you can eat all the bananas within `h` hours.

**Example 1:**

```java
Input: piles = [1,4,3,2], h = 9

Output: 2
```

Explanation: With an eating rate of 2, you can eat the bananas in 6 hours. With an eating rate of 1, you would need 10 hours to eat all the bananas (which exceeds h=9), thus the minimum eating rate is 2.

**Example 2:**

```java
Input: piles = [25,10,23,4], h = 4

Output: 25
```

**Constraints:**
* `1 <= piles.length <= 1,000`
* `piles.length <= h <= 1,000,000`
* `1 <= piles[i] <= 1,000,000,000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(nlogm)</code> time and <code>O(1)</code> space, where <code>n</code> is the size of the input array, and <code>m</code> is the maximum value in the array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    Given <code>h</code> is always greater than or equal to the length of piles, can you determine the upper bound for the answer? How much time does it take Koko to eat a pile with <code>x</code> bananas? 
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    It takes <code>ceil(x / k)</code> time to finish the <code>x</code> pile when Koko eats at a rate of <code>k</code> bananas per hour. Our task is to determine the minimum possible value of <code>k</code>. However, we must also ensure that at this rate, <code>k</code>, Koko can finish eating all the piles within the given <code>h</code> hours. Can you now think of the upper bound for <code>k</code>?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    The upper bound for <code>k</code> is the maximum size of all the piles. Why? Because if Koko eats the largest pile in one hour, then it is straightforward that she can eat any other pile in an hour only.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    Consider <code>m</code> to be the largest pile and <code>n</code> to be the number of piles. A brute force solution would be to linearly check all values from <code>1</code> to <code>m</code> and find the minimum possible value at which Koko can complete the task. This approach would take <code>O(n * m)</code> time. Can you think of a more efficient method? Perhaps an efficient searching algorithm could help.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 5</summary>
    <p>
    Rather than linearly scanning, we can use binary search. The upper bound of <code>k</code> is <code>max(piles)</code> and since we are only dealing with positive values, the lower bound is <code>1</code>. The search space of our binary search is <code>1</code> through <code>max(piles)</code>. This allows us to find the smallest possible <code>k</code> using binary search.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/U2SozAs9RzA/0.jpg)](https://www.youtube.com/watch?v=U2SozAs9RzA)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=U2SozAs9RzA)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/eating-bananas)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int speed = 1;
        while (true) {
            long totalTime = 0;
            foreach (int pile in piles) {
                totalTime += (int) Math.Ceiling((double) pile / speed);
            }

            if (totalTime <= h) {
                return speed;
            }
            speed++;
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * n)$
* Space complexity: $O(1)$

> Where $n$ is the length of the input array $piles$ and $m$ is the maximum number of bananas in a pile.

---

### 2. Binary Search






```csharp
public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int l = 1;
        int r = piles.Max();
        int res = r;

        while (l <= r) {
            int k = (l + r) / 2;

            long totalTime = 0;
            foreach (int p in piles) {
                totalTime += (int)Math.Ceiling((double)p / k);
            }
            if (totalTime <= h) {
                res = k;
                r = k - 1;
            } else {
                l = k + 1;
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * \log m)$
* Space complexity: $O(1)$

> Where $n$ is the length of the input array $piles$ and $m$ is the maximum number of bananas in a pile.
