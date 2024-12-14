# ⭐ | Subsets

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
- [Subsets](https://neetcode.io/courses/advanced-algorithms/11) [from NeetCode's Course(s)]


## Problem Description
Given an array `nums` of **unique** integers, return all possible subsets of `nums`.

The solution set must **not** contain duplicate subsets. You may return the solution in **any order**.

**Example 1:**

```java
Input: nums = [1,2,3]

Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]
```

**Example 2:**

```java
Input: nums = [7]

Output: [[],[7]]
```

**Constraints:**
* `1 <= nums.length <= 10`
* `-10 <= nums[i] <= 10`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n * (2^n))</code> time and <code>O(n)</code> space, where <code>n</code> is the size of the input array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    It is straightforward that if the array is empty we return an empty array. When we have an array <code>[1]</code> which is of size <code>1</code>, we have two subsets, <code>[[], [1]]</code> as the output. Can you think why the output is so?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can see that one subset includes a number, and another does not. From this, we can conclude that we need to find the subsets that include a number and those that do not. This results in <code>2^n</code> subsets for an array of size <code>n</code> because there are many combinations for including and excluding the array of numbers. Since the elements are unique, duplicate subsets will not be formed if we ensure that we don't pick the element more than once in the current subset. Which algorithm is helpful to generate all subsets, and how would you implement it?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We can use backtracking to generate all possible subsets. We iterate through the given array with an index <code>i</code> and an initially empty temporary list representing the current subset. We recursively process each index, adding the corresponding element to the current subset and continuing, which results in a subset that includes that element. Alternatively, we skip the element by not adding it to the subset and proceed to the next index, forming a subset without including that element. What can be the base condition to end this recursion?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    When the index <code>i</code> reaches the end of the array, we append a copy of the subset formed in that particular recursive path to the result list and return. All subsets of the given array are generated from these different recursive paths, which represent various combinations of "include" and "not include" steps for the elements of the array. As we are only iterating from left to right in the array, we don't pick an element more than once.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/REOH22Xwdkk/0.jpg)](https://www.youtube.com/watch?v=REOH22Xwdkk)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=REOH22Xwdkk)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/subsets)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Backtracking






```csharp
public class Solution {
    
    public List<List<int>> Subsets(int[] nums) {
        var res = new List<List<int>>();
        var subset = new List<int>();
        Dfs(nums, 0, subset, res);
        return res;
    }

    private void Dfs(int[] nums, int i, List<int> subset, List<List<int>> res) {
        if (i >= nums.Length) {
            res.Add(new List<int>(subset));
            return;
        }
        subset.Add(nums[i]);
        Dfs(nums, i + 1, subset, res);
        subset.RemoveAt(subset.Count - 1);
        Dfs(nums, i + 1, subset, res);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * 2 ^ n)$
* Space complexity: $O(n)$

---

### 2. Iteration






```csharp
public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        List<List<int>> res = new List<List<int>>();
        res.Add(new List<int>());
        
        foreach (int num in nums) {
            int size = res.Count;
            for (int i = 0; i < size; i++) {
                List<int> subset = new List<int>(res[i]);
                subset.Add(num);
                res.Add(subset);
            }
        }

        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * 2 ^ n)$
* Space complexity: $O(n)$

---

### 3. Bit Manipulation






```csharp
public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        int n = nums.Length;
        List<List<int>> res = new List<List<int>>();
        for (int i = 0; i < (1 << n); i++) {
            List<int> subset = new List<int>();
            for (int j = 0; j < n; j++) {
                if ((i & (1 << j)) != 0) {
                    subset.Add(nums[j]);
                }
            }
            res.Add(subset);
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * 2 ^ n)$
* Space complexity: $O(n)$
