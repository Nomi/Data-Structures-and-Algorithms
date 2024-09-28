# ⭐ | LRU Cache

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
- [Singly Linked Lists](https://neetcode.io/courses/dsa-for-beginners/5) [from NeetCode's Course(s)]
- [Doubly Linked Lists](https://neetcode.io/courses/dsa-for-beginners/6) [from NeetCode's Course(s)]
- [Hash Usage](https://neetcode.io/courses/dsa-for-beginners/26) [from NeetCode's Course(s)]


## Problem Description
Implement the [Least Recently Used (LRU)](https://en.wikipedia.org/wiki/Cache_replacement_policies#LRU) cache class `LRUCache`. The class should support the following operations

* `LRUCache(int capacity)` Initialize the LRU cache of size `capacity`.
* `int get(int key)` Return the value cooresponding to the `key` if the `key` exists, otherwise return `-1`.
* `void put(int key, int value)` Update the `value` of the `key` if the `key` exists. Otherwise, add the `key`-`value` pair to the cache. If the introduction of the new pair causes the cache to exceed its capacity, remove the least recently used key.

A key is considered used if a `get` or a `put` operation is called on it.

Ensure that `get` and `put` each run in $O(1)$ average time complexity.

**Example 1:**

```java
Input:
["LRUCache", [2], "put", [1, 10],  "get", [1], "put", [2, 20], "put", [3, 30], "get", [2], "get", [1]]

Output:
[null, null, 10, null, null, 20, -1]

Explanation:
LRUCache lRUCache = new LRUCache(2);
lRUCache.put(1, 10);  // cache: {1=10}
lRUCache.get(1);      // return 10
lRUCache.put(2, 20);  // cache: {1=10, 2=20}
lRUCache.put(3, 30);  // cache: {2=20, 3=30}, key=1 was evicted
lRUCache.get(2);      // returns 20 
lRUCache.get(1);      // return -1 (not found)
```

**Constraints:**
* `1 <= capacity <= 100`
* `0 <= key <= 1000`
* `0 <= value <= 1000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(1)</code> time for each <code>put()</code> and <code>get()</code> function call and an overall space of <code>O(n)</code>, where <code>n</code> is the capacity of the <code>LRU</code> cache.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    Can you think of a data structure for storing data in key-value pairs? Maybe a hash-based data structure with unique keys.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use a hash map which takes <code>O(1)</code> time to get and put the values. But, how can you deal with the least recently used to be removed criteria as a key is updated by the <code>put()</code> or recently used by the <code>get()</code> functions? Can you think of a data structure to store the order of values?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    A brute-force solution would involve maintaining the order of key-value pairs in an array list, performing operations by iterating through the list to erase and insert these key-value pairs. However, this would result in an <code>O(n)</code> time complexity. Can you think of a data structure that allows removing and reinserting elements in <code>O(1)</code> time?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We can use a doubly-linked list, which allows us to remove a node from the list when we have the address of that node. Can you think of a way to store these addresses so that we can efficiently remove or update a key when needed?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 5</summary>
    <p>
    We can use a doubly linked list where key-value pairs are stored as nodes, with the least recently used (LRU) node at the head and the most recently used (MRU) node at the tail. Whenever a key is accessed using <code>get()</code> or <code>put()</code>, we remove the corresponding node and reinsert it at the tail. When the cache reaches its capacity, we remove the LRU node from the head of the list. Additionally, we use a hash map to store each key and the corresponding address of its node, enabling efficient operations in <code>O(1)</code> time. 
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/7ABFKPK2hD4/0.jpg)](https://www.youtube.com/watch?v=7ABFKPK2hD4)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=7ABFKPK2hD4)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/lru-cache)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class LRUCache {
    private List<KeyValuePair<int, int>> cache;
    private int capacity;

    public LRUCache(int capacity) {
        this.cache = new List<KeyValuePair<int, int>>();
        this.capacity = capacity;
    }
    
    public int Get(int key) {
        for (int i = 0; i < cache.Count; i++) {
            if (cache[i].Key == key) {
                var tmp = cache[i];
                cache.RemoveAt(i);
                cache.Add(tmp);
                return tmp.Value;
            }
        }
        return -1;
    }
    
    public void Put(int key, int value) {
        for (int i = 0; i < cache.Count; i++) {
            if (cache[i].Key == key) {
                cache.RemoveAt(i);
                cache.Add(new KeyValuePair<int, int>(key, value));
                return;
            }
        }

        if (cache.Count == capacity) {
            cache.RemoveAt(0);
        }

        cache.Add(new KeyValuePair<int, int>(key, value));
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$ for each $put()$ and $get()$ operation.
* Space complexity: $O(n)$

---

### 2. Doubly Linked List






```csharp
public class Node {
    public int Key { get; set; }
    public int Val { get; set; }
    public Node Prev { get; set; }
    public Node Next { get; set; }

    public Node(int key, int val) {
        Key = key;
        Val = val;
        Prev = null;
        Next = null;
    }
}

public class LRUCache {
    
    private int cap;
    private Dictionary<int, Node> cache;
    private Node left;
    private Node right;

    public LRUCache(int capacity) {
        cap = capacity;
        cache = new Dictionary<int, Node>();
        left = new Node(0, 0);
        right = new Node(0, 0);
        left.Next = right;
        right.Prev = left;
    }

    private void Remove(Node node) {
        Node prev = node.Prev;
        Node nxt = node.Next;
        prev.Next = nxt;
        nxt.Prev = prev;
    }

    private void Insert(Node node) {
        Node prev = right.Prev;
        prev.Next = node;
        node.Prev = prev;
        node.Next = right;
        right.Prev = node;
    }

    public int Get(int key) {
        if (cache.ContainsKey(key)) {
            Node node = cache[key];
            Remove(node);
            Insert(node);
            return node.Val;
        }
        return -1;
    }

    public void Put(int key, int value) {
        if (cache.ContainsKey(key)) {
            Remove(cache[key]);
        }
        Node newNode = new Node(key, value);
        cache[key] = newNode;
        Insert(newNode);

        if (cache.Count > cap) {
            Node lru = left.Next;
            Remove(lru);
            cache.Remove(lru.Key);
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(1)$ for each $put()$ and $get()$ operation.
* Space complexity: $O(n)$

---

### 3. Built-In Data Structure






```csharp
public class LRUCache {
    private Dictionary<int, LinkedListNode<(int key, int value)>> cache;
    private LinkedList<(int key, int value)> order;
    private int capacity;

    public LRUCache(int capacity) {
        this.capacity = capacity;
        this.cache = new Dictionary<int, LinkedListNode<(int key, int value)>>();
        this.order = new LinkedList<(int key, int value)>();
    }

    public int Get(int key) {
        if (!cache.ContainsKey(key)) return -1;
        var node = cache[key];
        order.Remove(node);
        order.AddLast(node);
        return node.Value.value;
    }

    public void Put(int key, int value) {
        if (cache.ContainsKey(key)) {
            var node = cache[key];
            order.Remove(node);
            node.Value = (key, value);
            order.AddLast(node);
        } else {
            if (cache.Count == capacity) {
                var lru = order.First.Value;
                order.RemoveFirst();
                cache.Remove(lru.key);
            }
            var newNode = new LinkedListNode<(int key, int value)>((key, value));
            order.AddLast(newNode);
            cache[key] = newNode;
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(1)$ for each $put()$ and $get()$ operation.
* Space complexity: $O(n)$
