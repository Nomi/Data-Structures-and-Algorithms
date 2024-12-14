# ⭐ | Time Based Key Value Store

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
- [Search Array](https://neetcode.io/courses/dsa-for-beginners/14) [from NeetCode's Course(s)]


## Problem Description
Implement a time-based key-value data structure that supports:
 
* Storing multiple values for the same key at specified time stamps
* Retrieving the key's value at a specified timestamp

Implement the `TimeMap` class:
* `TimeMap()` Initializes the object.
* `void set(String key, String value, int timestamp)` Stores the key `key` with the value `value` at the given time `timestamp`.
* `String get(String key, int timestamp)` Returns the most recent value of `key` if `set` was previously called on it *and* the most recent timestamp for that key `prev_timestamp` is less than or equal to the given timestamp (`prev_timestamp <= timestamp`). If there are no values, it returns `""`.

Note: For all calls to `set`, the timestamps are in strictly increasing order.

**Example 1:**

```java
Input:
["TimeMap", "set", ["alice", "happy", 1], "get", ["alice", 1], "get", ["alice", 2], "set", ["alice", "sad", 3], "get", ["alice", 3]]

Output:
[null, null, "happy", "happy", null, "sad"]

Explanation:
TimeMap timeMap = new TimeMap();
timeMap.set("alice", "happy", 1);  // store the key "alice" and value "happy" along with timestamp = 1.
timeMap.get("alice", 1);           // return "happy"
timeMap.get("alice", 2);           // return "happy", there is no value stored for timestamp 2, thus we return the value at timestamp 1.
timeMap.set("alice", "sad", 3);    // store the key "alice" and value "sad" along with timestamp = 3.
timeMap.get("alice", 3);           // return "sad"
```

**Constraints:**
* `1 <= key.length, value.length <= 100`
* `key` and `value` only include lowercase English letters and digits.
* `1 <= timestamp <= 1000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(1)</code> time for <code>set()</code>, <code>O(logn)</code> time for <code>get()</code>, and <code>O(m * n)</code> space, where <code>n</code> is the total number of values associated with a key, and <code>m</code> is the total number of keys.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    Can you think of a data structure that is useful for storing key-value pairs? Perhaps a hash-based data structure where we not only store unique elements but also associate additional information with each element?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We store key-value pairs in a hash map. In this case, we store the keys as usual, but instead of a single value, we store a list of values, each paired with its corresponding timestamp. This allows us to implement the <code>set()</code> method in <code>O(1)</code>. How can you leverage this hash map to implement the <code>get()</code> method?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    A brute force solution would involve linearly going through every value associated with the key and returning the most recent value with a timestamp less than or equal to the given timestamp. This approach has a time complexity of <code>O(n)</code> for each <code>get()</code> call. Can you think of a better way? Since the timestamps in the value list are sorted in ascending order by default, maybe an efficient searching algorithm could help.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We can use binary search because the timestamps in the values list are sorted in ascending order. This makes it straightforward to find the value with the most recent timestamp that is less than or equal to the given timestamp.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/fu2cD_6E8Hw/0.jpg)](https://www.youtube.com/watch?v=fu2cD_6E8Hw)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=fu2cD_6E8Hw)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/time-based-key-value-store)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class TimeMap {
    private Dictionary<string, Dictionary<int, List<string>>> keyStore;

    public TimeMap() {
        keyStore = new Dictionary<string, Dictionary<int, List<string>>>();
    }

    public void Set(string key, string value, int timestamp) {
        if (!keyStore.ContainsKey(key)) {
            keyStore[key] = new Dictionary<int, List<string>>();
        }
        if (!keyStore[key].ContainsKey(timestamp)) {
            keyStore[key][timestamp] = new List<string>();
        }
        keyStore[key][timestamp].Add(value);
    }

    public string Get(string key, int timestamp) {
        if (!keyStore.ContainsKey(key)) {
            return "";
        }
        var timestamps = keyStore[key];
        int seen = 0;

        foreach (var time in timestamps.Keys) {
            if (time <= timestamp) {
                seen = time;
            }
        }
        return seen == 0 ? "" : timestamps[seen][^1];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(1)$ for $set()$ and $O(n)$ for $get()$.
* Space complexity: $O(m * n)$

> Where $n$ is the total number of unique timestamps associated with a key and $m$ is the total number of keys.

---

### 2. Binary Search (Sorted Map)






```csharp
public class TimeMap {
    private Dictionary<string, SortedList<int, string>> m;

    public TimeMap() {
        m = new Dictionary<string, SortedList<int, string>>();
    }

    public void Set(string key, string value, int timestamp) {
        if (!m.ContainsKey(key)) {
            m[key] = new SortedList<int, string>();
        }
        m[key][timestamp] = value;
    }

    public string Get(string key, int timestamp) {
        if (!m.ContainsKey(key)) return "";
        var timestamps = m[key];
        int left = 0;
        int right = timestamps.Count - 1;
        
        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (timestamps.Keys[mid] == timestamp) {
                return timestamps.Values[mid];
            } else if (timestamps.Keys[mid] < timestamp) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        
        if (right >= 0) {
            return timestamps.Values[right];
        }
        return "";
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(1)$ for $set()$ and $O(\log n)$ for $get()$.
* Space complexity: $O(m * n)$

> Where $n$ is the total number of values associated with a key and $m$ is the total number of keys.

---

### 3. Binary Search (Array)






```csharp
public class TimeMap {
    
    private Dictionary<string, List<Tuple<int, string>>> keyStore;

    public TimeMap() {
        keyStore = new Dictionary<string, List<Tuple<int, string>>>();
    }

    public void Set(string key, string value, int timestamp) {
        if (!keyStore.ContainsKey(key)) {
            keyStore[key] = new List<Tuple<int, string>>();
        }
        keyStore[key].Add(Tuple.Create(timestamp, value));
    }

    public string Get(string key, int timestamp) {
        if (!keyStore.ContainsKey(key)) {
            return "";
        }

        var values = keyStore[key];
        int left = 0, right = values.Count - 1;
        string result = "";

        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (values[mid].Item1 <= timestamp) {
                result = values[mid].Item2;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        return result;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(1)$ for $set()$ and $O(\log n)$ for $get()$.
* Space complexity: $O(m * n)$

> Where $n$ is the total number of values associated with a key and $m$ is the total number of keys.
