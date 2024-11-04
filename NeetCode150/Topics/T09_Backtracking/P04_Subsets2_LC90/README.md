# ⭐ | Subsets II

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
You are given an array `nums` of integers, which may contain duplicates. Return all possible subsets.

The solution must **not** contain duplicate subsets. You may return the solution in **any order**.

**Example 1:**

```java
Input: nums = [1,2,1]

Output: [[],[1],[1,2],[1,1],[1,2,1],[2]]
```

**Example 2:**

```java
Input: nums = [7,7]

Output: [[],[7], [7,7]]
```

**Constraints:**
* `1 <= nums.length <= 11`
* `-20 <= nums[i] <= 20`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution as good or better than <code>O(n * (2^n))</code> time and <code>O(n)</code> space, where <code>n</code> is the size of the input array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute-force solution would involve creating a hash set and inserting every subset into it. Then, converting the hash set to a list and returning it. However, this approach would require extra space of <code>O(2^n)</code>. Can you think of a better way? Maybe you should sort the input array and observe which recusive calls are resposible to make duplicate subsets.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use backtracking to generate subsets of an array. If the input contains duplicates, duplicate subsets may be created. To prevent this, we sort the array beforehand. For example, in <code>[1, 1, 2]</code>, sorting allows us to create subsets using the first <code>1</code> and skip the second <code>1</code>, ensuring unique subsets. How can you implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We start by sorting the input array. Then, we recursively iterate through the array from left to right, extending recursive paths by including or excluding each element. To avoid duplicate subsets, we skip an element if it is the same as the previous one. Finally, we return the generated subsets as a list.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/Vn2v6ajA7U0/0.jpg)](https://www.youtube.com/watch?v=Vn2v6ajA7U0)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=Vn2v6ajA7U0)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/subsets-ii)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    HashSet<string> res = new HashSet<string>();

    public List<List<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        Backtrack(nums, 0, new List<int>());
        List<List<int>> result = new List<List<int>>();
        result.Add(new List<int>());
        res.Remove("");
        foreach (string str in res) {
            List<int> subset = new List<int>();
            string[] arr = str.Split(',');
            foreach (string num in arr) {
                subset.Add(int.Parse(num));
            }
            result.Add(subset);
        }
        return result;
    }

    private void Backtrack(int[] nums, int i, List<int> subset) {
        if (i == nums.Length) {
            res.Add(string.Join(",", subset));
            return;
        }

        subset.Add(nums[i]);
        Backtrack(nums, i + 1, subset);
        subset.RemoveAt(subset.Count - 1);
        Backtrack(nums, i + 1, subset);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * 2 ^n)$
* Space complexity: $O(2 ^ n)$

---

### 2. Backtracking (Pick / Not Pick)






```csharp
public class Solution {
    List<List<int>> res = new List<List<int>>();

    public List<List<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        Backtrack(0, new List<int>(), nums);
        return res;
    }

    private void Backtrack(int i, List<int> subset, int[] nums) {
        if (i == nums.Length) {
            res.Add(new List<int>(subset));
            return;
        }

        subset.Add(nums[i]);
        Backtrack(i + 1, subset, nums);
        subset.RemoveAt(subset.Count - 1);

        while (i + 1 < nums.Length && nums[i] == nums[i + 1]) {
            i++;
        }
        Backtrack(i + 1, subset, nums);
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * 2 ^ n)$
* Space complexity: $O(n)$

---

### 3. Backtracking






```csharp
public class Solution {
    private List<List<int>> res = new List<List<int>>();

    public List<List<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        Backtrack(0, new List<int>(), nums);
        return res;
    }

    private void Backtrack(int i, List<int> subset, int[] nums) {
        res.Add(new List<int>(subset));
        for (int j = i; j < nums.Length; j++) {
            if (j > i && nums[j] == nums[j - 1]) {
                continue;
            }
            subset.Add(nums[j]);
            Backtrack(j + 1, subset, nums);
            subset.RemoveAt(subset.Count - 1);
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * 2 ^ n)$
* Space complexity: $O(n)$

---

### 4. Iteration






```csharp
public class Solution {
    public List<List<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        var res = new List<List<int>> { new List<int>() };
        int prevIdx = 0;
        int idx = 0;
        for (int i = 0; i < nums.Length; i++) {
            idx = (i >= 1 && nums[i] == nums[i - 1]) ? prevIdx : 0;
            prevIdx = res.Count;
            for (int j = idx; j < prevIdx; j++) {
                var tmp = new List<int>(res[j]);
                tmp.Add(nums[i]);
                res.Add(tmp);
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * 2 ^ n)$
* Space complexity: $O(1)$
