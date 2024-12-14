# Design Twitter

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
- [Heap Properties](https://neetcode.io/courses/dsa-for-beginners/23) [from NeetCode's Course(s)]
- [Push and Pop](https://neetcode.io/courses/dsa-for-beginners/24) [from NeetCode's Course(s)]
- [Hash Usage](https://neetcode.io/courses/dsa-for-beginners/26) [from NeetCode's Course(s)]


## Problem Description
Implement a simplified version of Twitter which allows users to post tweets, follow/unfollow each other, and view the `10` most recent tweets within their own news feed.

Users and tweets are uniquely identified by their IDs (integers).

Implement the following methods:

* `Twitter()` Initializes the twitter object.
* `void postTweet(int userId, int tweetId)` Publish a new tweet with ID `tweetId` by the user `userId`. You may assume that each `tweetId` is unique.
* `List<Integer> getNewsFeed(int userId)` Fetches at most the `10` most recent tweet IDs in the user's news feed. Each item must be posted by users who the user is following or by the user themself. Tweets IDs should be **ordered from most recent to least recent**.
* `void follow(int followerId, int followeeId)` The user with ID `followerId` follows the user with ID `followeeId`.
* `void unfollow(int followerId, int followeeId)` The user with ID `followerId` unfollows the user with ID `followeeId`.

**Example 1:**

```java
Input:
["Twitter", "postTweet", [1, 10], "postTweet", [2, 20], "getNewsFeed", [1], "getNewsFeed", [2], "follow", [1, 2], "getNewsFeed", [1], "getNewsFeed", [2], "unfollow", [1, 2], "getNewsFeed", [1]]

Output:
[null, null, null, [10], [20], null, [20, 10], [20], null, [10]]

Explanation:
Twitter twitter = new Twitter();
twitter.postTweet(1, 10); // User 1 posts a new tweet with id = 10.
twitter.postTweet(2, 20); // User 2 posts a new tweet with id = 20.
twitter.getNewsFeed(1);   // User 1's news feed should only contain their own tweets -> [10].
twitter.getNewsFeed(2);   // User 2's news feed should only contain their own tweets -> [20].
twitter.follow(1, 2);     // User 1 follows user 2.
twitter.getNewsFeed(1);   // User 1's news feed should contain both tweets from user 1 and user 2 -> [20, 10].
twitter.getNewsFeed(2);   // User 2's news feed should still only contain their own tweets -> [20].
twitter.unfollow(1, 2);   // User 1 follows user 2.
twitter.getNewsFeed(1);   // User 1's news feed should only contain their own tweets -> [10].
```

**Constraints:**
* `1 <= userId, followerId, followeeId <= 100`
* `0 <= tweetId <= 1000`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n)</code> time for each <code>getNewsFeed()</code> function call, <code>O(1)</code> time for the remaining methods, and <code>O((N * m) + (N * M) + n)</code> space, where <code>n</code> is the number of <code>followeeIds</code> associated with the <code>userId</code>, <code>m</code> is the maximum number of tweets by any user, <code>N</code> is the total number of <code>userIds</code>, and <code>M</code> is the maximum number of followees for any user.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    Can you think of a data structure to store all the information, such as <code>userIds</code> and corresponding <code>followeeIds</code>, or <code>userIds</code> and their tweets? Maybe you should think of a hash data structure in terms of key-value pairs. Also, can you think of a way to determine that a tweet was posted before another tweet?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We use a hash map <code>followMap</code> to store <code>userIds</code> and their unique <code>followeeIds</code> as a <code>hash set</code>. Another hash map, <code>tweetMap</code>, stores <code>userIds</code> and their tweets as a list of <code>(count, tweetId)</code> pairs. A counter <code>count</code>, incremented with each tweet, tracks the order of tweets. The variable <code>count</code> is helpful in distinguishing the time of tweets from two users. This way of storing data makes the functions <code>follow()</code>, <code>unfollow()</code>, and <code>postTweet()</code> run in <code>O(1)</code>. Can you think of a way to implement <code>getNewsFeed()</code>? Maybe consider a brute force approach and try to optimize it.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    A naive solution would involve taking the tweets of the userId and its followeeIds into a list, sorting them in descending order based on their <code>count</code> values, and returning the top <code>10</code> tweets as the most recent ones. Can you think of a more efficient approach that avoids collecting all tweets and sorting? Perhaps consider a data structure and leverage the fact that each user's individual tweets list is already sorted.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 4</summary>
    <p>
    We can use a Max-Heap to efficiently retrieve the top <code>10</code> most recent tweets. For each followee and the userId, we insert their most recent tweet from the <code>tweetMap</code> into the heap, along with the tweet's <code>count</code> and its index in the tweet list. This index is necessary because after processing a tweet, we can insert the next most recent tweet from the same user's list. By always pushing and popping tweets from the heap, we ensure that the <code>10</code> most recent tweets are retrieved without sorting all tweets.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/pNichitDD2E/0.jpg)](https://www.youtube.com/watch?v=pNichitDD2E)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=pNichitDD2E)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/design-twitter-feed)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Sorting






```csharp
class Twitter {
    private int time;
    private Dictionary<int, HashSet<int>> followMap;
    private Dictionary<int, List<(int, int)>> tweetMap;

    public Twitter() {
        time = 0;
        followMap = new Dictionary<int, HashSet<int>>();
        tweetMap = new Dictionary<int, List<(int, int)>>();
    }

    public void PostTweet(int userId, int tweetId) {
        if (!tweetMap.ContainsKey(userId)) {
            tweetMap[userId] = new List<(int, int)>();
        }
        tweetMap[userId].Add((time++, tweetId));
    }

    public List<int> GetNewsFeed(int userId) {
        var feed = new List<(int, int)>(tweetMap.GetValueOrDefault(userId, new List<(int, int)>()));
        foreach (var followeeId in followMap.GetValueOrDefault(userId, new HashSet<int>())) {
            feed.AddRange(tweetMap.GetValueOrDefault(followeeId, new List<(int, int)>()));
        }
        feed.Sort((a, b) => b.Item1 - a.Item1);
        var res = new List<int>();
        for (int i = 0; i < Math.Min(10, feed.Count); i++) {
            res.Add(feed[i].Item2);
        }
        return res;
    }

    public void Follow(int followerId, int followeeId) {
        if (followerId != followeeId) {
            if (!followMap.ContainsKey(followerId)) {
                followMap[followerId] = new HashSet<int>();
            }
            followMap[followerId].Add(followeeId);
        }
    }

    public void Unfollow(int followerId, int followeeId) {
        if (followMap.ContainsKey(followerId)) {
            followMap[followerId].Remove(followeeId);
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n * m + t\log t)$ for each $getNewsFeed()$ call and $O(1)$ for remaining methods.
* Space complexity: $O(N * m + N * M)$

> Where $n$ is the total number of $followeeIds$ associated with the $userId$, $m$ is the maximum number of tweets by any user, $t$ is the total number of tweets associated with the $userId$ and its $followeeIds$, $N$ is the total number of $userIds$ and $M$ is the maximum number of followees for any user.

---

### 2. Heap






```csharp
class Twitter {
    private int count;
    private Dictionary<int, List<int[]>> tweetMap;
    private Dictionary<int, HashSet<int>> followMap;

    public Twitter() {
        count = 0;
        tweetMap = new Dictionary<int, List<int[]>>();
        followMap = new Dictionary<int, HashSet<int>>();
    }

    public void PostTweet(int userId, int tweetId) {
        if (!tweetMap.ContainsKey(userId)) {
            tweetMap[userId] = new List<int[]>();
        }
        tweetMap[userId].Add(new int[] { count++, tweetId });
    }

    public List<int> GetNewsFeed(int userId) {
        List<int> res = new List<int>();
        PriorityQueue<int[], int> minHeap = new PriorityQueue<int[], int>();

        if (!followMap.ContainsKey(userId)) {
            followMap[userId] = new HashSet<int>();
        }
        followMap[userId].Add(userId);

        foreach (int followeeId in followMap[userId]) {
            if (tweetMap.ContainsKey(followeeId) && tweetMap[followeeId].Count > 0) {
                List<int[]> tweets = tweetMap[followeeId];
                int index = tweets.Count - 1;
                int[] latestTweet = tweets[index];
                minHeap.Enqueue(new int[] { latestTweet[0], latestTweet[1], followeeId, index }, -latestTweet[0]);
            }
        }

        while (minHeap.Count > 0 && res.Count < 10) {
            int[] curr = minHeap.Dequeue();
            res.Add(curr[1]);
            int index = curr[3];
            if (index > 0) {
                int[] tweet = tweetMap[curr[2]][index - 1];
                minHeap.Enqueue(new int[] { tweet[0], tweet[1], curr[2], index - 1 }, -tweet[0]);
            }
        }

        return res;
    }

    public void Follow(int followerId, int followeeId) {
        if (!followMap.ContainsKey(followerId)) {
            followMap[followerId] = new HashSet<int>();
        }
        followMap[followerId].Add(followeeId);
    }

    public void Unfollow(int followerId, int followeeId) {
        if (followMap.ContainsKey(followerId)) {
            followMap[followerId].Remove(followeeId);
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n)$ for each $getNewsFeed()$ call and $O(1)$ for remaining methods.
* Space complexity: $O(N * m + N * M + n)$

> Where $n$ is the total number of $followeeIds$ associated with the $userId$, $m$ is the maximum number of tweets by any user, $N$ is the total number of $userIds$ and $M$ is the maximum number of followees for any user.
