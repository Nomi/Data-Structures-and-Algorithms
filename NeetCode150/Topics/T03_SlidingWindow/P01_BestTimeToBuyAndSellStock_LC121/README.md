# ⭐ | Best Time to Buy And Sell Stock

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
- [Sliding Window Fixed Size](https://neetcode.io/courses/advanced-algorithms/1) [from NeetCode's Course(s)]
- [Sliding Window Variable Size](https://neetcode.io/courses/advanced-algorithms/2) [from NeetCode's Course(s)]


## Problem Description
You are given an integer array `prices` where `prices[i]` is the price of NeetCoin on the `ith` day.

You may choose a **single day** to buy one NeetCoin and choose a **different day in the future** to sell it.

Return the maximum profit you can achieve. You may choose to **not make any transactions**, in which case the profit would be `0`.

**Example 1:**

```java
Input: prices = [10,1,5,6,7,1]

Output: 6
```
Explanation: Buy `prices[1]` and sell `prices[4]`, `profit = 7 - 1 = 6`.

**Example 2:**

```java
Input: prices = [10,8,7,5,2]

Output: 0
```

Explanation: No profitable transactions can be made, thus the max profit is 0.

**Constraints:**
* `1 <= prices.length <= 100`
* `0 <= prices[i] <= 100`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time and <code>O(1)</code> space, where <code>n</code> is the size of the input array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would be to iterate through the array with index <code>i</code>, considering it as the day to buy, and trying all possible options for selling it on the days to the right of index <code>i</code>. This would be an <code>O(n^2)</code> solution. Can you think of a better way?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    You should buy at a price and always sell at a higher price. Can you iterate through the array with index <code>i</code>, considering it as either the buying price or the selling price?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We can iterate through the array with index <code>i</code>, considering it as the selling value. But what value will it be optimal to consider as buying point on the left of index <code>i</code>?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We are trying to maximize <code>profit = sell - buy</code>. If the current <code>i</code> is the sell value, we want to choose the minimum buy value to the left of <code>i</code> to maximize the profit. The result will be the maximum profit among all. However, if all profits are negative, we can return <code>0</code> since we are allowed to skip doing transaction. 
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/1pkOgXD63yU/0.jpg)](https://www.youtube.com/watch?v=1pkOgXD63yU)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=1pkOgXD63yU)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/buy-and-sell-crypto)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public int MaxProfit(int[] prices) {
        int res = 0;
        for (int i = 0; i < prices.Length; i++) {
            int buy = prices[i];
            for (int j = i + 1; j < prices.Length; j++) {
                int sell = prices[j];
                res = Math.Max(res, sell - buy);
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(1)$

---

### 2. Two Pointers






```csharp
public class Solution {
    public int MaxProfit(int[] prices) {
        int l = 0, r = 1;
        int maxP = 0;

        while (r < prices.Length) {
            if (prices[l] < prices[r]) {
                int profit = prices[r] - prices[l];
                maxP = Math.Max(maxP, profit);
            } else {
                l = r;
            }
            r++;
        }
        return maxP;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$

---

### 3. Dynamic Programming






```csharp
public class Solution {
    public int MaxProfit(int[] prices) {
        int maxP = 0;
        int minBuy = prices[0];

        foreach (int sell in prices) {
            maxP = Math.Max(maxP, sell - minBuy);
            minBuy = Math.Min(minBuy, sell);
        }
        return maxP;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(1)$
