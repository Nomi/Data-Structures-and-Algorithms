# ⭐ | Combination Sum

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
- [Tree Maze](https://neetcode.io/courses/dsa-for-beginners/22) [from NeetCode's Course(s)]
- [Combinations](https://neetcode.io/courses/advanced-algorithms/12) [from NeetCode's Course(s)]


## Problem Description
You are given an array of **distinct** integers `nums` and a target integer `target`. Your task is to return a list of all **unique combinations** of `nums` where the chosen numbers sum to `target`.

The **same** number may be chosen from `nums` an **unlimited number of times**. Two combinations are the same if the frequency of each of the chosen numbers is the same, otherwise they are different.

You may return the combinations in **any order** and the order of the numbers in each combination can be in **any order**.

**Example 1:**

```java
Input: 
nums = [2,5,6,9] 
target = 9

Output: [[2,2,5],[9]]
```

Explanation:
2 + 2 + 5 = 9. We use 2 twice, and 5 once.
9 = 9. We use 9 once.

**Example 2:**

```java
Input: 
nums = [3,4,5]
target = 16

Output: [[3,3,3,3,4],[3,3,5,5],[4,4,4,4],[3,4,4,5]]
```

**Example 3:**

```java
Input: 
nums = [3]
target = 5

Output: []
```

**Constraints:**
* All elements of `nums` are **distinct**.
* `1 <= nums.length <= 20`
* `2 <= nums[i] <= 30`
* `2 <= target <= 30`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(2^(t/m))</code> time and <code>O(t/m)</code> space, where <code>t</code> is the given <code>target</code> and <code>m</code> is the minimum value in the given array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    Can you think of this problem in terms of a decision tree, where at each step, we have <code>n</code> decisions, where <code>n</code> is the size of the array? In this decision tree, we can observe that different combinations of paths are formed. Can you think of a base condition to stop extending a path? Maybe you should consider the target value. 
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use backtracking to recursively traverse these paths and make decisions to choose an element at each step. We maintain a variable <code>sum</code>, which represents the sum of all the elements chosen in the current path. We stop this recursive path if <code>sum == target</code>, and add a copy of the chosen elements to the result. How do you implement it?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We recursively traverse the array starting from index <code>i</code>. At each step, we select an element from <code>i</code> to the end of the array. We extend the recursive path with elements where <code>sum <= target</code> after including that element. This creates multiple recursive paths, and we append the current list to the result whenever the base condition is met.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/GBKI9VSKdGg/0.jpg)](https://www.youtube.com/watch?v=GBKI9VSKdGg)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=GBKI9VSKdGg)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/combination-target-sum)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Backtracking






```csharp
public class Solution {
    
    List<List<int>> res = new List<List<int>>();

    public void backtrack(int i, List<int> cur, int total, int[] nums, int target) {
        if(total == target) {
            res.Add(cur.ToList());
            return;
        }
        
        if(total > target || i >= nums.Length) return;
        
        cur.Add(nums[i]);
        backtrack(i, cur, total + nums[i], nums, target);
        cur.Remove(cur.Last());

        backtrack(i + 1, cur, total, nums, target);
        
    }
    public List<List<int>> CombinationSum(int[] nums, int target) {
        backtrack(0, new List<int>(), 0, nums, target);
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(2 ^ \frac{t}{m})$
* Space complexity: $O(\frac{t}{m})$

> Where $t$ is the given $target$ and $m$ is the minimum value in $nums$.

---

### 2. Backtracking (Optimal)






```csharp
public class Solution {
    List<List<int>> res;
    public List<List<int>> CombinationSum(int[] nums, int target) {
        res = new List<List<int>>();
        Array.Sort(nums);
        dfs(0, new List<int>(), 0, nums, target);
        return res;
    }

    private void dfs(int i, List<int> cur, int total, int[] nums, int target) {
        if (total == target) {
            res.Add(new List<int>(cur));
            return;
        }
        
        for (int j = i; j < nums.Length; j++) {
            if (total + nums[j] > target) {
                return;
            }
            cur.Add(nums[j]);
            dfs(j, cur, total + nums[j], nums, target);
            cur.RemoveAt(cur.Count - 1);
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(2 ^ \frac{t}{m})$
* Space complexity: $O(\frac{t}{m})$

> Where $t$ is the given $target$ and $m$ is the minimum value in $nums$.
