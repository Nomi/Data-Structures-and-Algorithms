# ⭐ | Combination Sum II

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
You are given an array of integers `candidates`, which may contain duplicates, and a target integer `target`. Your task is to return a list of all **unique combinations** of `candidates` where the chosen numbers sum to `target`.

Each element from `candidates` may be chosen **at most once** within a combination. The solution set must not contain duplicate combinations.

You may return the combinations in **any order** and the order of the numbers in each combination can be in **any order**.

**Example 1:**

```java
Input: candidates = [9,2,2,4,6,1,5], target = 8

Output: [
  [1,2,5],
  [2,2,4],
  [2,6]
]
```

**Example 2:**

```java
Input: candidates = [1,2,3,4,5], target = 7

Output: [
  [1,2,4],
  [2,5],
  [3,4]
]
```

**Constraints:**
* `1 <= candidates.length <= 100`
* `1 <= candidates[i] <= 50`
* `1 <= target <= 30`

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
    A brute-force solution would be to create a <code>hash set</code>, which is used to detect duplicates, to get combinations without duplicates. Can you think of a better way without using a <code>hash set</code>? Maybe you should sort the input array and observe the recursive calls that are responsible for duplicate combinations.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use backtracking to generate all combinations whose sum equals the given target. When the input array contains duplicate elements, it may result in duplicate combinations. To avoid this, we can sort the array. Why does sorting help? Because as we traverse the array from left to right, we form combinations with the current element. By skipping duplicate elements, we ensure that the same combinations are not repeated for identical elements. How can you implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We recursively traverse the given array starting at index <code>i</code>, with a variable <code>sum</code> representing the sum of the picked elements. We explore elements from <code>i</code> to the end of the array and extend the recursive path if adding the current element results in <code>sum <= target</code>. When we processed an element, we backtrack and proceed to the next distinct element, skipping any similar elements in the middle to avoid duplicate combinations.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/FOyRpNUSFeA/0.jpg)](https://www.youtube.com/watch?v=FOyRpNUSFeA)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=FOyRpNUSFeA)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/combination-target-sum-ii)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    private HashSet<string> res;

    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        res = new HashSet<string>();
        Array.Sort(candidates);
        GenerateSubsets(candidates, target, 0, new List<int>(), 0);
        return res.Select(s => s.Split(',').Select(int.Parse).ToList()).ToList();
    }

    private void GenerateSubsets(int[] candidates, int target, int i, List<int> cur, int total) {
        if (total == target) {
            res.Add(string.Join(",", cur));
            return;
        }
        if (total > target || i == candidates.Length) {
            return;
        }

        cur.Add(candidates[i]);
        GenerateSubsets(candidates, target, i + 1, cur, total + candidates[i]);
        cur.RemoveAt(cur.Count - 1);

        GenerateSubsets(candidates, target, i + 1, cur, total);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * 2 ^ n)$
* Space complexity: $O(n * 2 ^ n)$

---

### 2. Backtracking






```csharp
public class Solution {
    private List<List<int>> res;

    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        res = new List<List<int>>();
        Array.Sort(candidates);
        Dfs(candidates, target, 0, new List<int>(), 0);
        return res;
    }

    private void Dfs(int[] candidates, int target, int i, List<int> cur, int total) {
        if (total == target) {
            res.Add(new List<int>(cur));
            return;
        }
        if (total > target || i == candidates.Length) {
            return;
        }

        cur.Add(candidates[i]);
        Dfs(candidates, target, i + 1, cur, total + candidates[i]);
        cur.RemoveAt(cur.Count - 1);

        while (i + 1 < candidates.Length && candidates[i] == candidates[i + 1]) {
            i++;
        }
        Dfs(candidates, target, i + 1, cur, total);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * 2 ^n)$
* Space complexity: $O(n)$

---

### 3. Backtracking (Hash Map)






```csharp
public class Solution {
    public List<List<int>> res = new List<List<int>>();
    public Dictionary<int, int> count = new Dictionary<int, int>();

    public List<List<int>> CombinationSum2(int[] nums, int target) {
        List<int> cur = new List<int>();
        List<int> A = new List<int>();
        
        foreach (int num in nums) {
            if (!count.ContainsKey(num)) {
                A.Add(num);
            }
            if (count.ContainsKey(num)) {
                count[num]++;
            } else {
                count[num] = 1;
            }
        }
        Backtrack(A, target, cur, 0);
        return res;
    }

    private void Backtrack(List<int> nums, int target, List<int> cur, int i) {
        if (target == 0) {
            res.Add(new List<int>(cur));
            return;
        }
        if (target < 0 || i >= nums.Count) {
            return;
        }

        if (count[nums[i]] > 0) {
            cur.Add(nums[i]);
            count[nums[i]]--;
            Backtrack(nums, target - nums[i], cur, i);
            count[nums[i]]++;
            cur.RemoveAt(cur.Count - 1);
        }

        Backtrack(nums, target, cur, i + 1);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * 2 ^ n)$
* Space complexity: $O(n)$

---

### 4. Backtracking (Optimal)






```csharp
public class Solution {
    private static List<List<int>> res = new List<List<int>>();

    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        res.Clear();
        Array.Sort(candidates);

        dfs(0, new List<int>(), 0, candidates, target);
        return res;
    }

    private void dfs(int idx, List<int> path, int cur, int[] candidates, int target) {
        if (cur == target) {
            res.Add(new List<int>(path));
            return;
        }
        for (int i = idx; i < candidates.Length; i++) {
            if (i > idx && candidates[i] == candidates[i - 1]) {
                continue;
            }
            if (cur + candidates[i] > target) {
                break;
            }

            path.Add(candidates[i]);
            dfs(i + 1, path, cur + candidates[i], candidates, target);
            path.RemoveAt(path.Count - 1);
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * 2 ^ n)$
* Space complexity: $O(n)$
