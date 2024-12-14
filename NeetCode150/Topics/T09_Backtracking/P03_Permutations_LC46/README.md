# Permutations

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
- [Tree Maze](https://neetcode.io/courses/dsa-for-beginners/22) [from NeetCode's Course(s)]
- [Permutations](https://neetcode.io/courses/advanced-algorithms/13) [from NeetCode's Course(s)]


## Problem Description
Given an array `nums` of **unique** integers, return all the possible permutations. You may return the answer in **any order**.

**Example 1:**

```java
Input: nums = [1,2,3]

Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
```

**Example 2:**

```java
Input: nums = [7]

Output: [[7]]
```

**Constraints:**
* `1 <= nums.length <= 6`
* `-10 <= nums[i] <= 10`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n * n!)</code> time and <code>O(n)</code> space, where <code>n</code> is the size of the input array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A permutation is the same as the array but with the numbers arranged in a different order. The given array itself is also considered a permutation. This means we should make a decision at each step to take any element from the array that has not been chosen previously. By doing this recursively, we can generate all permutations. How do you implement it?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use backtracking to explore all possible permutation paths. We initialize a temporary list to append the chosen elements and a boolean array of size <code>n</code> (the same size as the input array) to track which elements have been picked so far (<code>true</code> means the element is chosen; otherwise, <code>false</code>). At each step of recursion, we iterate through the entire array, picking elements that have not been chosen previously, and proceed further along that path. Can you think of the base condition to terminate the current recursive path?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We observe that every permutation has the same size as the input array. Therefore, we can append a copy of the list of chosen elements in the current path to the result list if the size of the list equals the size of the input array terminating the current recursive path.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/FZe0UqISmUw/0.jpg)](https://www.youtube.com/watch?v=FZe0UqISmUw)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=FZe0UqISmUw)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/permutations)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Recursion






```csharp
public class Solution {
    public List<List<int>> Permute(int[] nums) {
        if (nums.Length == 0) {
            return new List<List<int>> { new List<int>() };
        }
        
        var perms = Permute(nums[1..]);
        var res = new List<List<int>>();
        foreach (var p in perms) {
            for (int i = 0; i <= p.Count; i++) {
                var p_copy = new List<int>(p);
                p_copy.Insert(i, nums[0]);
                res.Add(p_copy);
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n! * n ^ 2)$
* Space complexity: $O(n! * n)$

---

### 2. Iteration






```csharp
public class Solution {
    public List<List<int>> Permute(int[] nums) {
        var perms = new List<List<int>>() { new List<int>() };
        foreach (int num in nums) {
            var new_perms = new List<List<int>>();
            foreach (var p in perms) {
                for (int i = 0; i <= p.Count; i++) {
                    var p_copy = new List<int>(p);
                    p_copy.Insert(i, num);
                    new_perms.Add(p_copy);
                }
            }
            perms = new_perms;
        }
        return perms;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n! * n ^ 2)$
* Space complexity: $O(n! * n)$

---

### 3. Backtracking






```csharp
public class Solution {
    List<List<int>> res;
    public List<List<int>> Permute(int[] nums) {
        res = new List<List<int>>();
        Backtrack(new List<int>(), nums, new bool[nums.Length]);
        return res;
    }

    private void Backtrack(List<int> perm, int[] nums, bool[] pick) {
        if (perm.Count == nums.Length) {
            res.Add(new List<int>(perm));
            return;
        }
        for (int i = 0; i < nums.Length; i++) {
            if (!pick[i]) {
                perm.Add(nums[i]);
                pick[i] = true;
                Backtrack(perm, nums, pick);
                perm.RemoveAt(perm.Count - 1);
                pick[i] = false;
            }
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n! * n)$
* Space complexity: $O(n)$

---

### 4. Backtracking (Bit Mask)






```csharp
public class Solution {
    List<List<int>> res = new List<List<int>>();

    public List<List<int>> Permute(int[] nums) {
        Backtrack(new List<int>(), nums, 0);
        return res;
    }

    private void Backtrack(List<int> perm, int[] nums, int mask) {
        if (perm.Count == nums.Length) {
            res.Add(new List<int>(perm));
            return;
        }
        for (int i = 0; i < nums.Length; i++) {
            if ((mask & (1 << i)) == 0) {
                perm.Add(nums[i]);
                Backtrack(perm, nums, mask | (1 << i));
                perm.RemoveAt(perm.Count - 1);
            }
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n! * n)$
* Space complexity: $O(n)$

---

### 5. Backtracking (Optimal)






```csharp
public class Solution {
    private List<List<int>> res;

    public List<List<int>> Permute(int[] nums) {
        res = new List<List<int>>();
        Backtrack(nums, 0);
        return res;
    }

    private void Backtrack(int[] nums, int idx) {
        if (idx == nums.Length) {
            res.Add(new List<int>(nums));
            return;
        }
        for (int i = idx; i < nums.Length; i++) {
            Swap(nums, idx, i);
            Backtrack(nums, idx + 1);
            Swap(nums, idx, i);
        }
    }

    private void Swap(int[] nums, int i, int j) {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n! * n)$
* Space complexity: $O(n)$
