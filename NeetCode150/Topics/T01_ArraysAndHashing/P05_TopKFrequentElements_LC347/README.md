# ⭐ | Top K Frequent Elements

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
- [Bucket Sort](https://neetcode.io/courses/dsa-for-beginners/13) [from NeetCode's Course(s)]


## Problem Description
Given an integer array `nums` and an integer `k`, return the `k` most frequent elements within the array.

The test cases are generated such that the answer is always **unique**.

You may return the output in **any order**.

**Example 1:**

```java
Input: nums = [1,2,2,3,3,3], k = 2

Output: [2,3]
```

**Example 2:**

```java
Input: nums = [7,7], k = 1

Output: [7]
```

**Constraints:**
* `1 <= nums.length <= 10^4`.
* `-1000 <= nums[i] <= 1000`
* `1 <= k <= number of distinct elements in nums`.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time and <code>O(n)</code> space, where <code>n</code> is the size of the input array.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A naive solution would be to count the frequency of each number and then sort the array based on each element’s frequency. After that, we would select the top <code>k</code> frequent elements. This would be an <code>O(nlogn)</code> solution. Though this solution is acceptable, can you think of a better way?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    Can you think of an algorithm which involves grouping numbers based on their frequency?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    Use the bucket sort algorithm to create <code>n</code> buckets, grouping numbers based on their frequencies from <code>1</code> to <code>n</code>. Then, pick the top <code>k</code> numbers from the buckets, starting from <code>n</code> down to <code>1</code>.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/YPTqKIgVk-k/0.jpg)](https://www.youtube.com/watch?v=YPTqKIgVk-k)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=YPTqKIgVk-k)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/top-k-elements-in-list)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Sorting






```csharp
public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> count = new Dictionary<int, int>();
        foreach (int num in nums) {
            if (count.ContainsKey(num)) count[num]++;
            else count[num] = 1;
        }

        List<int[]> arr = count.Select(entry => new int[] {entry.Value, entry.Key}).ToList();
        arr.Sort((a, b) => b[0].CompareTo(a[0]));

        int[] res = new int[k];
        for (int i = 0; i < k; i++) {
            res[i] = arr[i][1];
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log n)$
* Space complexity: $O(n)$

---

### 2. Heap






```csharp
public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var count = new Dictionary<int, int>();
        foreach (var num in nums) {
            if (count.ContainsKey(num)) {
                count[num]++;
            } else {
                count[num] = 1;
            }
        }

        var heap = new PriorityQueue<int, int>();
        foreach (var entry in count) {
            heap.Enqueue(entry.Key, entry.Value);
            if (heap.Count > k) {
                heap.Dequeue();
            }
        }
        
        var res = new int[k];
        for (int i = 0; i < k; i++) {
            res[i] = heap.Dequeue();
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n \log k)$
* Space complexity: $O(n + k)$

> Where $n$ is the length of the array and $k$ is the number of top frequent elements.

---

### 3. Bucket Sort






```csharp
public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> count = new Dictionary<int, int>();
        List<int>[] freq = new List<int>[nums.Length + 1];
        for (int i = 0; i < freq.Length; i++) {
            freq[i] = new List<int>();
        }

        foreach (int n in nums) {
            if (count.ContainsKey(n)) {
                count[n]++;
            } else {
                count[n] = 1;
            }
        }
        foreach (var entry in count){
            freq[entry.Value].Add(entry.Key);
        }

        int[] res = new int[k];
        int index = 0;
        for (int i = freq.Length - 1; i > 0 && index < k; i--) {
            foreach (int n in freq[i]) {
                res[index++] = n;
                if (index == k) {
                    return res;
                }
            }
        }
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$
* Space complexity: $O(n)$
