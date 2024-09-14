# ⭐ | 3Sum

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
- [Two Pointers](https://neetcode.io/courses/advanced-algorithms/3) [from NeetCode's Course(s)]


## Problem Description
Given an integer array `nums`, return all the triplets `[nums[i], nums[j], nums[k]]` where `nums[i] + nums[j] + nums[k] == 0`, and the indices `i`, `j` and `k` are all distinct.

The output should *not* contain any duplicate triplets. You may return the output and the triplets in **any order**.

**Example 1:**

```java
Input: nums = [-1,0,1,2,-1,-4]

Output: [[-1,-1,2],[-1,0,1]]
```

Explanation: 
`nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.`
`nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.`
`nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.`
The distinct triplets are `[-1,0,1]` and `[-1,-1,2]`.

**Example 2:**

```java
Input: nums = [0,1,1]

Output: []
```

Explanation: The only possible triplet does not sum up to 0.

**Example 3:**

```java
Input: nums = [0,0,0]

Output: [[0,0,0]]
```

Explanation: The only possible triplet sums up to 0.


**Constraints:**
* `3 <= nums.length <= 1000`
* `-10^5 <= nums[i] <= 10^5`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n^2)</code> time and <code>O(1)</code> space, where <code>n</code> is the size of the input array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would be to check for every triplet in the array. This would be an <code>O(n^3)</code> solution. Can you think of a better way?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    Can you think of an algorithm after sorting the input array? What can we observe by rearranging the given equation in the problem?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
     We can iterate through nums with index <code>i</code> and get <code>nums[i] = -(nums[j] + nums[k])</code> after rearranging the equation, making <code>-nums[i] = nums[j] + nums[k]</code>. For each index <code>i</code>, we should efficiently  calculate the <code>j</code> and <code>k</code> pairs without duplicates. Which algorithm is suitable to find <code>j</code> and <code>k</code> pairs?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    To efficiently find the <code>j</code> and <code>k</code> pairs, we run the two pointer approach on the elements to the right of index <code>i</code> as the array is sorted. When we run two pointer algorithm, consider <code>j</code> and <code>k</code> as pointers (<code>j</code> is at left, <code>k</code> is at right) and <code>target = -nums[i]</code>, if the current sum <code>num[j] + nums[k] < target</code> then we need to increase the value of current sum by incrementing <code>j</code> pointer. Else if the current sum <code>num[j] + nums[k] > target</code> then we should decrease the value of current sum by decrementing <code>k</code> pointer. How do you deal with duplicates? 
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 5</summary>
    <p>
     When the current sum <code>nums[j] + nums[k] == target</code> add this pair to the result. We can move <code>j</code> or <code>k</code> pointer until <code>j < k</code> and the pairs are repeated. This ensures that no duplicate pairs are added to the result.
    </p>
</details>


## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/jzZsG8n2R9A/0.jpg)](https://www.youtube.com/watch?v=jzZsG8n2R9A)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=jzZsG8n2R9A)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/three-integer-sum)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        HashSet<Tuple<int, int, int>> uniqueTriplets = new HashSet<Tuple<int, int, int>>();
        List<List<int>> res = new List<List<int>>();
        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                for (int k = j + 1; k < nums.Length; k++) {
                    if (nums[i] + nums[j] + nums[k] == 0) {
                        var triplet = Tuple.Create(nums[i], nums[j], nums[k]);
                        uniqueTriplets.Add(triplet);
                    }
                }
            }
        }

        foreach (var triplet in uniqueTriplets) {
            res.Add(new List<int> { triplet.Item1, triplet.Item2, triplet.Item3 });
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 3)$
* Space complexity: $O(m)$

> Where $m$ is the number of triplets and $n$ is the length of the given array.

---

### 2. Hash Map






```csharp
public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        Array.Sort(nums);
        Dictionary<int, int> count = new Dictionary<int, int>();
        foreach (int num in nums) {
            if (!count.ContainsKey(num)) {
                count[num] = 0;
            }
            count[num]++;
        }

        List<List<int>> res = new List<List<int>>();
        for (int i = 0; i < nums.Length; i++) {
            count[nums[i]]--;
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            for (int j = i + 1; j < nums.Length; j++) {
                count[nums[j]]--;
                if (j > i + 1 && nums[j] == nums[j - 1]) continue;

                int target = -(nums[i] + nums[j]);
                if (count.ContainsKey(target) && count[target] > 0) {
                    res.Add(new List<int> { nums[i], nums[j], target });
                }
            }

            for (int j = i + 1; j < nums.Length; j++) {
                count[nums[j]]++;
            }
        }

        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(n)$

---

### 3. Two Pointers






```csharp
public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        Array.Sort(nums);
        List<List<int>> res = new List<List<int>>();

        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] > 0) break;
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            int l = i + 1, r = nums.Length - 1;
            while (l < r) {
                int sum = nums[i] + nums[l] + nums[r];
                if (sum > 0) {
                    r--;
                } else if (sum < 0) {
                    l++;
                } else {
                    res.Add(new List<int> {nums[i], nums[l], nums[r]});
                    l++;
                    r--;
                    while (l < r && nums[l] == nums[l - 1]) {
                        l++;
                    }
                }
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(1)$ or $O(n)$ depending on the sorting algorithm.
