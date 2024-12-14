# ⭐ | Longest Consecutive Sequence

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
- [Hash Usage](https://neetcode.io/courses/dsa-for-beginners/26) [from NeetCode's Course(s)]


## Problem Description
Given an array of integers `nums`, return *the length* of the longest consecutive sequence of elements that can be formed.

A *consecutive sequence* is a sequence of elements in which each element is exactly `1` greater than the previous element. The elements do *not* have to be consecutive in the original array.

You must write an algorithm that runs in `O(n)` time.

**Example 1:**

```java
Input: nums = [2,20,4,10,3,4,5]

Output: 4
```

Explanation: The longest consecutive sequence is `[2, 3, 4, 5]`.

**Example 2:**

```java
Input: nums = [0,3,2,5,4,6,1,1]

Output: 7
```

**Constraints:**
* `0 <= nums.length <= 1000`
* `-10^9 <= nums[i] <= 10^9`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution as good or better than <code>O(n)</code> time and <code>O(n)</code> space, where <code>n</code> is the size of the input array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A brute force solution would be to consider every element from the array as the start of the sequence and count the length of the sequence formed with that starting element. This would be an <code>O(n^2)</code> solution. Can you think of a better way?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    Is there any way to identify the start of a sequence? For example, in <code>[1, 2, 3, 10, 11, 12]</code>, only <code>1</code> and <code>10</code> are the beginning of a sequence. Instead of trying to form a sequence for every number, we should only consider numbers like <code>1</code> and <code>10</code>.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We can consider a number <code>num</code> as the start of a sequence if and only if <code>num - 1</code> does not exist in the given array. We iterate through the array and only start building the sequence if it is the start of a sequence. This avoids repeated work. We can use a hash set for <code>O(1)</code> lookups by converting the array to a hash set.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/P6RZZMu_maU/0.jpg)](https://www.youtube.com/watch?v=P6RZZMu_maU)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=P6RZZMu_maU)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/longest-consecutive-sequence)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public int LongestConsecutive(int[] nums) {
        int res = 0;
        HashSet<int> store = new HashSet<int>(nums);

        foreach (int num in nums) {
            int streak = 0, curr = num;
            while (store.Contains(curr)) {
                streak++;
                curr++;
            }
            res = Math.Max(res, streak);
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(n)$

---

### 2. Sorting






```csharp
public class Solution {
    public int LongestConsecutive(int[] nums) {
        if (nums.Length == 0) {
            return 0;
        }
        Array.Sort(nums);
        
        int res = 0, curr = nums[0], streak = 0, i = 0;

        while (i < nums.Length) {
            if (curr != nums[i]) {
                curr = nums[i];
                streak = 0;
            }
            while (i < nums.Length && nums[i] == curr) {
                i++;
            }
            streak++;
            curr++;
            res = Math.Max(res, streak);
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log n)$
* Space complexity: $O(1)$

---

### 3. Hash Set






```csharp
public class Solution {
    public int LongestConsecutive(int[] nums) {
        HashSet<int> numSet = new HashSet<int>(nums);
        int longest = 0;

        foreach (int num in numSet) {
            if (!numSet.Contains(num - 1)) {
                int length = 1;
                while (numSet.Contains(num + length)) {
                    length++;
                }
                longest = Math.Max(longest, length);
            }
        }
        return longest;       
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$

---

### 4. Hash Map






```csharp
public class Solution {
    public int LongestConsecutive(int[] nums) {
        Dictionary<int, int> mp = new Dictionary<int, int>();
        int res = 0;

        foreach (int num in nums) {
            if (!mp.ContainsKey(num)) {
                mp[num] = (mp.ContainsKey(num - 1) ? mp[num - 1] : 0) + 
                          (mp.ContainsKey(num + 1) ? mp[num + 1] : 0) + 1;

                mp[num - (mp.ContainsKey(num - 1) ? mp[num - 1] : 0)] = mp[num];
                mp[num + (mp.ContainsKey(num + 1) ? mp[num + 1] : 0)] = mp[num];

                res = Math.Max(res, mp[num]);
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
