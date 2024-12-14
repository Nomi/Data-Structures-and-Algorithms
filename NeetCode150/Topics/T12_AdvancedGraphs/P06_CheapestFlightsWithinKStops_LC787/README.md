# ⭐ | Cheapest Flights Within K Stops

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
- [Adjacency List](https://neetcode.io/courses/dsa-for-beginners/31) [from NeetCode's Course(s)]


## Problem Description
There are `n` airports, labeled from `0` to `n - 1`, which are connected by some flights. You are given an array `flights` where `flights[i] = [from_i, to_i, price_i]` represents a one-way flight from airport `from_i` to airport `to_i` with cost `price_i`. You may assume there are no duplicate flights and no flights from an airport to itself.

You are also given three integers `src`, `dst`, and `k` where:

* `src` is the starting airport
* `dst` is the destination airport
* `src != dst`
* `k` is the maximum number of stops you can make (not including `src` and `dst`)

Return **the cheapest price** from `src` to `dst` with at most `k` stops, or return `-1` if it is impossible.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/e272e71f-c38b-4db8-3c4e-1158418d2a00/public)

```java
Input: n = 4, flights = [[0,1,200],[1,2,100],[1,3,300],[2,3,100]], src = 0, dst = 3, k = 1

Output: 500
```

Explanation:
The optimal path with at most 1 stop from airport 0 to 3 is shown in red, with total cost `200 + 300 = 500`.
Note that the path `[0 -> 1 -> 2 -> 3]` costs only 400, and thus is cheaper, but it requires 2 stops, which is more than k.

**Example 2:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/93e910ee-378d-4ac8-93e0-471df7ccf600/public)

```java
Input: n = 3, flights = [[1,0,100],[1,2,200],[0,2,100]], src = 1, dst = 2, k = 1

Output: 200
```

Explanation:
The optimal path with at most 1 stop from airport 1 to 2 is shown in red and has cost `200`.

**Constraints:**
* `1 <= n <= 100`
* `fromi != toi`
* `1 <= pricei <= 1000`
* `0 <= src, dst, k < n`


## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/5eIK3zUdYmE/0.jpg)](https://www.youtube.com/watch?v=5eIK3zUdYmE)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=5eIK3zUdYmE)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/cheapest-flight-path)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Dijkstra's Algorithm






```csharp
public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        int INF = int.MaxValue;
        List<int[]>[] adj = new List<int[]>[n];
        int[][] dist = new int[n][];
        
        for (int i = 0; i < n; i++) {
            adj[i] = new List<int[]>();
            dist[i] = new int[k + 2];
            Array.Fill(dist[i], INF);
        }
        
        foreach (var flight in flights) {
            adj[flight[0]].Add(new int[] { flight[1], flight[2] });
        }
        
        dist[src][0] = 0;
        var minHeap = new PriorityQueue<(int cst, int node, int stops), int>();
        minHeap.Enqueue((0, src, 0), 0);
        
        while (minHeap.Count > 0) {
            var (cst, node, stops) = minHeap.Dequeue();
            if (node == dst) return cst;
            if (stops > k) continue;
            
            foreach (var neighbor in adj[node]) {
                int nei = neighbor[0], w = neighbor[1];
                int nextCst = cst + w;
                int nextStops = stops + 1;
                
                if (dist[nei][nextStops] > nextCst) {
                    dist[nei][nextStops] = nextCst;
                    minHeap.Enqueue((nextCst, nei, nextStops), nextCst);
                }
            }
        }
        return -1;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O((n + m) * k)$
* Space complexity: $O(n * k)$

> Where $n$ is the number of flights, $m$ is the number of edges and $k$ is the number of stops.

---

### 2. Bellman Ford Algorithm






```csharp
public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        int[] prices = new int[n];
        Array.Fill(prices, int.MaxValue);
        prices[src] = 0;

        for (int i = 0; i <= k; i++) {
            int[] tmpPrices = (int[])prices.Clone();

            foreach (var flight in flights) {
                int s = flight[0];
                int d = flight[1];
                int p = flight[2];

                if (prices[s] == int.MaxValue)
                    continue;

                if (prices[s] + p < tmpPrices[d])
                    tmpPrices[d] = prices[s] + p;
            }

            prices = tmpPrices;
        }

        return prices[dst] == int.MaxValue ? -1 : prices[dst];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n + (m * k))$
* Space complexity: $O(n)$

> Where $n$ is the number of flights, $m$ is the number of edges and $k$ is the number of stops.

---

### 3. Shortest Path Faster Algorithm






```csharp
public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        int[] prices = new int[n];
        Array.Fill(prices, int.MaxValue);
        prices[src] = 0;
        List<int[]>[] adj = new List<int[]>[n];
        for (int i = 0; i < n; i++) {
            adj[i] = new List<int[]>();
        }
        foreach (var flight in flights) {
            adj[flight[0]].Add(new int[] { flight[1], flight[2] });
        }

        var q = new Queue<(int cst, int node, int stops)>();
        q.Enqueue((0, src, 0));

        while (q.Count > 0) {
            var (cst, node, stops) = q.Dequeue();
            if (stops > k) continue;

            foreach (var neighbor in adj[node]) {
                int nei = neighbor[0], w = neighbor[1];
                int nextCost = cst + w;
                if (nextCost < prices[nei]) {
                    prices[nei] = nextCost;
                    q.Enqueue((nextCost, nei, stops + 1));
                }
            }
        }
        return prices[dst] == int.MaxValue ? -1 : prices[dst];
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * k)$
* Space complexity: $O(n + m)$

> Where $n$ is the number of flights, $m$ is the number of edges and $k$ is the number of stops.
